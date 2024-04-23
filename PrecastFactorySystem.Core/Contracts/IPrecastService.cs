namespace PrecastFactorySystem.Core.Contracts
{
	using System.Threading.Tasks;

	using Models.Precast;

	using PrecastFactorySystem.Core.Enumeration;

	public interface IPrecastService
	{
		Task<PrecastQueryModel> GetAllPrecastAsync(string? searchTerm = null,
			int? projectId = null,
			int? precastTypeId = null,
			PrecastSorting sorting = PrecastSorting.Newest,
			int currentPage = 1,
			int projectsPerPage = 12);

		Task AddPrecastAsync(PrecastFormViewModel model);

		Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);

		Task EditPrecastAsync(int id, PrecastFormViewModel model);

		Task<PrecastDetailsViewModel?> GetPrecastDetailsAsync(int id);

		Task<PrecastDeleteViewModel?> GetPrecastToDeleteByIdAsync(int id);

		Task DeletePrecastAsync(int id);

		Task<PrecastReinforceQueryModel> GetPrecastReinforceAsync(
				int id,
				int currentPage = 1,
				int reinforcePerPage = 7
			);

		Task<PrecastProductionQueryModel> GetPrecastProductionAsync(
				int id,
				int currentPage = 1,
				int precastPerPage = 7);

		Task<int> GetReinforcedPrecastCountAsync(int id);

		Task<bool> IsPrecastExist(int id);
	}
}
