namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Exceptions;
	using Models.Precast;
	using Models.Reinforce;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;

	using static Constants.MessageConstants;
	using static Infrastructure.DataValidation.DataConstants;

	public class PrecastService : IPrecastService
	{
		private readonly IRepository repository;
		private readonly IBaseServise baseServise;


		public PrecastService(IRepository _repository,
			IBaseServise _baseService
		)
		{
			repository = _repository;
			baseServise = _baseService;
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
					  Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					  Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
				  })
				  .OrderBy(p => p.Project)
				  .ThenBy(p => p.PrecastType)
				  .ThenBy(p => p.Name)
				  .ToArrayAsync();
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

		public async Task<PrecastFormViewModel> GetPrecastByIdAsync(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			return new PrecastFormViewModel()
			{
				Name = precast.Name,
				PrecastTypeId = precast.PrecastTypeId,
				Types = await baseServise.GetPrecastTypesAsync(),
				Count = precast.Count,
				ProjectId = precast.ProjectId,
				Projects = await baseServise.GetProjectsAsync(),
				ConcreteClassId = precast.ConcreteClassId,
				Concrete = await baseServise.GetConcreteClassesAsync(),
				ConcreteProjectAmount = precast.ConcreteProjectAmount,
				ReinforceProjectAmount = precast.ReinforceProjectWeight,
			};
		}

		public async Task EditPrecastAsync(int id, PrecastFormViewModel model)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			precast.Name = model.Name;
			precast.PrecastTypeId = model.PrecastTypeId;
			precast.Count = model.Count;
			precast.ProjectId = model.ProjectId;
			precast.ConcreteClassId = model.ConcreteClassId;
			precast.ConcreteProjectAmount = model.ConcreteProjectAmount;
			precast.ReinforceProjectWeight = model.ReinforceProjectAmount;

			await repository.SaveChangesAsync();
		}

		public async Task<PrecastDetailsViewModel?> GetPrecastDetailsAsync(int id)
		{
			var model = await repository.AllReadonly<Precast>(p => p.Id == id)
				   .Select(p => new PrecastDetailsViewModel()
				   {
					   Id = p.Id,
					   Name = p.Name,
					   Count = p.Count,
					   Project = p.Project.Name,
					   PrecastType = p.PrecastType.Name,
					   ConcreteClass = p.ConcreteClass.Name,
					   ConcreteProjectAmount = p.ConcreteProjectAmount,
					   ReinforceProjectAmount = p.ReinforceProjectWeight,
					   Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					   Produced = p.DepartmentPrecast.Sum(dp => dp.Count),

				   }).FirstOrDefaultAsync();

			return model;
		}

		public async Task<IEnumerable<PrecastInfoViewModel>> GetPrecastByClauseAsync(Expression<Func<Precast, bool>> clause)
		{
			return await repository.AllReadonly<Precast>(clause)
					  .Select(p => new PrecastInfoViewModel()
					  {
						  Id = p.Id,
						  PrecastType = p.PrecastType.Name,
						  Name = p.Name,
						  Count = p.Count,
						  Project = p.Project.Name,
						  Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
						  Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
					  }).ToArrayAsync();
		}

		public async Task<PrecastDeleteViewModel?> GetPrecastToDeleteByIdAsync(int id)
		{
			var model = await repository.AllReadonly<Precast>(p => p.Id == id)
			   .Select(p => new PrecastDeleteViewModel()
			   {
				   Id = p.Id,
				   Name = p.Name,
				   AddedOn = p.AddedOn.ToString(DateFormat),
				   Project = p.Project.Name,
				   PrecastType = p.PrecastType.Name,

			   }).FirstOrDefaultAsync();

			if (await GetReinforcedPrecastCountAsync(id) > 0)
			{
				throw new DeleteActionException(DeletePrecastErrorMessage);
			}

			return model;
		}

		public async Task DeletePrecastAsync(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			if (await GetReinforcedPrecastCountAsync(id) > 0)
			{
				throw new DeleteActionException(DeletePrecastErrorMessage);
			}

			repository.Delete(precast);
			await repository.SaveChangesAsync();
		}

		public async Task<PrecastReinforceViewModel?> GetPrecastReinforceAsync(int id)
		{
			return await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new PrecastReinforceViewModel()
				{
					Id = p.Id,
					PrecastType = p.PrecastType.Name,
					Name = p.Name,
					Count = p.Count,
					Project = p.Project.Name,
					Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
					Reinforce = p.PrecastReinforce.Select(pr => new ReinforceFullInfoViewModel()
					{
						Id = pr.Id,
						PrecastId = pr.PrecastId,
						Position = pr.Position,
						ReinforceType = $"{pr.ReinforceType.ReinforceClass.ToString()} {pr.ReinforceType.Diameter}",
						Count = pr.Count,
						Length = pr.Length
					}).ToArray()
				}).FirstOrDefaultAsync();
		}

		public async Task AddReinforceAsync(int id, ReinforceFormViewModel model)
		{

			var reinforce = new PrecastReinforce()
			{
				PrecastId = id,
				Count = model.Count,
				Position = model.Position,
				Length = model.Length,
				ReinforceTypeId = model.ReinforceTypeId
			};

			await repository.AddAsync<PrecastReinforce>(reinforce);
			await repository.SaveChangesAsync();
		}

		public async Task<PrecastProductionViewModel?> GetPrecastProductionAsync(int id)
		{
			return await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new PrecastProductionViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Project = p.Project.Name,
					Count = p.Count,
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
					Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					ByDepartments = p.DepartmentPrecast.Select(dp => new PrecastByDepartmentsViewModel()
					{
						Department = dp.Department.Name,
						Date = dp.Date.ToString(DateFormat),
						Count = dp.Count,
						ConcreteAmont = dp.ConcreteAmount,
					}).ToArray()
				}).FirstOrDefaultAsync();
		}

		public async Task<PrecastProductionFormViewModel?> GetPrecastProductionFormAsync(int id)
		{
			var model = new PrecastProductionFormViewModel()
			{
				Id = id,
				ProducedCount = await GetPrecastToProduceCountAsync(id),
				Departments = await baseServise.GetDepartmentsAsync()
			};

			return model;
		}

		public async Task ProducePrecastAsync(int id, PrecastProductionFormViewModel model)
		{
			var entity = new PrecastDepartment()
			{
				PrecastId = id,
				Count = model.ProducedCount,
				Date = model.Date,
				DepartmentId = model.DepartmentId,
				ConcreteAmount = model.ConcreteAmount
			};

			await repository.AddAsync<PrecastDepartment>(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<int> GetReinforcedPrecastCountAsync(int id)
		{
			return await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id)
				.SumAsync(pro => pro.ReinforceOrder.Count);
		}

		public async Task<int> GetPrecastToReinforceCountAsync(int id)
		{
			var precast = await repository.GetByIdAsync<Precast>(id);

			return precast.Count - await GetReinforcedPrecastCountAsync(id);
		}

		public Task<int> GetProducedPrecastCountAsync(int id)
		{
			return repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id)
				.SumAsync(dp => dp.Count);
		}
		public async Task<int> GetPrecastToProduceCountAsync(int id)
		{
			var reinforced = await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id && pro.ReinforceOrder.DeliverDate <= DateTime.UtcNow)
				.SumAsync(pro => pro.ReinforceOrder.Count);
			var produced = await GetProducedPrecastCountAsync(id);

			return reinforced - produced;
		}

		public async Task<decimal> GetPrecastActualWeightAsync(int id)
		{
			return await repository.AllReadonly<PrecastReinforce>(pr => pr.PrecastId == id)
				.SumAsync(pr => pr.Count *
								pr.Length *
								(decimal)(Math.PI * Math.Pow(pr.ReinforceType.Diameter / 2.0, 2) / 4.0));
		}

		public async Task<bool> IsPrecastExist(int id)
		{
			return await repository.AllReadonly<Precast>()
				.AnyAsync(p => p.Id == id);

		}



	}
}
