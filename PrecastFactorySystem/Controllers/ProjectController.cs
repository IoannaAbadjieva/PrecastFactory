﻿namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Precast;
	using Core.Models.Project;
	using Core.Exceptions;
	using Core.Models;
	using PrecastFactorySystem.Attributes;

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
			try
			{
				ProjectDetailsViewModel model = await projectService.GetProjectDetails(id);
				model.Precast = await precastService.GetPrecastByClauseAsync(p => p.ProjectId == id);

				return View(model);
			}
			catch (ArgumentException)
			{

				return BadRequest();
			}

		}

		public async Task<IActionResult> AddPrecast(int id)
		{
			PrecastFormViewModel model = new PrecastFormViewModel()
			{
				ProjectId = id,
				Concrete = await baseService.GetConcreteClassesAsync(),
				Types = await baseService.GetPrecastTypesAsync(),
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddPrecast(PrecastFormViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				model.ProjectId = id;
				model.Concrete = await baseService.GetConcreteClassesAsync();
				model.Types = await baseService.GetPrecastTypesAsync();

				return View(model);
			}

			try
			{
				await projectService.AddPrecastToProjectAsync(model, id);
				return RedirectToAction(nameof(Details), new { id = id });
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
		}

		[ProjectExist]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				ProjectFormViewModel model = await projectService.GetProjectByIdAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}

		[HttpPost]
		[ProjectExist]
		public async Task<IActionResult> Edit(ProjectFormViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await projectService.EditProjectAsync(id, model);
				return RedirectToAction(nameof(All));
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}

		[ProjectExist]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				ProjectInfoViewModel model = await projectService.GetProjectToDeleteByIdAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
			catch (DeleteActionException dae)
			{

				return View("DeleteError", new DeleteErrorViewModel()
				{
					Message = dae.Message
				});
			}

		}

		[HttpPost]
		[ProjectExist]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await projectService.DeleteProjectAsync(id);
				return RedirectToAction(nameof(All));
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
			catch (DeleteActionException dae)
			{

				return View("DeleteError", new DeleteErrorViewModel()
				{
					Message = dae.Message
				});
			}


		}
	}
}