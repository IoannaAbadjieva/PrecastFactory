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

		Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);

		Task EditPrecastAsync(int id, PrecastFormViewModel model);

		Task<PrecastDetailsViewModel?> GetPrecastDetailsAsync(int id);

		Task<IEnumerable<PrecastInfoViewModel>> GetPrecastByClauseAsync(Expression<Func<Precast, bool>> clause);

		Task<PrecastDeleteViewModel?> GetPrecastToDeleteByIdAsync(int id);

		Task DeletePrecastAsync(int id);

		Task<PrecastReinforceViewModel?> GetPrecastReinforceAsync(int id);

		Task AddReinforceAsync(int id, ReinforceFormViewModel model);

		Task<PrecastProductionViewModel?> GetPrecastProductionAsync(int id);

		Task<PrecastProductionFormViewModel?> GetPrecastProductionFormAsync(int id);

		Task ProducePrecastAsync(int id, PrecastProductionFormViewModel model);

		Task<int> GetReinforcedPrecastCountAsync(int id);

		Task<int> GetPrecastToReinforceCountAsync(int id);

		Task<int> GetPrecastToProduceCountAsync(int id);

		Task<int> GetProducedPrecastCountAsync(int id);

		Task<decimal> GetPrecastActualWeightAsync(int id);

		Task<bool> IsPrecastExist(int id);
	}
}
