namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;


		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Daily", "Department");
			}
			return View();
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400)
			{
				return View("NotFound");
			}

			if (statusCode == 401)
			{
				return View("UnAuthorized");
			}

			if (statusCode == 404)
			{
				return View("BadRequest");
			}

			return View();
		}
	}
}