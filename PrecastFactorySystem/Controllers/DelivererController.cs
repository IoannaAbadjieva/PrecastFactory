namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Core.Models.Deliverer;

	
	public class DelivererController : BaseController
	{
		private readonly IDelivererService delivererService;

		public DelivererController(IDelivererService _delivererService)
		{
			delivererService = _delivererService;
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllDeliverersQueryModel model)
		{
			var deliverers = await delivererService.GetAllDeliverersAsync(
				model.SearchTerm,
				model.CurrentPage,
				AllDeliverersQueryModel.DeliverersPerPage);

			model.Deliverers = deliverers.Deliverers;
			model.TotalDeliverers = deliverers.TotalDeliverers;

			return View(model);
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[HttpGet]
		public IActionResult Add()
		{
			DelivererFormViewModel model = new DelivererFormViewModel();

			return View(model);
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[HttpPost]
		public async Task<IActionResult> Add(DelivererFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await delivererService.AddDelivererAsync(model);

			return RedirectToAction(nameof(All));
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[DelivererExists]
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{

			DelivererFormViewModel model = await delivererService.GetDelivererByIdAsync(id);
			return View(model);

		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[DelivererExists]
		[HttpPost]
		public async Task<IActionResult> Edit(int id, DelivererFormViewModel model)
		{

			await delivererService.EditDelivererAsync(id, model);
			return RedirectToAction(nameof(All));

		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[DelivererExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				DelivererDeleteViewModel model = await delivererService.GetDelivererToDeleteByIdAsync(id);
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

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[DelivererExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await delivererService.DeleteDelivererAsync(id);
			}
			catch (DeleteActionException dae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = dae.Message
				});
			}

			return RedirectToAction(nameof(All));

		}

	}
}

