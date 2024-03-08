namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class DepartmentController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
