namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	public interface IBaseServise
	{
		Task<IEnumerable<BaseInfoViewModel>> GetBaseEntityDataAsync<T>() where T : class, IBaseEntity;

		Task<IEnumerable<BaseInfoViewModel>> GetBaseEntityDataAsync<T>(Expression<Func<T, bool>> clause)
			where T : class, IBaseEntity;

		Task<IEnumerable<ReinforceTypeSelectorViewModel>> GetReinforceTypesAsync();

		Task<BaseInfoViewModel> GetEntityBaseInfoAsync<T>(int id) where T : class, IBaseEntity;

		Task DeleteEntityAsync<T>(int id) where T : class, IBaseEntity;
	}

}
