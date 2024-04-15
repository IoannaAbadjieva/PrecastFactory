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
	using PrecastFactorySystem.Infrastructure.Data.Models;

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
				model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
				model.Types = await baseService.GetBaseEntityDataAsync<PrecastType>();
				model.Concrete = await baseService.GetBaseEntityDataAsync<ConcreteClass>();

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
				return View("DeleteError", new BaseErrorViewModel()
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

				return View("DeleteError", new BaseErrorViewModel()
				{
					Message = dae.Message
				});
			}

			return RedirectToAction(nameof(All));

		}

		[PrecastExist]
		public async Task<IActionResult> Reinforce(int id, [FromQuery]AllPrecastReinforceQueryModel model)
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

		[PrecastExist]
		public async Task<IActionResult> Produce(int id)
		{
			try
			{
				PrecastProductionFormViewModel? model = await precastService.GetPrecastProductionFormAsync(id);
				return View(model);
			}
			catch (ProduceActionException pae)
			{

				return View("ProduceError", new BaseErrorViewModel()
				{
					Message = pae.Message
				});
			}

		}

		[HttpPost]
		[PrecastExist]
		public async Task<IActionResult> Produce(int id, PrecastProductionFormViewModel model)
		{
			try
			{
				int maxCount = await precastService.GetPrecastToProduceCountAsync(id);

				if (model.ProducedCount > maxCount)
				{
					ModelState.AddModelError(nameof(model.ProducedCount),
						string.Format(InvalidProduceCountErrorMessage, maxCount));
				}

				if (!ModelState.IsValid)
				{
					model.Departments = await baseService.GetBaseEntityDataAsync<Department>();
					return View(model);
				}

				await precastService.ProducePrecastAsync(id, model);
				return RedirectToAction(nameof(Production), new { id });
			}
			catch (ProduceActionException pae)
			{

				return View("ProduceError", new BaseErrorViewModel()
				{
					Message = pae.Message
				});
			}
			
		}

	}
}
