namespace PrecastFactorySystem.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Precast;
    using PrecastFactorySystem.Data.Models;
    using PrecastFactorySystem.Infrastructure.Data.Common;

    public class PrecastService : IPrecastService
	{
		private readonly IRepository repository;

		public PrecastService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task AddPrecastAsync(PrecastFormViewModel model)
		{
			Precast entity = new Precast()
			{
				Name = model.Name,
				PrecastTypeId = model.PrecastTypeId,
				Count = model.Count,
				AddedOn = DateTime.Now,
				ProjectId = model.ProjectId,
				ConcreteClassId = model.ConcreteClassId,
				ConcreteProjectAmount = model.ConcreteProjectAmount,
				ReinforceProjectWeight = model.ReinforceProjectAmount
			};

			await repository.AddAsync<Precast>(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<PrecastInfoViewModel>> GetAllPrecastAsync()
		{
			return await repository.AllReadonly<Precast>()
				  .Select(p => new PrecastInfoViewModel()
				  {
					  Id = p.Id,
					  PrecastType = p.PrecastType.Name,
					  Name = p.Name,
					  Count = p.Count,
					  Project = p.Project.Name,
					  Reinforced = p.PrecastReinforceOrders.Sum(p => p.ReinforceOrder.Count),
					  Produced = p.DepartmentPrecast.Sum(dp => dp.Count)
				  }).ToArrayAsync();
		}

	
		public async Task<IEnumerable<BaseSelectorViewModel>> GetProjectAsync()
		{
			return await repository.AllReadonly<Project>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypeAsync()
		{
			return await repository.AllReadonly<PrecastType>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassAsync()
		{
			return await repository.AllReadonly<ConcreteClass>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<PrecastFormViewModel> GetNewPrecastFormViewModelAsync()
		{
			return new PrecastFormViewModel()
			{
				Projects = await GetProjectAsync(),
				Types = await GetPrecastTypeAsync(),
				Concrete = await GetConcreteClassAsync(),
			};
		}


		public async Task<IEnumerable<PrecastDetailedInfoViewModel>> GetPrecastWithClauseAsync(Expression<Func<Precast, bool>> findWhereClause)
		{
			return await repository.AllReadonly<Precast>()
				.Where(findWhereClause)
				.Select(p => new PrecastDetailedInfoViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Count = p.Count,
					Project = p.Project.Name,
					PrecastType = p.PrecastType.Name,
					ConcreteClass = p.ConcreteClass.Name,
					ConcreteProjectAmount = p.ConcreteProjectAmount,
					ReinforceProjectAmount = p.ConcreteProjectAmount,
					Reinforced = p.PrecastReinforceOrders.Sum(p => p.ReinforceOrder.Count),
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count)
				}).ToArrayAsync();
		}

		public async Task<PrecastFormViewModel> GetPrecastByIdAsync(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			if (precast == null)
			{
				throw new ArgumentException();
			}

			return new PrecastFormViewModel()
			{
				Name = precast.Name,
				PrecastTypeId = precast.PrecastTypeId,
				Types = await GetPrecastTypeAsync(),
				Count = precast.Count,
				ProjectId= precast.ProjectId,
				Projects = await GetProjectAsync(),
				ConcreteClassId = precast.ConcreteClassId,
				Concrete = await GetConcreteClassAsync(),
				ConcreteProjectAmount = precast.ConcreteProjectAmount,
				ReinforceProjectAmount = precast.ReinforceProjectWeight,
			};
		}

		public async Task EditPrecastAsync(int id, PrecastFormViewModel model)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			if (precast == null)
			{
				throw new ArgumentException();
			}

			precast.Name = model.Name;
			precast.PrecastTypeId = model.PrecastTypeId;
			precast.Count = model.Count;
			precast.ProjectId = model.ProjectId;
			precast.ConcreteClassId = model.ConcreteClassId;
			precast.ConcreteProjectAmount = model.ConcreteProjectAmount;
			precast.ReinforceProjectWeight = model.ReinforceProjectAmount;

			await repository.SaveChangesAsync();
		}

		public async Task<int> GetReinforcedPrecastCount(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			if (precast == null)
			{
				throw new ArgumentException();
			}

			return precast.PrecastReinforceOrders.Sum(p => p.ReinforceOrder.Count);
		}
	}
}
