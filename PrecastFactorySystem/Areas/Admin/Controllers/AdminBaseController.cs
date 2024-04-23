namespace PrecastFactorySystem.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using static PrecastFactorySystem.Core.Constants.AdministratorConstants;

	[Area("Admin")]
	[Authorize(Roles = AdminRoleName)]
	public class AdminBaseController : Controller
	{
		
	}
}
