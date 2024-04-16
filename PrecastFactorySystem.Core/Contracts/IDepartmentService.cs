namespace PrecastFactorySystem.Core.Contracts
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Department;
	using PrecastFactorySystem.Core.Models.Order;

	public interface IDepartmentService
	{
		Task<IEnumerable<ProductionInfoViewModel>> GetDailyProductionAsync();
		Task<ReportQueryModel> GetMonthlyProductionAsync(
			DateTime? month, 
			int? projectId, 
			int? departmentId,
			int currentPage = 1,
			int precastPerPage = 12);

		Task<ProductionDetailsQueryModel> GetPrecastProductionDetailsAsync(
			int id,
			int currentPage = 1,
			int recordsPerPage = 12);

		Task<ProductionQueryModel> GetProductionAsync(int? projectId = null,
			int? precastTypeId = null,
			int? departmentId = null,
			DateTime? fromDate = null,
			DateTime? toDate = null, 
			string? searchTerm = null, 
			ProductionSorting sorting = ProductionSorting.ProjectName,
			int currentPage = 1, 
			int precastPerPage = 12);
	}
}
