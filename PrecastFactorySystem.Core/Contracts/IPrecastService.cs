namespace PrecastFactorySystem.Core.Contracts
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using Models.Precast;
	using Models.Reinforce;


	using Infrastructure.Data.Models;

	public interface IPrecastService
	{
		Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync();

		Task AddPrecastAsync(PrecastFormViewModel model);

		Task<PrecastFormViewModel> GetNewPrecastFormViewModelAsync();

		Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);

		Task EditPrecastAsync(int id, PrecastFormViewModel model);

		Task<int> GetReinforcedPrecastCount(int id);

		Task<int> GetPrecastToReinforceCount(int id);

		Task<int> GetProducedPrecastCount(int id);

		Task<PrecastDetailsViewModel?> GetPrecastDetailsAsync(int id);

		Task<IEnumerable<PrecastInfoViewModel>> GetPrecastByClauseAsync(Expression<Func<Precast, bool>> clause);

		Task<PrecastDeleteViewModel?> GetPrecastToDeleteByIdAsync(int id);

		Task DeletePrecastAsync(int id);

		Task<PrecastReinforceViewModel?> GetPrecastReinforceAsync(int id);

		Task AddReinforceAsync(int id, ReinforceFormViewModel model);

		Task<bool> IsPrecastExist(int id);

		Task OrderPrecastAsync(int id, OrderPrecastReinforceViewModel model);

		Task<decimal> GetPrecastActualWeightAsync(int id);
	}
}
