namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Enumeration;
	using Exceptions;
	using Models.Precast;
	using Models.Reinforce;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;

	using static Constants.MessageConstants;
	using static Infrastructure.DataValidation.DataConstants;
	using PrecastFactorySystem.Infrastructure.Data.Enums;

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

		public async Task<PrecastQueryModel> GetAllPrecastAsync(string? searchTerm = null,
			int? projectId = null,
			int? precastTypeId = null,
			PrecastSorting sorting = PrecastSorting.Newest,
			int currentPage = 1,
			int precastPerPage = 12)
		{
			var query = repository.AllReadonly<Precast>();

			string search = searchTerm?.ToLower() ?? string.Empty;

			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(p => p.Name.ToLower().Contains(search)
									|| p.Project.Name.Contains(search)
									|| p.PrecastType.Name.Contains(search)
									|| p.ConcreteClass.Name.Contains(search));
			}

			if (projectId.HasValue)
			{
				query = query.Where(p => p.ProjectId == projectId);
			}

			if (precastTypeId.HasValue)
			{
				query = query.Where(p => p.PrecastTypeId == precastTypeId);
			}

			query = sorting switch
			{
				PrecastSorting.ByProject => query.OrderBy(p => p.Project.Name)
												 .ThenBy(p => p.PrecastType.Name)
												 .ThenBy(p => p.Name),
				PrecastSorting.ByType => query.OrderBy(p => p.PrecastType.Name)
												.ThenBy(p => p.Project.Name)
												.ThenBy(p => p.Name),
				_ => query.OrderByDescending(p => p.Id)
			};

			var totalPrecasts = await query.CountAsync();

			var precast = await query
				.Skip((currentPage - 1) * precastPerPage)
				.Take(precastPerPage)
				.Select(p => new PrecastInfoViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Project = p.Project.Name,
					PrecastType = p.PrecastType.Name,
					Count = p.Count,
					Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
				}).ToArrayAsync();

			return new PrecastQueryModel()
			{
				TotalPrecast = totalPrecasts,
				Precasts = precast
			};
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
				ConcreteActualAmount = model.ConcreteActualAmount,
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
				Types = await baseServise.GetBaseEntityDataAsync<PrecastType>(),
				Count = precast.Count,
				ProjectId = precast.ProjectId,
				Projects = await baseServise.GetBaseEntityDataAsync<Project>(),
				ConcreteClassId = precast.ConcreteClassId,
				Concrete = await baseServise.GetBaseEntityDataAsync<ConcreteClass>(),
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

		public async Task<PrecastReinforceQueryModel> GetPrecastReinforceAsync(
			int id,
			int currentPage = 1,
			int reinforcePerPage = 7)
		{
			var query = repository.AllReadonly<PrecastReinforce>(pr => pr.PrecastId == id);

			var totalReinforces = await query.CountAsync();

			var reinforces = await query
				.Skip((currentPage - 1) * reinforcePerPage)
				.Take(reinforcePerPage)
				.Select(pr => new ReinforceInfoViewModel()
				{
					Id = pr.Id,
					PrecastId = pr.PrecastId,
					Position = pr.Position,
					ReinforceType = $"{pr.ReinforceType.ReinforceClass.ToString()} {pr.ReinforceType.Diameter}",
					Count = pr.Count,
					Length = pr.Length
				}).ToArrayAsync();

			var precast = await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new
				{
					Id = p.Id,
					Name = p.Name,
					PrecastType = p.PrecastType.Name,
					Project = p.Project.Name,
					Count = p.Count,
					Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
				}).FirstAsync();


			return new PrecastReinforceQueryModel()
			{
				Id = precast.Id,
				Name = precast.Name,
				PrecastType = precast.PrecastType,
				Project = precast.Project,
				Count = precast.Count,
				Produced = precast.Produced,
				Reinforced = precast.Reinforced,
				TotalReinforce = totalReinforces,
				Reinforce = reinforces

			};
		}


		public async Task<PrecastProductionQueryModel> GetPrecastProductionAsync(
			int id,
			int currentPage = 1,
			int precastPerPage = 7)
		{
			var query = repository.AllReadonly<PrecastDepartment>(pr => pr.PrecastId == id);

			var totalPrecast = await query.CountAsync();

			var precastProduction = await query
				.Skip((currentPage - 1) * precastPerPage)
				.Take(precastPerPage)
				.Select(pr => new PrecastProductionViewModel()
				{
					Id = pr.Id,
					PrecastId = pr.PrecastId,
					Department = pr.Department.Name,
					Count = pr.Count,
					Date = pr.Date.ToString(DateFormat),
				}).ToArrayAsync();

			var precast = await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new
				{
					Id = p.Id,
					Name = p.Name,
					PrecastType = p.PrecastType.Name,
					Project = p.Project.Name,
					Count = p.Count,
					Reinforced = p.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
					Produced = p.DepartmentPrecast.Sum(dp => dp.Count),
				}).FirstAsync();


			return new PrecastProductionQueryModel()
			{
				Id = precast.Id,
				Name = precast.Name,
				PrecastType = precast.PrecastType,
				Project = precast.Project,
				Count = precast.Count,
				Produced = precast.Produced,
				Reinforced = precast.Reinforced,
				TotalPrecast = totalPrecast,
				Precast = precastProduction
			};
		}

		public async Task ProducePrecastAsync(int id, PrecastProductionFormViewModel model)
		{
			if (await GetPrecastToProduceCountAsync(id, null) <= 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

			var entity = new PrecastDepartment()
			{
				PrecastId = id,
				Count = model.ProducedCount,
				Date = model.Date,
				DepartmentId = model.DepartmentId,
			};

			await repository.AddAsync<PrecastDepartment>(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<PrecastProductionFormViewModel?> GetPrecastProductionByIdAsync(int id)
		{
			var model = await repository.AllReadonly<PrecastDepartment>(p => p.Id == id)
				.Select(p => new PrecastProductionFormViewModel()
				{
					Date = p.Date,
					ProducedCount = p.Count,
					DepartmentId = p.DepartmentId,
				}).FirstOrDefaultAsync();

			if (model != null)
			{
				model.Departments = await baseServise.GetBaseEntityDataAsync<Department>();
			}

			return model;
		}

		public async Task EditProductionRecordAsync(int id, PrecastProductionFormViewModel model)
		{
			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			entity.Count = model.ProducedCount;
			entity.Date = model.Date;
			entity.DepartmentId = model.DepartmentId;

			await repository.SaveChangesAsync();
		}


		public async Task DeleteProductionRecordAsync(int id)
		{
			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> IsProductionRecordExist(int id)
		{
			return await repository.AllReadonly<PrecastDepartment>()
				.AnyAsync(p => p.Id == id);
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

		public async Task<int> GetProducedPrecastCountAsync(int id, int? recordId)
		{
			var produced = 0;

			if (recordId.HasValue)
			{
				produced = await repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id && dp.Id != recordId)
				   .SumAsync(dp => dp.Count);
			}
			else
			{
				produced = await repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id)
				   .SumAsync(dp => dp.Count);
			}

			return produced;
		}

		public async Task<int> GetPrecastToProduceCountAsync(int id, int? recordId)
		{
			var reinforced = await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id && pro.ReinforceOrder.DeliverDate <= DateTime.UtcNow)
				.SumAsync(pro => pro.ReinforceOrder.Count);
			var produced = await GetProducedPrecastCountAsync(id, recordId);

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

		public async Task<PrecastProductionFormViewModel?> GetPrecastProductionFormAsync(int id)
		{
			int maxCount = await GetPrecastToProduceCountAsync(id, null);

			if (maxCount <= 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

			return new PrecastProductionFormViewModel()
			{
				Id = id,
				PrecastId = id,
				ProducedCount = maxCount,
				Date = DateTime.Now,
				Departments = await baseServise.GetBaseEntityDataAsync<Department>(
					d => d.DepartmentType == DepartmentType.PrecastProduction)
			};
		}

		public async Task<PrecastProductionFormViewModel?> GetPrecastProductionRecordByIdAsync(int id)
		{
			var model = await repository.AllReadonly<PrecastDepartment>(p => p.Id == id)
				.Select(p => new PrecastProductionFormViewModel()
				{
					Id = p.Id,
					PrecastId = p.PrecastId,
					ProducedCount = p.Count,
					Date = p.Date,
					DepartmentId = p.DepartmentId,

				}).FirstOrDefaultAsync();

			if (model != null)
			{
				model.Departments = await baseServise.GetBaseEntityDataAsync<Department>();
			}

			return model;
		}

		public async Task EditPrecastProductionRecordAsync(int id, PrecastProductionFormViewModel model)
		{
			int precastId = model.PrecastId;

			int maxCount = await GetPrecastToProduceCountAsync(precastId, id);

			if (model.ProducedCount > maxCount)
			{
				throw new ProduceActionException(InvalidProduceCountErrorMessage);
			}

			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			entity.Count = model.ProducedCount;
			entity.Date = model.Date;
			entity.DepartmentId = model.DepartmentId;

			await repository.SaveChangesAsync();
		}

		public async Task DeletePrecastProductionRecordAsync(int id)
		{
			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}

	}
}
