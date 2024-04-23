namespace PrecastFactorySystem.Core.Contracts
{
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Produce;

	public interface IProduceService
	{
		Task<ProduceFormViewModel> GetProductionFormAsync(int precastId);

		Task ProducePrecastAsync(int id, ProduceFormViewModel model);

		Task<ProduceFormViewModel> GetProductionRecordByIdAsync(int id);

		Task EditProductionRecordAsync(int id, ProduceFormViewModel model);

		Task DeleteProductionRecordAsync(int id);

		Task<int> GetProducedPrecastCountAsync(int id, int? recordId);

		Task<int> GetPrecastToProduceCountAsync(int id, int? recordId);
		Task<DateTime> GetFirstOrderDeliveryDate(int id);

		Task<bool> IsProductionRecordExist(int id);
	}
}
