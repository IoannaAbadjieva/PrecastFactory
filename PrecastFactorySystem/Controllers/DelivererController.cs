﻿namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Attributes;
	using Core.Contracts;
	using Core.Exceptions;
	using Core.Models;
	using Core.Models.Deliverer;
	using PrecastFactorySystem.Core.Models.Project;

	public class DelivererController : BaseController
	{
		private readonly IDelivererService delivererService;

		public DelivererController(IDelivererService _delivererService)
		{
			delivererService = _delivererService;
		}
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

		public IActionResult Add()
		{
			DelivererFormViewModel model = new DelivererFormViewModel();

			return View(model);
		}

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

		[DelivererExist]
		public async Task<IActionResult> Edit(int id)
		{

			DelivererFormViewModel model = await delivererService.GetDelivererByIdAsync(id);
			return View(model);

		}

		[HttpPost]
		[DelivererExist]
		public async Task<IActionResult> Edit(int id, DelivererFormViewModel model)
		{

			await delivererService.EditDelivererAsync(id, model);
			return RedirectToAction(nameof(All));

		}

		[DelivererExist]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				DelivererDeleteViewModel model = await delivererService.GetDelivererToDeleteByIdAsync(id);
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
		[DelivererExist]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await delivererService.DeleteDelivererAsync(id);
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

	}
}

