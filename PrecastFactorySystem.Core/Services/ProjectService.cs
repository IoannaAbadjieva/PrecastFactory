namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Data.Models;
	using Infrastructure.Data.Common;
	using Models.Project;

	using static Constants.DataConstants;
	using PrecastFactorySystem.Core.Models.Precast;

	public class ProjectService : IProjectService
	{
		private readonly IRepository repository;

		public ProjectService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<ProjectInfoViewModel>> GetAllProjectsAsync()
		{
			return await repository.AllReadonly<Project>()
				.Select(p => new ProjectInfoViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					ProdNumber = p.ProdNumber,
					AddedOn = p.AddedOn.ToString(DateFormat),
					PrecastCount = p.ProjectPrecast.Count,
					PrecastTotalCount = p.ProjectPrecast.Sum(precast => precast.Count)
				})
				.OrderByDescending(p => p.Id)
				.ToArrayAsync();
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

			if (project == null)
			{
				throw new ArgumentException();
			}

			return new ProjectFormViewModel()
			{
				Name = project.Name,
				ProdNumber = project.ProdNumber,
			};
		}

		public async Task EditProjectAsync(int id, ProjectFormViewModel model)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			if (project == null)
			{
				throw new ArgumentException();
			}

			project.Name = model.Name;
			project.ProdNumber = model.ProdNumber;

			await repository.SaveChangesAsync();
		}

		public async Task AddPrecastToProjectAsync(PrecastFormViewModel model, int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			if (project == null)
			{
				throw new ArgumentException();
			}

			project.ProjectPrecast.Add(new Precast()
			{
				Name = model.Name,
				PrecastTypeId = model.PrecastTypeId,
				Count = model.Count,
				ProjectId = project.Id,
				ConcreteClassId = model.ConcreteClassId,
				ConcreteProjectAmount = model.ConcreteProjectAmount,
				ReinforceProjectWeight = model.ReinforceProjectAmount
			});

			await repository.SaveChangesAsync();
		}

		public async Task<ProjectInfoViewModel> GetProjectToDeleteByIdAsync(int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			if (project == null)
			{
				throw new ArgumentException();
			}

			if (project.ProjectPrecast.Any(p => p.DepartmentPrecast.Count > 0 || p.PrecastReinforceOrders.Count > 0))
			{
				throw new InvalidOperationException();
			}

			return new ProjectInfoViewModel()
			{
				Id = project.Id,
				Name = project.Name,
				ProdNumber = project.ProdNumber,
				AddedOn = project.AddedOn.ToString(DateFormat),
				PrecastCount = project.ProjectPrecast.Count(),
			};
		}

		public async Task DeleteProjectAsync(int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			if (project == null)
			{
				throw new ArgumentException();
			}

			if (project.ProjectPrecast.Any(p => p.DepartmentPrecast.Count > 0 || p.PrecastReinforceOrders.Count > 0))
			{
				throw new InvalidOperationException();
			}

			repository.Delete(project);
			await repository.SaveChangesAsync();
		}
	}
}