namespace PrecastFactorySystem.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Core.Contracts;

	public class ProductionRecordExistsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IPrecastService? precastService =
				context.HttpContext.RequestServices.GetService<IPrecastService>();

			if (precastService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}



			if (precastService != null
				&& !precastService.IsProductionRecordExist((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
