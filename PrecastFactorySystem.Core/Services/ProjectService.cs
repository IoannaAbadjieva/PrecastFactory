namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Exceptions;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Precast;
	using Models.Project;

	using static Constants.MessageConstants;
	using static Infrastructure.DataValidation.DataConstants;


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
			var model = await repository.AllReadonly<Project>(p => p.Id == id)
			.Select(p => new ProjectInfoViewModel()
			{
				Id = p.Id,
				Name = p.Name,
				ProdNumber = p.ProdNumber,
				AddedOn = p.AddedOn.ToString(DateFormat),
				PrecastCount = p.ProjectPrecast.Count(),
			}).FirstOrDefaultAsync();

			if (model == null)
			{
				throw new ArgumentException();
			}

			bool isReinforce = await repository.AllReadonly<Precast>(p => p.ProjectId == id)
				 .AnyAsync(p => p.Reinforced > 0);

			if (isReinforce)
			{
				throw new DeleteActionException(DeleteProjectErrorMessage);
			}

			return model;
		}

		public async Task DeleteProjectAsync(int id)
		{
			var project = await repository.GetByIdAsync<Project>(id);

			if (project == null)
			{
				throw new ArgumentException();

			}


			bool isReinforce = await repository.AllReadonly<Precast>(p => p.ProjectId == id)
						   .AnyAsync(p => p.PrecastReinforceOrders.Count > 0);

			if (isReinforce)
			{
				throw new DeleteActionException(DeleteProjectErrorMessage);
			}

			repository.Delete(project);
			await repository.SaveChangesAsync();
		}

		public async Task<ProjectDetailsViewModel> GetProjectDetails(int id)
		{
			var model = await repository.AllReadonly<Project>(p => p.Id == id)
				 .Select(p => new ProjectDetailsViewModel()
				 {
					 Id = p.Id,
					 Name = p.Name,
					 ProdNumber = p.ProdNumber,
				 }).FirstOrDefaultAsync();

			if (model == null)
			{
				throw new ArgumentException();
			}

			return model;
		}
	}
}