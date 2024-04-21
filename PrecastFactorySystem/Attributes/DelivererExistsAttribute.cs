namespace PrecastFactorySystem.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Core.Contracts;

	public class DelivererExistsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IDelivererService? delivererService =
				context.HttpContext.RequestServices.GetService<IDelivererService>();

			if (delivererService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}



			if (delivererService != null
				&& !delivererService.IsDelivererExistAsync((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
