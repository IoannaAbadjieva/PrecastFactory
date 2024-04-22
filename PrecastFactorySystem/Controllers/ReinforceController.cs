namespace PrecastFactorySystem.Controllers
{
	using Core.Contracts;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Models.Reinforce;
	using PrecastFactorySystem.Core.Services;

	public class ReinforceController : BaseController
	{
		private readonly IReinforceService reinforceService;
		private readonly IBaseServise baseService;

		public ReinforceController(IReinforceService _reinforceService,
			IBaseServise _baseService)
		{
			reinforceService = _reinforceService;
			baseService = _baseService;
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Add(int id)
		{
			ReinforceFormViewModel model = new ReinforceFormViewModel()
			{
				PrecastId = id,
				ReinforceTypes = await baseService.GetReinforceTypesAsync()
			};
			return View(model);
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[PrecastExists]
		[HttpPost]
		public async Task<IActionResult> Add(int id, ReinforceFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.ReinforceTypes = await baseService.GetReinforceTypesAsync();
				return View(model);
			}

			await reinforceService.AddReinforceAsync(id, model);
			return RedirectToAction("Reinforce", "Precast", new { id });
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[ReinforceExists]
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			ReinforceFormViewModel? model = await reinforceService.GetReinforceByIdAsync(id);
			return View(model);
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[ReinforceExists]
		[HttpPost]
		public async Task<IActionResult> Edit(int id, ReinforceFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.ReinforceTypes = await baseService.GetReinforceTypesAsync();
				return View(model);
			}

			int precastId = await reinforceService.EditReinforceAsync(id, model);
			return RedirectToAction("Reinforce", "Precast", new { id = precastId });

		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[ReinforceExists]
		public async Task<IActionResult> Delete(int id, int precastId)
		{
			await reinforceService.DeleteReinforceAsync(id);
			return RedirectToAction("Reinforce", "Precast", new { id = precastId });

		}


	}
}
