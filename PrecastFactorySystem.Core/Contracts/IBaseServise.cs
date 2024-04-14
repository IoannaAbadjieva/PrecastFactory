namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	public interface IBaseServise
	{
		Task<IEnumerable<BaseSelectorViewModel>> GetBaseEntityDataAsync<T>() where T : class, IBaseEntity;

		Task<IEnumerable<BaseSelectorViewModel>> GetBaseEntityDataAsync<T>(Expression<Func<T, bool>> clause)
			where T : class, IBaseEntity;

		Task<IEnumerable<BaseSelectorViewModel>> GetReinforceTypesAsync();
	}

}
