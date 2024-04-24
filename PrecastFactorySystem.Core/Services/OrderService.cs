namespace PrecastFactorySystem.Core.Services
{
    using System;
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


		private const int DaysLeftToDeliverDate = 4;

		public OrderService(IRepository _repository,
						IBaseServise _baseServise,
						IPrecastService _precastService)
		{
			repository = _repository;
			baseServise = _baseServise;
			precastService = _precastService;
		}



		public async Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int id)
		{
			int maxCountToBeOrdered = await GetPrecastToReinforceCountAsync(id);

			if (maxCountToBeOrdered == 0)
			{
				throw new OrderActionException(PrecastOrderedErrorMessage);
			}

			if (!await repository.AllReadonly<PrecastReinforce>().AnyAsync(pr => pr.PrecastId == id))
			{
				throw new OrderActionException(NoReinforceToOrderErrorMessage);
			}

			return new OrderPrecastReinforceViewModel()
			{
				PrecastId = id,
				OrderedCount = maxCountToBeOrdered,
				Departments = await baseServise.GetBaseEntityDataAsync<Department>(),
				Deliverers = await baseServise.GetBaseEntityDataAsync<Deliverer>()
			};
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
					Id = pro.ReinforceOrder.Id,
					OrderDate = pro.ReinforceOrder.OrderDate.ToString(DateFormat),
					Project = pro.Precast.Project.Name,
					PrecastType = pro.Precast.PrecastType.Name,
					Precast = pro.Precast.Name,
					OrderedCount = pro.ReinforceOrder.Count,
					DeliverDate = pro.ReinforceOrder.DeliverDate.ToString(DateFormat),
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


		public async Task<OrderViewModel> OrderPrecastAsync(int id, OrderPrecastReinforceViewModel model)
		{
			int maxCountToBeOrdered = await GetPrecastToReinforceCountAsync(id);

			if (maxCountToBeOrdered == 0)
			{
				throw new OrderActionException(PrecastOrderedErrorMessage);
			}

			if (!await repository.AllReadonly<PrecastReinforce>().AnyAsync(pr => pr.PrecastId == id))
			{
				throw new OrderActionException(NoReinforceToOrderErrorMessage);
			}

			var actualWeight = await GetPrecastActualWeightAsync(id);

			int lastOrderNumber = await repository.AllReadonly<ReinforceOrder>().MaxAsync(o => o.Id);

			var department = await repository.GetByIdAsync<Department>(model.DepartmentId);
			string departmentName = department.Name;

			var deliverer = await repository.GetByIdAsync<Deliverer>(model.DelivererId);
			string delivererEmail = deliverer.Email;

			var precastOrder = await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new OrderViewModel()
				{
					OrderNum = lastOrderNumber + 1,
					PrecastId = id,
					Precast = p.Name,
					Project = p.Project.Name,
					Count = model.OrderedCount,
					OrderDate = DateTime.Now,
					DeliveryDate = model.DeliveryDate,
					DelivererId = model.DelivererId,
					DelivererEmail = delivererEmail,
					DepartmentId = model.DepartmentId,
					Department = departmentName,
					Reinforce = p.PrecastReinforce.Select(pr => new ReinforceInfoViewModel()
					{
						Position = pr.Position,
						ReinforceType = $"{pr.ReinforceType.ReinforceClass.ToString()}"
						+ $" {pr.ReinforceType.Diameter}",
						Count = pr.Count * model.OrderedCount,
						Length = pr.Length,
						Weight = pr.Weight * model.OrderedCount,
					})
					.ToArray()

				})
				.FirstAsync();

			return precastOrder;

		}

		public async Task SaveOrderAsync(OrderViewModel orderModel)
		{
			var entityOrder = new ReinforceOrder()
			{
				OrderDate = orderModel.OrderDate,
				DeliverDate = orderModel.DeliveryDate,
				Count = orderModel.Count,
				DepartmentId = orderModel.DepartmentId,
				DelivererId = orderModel.DelivererId
			};

			var entity = new PrecastReinforceOrder()
			{
				PrecastId = orderModel.PrecastId,
				ReinforceOrder = entityOrder
			};

			await repository.AddAsync(entityOrder);
			await repository.AddAsync(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<OrdersQueryModel> GetReinforceOrdersByPrecastAsync(int id, int currentPage = 1, int ordersPerPage = 12)
		{
			var query = repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id);

			var totalOrders = await query.CountAsync();

			var orders = await query
				.Skip((currentPage - 1) * ordersPerPage)
				.Take(ordersPerPage)
				.Select(pro => new ReinforceOrderInfoViewModel()
				{
					Id = pro.ReinforceOrder.Id,
					OrderDate = pro.ReinforceOrder.OrderDate.ToString(DateFormat),
					Project = pro.Precast.Project.Name,
					PrecastType = pro.Precast.PrecastType.Name,
					Precast = pro.Precast.Name,
					OrderedCount = pro.ReinforceOrder.Count,
					DeliverDate = pro.ReinforceOrder.DeliverDate.ToString(DateFormat),
					Department = pro.ReinforceOrder.Department.Name,
					Deliverer = pro.ReinforceOrder.Deliverer.Name
				})
				.ToArrayAsync();



			return new OrdersQueryModel()
			{
				TotalOrders = totalOrders,
				Orders = orders
			};
		}

		public async Task<DeleteOrderViewModel> CheckOrderToDeleteByIdAsync(int id)
		{
			var entity = await CheckOrderDateAsync(id);

			return await GetOrderToDeleteByIdAsync(id);
		}

		public async Task<DeleteOrderViewModel> GetOrderToDeleteByIdAsync(int id)
		{
			return await repository.AllReadonly<PrecastReinforceOrder>(r => r.ReinforceOrderId == id)
				.Select(pro => new DeleteOrderViewModel()
				{
					Id = id,
					OrderDate = pro.ReinforceOrder.OrderDate,
					Project = pro.Precast.Project.Name,
					OrderedCount = pro.ReinforceOrder.Count,
					DeliverDate = pro.ReinforceOrder.OrderDate,
					DepartmentId = pro.ReinforceOrder.DepartmentId,
					Department = pro.ReinforceOrder.Department.Name,
					DelivererEmail = pro.ReinforceOrder.Deliverer.Email
				})
				.FirstAsync();
		}

		public async Task DeleteOrderAsync(int id)
		{
			var entity = await CheckOrderDateAsync(id);
			await DeleteAsync(id);
		}

		public async Task DeleteAsync(int id)
		{
			await repository.DeleteAsync<ReinforceOrder>(id);
			await repository.SaveChangesAsync();
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

		public async Task<int> GetPrecastToReinforceCountAsync(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			return precast.Count - await precastService.GetReinforcedPrecastCountAsync(id);
		}

		public async Task<decimal> GetPrecastActualWeightAsync(int id)
		{
			return await repository.AllReadonly<PrecastReinforce>(pr => pr.PrecastId == id)
				.SumAsync(pr => pr.Weight);
		}
		public async Task<bool> IsOrderExistAsync(int id)
		{
			return await repository.AllReadonly<ReinforceOrder>()
				.AnyAsync(ro => ro.Id == id);
		}


	}

}
