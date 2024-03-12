namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Project;
    using PrecastFactorySystem.Core.Models.Precast;

	public class ProjectController : BaseController
	{
		private readonly IProjectService projectService;
		private readonly IPrecastService precastService;

		public ProjectController(
			IProjectService _projectService,
			IPrecastService _precastService
			)
		{
			projectService = _projectService;
			precastService = _precastService;
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

		public  async Task<IActionResult> Details(int id)
		{
			IEnumerable<PrecastInfoViewModel> model = await precastService.GetPrecastAsync(p => p.ProjectId == id);

			return View(model);
		}

        public IActionResult AddToProject()
        {
            AddToProjectViewModel model = new AddToProjectViewModel();

            return View(model);
        }

        public IActionResult AddToProject(AddToProjectViewModel model,int id)
        {
          
        }
    }
}