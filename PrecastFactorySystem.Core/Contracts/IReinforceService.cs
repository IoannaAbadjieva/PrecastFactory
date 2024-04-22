namespace PrecastFactorySystem.Core.Contracts
{
	using Models.Reinforce;

	public interface IReinforceService
	{
		Task AddReinforceAsync(int precastId, ReinforceFormViewModel model);

		Task<int> EditReinforceAsync(int id, ReinforceFormViewModel model);

		Task DeleteReinforceAsync(int id);

		Task<ReinforceFormViewModel?> GetReinforceByIdAsync(int id);

		Task<bool> IsReinforceExist(int id);
		
	}
}
