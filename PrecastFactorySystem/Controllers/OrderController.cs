namespace PrecastFactorySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Web.Attributes;
	
	using static PrecastFactorySystem.Core.Constants.MessageConstants;

	public class OrderController : BaseController
	{
		private readonly IOrderService orderService;
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;
		private readonly IExportService exportService;
		private readonly IEmailService emailService;

		public OrderController(IOrderService _orderService,
			IPrecastService _precastService,
			IBaseServise _baseService,
			IExportService _exportService,
			IEmailService _emailService)
		{
			orderService = _orderService;
			precastService = _precastService;
			baseService = _baseService;
			exportService = _exportService;
			emailService = _emailService;
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllOrdersQueryModel model)
		{
			var orders = await orderService.GetReinforceOrdersAsync(
				model.SearchTerm,
				model.ProjectId,
				model.DepartmentId,
				model.FromDate,
				model.ToDate,
				model.CurrentPage,
				AllOrdersQueryModel.OrdersPerPage);

			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.Departments = await baseService.GetBaseEntityDataAsync<Department>();
			model.Orders = orders.Orders;
			model.TotalOrders = orders.TotalOrders;

			return View(model);
		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[HttpGet]
		[PrecastExists]
		public async Task<IActionResult> Order(int id)
		{
			try
			{
				OrderPrecastReinforceViewModel model = await orderService.GetOrderPrecastReinforceViewModel(id);
				return View(model);
			}
			catch (OrderActionException oae)
			{
				return View("BaseError", new BaseErrorViewModel()
				{
					Message = oae.Message
				});
			}

		}

		[Authorize(Roles = "Administrator, ReinforceManager")]
		[HttpPost]
		[PrecastExists]
		public async Task<IActionResult> Order(int id, OrderPrecastReinforceViewModel model)
		{
			try
			{
				int maxCountToBeOrdered = await orderService.GetPrecastToReinforceCountAsync(id);

				if (model.OrderedCount > maxCountToBeOrdered)
				{
					ModelState.AddModelError(nameof(model.OrderedCount),
						string.Format(InvalidOrderCountErrorMessage, maxCountToBeOrdered));
				}

				if (!ModelState.IsValid)
				{
					model.Deliverers = await baseService.GetBaseEntityDataAsync<Deliverer>();
					model.Departments = await baseService.GetBaseEntityDataAsync<Department>();
					return View(model);
				}

				var orderModel = await orderService.OrderPrecastAsync(id, model);

				byte[] bytes = exportService.ExportOrderToPdf(orderModel);

				var fileName = $"Order {orderModel.OrderNum} - {orderModel.Precast}  {orderModel.Project}";

				var IsSuccess = await emailService.SendOrderEmailAsync(orderModel.DelivererEmail, fileName, bytes);

				if (IsSuccess)
				{
					await orderService.SaveOrderAsync(orderModel);
					TempData["Message"] = "You have successfully ordered precast!";
				}
				else
				{
					TempData["Message"] = "Something went wrong, and the order was not created!";
				}

				return RedirectToAction("Reinforce", "Precast", new { id });
			}
			catch (OrderActionException oae)
			{

				return View("BaseError", new BaseErrorViewModel()
				{
					Message = oae.Message
				});
			}



		}


		[Authorize(Roles = "Administrator, ReinforceManager")]
		[HttpGet]
		[OrderExists]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				DeleteOrderViewModel model = await orderService.CheckOrderToDeleteByIdAsync(id);
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
		[HttpPost]
		[OrderExists]
		public async Task<IActionResult> DeleteConfirmed(int id,string delivererEmail)
		{
			try
			{
				var IsSuccess = await emailService.SendCancelOrderEmailAsync(delivererEmail, $"Order N:  {id}");
				if (IsSuccess)
				{
					TempData["Message"] = "You have successfully deleted order!";
					await orderService.DeleteOrderAsync(id);
				}
				else
				{
					TempData["Message"] = "Something went wrong, and the order was not deleted!";
				}

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
		[HttpGet]
		[PrecastExists]
		public async Task<IActionResult> ForPrecast(int id, [FromQuery] AllPrecastOrdersQueryModel model)
		{
			var orders = await orderService.GetReinforceOrdersByPrecastAsync(
				id,
				model.CurrentPage,
				AllPrecastOrdersQueryModel.OrdersPerPage);

			model.Orders = orders.Orders;
			model.TotalOrders = orders.TotalOrders;

			ViewBag.PrecastId = id;
			return View(model);
		}
	}
}
