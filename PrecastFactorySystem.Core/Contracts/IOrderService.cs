namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Order;

	public interface IOrderService
	{

		Task<OrdersQueryModel> GetReinforceOrdersAsync(string? searchTerm = null,
			int? projectId = null,
			int? departmentId = null,
			DateTime? fromDate = null,
			DateTime? toDate = null,
			int currentPage = 1,
			int ordersPerPage = 12);

		Task<DeleteOrderViewModel> GetOrderToDeleteByIdAsync(int id);

		Task DeleteOrderAsync(int id);

		Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int precastId);

		Task<OrderViewModel> OrderPrecastAsync(int precastId, OrderPrecastReinforceViewModel model);

		
		Task SaveOrderAsync(OrderViewModel orderModel);

		Task<OrdersQueryModel> GetReinforceOrdersByPrecastAsync(
			int id, 
			int currentPage = 1,
			int ordersPerPage = 12);

		Task<int> GetPrecastToReinforceCountAsync(int id);

		Task<decimal> GetPrecastActualWeightAsync(int id);

		Task<bool> IsOrderExistAsync(int id);
		
	}
}
