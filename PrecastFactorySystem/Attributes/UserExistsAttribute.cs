namespace PrecastFactorySystem.Attributes
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	public class UserExistsAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			UserManager<ApplicationUser>? userManager =
				context.HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();

			if (userManager == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (userManager != null
								&& userManager.FindByIdAsync((string)(context.ActionArguments["id"] ?? string.Empty)).Result == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
