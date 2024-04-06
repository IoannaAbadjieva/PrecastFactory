namespace PrecastFactorySystem.Controllers
{
	using Core.Contracts;

	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Models.Reinforce;

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

		[ReinforceExist]
		public async Task<IActionResult> Edit(int id)
		{

			ReinforceFormViewModel model = await reinforceService.GetReinforceByIdAsync(id);
			return View(model);

		}

		[HttpPost]
		[ReinforceExist]
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

		[HttpPost]
		[ReinforceExist]
		public async Task<IActionResult> Delete(int id)
		{
			int precastId = await reinforceService.DeleteReinforceAsync(id);
			return RedirectToAction("Reinforce", "Precast", new { id = precastId });

		}
	}
}
