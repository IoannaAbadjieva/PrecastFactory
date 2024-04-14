namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Core.Models.Reinforce;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;
	using static PrecastFactorySystem.Core.Constants.MessageConstants;

	public class OrderService : IOrderService
	{
		private readonly IRepository repository;
		private readonly IBaseServise baseServise;
		private readonly IPrecastService precastService;
		private readonly IDelivererService delivererService;
		private readonly IExportService exportService;
		private readonly IEmailService emailService;

		private const int DaysLeftToDeliverDate = 4;

		public OrderService(IRepository _repository,
						IBaseServise _baseServise,
						IPrecastService _precastService,
						IDelivererService _delivererService,
						IExportService _exportService,
						IEmailService _emailService)
		{
			repository = _repository;
			baseServise = _baseServise;
			precastService = _precastService;
			delivererService = _delivererService;
			exportService = _exportService;
			emailService = _emailService;
		}



		public async Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int id)
		{
			return new OrderPrecastReinforceViewModel()
			{
				Id = id,
				OrderedCount = await precastService.GetPrecastToReinforceCountAsync(id),
				Departments = await baseServise.GetBaseEntityDataAsync<Department>(),
				Deliverers = await baseServise.GetBaseEntityDataAsync<Deliverer>()
			};
		}

		public async Task OrderPrecastAsync(int id, OrderPrecastReinforceViewModel model)
		{
			var order = new ReinforceOrder()
			{
				Count = model.OrderedCount,
				PrecastWeight = await precastService.GetPrecastActualWeightAsync(id),
				DepartmentId = model.DepartmentId,
				DelivererId = model.DelivererId,
				DeliverDate = model.DeliverDate,
				OrderDate = DateTime.Now

			};

			await repository.AddAsync<ReinforceOrder>(order);
			await repository.SaveChangesAsync();

			await repository.AddAsync<PrecastReinforceOrder>(new PrecastReinforceOrder
			{
				PrecastId = id,
				ReinforceOrderId = order.Id
			});
			await repository.SaveChangesAsync();

			string? email = await delivererService.GetDelivererEmailAsync(model.DelivererId);

			await GetOrderDetailsAndEmailAsync(order.Id, id, email ?? string.Empty);

		}

		public async Task GetOrderDetailsAndEmailAsync(int orderId, int id, string email)
		{
			var precastOrder = await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id && pro.ReinforceOrder.Id == orderId)
				.Include(pro => pro.Precast.PrecastReinforce)
				.Select(pro => new OrderViewModel()
				{
					OrderNum = pro.ReinforceOrder.Id,
					Precast = pro.Precast.Name,
					Project = pro.Precast.Project.Name,
					Count = pro.ReinforceOrder.Count,
					OrderDate = pro.ReinforceOrder.OrderDate.ToString(DateFormat, CultureInfo.InvariantCulture),
					DeliverDate = pro.ReinforceOrder.DeliverDate.ToString(DateFormat, CultureInfo.InvariantCulture),
					Department = pro.ReinforceOrder.Department.Name,
					Reinforce = pro.Precast.PrecastReinforce.Select(pr => new ReinforceInfoViewModel()
					{
						Position = pr.Position,
						ReinforceType = $"{pr.ReinforceType.ReinforceClass.ToString()} {pr.ReinforceType.Diameter}",
						Count = pr.Count * pro.ReinforceOrder.Count,
						Length = pr.Length
					}).ToArray()
				}).FirstAsync();


			string fileName = $"Order {precastOrder.OrderNum} - {precastOrder.Precast}  {precastOrder.Project}";

			exportService.ExportToPdf(precastOrder, fileName);

			await emailService.SendEmailAsync(email, fileName);

		}

		public async Task<OrdersQueryModel> GetReinforceOrdersAsync(string? searchTerm = null,
			int? projectId = null,
			int? departmentId = null,
			DateTime? fromDate = null,
			DateTime? toDate = null,
			int currentPage = 1,
			int ordersPerPage = 12)
		{
			var query = repository.AllReadonly<PrecastReinforceOrder>();

			var search = searchTerm?.ToLower();


			if (projectId.HasValue)
			{
				query = query.Where(pro => pro.Precast.ProjectId == projectId);
			}

			if (departmentId.HasValue)
			{
				query = query.Where(pro => pro.ReinforceOrder.DepartmentId == departmentId);
			}


			if (fromDate.HasValue)
			{
				query = query.Where(pro => pro.ReinforceOrder.DeliverDate.Date >= fromDate.Value.Date);
			}

			if (toDate.HasValue)
			{
				query = query.Where(pro => pro.ReinforceOrder.DeliverDate.Date <= toDate.Value.Date);
			}


			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(pro => pro.Precast.Name.ToLower().Contains(search)
								|| pro.Precast.Project.Name.ToLower().Contains(search)
								|| pro.Precast.PrecastType.Name.ToLower().Contains(search)
								|| pro.ReinforceOrder.Department.Name.ToLower().Contains(search));
			}


			var totalOrders = await query.CountAsync();

			var orders = await query
				.Skip((currentPage - 1) * ordersPerPage)
				.Take(ordersPerPage)
				.Select(pro => new ReinforceOrderInfoViewModel()
				{
					OrderId = pro.ReinforceOrder.Id,
					OrderDate = pro.ReinforceOrder.OrderDate,
					Project = pro.Precast.Project.Name,
					PrecastType = pro.Precast.PrecastType.Name,
					Precast = pro.Precast.Name,
					OrderedCount = pro.ReinforceOrder.Count,
					DeliverDate = pro.ReinforceOrder.DeliverDate,
					Department = pro.ReinforceOrder.Department.Name,
					Deliverer = pro.ReinforceOrder.Deliverer.Name
				})
				.ToArrayAsync();

			return new OrdersQueryModel
			{
				TotalOrders = totalOrders,
				Orders = orders
			};
		}

		public async Task<ReinforceOrderInfoViewModel> GetOrderToDeleteByIdAsync(int id)
		{
			var entity = await CheckOrderDateAsync(id);

			return await repository.AllReadonly<ReinforceOrder>(r => r.Id == id)
				.Select(ro => new ReinforceOrderInfoViewModel()
				{
					OrderId = ro.Id,
					OrderDate = ro.OrderDate,
					Project = ro.PrecastReinforceOrders.First().Precast.Project.Name,
					PrecastType = ro.PrecastReinforceOrders.First().Precast.PrecastType.Name,
					DeliverDate = ro.DeliverDate,
					Department = ro.Department.Name,
					Deliverer = ro.Deliverer.Name
				})
				.FirstAsync();
		}

		public async Task DeleteOrderAsync(int id)
		{
			var entity = await CheckOrderDateAsync(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> IsOrderExistAsync(int id)
		{
			return await repository.AllReadonly<ReinforceOrder>()
				.AnyAsync(ro => ro.Id == id);
		}

		private async Task<ReinforceOrder> CheckOrderDateAsync(int id)
		{
			var currentDate = DateTime.Now;
			var entity = await repository.GetByIdAsync<ReinforceOrder>(id);

			if ((entity.DeliverDate.Date - currentDate.Date).Days < DaysLeftToDeliverDate)
			{
				throw new DeleteActionException(DeleteOrderErrorMessage);
			}

			return entity;
		}
	}

}
