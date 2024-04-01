namespace PrecastFactorySystem.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Models.Precast;

    using Infrastructure.Data.Models;
    using PrecastFactorySystem.Core.Models.Base;

    public interface IPrecastService
    {
        Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync();

        Task AddPrecastAsync(PrecastFormViewModel model);

        Task<PrecastFormViewModel> GetNewPrecastFormViewModelAsync();

        Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);

        Task EditPrecastAsync(int id, PrecastFormViewModel model);

        Task<int> GetReinforcedPrecastCount(int id);

        Task<PrecastDetailsViewModel> GetPrecastDetailsAsync(int id);

        Task<IEnumerable<PrecastInfoViewModel>> GetPrecastByClauseAsync(Expression<Func<Precast, bool>> clause);

		Task<PrecastDeleteViewModel> GetPrecastToDeleteByIdAsync(int id);

		Task DeletePrecastAsync(int id);


		Task<IEnumerable<BaseSelectorViewModel>> GetProjectAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypeAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassAsync();
		Task<PrecastReinforceViewModel> GetPrecastReinforceAsync(int id);
	}
}
