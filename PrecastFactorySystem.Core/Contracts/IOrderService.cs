namespace PrecastFactorySystem.Core.Contracts
{
    using System.Threading.Tasks;

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

        Task<OrdersQueryModel> GetReinforceOrdersByPrecastAsync(
            int id,
            int currentPage = 1,
            int ordersPerPage = 12);

        Task<OrderPrecastReinforceViewModel> GetOrderPrecastReinforceViewModel(int precastId);

        Task<OrderViewModel> OrderPrecastAsync(int precastId, OrderPrecastReinforceViewModel model);

        Task SaveOrderAsync(OrderViewModel orderModel);

        Task<DeleteOrderViewModel> CheckOrderToDeleteByIdAsync(int id);

        Task<DeleteOrderViewModel> GetOrderToDeleteByIdAsync(int id);

        Task DeleteOrderAsync(int id);

        Task DeleteAsync(int id);

        Task<int> GetPrecastToReinforceCountAsync(int id);

         Task<bool> IsOrderExistAsync(int id);

    }
}
