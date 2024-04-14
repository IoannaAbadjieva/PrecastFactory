namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Attributes;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Department;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class DepartmentController : BaseController
	{
		private readonly IDepartmentService departmentService;
		private readonly IBaseServise baseService;

		public DepartmentController(IDepartmentService _departmentService,
			IBaseServise _baseService)
		{
			departmentService = _departmentService;
			baseService = _baseService;
		}
		public async Task<IActionResult> All([FromQuery] AllProductionQueryModel model)
		{
			var precast = await departmentService.GetProductionAsync(
				model.ProjectId,
				model.PrecastTypeId,
				model.DepartmentId,
				model.FromDate,
				model.ToDate,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				AllProductionQueryModel.PrecastPerPage);

			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.PrecastTypes = await baseService.GetBaseEntityDataAsync<PrecastType>();
			model.Departments = await baseService.GetBaseEntityDataAsync<Department>();
			model.Precast = precast.Precast;
			model.TotalPrecast = precast.TotalProduced;


			return View(model);
		}

		public async Task<IActionResult> Daily()
		{
			IEnumerable<ProductionInfoViewModel> model = await departmentService.GetDailyProductionAsync();
			return View(model);
		}

		public async Task<IActionResult> Monthly([FromQuery] AllReportQueryModel model)
		{
			var precast = await departmentService.GetMonthlyProductionAsync(
				model.Month,
				model.ProjectId,
				model.DepartmentId,
				model.CurrentPage,
				AllReportQueryModel.PrecastPerPage);

			model.Precast = precast.Precast;
			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.Departments = await baseService.GetBaseEntityDataAsync<Department>();

			return View(model);
		}

		[PrecastExist]
		public async Task<IActionResult> Details(int id)
		{
			IEnumerable<ProductionDetailsViewModel> model = await departmentService.GetPrecastProductionDetailsAsync(id);
			return View(model);
		}
	}
}
