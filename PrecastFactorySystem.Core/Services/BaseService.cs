namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Contracts;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class BaseService : IBaseServise
	{
		private readonly IRepository repository;


		public BaseService(IRepository _repository)
		{
			repository = _repository;
		}

		
		public async Task<IEnumerable<BaseSelectorViewModel>> GetReinforceTypesAsync()
		{
			return await repository.AllReadonly<ReinforceType>()
				.Select(rt => new BaseSelectorViewModel()
				{
					Id = rt.Id,
					Name = $"{rt.ReinforceClass}  {rt.Diameter}"
				}).ToArrayAsync();
		}

		
		public async Task<IEnumerable<BaseSelectorViewModel>> GetBaseEntityDataAsync<T>() where T : class, IBaseEntity
		{
			return await repository.AllReadonly<T>()
				.Select(e => new BaseSelectorViewModel()
				{
					Id = e.Id,
					Name = e.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetBaseEntityDataAsync<T>(Expression<Func<T, bool>> clause)
			where T : class, IBaseEntity
		{
			return await repository.AllReadonly(clause)
				.Select(e => new BaseSelectorViewModel()
				{
					Id = e.Id,
					Name = e.Name,
				}).ToArrayAsync();
		}
	}
}


