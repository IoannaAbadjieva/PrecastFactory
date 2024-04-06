namespace PrecastFactorySystem.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Core.Contracts;

	public class ProjectExistAttribute:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IProjectService? projectService =
				context.HttpContext.RequestServices.GetService<IProjectService>();

			if (projectService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (projectService != null
				&& !projectService.IsProjectExistAsync((int)(context.ActionArguments["id"] ?? 0)).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
	
}
