namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Order;

	public interface IOrderService
	{
		
		Task<IEnumerable<ReinforceOrderInfoViewModel>> GetReinforceOrdersAsync();
		Task<int> DeleteOrderAsync(int id);
		//Task<OrderFormViewModel> GetOrderByIdAsync(int id);

		Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int precastId);

		Task OrderPrecastAsync(int precastId, OrderPrecastReinforceViewModel model);

		Task GetOrderDetailsAndEmailAsync(int orderId, int precastId, string email);

		Task<bool> IsOrderExistAsync(int id);
	}
}
