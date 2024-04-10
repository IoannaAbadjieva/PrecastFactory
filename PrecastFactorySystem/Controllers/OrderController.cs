namespace PrecastFactorySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using PrecastFactorySystem.Attributes;
    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Order;

    using static PrecastFactorySystem.Core.Constants.MessageConstants;

    public class OrderController : BaseController
	{
		private readonly IOrderService orderService;
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;

		public OrderController(IOrderService _orderService,
			IPrecastService _precastService,
			IBaseServise _baseService)
		{
			orderService = _orderService;
			precastService = _precastService;
			baseService = _baseService;
		}
		public async Task<IActionResult> All()
		{
			IEnumerable<ReinforceOrderInfoViewModel> model = await orderService.GetReinforceOrdersAsync();
			return View(model);
		}

		[PrecastExist]
		public async Task<IActionResult> Order(int id)
		{
			OrderPrecastReinforceViewModel model = await orderService.GetOrderPrecastReinforceViewModel(id);
			return View(model);
		}

		[HttpPost]
		[PrecastExist]
		public async Task<IActionResult> Order(int id, OrderPrecastReinforceViewModel model)
		{
			int maxCount = await precastService.GetPrecastToReinforceCountAsync(id);

			if (model.OrderedCount > maxCount)
			{
				ModelState.AddModelError(nameof(model.OrderedCount),
					string.Format(InvalidOrderCountErrorMessage, maxCount));
			}

			if (!ModelState.IsValid)
			{
				model.Deliverers = await baseService.GetDeliverersAsync();
				model.Departments = await baseService.GetDepartmentsAsync();
				return View(model);
			}

			await orderService.OrderPrecastAsync(id, model);
			return RedirectToAction("Reinforce", "Precast", new { id });
		}
	}
}
