namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Deliverer;

	public interface IDelivererService
	{
		Task AddDelivererAsync(DelivererFormViewModel model);

		Task DeletePrecastAsync(int id);

		Task EditDelivererAsync(int id, DelivererFormViewModel model);

		Task<IEnumerable<DelivererInfoViewModel>> GetAllDeliverersAsync();

		Task<DelivererFormViewModel> GetDelivererByIdAsync(int id);

		Task<DelivererDeleteViewModel> GetDelivererToDeleteByIdAsync(int id);

		Task<bool> HasOrdersAsync(int id);

		Task<bool> IsDelivererExistAsync(int id);
	}
}
