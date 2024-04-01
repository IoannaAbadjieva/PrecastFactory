namespace PrecastFactorySystem.Controllers
{
	using Core.Exceptions;
	using Core.Models;

	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Precast;

	using static Core.Constants.MessageConstants;

	public class PrecastController : BaseController
	{
		private readonly IPrecastService precastService;

		public PrecastController(IPrecastService _precastService)
		{
			precastService = _precastService;
		}
		public async Task<IActionResult> All()
		{
			IEnumerable<PrecastInfoViewModel> model = await precastService.GetAllPrecastAsync();
			return View(model);
		}

		public async Task<IActionResult> Add()
		{
			PrecastFormViewModel model = new PrecastFormViewModel()
			{
				Projects = await precastService.GetProjectAsync(),
				Types = await precastService.GetPrecastTypeAsync(),
				Concrete = await precastService.GetConcreteClassAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(PrecastFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Projects = await precastService.GetProjectAsync();
				model.Types = await precastService.GetPrecastTypeAsync();
				model.Concrete = await precastService.GetConcreteClassAsync();

				return View(model);
			}

			await precastService.AddPrecastAsync(model);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				PrecastFormViewModel model = await precastService.GetPrecastByIdAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}

		[HttpPost]
		public async Task<IActionResult> Edit(PrecastFormViewModel model, int id)
		{
			int reinforced = await precastService.GetReinforcedPrecastCount(id);

			if (model.Count < reinforced)
			{
				ModelState.AddModelError(nameof(model.Count),
					string.Format(InvalidPrecastCountErrorMessage, reinforced));
			}

			if (!ModelState.IsValid)
			{
				model.Projects = await precastService.GetProjectAsync();
				model.Types = await precastService.GetPrecastTypeAsync();
				model.Concrete = await precastService.GetConcreteClassAsync();

				return View(model);
			}

			try
			{
				await precastService.EditPrecastAsync(id, model);
				return RedirectToAction(nameof(All));
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}


		public async Task<IActionResult> Details(int id)
		{
			try
			{
				PrecastDetailsViewModel model = await precastService.GetPrecastDetailsAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}

		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				PrecastDeleteViewModel model = await precastService.GetPrecastToDeleteByIdAsync(id);
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
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await precastService.DeletePrecastAsync(id);
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

			return RedirectToAction(nameof(All));

		}

		public async Task<IActionResult> Reinforce(int id)
		{
			try
			{
				PrecastReinforceViewModel model = await precastService.GetPrecastReinforceAsync(id);
				return View(model);

			}
			catch (ArgumentException )
			{
				return BadRequest();
			}
		}
	}
}
