namespace PrecastFactorySystem.Web.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Core.Contracts;

	public class ReinforceExistsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IReinforceService? reinforceService =
				context.HttpContext.RequestServices.GetService<IReinforceService>();

			if (reinforceService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (reinforceService != null
				&& !reinforceService.IsReinforceExist((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}

}
