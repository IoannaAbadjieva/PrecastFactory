namespace PrecastFactorySystem.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Models.Project;
	using PrecastFactorySystem.Data.Models;

    public interface IPrecastService
    {
        Task AddPrecastAsync(PrecastFormViewModel model);

        Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync();

        Task<PrecastFormViewModel> GetNewPrecastFormViewModelAsync();

        Task<IEnumerable<BaseSelectorViewModel>> GetProjectAsync();

        Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypeAsync();

        Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassAsync();

        Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);

        Task EditPrecastAsync(int id, PrecastFormViewModel model);

        Task<int> GetReinforcedPrecastCount(int id);

        Task<PrecastDetailsViewModel> GetPrecastDetailsAsync(int id);

        Task<IEnumerable<PrecastInfoViewModel>> GetPrecastByClauseAsync(Expression<Func<Precast, bool>> clasue);
		Task<PrecastDeleteViewModel> GetPrecastToDeleteByIdAsync(int id);
		Task DeletePrecastAsync(int id);
	}
}
