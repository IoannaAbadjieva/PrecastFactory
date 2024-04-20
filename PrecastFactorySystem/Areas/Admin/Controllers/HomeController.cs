namespace PrecastFactorySystem.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : AdminBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
