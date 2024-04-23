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

			IProduceService? produceService =
				context.HttpContext.RequestServices.GetService<IProduceService>();

			if (produceService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}



			if (produceService != null
				&& !produceService.IsProductionRecordExist((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
