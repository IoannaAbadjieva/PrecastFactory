namespace PrecastFactorySystem.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using PrecastFactorySystem.Core.Models.Precast;
    using PrecastFactorySystem.Data.Models;

    public interface IPrecastService
    {
        Task AddPrecastAsync(PrecastFormViewModel model);
        Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync();
		Task<PrecastFormViewModel> GetNewPrecastFormViewModelAsync();
        Task<IEnumerable<PrecastDetailedInfoViewModel>> GetPrecastWithClauseAsync(Expression<Func<Precast, bool>> findWhereClause);
		Task<IEnumerable<BaseSelectorViewModel>> GetProjectAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypeAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassAsync();
		Task<PrecastFormViewModel> GetPrecastByIdAsync(int id);
		Task EditPrecastAsync(int id, PrecastFormViewModel model);
		Task<int> GetReinforcedPrecastCount(int id);
	}
}
