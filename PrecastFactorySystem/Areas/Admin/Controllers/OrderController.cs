namespace PrecastFactorySystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Web.Attributes;

	public class OrderController : AdminBaseController
	{

		private readonly IOrderService orderService;
		private readonly IBaseServise baseService;

        public OrderController(
			IOrderService _orderService, 
			IBaseServise _baseService)
        {
			orderService = _orderService;
            baseService = _baseService;
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

		[OrderExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = await orderService.GetOrderToDeleteByIdAsync(id);
			return View(model);
		}

		[OrderExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await orderService.DeleteAsync(id);
			TempData["Message"] = "You have successfully deleted order!";
			return RedirectToAction(nameof(All));
		}
	}
}
