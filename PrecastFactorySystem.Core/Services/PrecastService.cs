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
			int projectsPerPage = 12)
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
				.Skip((currentPage - 1) * projectsPerPage)
				.Take(projectsPerPage)
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
			if (await GetPrecastToProduceCountAsync(id) <= 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

			return new PrecastProductionFormViewModel()
			{
				Id = id,
				ProducedCount = await GetPrecastToProduceCountAsync(id),
				Departments = await baseServise.GetDepartmentsAsync()
			};

		}

		public async Task ProducePrecastAsync(int id, PrecastProductionFormViewModel model)
		{
			if (await GetPrecastToProduceCountAsync(id) <= 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

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
