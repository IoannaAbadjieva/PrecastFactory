﻿namespace PrecastFactorySystem.Core.Services
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
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class BaseService : IBaseServise
	{
		private readonly IRepository repository;


		public BaseService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<ReinforceTypeSelectorViewModel>> GetReinforceTypesAsync()
		{
			return await repository.AllReadonly<ReinforceType>()
				.Select(rt => new ReinforceTypeSelectorViewModel()
				{
					Id = rt.Id,
					Name = $"{rt.ReinforceClass}  {rt.Diameter}",
					SpecificMass = rt.SpecificMass,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseInfoViewModel>> GetBaseEntityDataAsync<T>() where T : class, IBaseEntity
		{
			return await repository.AllReadonly<T>()
				.Select(e => new BaseInfoViewModel()
				{
					Id = e.Id,
					Name = e.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseInfoViewModel>> GetBaseEntityDataAsync<T>(Expression<Func<T, bool>> clause)
			where T : class, IBaseEntity
		{
			return await repository.AllReadonly<T>(clause)
				.Select(e => new BaseInfoViewModel()
				{
					Id = e.Id,
					Name = e.Name,
				}).ToArrayAsync();
		}

		public async Task<BaseInfoViewModel> GetEntityBaseInfoAsync<T>(int id) where T : class, IBaseEntity
		{
			return await repository.AllReadonly<T>(e => e.Id == id)
								.Select(e => new BaseInfoViewModel()
								{
									Id = e.Id,
									Name = e.Name,
								}).FirstAsync();
		}

		public async Task DeleteEntityAsync<T>(int id) where T : class, IBaseEntity
		{
			var entity = await repository.GetByIdAsync<T>(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}
	}
}


