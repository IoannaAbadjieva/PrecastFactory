namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Project;

	public class ProjectController : BaseController
	{
		private readonly IProjectService projectService;

		public ProjectController(IProjectService _projectService)
		{
			projectService = _projectService;
		}
		public async Task<IActionResult> All()
		{
			IEnumerable<ProjectInfoViewModel> model = await projectService.GetAllProjectsAsync();

			return View(model);
		}

		public IActionResult Add()
		{
			ProjectFormViewModel model = new ProjectFormViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProjectFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await projectService.AddProjectAsync(model);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> Details(int id)
		{
			
		}
	}
}