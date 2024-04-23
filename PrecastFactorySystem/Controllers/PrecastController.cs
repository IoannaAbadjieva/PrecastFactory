namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Attributes;

	using Core.Contracts;
	using Core.Exceptions;
	using Core.Models;
	using Core.Models.Precast;

	using static Core.Constants.MessageConstants;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Authorization;

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

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllPrecastQueryModel model)
		{
			var precasts = await precastService.GetAllPrecastAsync(
				model.SearchTerm,
				model.ProjectId,
				model.PrecastTypeId,
				model.Sorting,
				model.CurrentPage,
				AllPrecastQueryModel.PrecastsPerPage);

			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.PrecastTypes = await baseService.GetBaseEntityDataAsync<PrecastType>();
			model.Precast = precasts.Precasts;
			model.TotalPrecast = precasts.TotalPrecast;

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			PrecastFormViewModel model = new PrecastFormViewModel()
			{
				Projects = await baseService.GetBaseEntityDataAsync<Project>(),
				Types = await baseService.GetBaseEntityDataAsync<PrecastType>(),
				Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>()
			};

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[HttpPost]
		public async Task<IActionResult> Add(PrecastFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
				model.Types = await baseService.GetBaseEntityDataAsync<PrecastType>();
				model.Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>();

				return View(model);
			}

			await precastService.AddPrecastAsync(model);

			TempData["Message"] = "You have successfully added precast!";
			return RedirectToAction(nameof(All));
		}

		[Authorize(Roles = "Administrator, Manager")]
		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			PrecastFormViewModel model = await precastService.GetPrecastByIdAsync(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[PrecastExists]
		[HttpPost]
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
				model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
				model.Types = await baseService.GetBaseEntityDataAsync<PrecastType>();
				model.Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>();

				return View(model);
			}
			await precastService.EditPrecastAsync(id, model);
			TempData["Message"] = "You have successfully edited precast!";
			return RedirectToAction(nameof(All));

		}


		[PrecastExists]
		public async Task<IActionResult> Details(int id)
		{
			PrecastDetailsViewModel? model = await precastService.GetPrecastDetailsAsync(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				PrecastDeleteViewModel? model = await precastService.GetPrecastToDeleteByIdAsync(id);
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
		[PrecastExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await precastService.DeletePrecastAsync(id);
				TempData["Message"] = "You have successfully deleted precast!";
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

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Reinforce(int id, [FromQuery] AllPrecastReinforceQueryModel model)
		{
			PrecastReinforceQueryModel precastReinforce = await precastService.GetPrecastReinforceAsync(
				id,
				model.CurrentPage,
				AllPrecastReinforceQueryModel.ReinforcePerPage);

			model.Id = id;
			model.Name = precastReinforce.Name;
			model.Count = precastReinforce.Count;
			model.PrecastType = precastReinforce.PrecastType;
			model.Project = precastReinforce.Project;
			model.Reinforced = precastReinforce.Reinforced;
			model.Produced = precastReinforce.Produced;
			model.Reinforce = precastReinforce.Reinforce;
			model.TotalReinforce = precastReinforce.TotalReinforce;

			return View(model);
		}

		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Production(int id, [FromQuery] AllPrecastProductionQueryModel model)
		{
			PrecastProductionQueryModel precastProduction = await precastService.GetPrecastProductionAsync(
				id,
				model.CurrentPage,
				AllPrecastProductionQueryModel.PrecastPerPage);

			model.Id = id;
			model.Name = precastProduction.Name;
			model.Count = precastProduction.Count;
			model.PrecastType = precastProduction.PrecastType;
			model.Project = precastProduction.Project;
			model.Reinforced = precastProduction.Reinforced;
			model.Produced = precastProduction.Produced;
			model.Precast = precastProduction.Precast;
			model.TotalPrecast = precastProduction.TotalPrecast;

			return View(model);

		}
	}

}
