namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data.Common;

	public class PrecastController : BaseController
	{
		private readonly IPrecastService precastService;

		public PrecastController(IPrecastService _precastService)
		{
			precastService = _precastService;
		}
		public async Task<IActionResult> All()
		{
			IEnumerable<PrecastInfoViewModel> model = precastService.GetAllPrecastAsync();
			return View(model);
		}
	}
}
