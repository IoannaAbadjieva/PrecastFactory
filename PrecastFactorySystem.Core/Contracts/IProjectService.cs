namespace PrecastFactorySystem.Core.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using Models.Project;

public interface IProjectService
{
	Task AddProjectAsync(ProjectFormViewModel model);
	Task<IEnumerable<ProjectInfoViewModel>> GetAllProjectsAsync();
}