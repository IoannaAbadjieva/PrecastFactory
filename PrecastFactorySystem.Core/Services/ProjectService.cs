namespace PrecastFactorySystem.Core.Services
{
	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Models.Project;

	using static PrecastFactorySystem.Core.Constants.MessageConstants;
	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;

	public class ProjectService : IProjectService
	{

		private readonly IRepository repository;

		public ProjectService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<ProjectQueryModel> GetAllProjectsAsync(string? searchTerm = null,
			ProjectSorting sorting = ProjectSorting.Newest,
			int currentPage = 1,
			int projectsPerPage = 4)
		{
			var query = repository.AllReadonly<Project>();

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				query = query.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
			}

			query = sorting switch
			{
				ProjectSorting.Newest => query.OrderBy(p => p.AddedOn),
				ProjectSorting.Name => query.OrderBy(p => p.Name),
				_ => query.OrderByDescending(p => p.Id)
			};

			var totalProjects = await query.CountAsync();

			var projects = await query
				.Skip((currentPage - 1) * projectsPerPage)
				.Take(projectsPerPage)
				.Select(p => new ProjectInfoViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					ProdNumber = p.ProdNumber,
					AddedOn = p.AddedOn.ToString(DateFormat),
					PrecastCount = p.ProjectPrecast.Count(),
					PrecastTotalCount = p.ProjectPrecast.Sum(p => p.Count),
				}).ToListAsync();

			return new ProjectQueryModel()
			{
				TotalProjects = totalProjects,
				Projects = projects
			};
		}

		public async Task AddProjectAsync(ProjectFormViewModel model)
		{
			var entity = new Project()
			{
				Name = model.Name,
				ProdNumber = model.ProdNumber,
				AddedOn = DateTime.Now,
			};

			await repository.AddAsync(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<ProjectFormViewModel> GetProjectByIdAsync(int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			return new ProjectFormViewModel()
			{
				Name = project.Name,
				ProdNumber = project.ProdNumber,
			};
		}

		public async Task EditProjectAsync(int id, ProjectFormViewModel model)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			project.Name = model.Name;
			project.ProdNumber = model.ProdNumber;

			await repository.SaveChangesAsync();
		}

		public async Task AddPrecastToProjectAsync(PrecastFormViewModel model, int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			project.ProjectPrecast.Add(new Precast()
			{
				Name = model.Name,
				PrecastTypeId = model.PrecastTypeId,
				Count = model.Count,
				ProjectId = project.Id,
				ConcreteClassId = model.ConcreteClassId,
				ConcreteProjectAmount = model.ConcreteProjectAmount,
				ConcreteActualAmount = model.ConcreteActualAmount,
				ReinforceProjectWeight = model.ReinforceProjectAmount
			});

			await repository.SaveChangesAsync();
		}

		public async Task<ProjectInfoViewModel?> GetProjectToDeleteByIdAsync(int id)
		{
			bool isReinforce = await IsReinforcedProjectPrecastAsync(id);

			if (isReinforce)
			{
				throw new DeleteActionException(DeleteProjectErrorMessage);
			}

			return await repository.AllReadonly<Project>(p => p.Id == id)
			.Select(p => new ProjectInfoViewModel()
			{
				Id = p.Id,
				Name = p.Name,
				ProdNumber = p.ProdNumber,
				AddedOn = p.AddedOn.ToString(DateFormat),
				PrecastCount = p.ProjectPrecast.Count(),
			}).FirstOrDefaultAsync();

		}

		public async Task DeleteProjectAsync(int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			bool isReinforce = await IsReinforcedProjectPrecastAsync(id);

			if (isReinforce)
			{
				throw new DeleteActionException(DeleteProjectErrorMessage);
			}

			repository.Delete(project);
			await repository.SaveChangesAsync();
		}

		public async Task<ProjectDetailsViewModel?> GetProjectDetails(int id)
		{
			return await repository.AllReadonly<Project>(p => p.Id == id)
				 .Select(p => new ProjectDetailsViewModel()
				 {
					 Id = p.Id,
					 Name = p.Name,
					 ProdNumber = p.ProdNumber,
					 Precast = p.ProjectPrecast.Select(precast => new PrecastInfoViewModel()
					 {
						 Id = precast.Id,
						 PrecastType = precast.PrecastType.Name,
						 Name = precast.Name,
						 Count = precast.Count,
						 Reinforced = precast.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count),
						 Produced = precast.DepartmentPrecast.Sum(dp => dp.Count),
					 }).ToArray()
				 }).FirstOrDefaultAsync();

		}

		public async Task<bool> IsReinforcedProjectPrecastAsync(int id)
		{
			return await repository.AllReadonly<Precast>(p => p.ProjectId == id)
				.AnyAsync(p => p.PrecastReinforceOrders.Count > 0);
		}

		public async Task<bool> IsProjectExistAsync(int id)
		{
			return await repository.AllReadonly<Project>()
			   .AnyAsync(p => p.Id == id);
		}


	}
}