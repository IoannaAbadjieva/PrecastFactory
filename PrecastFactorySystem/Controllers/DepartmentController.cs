namespace PrecastFactorySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using iText.Html2pdf;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Core.Models.Department;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Web.Attributes;

	using static PrecastFactorySystem.Core.Constants.MessageConstants;

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
			model.Departments = await baseService.GetBaseEntityDataAsync<Department>
				(d => d.DepartmentType == DepartmentType.PrecastProduction); ;
			model.Precast = precast.Precast;
			model.TotalPrecast = precast.TotalProduced;


			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Daily()
		{
			IEnumerable<ProductionInfoViewModel> model = await departmentService.GetDailyProductionAsync();
			return View(model);
		}

		[Authorize(Roles = "Administrator,Manager,ReinforceManager,PrecastProductionManager")]
		[HttpGet]
		public async Task<IActionResult> Monthly([FromQuery] AllReportQueryModel model)
		{
			var precast = await departmentService.GetMonthlyProductionAsync(
				model.Month,
				model.ProjectId,
				model.DepartmentId);

			model.Precast = precast.Precast;
			model.Projects = await baseService.GetBaseEntityDataAsync<Project>();
			model.Departments = await baseService.GetBaseEntityDataAsync<Department>
								(d => d.DepartmentType == DepartmentType.PrecastProduction);
			model.TotalPrecast = precast.TotalPrecast;
			model.TotalReinforceWeight = precast.TotalReinforceWeight;
			model.TotalConcreteAmount = precast.TotalConcreteAmount;

			return View(model);
		}

		
		[PrecastExists]
		[HttpGet]

		public async Task<IActionResult> Details(int id, [FromQuery] AllProductionDetailsQueryModel model)
		{
			ProductionDetailsQueryModel precast = await departmentService.GetPrecastProductionDetailsAsync(
				id,
				model.CurrentPage,
				AllProductionDetailsQueryModel.RecordsPerPage);

			model.ProjectName = precast.ProjectName;
			model.PrecastType = precast.PrecastType;
			model.PrecastId = id;
			model.PrecastName = precast.PrecastName;
			model.Precast = precast.Produced;
			model.TotalRecords = precast.TotalRecords;

			return View(model);
		}

		[Authorize(Roles = "Administrator, Manager")]
		[HttpPost]
		public IActionResult Download(string ReportHtml)
		{
			if (string.IsNullOrWhiteSpace(ReportHtml))
			{
				return View("BaseError", new BaseErrorViewModel()
				{
					Message = DownloadReportErrorMessage
				});
			}

			using MemoryStream stream = new MemoryStream();
			HtmlConverter.ConvertToPdf(ReportHtml, stream);
			return File(stream.ToArray(), "application/pdf", "Report.pdf");
		}


	}
}
