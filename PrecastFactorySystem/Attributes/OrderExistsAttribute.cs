namespace PrecastFactorySystem.Web.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Core.Contracts;

	public class OrderExistsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IOrderService? orderService =
				context.HttpContext.RequestServices.GetService<IOrderService>();

			if (orderService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}



			if (orderService != null
				&& !orderService.IsOrderExistAsync((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
