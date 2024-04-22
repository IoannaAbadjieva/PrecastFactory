namespace PrecastFactorySystem.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Project;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class ProjectController : AdminBaseController
	{
		private readonly IProjectService projectService;
		private readonly IBaseServise baseService;

		public ProjectController(IProjectService _projectService,
			IBaseServise _baseService)
		{
			projectService = _projectService;
			baseService = _baseService;
		}
		public async Task<IActionResult> All([FromQuery] AllProjectsQueryModel model)
		{
			var projects = await projectService.GetAllProjectsAsync(
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				AllProjectsQueryModel.ProjectsPerPage + 8);

			model.Projects = projects.Projects;
			model.TotalProjects = projects.TotalProjects;

			return View(model);
		}

		[ProjectExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = await baseService.GetEntityBaseInfoAsync<Project>(id);
			return View(model);
		}

		[ProjectExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await baseService.DeleteEntityAsync<Project>(id);
			return RedirectToAction(nameof(All));
		}
	}
}
