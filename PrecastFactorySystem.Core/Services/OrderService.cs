namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Core.Models.Reinforce;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;

	public class OrderService : IOrderService
	{
		private readonly IRepository repository;
		private readonly IBaseServise baseServise;
		private readonly IPrecastService precastService;
		private readonly IDelivererService delivererService;
		private readonly IExportService exportService;
		private readonly IEmailService emailService;


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

		public Task<int> DeleteOrderAsync(int id)
		{
			throw new NotImplementedException();
		}

		//public Task<OrderFormViewModel> GetOrderByIdAsync(int id)
		//{
		//	throw new NotImplementedException();
		//}

		public async Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int id)
		{
			return new OrderPrecastReinforceViewModel()
			{
				Id = id,
				OrderedCount = await precastService.GetPrecastToReinforceCountAsync(id),
				Departments =await baseServise.GetDepartmentsAsync(),
				Deliverers = await baseServise.GetDeliverersAsync()
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

		public async Task<IEnumerable<ReinforceOrderInfoViewModel>> GetReinforceOrdersAsync()
		{
			return await repository.AllReadonly<PrecastReinforceOrder>()
					.Select(pro => new ReinforceOrderInfoViewModel()
					{
						OrderId = pro.ReinforceOrder.Id,
						OrderDate = pro.ReinforceOrder.OrderDate,
						Project = pro.Precast.Project.Name,
						PrecastType = pro.Precast.PrecastType.Name,
						DeliverDate = pro.ReinforceOrder.DeliverDate,
						Department = pro.ReinforceOrder.Department.Name,
						Deliverer = pro.ReinforceOrder.Deliverer.Name

					})
					.OrderByDescending(ro => ro.DeliverDate)
					.ToArrayAsync();
		}

		public async Task<bool> IsOrderExistAsync(int id)
		{
			return await repository.AllReadonly<ReinforceOrder>()
				.AnyAsync(ro => ro.Id == id);
		}
	}

}
