namespace PrecastFactorySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Web.Attributes;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Models.Project;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Authorization;


	public class ProjectController : BaseController
	{
		private readonly IProjectService projectService;
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;

		public ProjectController(
			IProjectService _projectService,
			IPrecastService _precastService,
			IBaseServise _baseService
			)
		{
			projectService = _projectService;
			precastService = _precastService;
			baseService = _baseService;
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery]AllProjectsQueryModel model)
		{
			var projects = await projectService.GetAllProjectsAsync(
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				AllProjectsQueryModel.ProjectsPerPage);

			model.Projects = projects.Projects;
			model.TotalProjects = projects.TotalProjects;

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[HttpGet]
		public IActionResult Add()
		{
			ProjectFormViewModel model = new ProjectFormViewModel();

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[HttpPost]
		public async Task<IActionResult> Add(ProjectFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await projectService.AddProjectAsync(model);

			TempData["Message"] = "You have successfully added project!";
			return RedirectToAction(nameof(All));
		}

		[ProjectExists]
		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			ProjectDetailsViewModel? model = await projectService.GetProjectDetails(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpGet]
		public async Task<IActionResult> AddPrecast(int id)
		{
			PrecastFormViewModel model = new PrecastFormViewModel()
			{
				ProjectId = id,
				Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>(),
				Types = await baseService.GetBaseEntityDataAsync<PrecastType>(),
			};

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpPost]
		public async Task<IActionResult> AddPrecast(PrecastFormViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				model.ProjectId = id;
				model.Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>();
				model.Types = await baseService.GetBaseEntityDataAsync<PrecastType>();

				return View(model);
			}


			await projectService.AddPrecastToProjectAsync(model, id);

			TempData["Message"] = "You have successfully added precast!";
			return RedirectToAction(nameof(All));

		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			ProjectFormViewModel model = await projectService.GetProjectByIdAsync(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpPost]
		public async Task<IActionResult> Edit(ProjectFormViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await projectService.EditProjectAsync(id, model);

			TempData["Message"] = "You have successfully edited project!";
			return RedirectToAction(nameof(All));
		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				ProjectInfoViewModel? model = await projectService.GetProjectToDeleteByIdAsync(id);
				return View(model);
			}
			catch (DeleteActionException dae)
			{
				return View("BaseError", new BaseErrorViewModel()
				{
					Message = dae.Message
				});
			}

		}

		[Authorize(Roles = "Administrator, Manager")]
		[ProjectExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await projectService.DeleteProjectAsync(id);

				TempData["Message"] = "You have successfully deleted project!";
				return RedirectToAction(nameof(All));
			}
			catch (DeleteActionException dae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = dae.Message
				});
			}
		}
	}
}