namespace PrecastFactorySystem.Core.Contracts
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using PrecastFactorySystem.Core.Models.Base;
    using PrecastFactorySystem.Data.Models;

    public interface IBaseService
	{
		Task<IEnumerable<ProjectViewModel>> GetProjectAsync();

		Task<IEnumerable<PrecastTypeViewModel>> GetPrecastTypeAsync(Expression<Func<PrecastType, bool>> condition);

        Task<IEnumerable<ConcreteClassViewModel>> GetConcreteClassAsync();
	}
}
