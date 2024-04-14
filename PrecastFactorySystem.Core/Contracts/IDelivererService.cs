namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Deliverer;

	public interface IDelivererService
	{
		Task AddDelivererAsync(DelivererFormViewModel model);

		Task DeleteDelivererAsync(int id);

		Task EditDelivererAsync(int id, DelivererFormViewModel model);

		Task<DeliverersQueryModel> GetAllDeliverersAsync(
			string? searchTerm = null,
				int currentPage = 1,
				int deliverersPerPage = 4);

		Task<DelivererFormViewModel> GetDelivererByIdAsync(int id);

		Task<DelivererDeleteViewModel> GetDelivererToDeleteByIdAsync(int id);

		Task<bool> HasOrdersAsync(int id);

		Task<string?> GetDelivererEmailAsync(int id);

		Task<bool> IsDelivererExistAsync(int id);
	}
}
