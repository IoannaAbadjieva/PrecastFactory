namespace PrecastFactorySystem.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Models.Project;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class PrecastController : AdminBaseController
	{
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;

		public PrecastController(IPrecastService _precastService,
						IBaseServise _baseService)
		{
			precastService = _precastService;
			baseService = _baseService;
		}
		public async Task<IActionResult> All([FromQuery] AllPrecastQueryModel model)
		{
			var precasts = await precastService.GetAllPrecastAsync(
				model.SearchTerm,
				model.ProjectId,
				model.PrecastTypeId,
			model.Sorting,
			model.CurrentPage,
				AllPrecastQueryModel.PrecastsPerPage);

			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.PrecastTypes = await baseService.GetBaseEntityDataAsync<PrecastType>();
			model.Precast = precasts.Precast;
			model.TotalPrecast = precasts.TotalPrecast;

			return View(model);
		}


		[PrecastExists]
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = await baseService.GetEntityBaseInfoAsync<Precast>(id);
			return View(model);
		}

		[PrecastExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await baseService.DeleteEntityAsync<Precast>(id);
			TempData["Message"] = "You have successfully deleted precast!";
			return RedirectToAction(nameof(All));
		}
	}
}
