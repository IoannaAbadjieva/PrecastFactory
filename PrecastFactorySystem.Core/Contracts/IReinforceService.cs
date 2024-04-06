namespace PrecastFactorySystem.Core.Contracts
{
	using Models.Reinforce;

	using PrecastFactorySystem.Core.Models.Base;

	public interface IReinforceService
	{
		Task<IEnumerable<ReinforceInfoViewModel>> GetReinforceAsync(int id);

		Task<int> EditReinforceAsync(int id, ReinforceFormViewModel model);

		Task<int> DeleteReinforceAsync(int id);

		Task<ReinforceFormViewModel> GetReinforceByIdAsync(int id);

		Task<bool> IsReinforceExist(int id);

	}
}
