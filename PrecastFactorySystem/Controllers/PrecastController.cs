namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Attributes;

	using Core.Contracts;
	using Core.Exceptions;
	using Core.Models;
	using Core.Models.Precast;
	using Core.Models.Reinforce;

	using static Core.Constants.MessageConstants;

	public class PrecastController : BaseController
	{
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;
		private readonly IReinforceService reinforceService;

		public PrecastController(IPrecastService _precastService,
			IBaseServise _baseService,
			IReinforceService _reinforceService)
		{
			precastService = _precastService;
			baseService = _baseService;
			reinforceService = _reinforceService;
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
				Projects = await baseService.GetProjectsAsync(),
				Types = await baseService.GetPrecastTypesAsync(),
				Concrete = await baseService.GetConcreteClassesAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(PrecastFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Projects = await baseService.GetProjectsAsync();
				model.Types = await baseService.GetPrecastTypesAsync();
				model.Concrete = await baseService.GetConcreteClassesAsync();

				return View(model);
			}

			await precastService.AddPrecastAsync(model);

			return RedirectToAction(nameof(All));
		}

		[PrecastExist]
		public async Task<IActionResult> Edit(int id)
		{
			PrecastFormViewModel model = await precastService.GetPrecastByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		[PrecastExist]
		public async Task<IActionResult> Edit(PrecastFormViewModel model, int id)
		{
			int reinforced = await precastService.GetReinforcedPrecastCountAsync(id);

			if (model.Count < reinforced)
			{
				ModelState.AddModelError(nameof(model.Count),
					string.Format(InvalidPrecastCountErrorMessage, reinforced));
			}

			if (!ModelState.IsValid)
			{
				model.Projects = await baseService.GetProjectsAsync();
				model.Types = await baseService.GetPrecastTypesAsync();
				model.Concrete = await baseService.GetConcreteClassesAsync();

				return View(model);
			}
			await precastService.EditPrecastAsync(id, model);
			return RedirectToAction(nameof(All));

		}


		[PrecastExist]
		public async Task<IActionResult> Details(int id)
		{
			PrecastDetailsViewModel? model = await precastService.GetPrecastDetailsAsync(id);
			return View(model);
		}

		[PrecastExist]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				PrecastDeleteViewModel? model = await precastService.GetPrecastToDeleteByIdAsync(id);
				return View(model);
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
		[PrecastExist]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await precastService.DeletePrecastAsync(id);
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

		[PrecastExist]
		public async Task<IActionResult> Reinforce(int id)
		{

			PrecastReinforceViewModel? model = await precastService.GetPrecastReinforceAsync(id);
			return View(model);

		}


		[PrecastExist]
		public async Task<IActionResult> AddReinforce(int id)
		{
			ReinforceFormViewModel model = new ReinforceFormViewModel()
			{
				PrecastId = id,
				ReinforceTypes = await baseService.GetReinforceTypesAsync()
			};
			return View(model);
		}

		[HttpPost]
		[PrecastExist]
		public async Task<IActionResult> AddReinforce(int id, ReinforceFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.ReinforceTypes = await baseService.GetReinforceTypesAsync();
				return View(model);
			}

			await precastService.AddReinforceAsync(id, model);
			return RedirectToAction(nameof(Reinforce), new { id });
		}


		[PrecastExist]
		public async Task<IActionResult> Production(int id)
		{
			PrecastProductionViewModel? model = await precastService.GetPrecastProductionAsync(id);
			return View(model);
		}

		[PrecastExist]
		public async Task<IActionResult> Produce(int id)
		{
			PrecastProductionFormViewModel? model = await precastService.GetPrecastProductionFormAsync(id);
			return View(model);
		}

		[HttpPost]
		[PrecastExist]
		public async Task<IActionResult> Produce(int id, PrecastProductionFormViewModel model)
		{

			int maxCount = await precastService.GetPrecastToProduceCountAsync(id);

			if (model.ProducedCount > maxCount)
			{
				ModelState.AddModelError(nameof(model.ProducedCount),
					string.Format(InvalidProduceCountErrorMessage, maxCount));
			}

			if (!ModelState.IsValid)
			{
				model.Departments = await baseService.GetDepartmentsAsync();
				return View(model);
			}

			await precastService.ProducePrecastAsync(id, model);
			return RedirectToAction(nameof(Production), new { id });
		}

	}
}
