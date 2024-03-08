namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Data.Models;
	using Infrastructure.Data.Common;
	using Models.Project;

	using static Constants.DataConstants;


	public class ProjectService : IProjectService
	{
		private readonly IRepository repository;

		public ProjectService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task AddProjectAsync(ProjectFormViewModel model)
		{
			Project entity = new Project()
			{
				Name = model.Name,
				ProdNumber = model.ProdNumber,
				AddedOn = DateTime.Now,
			};

			await repository.AddAsync<Project>(entity);
			await repository.SaveChangesAsync();
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
					PrecastCount = p.Precast.Sum(p => p.Count)
				}).ToArrayAsync();
		}
	}
}