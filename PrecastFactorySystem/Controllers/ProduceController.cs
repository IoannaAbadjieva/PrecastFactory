namespace PrecastFactorySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Core.Models.Produce;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Web.Attributes;

	using static PrecastFactorySystem.Core.Constants.MessageConstants;


	public class ProduceController : BaseController
	{
		private readonly IProduceService produceService;
		private readonly IBaseServise baseService;

		public ProduceController(
			IProduceService _productionService,
			IBaseServise _baseService)
		{
			produceService = _productionService;
			baseService = _baseService;

		}

		[Authorize(Roles = "Administrator, PrecastProductionManager")]
		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Produce(int id)
		{
			try
			{
				ProduceFormViewModel model = await produceService.GetProductionFormAsync(id);
				return View(model);
			}
			catch (ProduceActionException pae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = pae.Message
				});
			}

		}

		[Authorize(Roles = "Administrator, PrecastProductionManager")]
		[PrecastExists]
		[HttpPost]
		public async Task<IActionResult> Produce(int id, ProduceFormViewModel model)
		{
			try
			{
				int maxCount = await produceService.GetPrecastToProduceCountAsync(id, null);

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

				await produceService.ProducePrecastAsync(id, model);
				TempData["Message"] = "You have successfully added production record!";
				return RedirectToAction("Production", "Precast", new { id });
			}
			catch (ProduceActionException pae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = pae.Message
				});
			}

		}

		[Authorize(Roles = "Administrator, PrecastProductionManager")]
		[ProductionRecordExists]
		public async Task<IActionResult> Edit(int id)
		{
			ProduceFormViewModel model = await produceService.GetProductionRecordByIdAsync(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, PrecastProductionManager")]
		[ProductionRecordExists]
		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProduceFormViewModel model)
		{
			try
			{
				int precastId = model.PrecastId;

				int maxCount = await produceService.GetPrecastToProduceCountAsync(precastId, id);

				if (model.ProducedCount > maxCount)
				{
					ModelState.AddModelError(nameof(model.ProducedCount),
												string.Format(InvalidProduceCountErrorMessage, maxCount));
				}

				if (!ModelState.IsValid)
				{
					model.Departments = await baseService.GetBaseEntityDataAsync<Department>
						(d => d.DepartmentType == Infrastructure.Data.Enums.DepartmentType.PrecastProduction);
					return View(model);
				}

				await produceService.EditProductionRecordAsync(id, model);
				TempData["Message"] = "You have successfully edited production record!";
				return RedirectToAction("Production", "Precast", new { id = precastId });
			}
			catch (ProduceActionException pae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = pae.Message
				});
			}

		}


		[Authorize(Roles = "Administrator, PrecastProductionManager")]
		[ProductionRecordExists]
		public async Task<IActionResult> Delete(int id, int precastId)
		{
			await produceService.DeleteProductionRecordAsync(id);

			TempData["Message"] = "You have successfully deleted production record!";
			return RedirectToAction("Production", "Precast", new { id = precastId });
		}
	}
}
