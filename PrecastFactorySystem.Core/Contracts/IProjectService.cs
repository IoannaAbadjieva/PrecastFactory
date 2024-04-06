namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Models.Project;

	using PrecastFactorySystem.Core.Models.Precast;

	public interface IProjectService
	{
		Task AddPrecastToProjectAsync(PrecastFormViewModel model, int id);

		Task AddProjectAsync(ProjectFormViewModel model);

		Task DeleteProjectAsync(int id);

		Task EditProjectAsync(int id, ProjectFormViewModel model);

		Task<IEnumerable<ProjectInfoViewModel>> GetAllProjectsAsync();

		Task<ProjectFormViewModel> GetProjectByIdAsync(int id);

		Task<ProjectDetailsViewModel> GetProjectDetails(int id);

		Task<bool>IsReinforcedProjectPrecastAsync(int id);

		Task<ProjectInfoViewModel> GetProjectToDeleteByIdAsync(int id);

		Task<bool> IsProjectExistAsync(int id);
	}
}