namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Models.Project;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Precast;

	public interface IProjectService
	{		
		Task<ProjectQueryModel> GetAllProjectsAsync(string? searchTerm = null,
			ProjectSorting sorting = ProjectSorting.Oldest,
			int currentPage = 1,
			int projectsPerPage = 4);
		Task AddProjectAsync(ProjectFormViewModel model);

		Task AddPrecastToProjectAsync(PrecastFormViewModel model, int id);

		Task<ProjectFormViewModel> GetProjectByIdAsync(int id);

        Task EditProjectAsync(int id, ProjectFormViewModel model);

		Task<ProjectInfoViewModel> GetProjectToDeleteByIdAsync(int id);

        Task DeleteProjectAsync(int id);

		Task<ProjectDetailsViewModel> GetProjectDetails(int id);

		Task<bool>IsReinforcedProjectPrecastAsync(int id);

		Task<bool> IsProjectExistAsync(int id);
	}
}