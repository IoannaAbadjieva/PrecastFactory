namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using iText.Layout;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Department;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class DepartmentService : IDepartmentService
	{
		private readonly IRepository repository;
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseServise;

		public DepartmentService(
			IRepository _repository,
			IPrecastService _precastService,
			IBaseServise _baseServise)
		{
			repository = _repository;
			precastService = _precastService;
			baseServise = _baseServise;
		}

		public async Task<IEnumerable<ProductionInfoViewModel>> GetDailyProductionAsync()
		{
			var precast = await repository.AllReadonly<PrecastDepartment>(dp => dp.Date.Date == DateTime.Today.Date)
				.Select(dp => new ProductionInfoViewModel
				{
					ProjectName = dp.Precast.Project.Name,
					PrecastTypeId = dp.Precast.PrecastTypeId,
					PrecastId = dp.PrecastId,
					PrecastName = dp.Precast.Name,
					Count = dp.Count,
					Department = dp.Department.Name,
				})
				.OrderBy(dp => dp.Department)
				.ThenBy(dp => dp.ProjectName)
				.ThenBy(dp => dp.PrecastTypeId)
				.ThenBy(dp => dp.PrecastName)
				.ToArrayAsync();

			return precast.GroupBy(dp => new { dp.ProjectName, dp.PrecastTypeId, dp.PrecastId, dp.PrecastName, dp.Department })
				.Select(dp => new ProductionInfoViewModel
				{
					ProjectName = dp.Key.ProjectName,
					PrecastTypeId = dp.Key.PrecastTypeId,
					PrecastId = dp.Key.PrecastId,
					PrecastName = dp.Key.PrecastName,
					Count = dp.Sum(p => p.Count),
					Department = dp.Key.Department
				}).ToArray();
		}

		public async Task<ReportQueryModel> GetMonthlyProductionAsync(
			DateTime? month,
			int? projectId,
			int? departmentId,
			int currentPage = 1,
			int precastPerPage = 6)
		{
			var query = repository.AllReadonly<PrecastDepartment>();

			if (month.HasValue)
			{
				query = query.Where(dp => dp.Date.Month == month.Value.Month && dp.Date.Year == month.Value.Year);
			}
			else
			{
				query = query.Where(dp => dp.Date.Month == DateTime.Today.Month && dp.Date.Year == DateTime.Today.Year);
			}

			if (projectId.HasValue)
			{
				query = query.Where(dp => dp.Precast.ProjectId == projectId);
			}

			if (departmentId.HasValue)
			{
				query = query.Where(dp => dp.DepartmentId == departmentId);
			}

			query = query.OrderBy(dp => dp.DepartmentId)
				.ThenBy(dp => dp.Precast.Project.Name)
			   .ThenBy(dp => dp.Precast.PrecastTypeId)
			   .ThenBy(dp => dp.Precast.Name);

			var precast = await query
				.Select(dp => new ReportInfoViewModel
				{
					ProjectName = dp.Precast.Project.Name,
					PrecastType = dp.Precast.PrecastType.Name,
					PrecastId = dp.PrecastId,
					PrecastName = dp.Precast.Name,
					Count = dp.Count,
					Department = dp.Department.Name,
					ReinforceWeight = dp.Precast.PrecastReinforceOrders.Average(pro => pro.ReinforceOrder.PrecastWeight),
					ConcreteAmount = dp.Precast.ConcreteActualAmount ?? dp.Precast.ConcreteProjectAmount
				})

				.ToArrayAsync();

			precast = precast.GroupBy(dp => new
			{
				dp.ProjectName,
				dp.PrecastType,
				dp.PrecastId,
				dp.PrecastName,
				dp.Department,
				dp.ConcreteAmount,
				dp.ReinforceWeight
			})
				.Select(dp => new ReportInfoViewModel
				{
					ProjectName = dp.Key.ProjectName,
					PrecastType = dp.Key.PrecastType,
					PrecastId = dp.Key.PrecastId,
					PrecastName = dp.Key.PrecastName,
					Count = dp.Sum(p => p.Count),
					Department = dp.Key.Department,
					ReinforceWeight = dp.Key.ReinforceWeight,
					Reinforcement = dp.Sum(p => p.ReinforceWeight * p.Count),
					ConcreteAmount = dp.Key.ConcreteAmount,
					Concrete = dp.Sum(p => p.ConcreteAmount * p.Count)
				}).ToArray();

			return new ReportQueryModel()
			{
				Precast = precast,
				TotalPrecast = precast.Count(),
			};

		}

		public async Task<ProductionDetailsQueryModel> GetPrecastProductionDetailsAsync(
		int id,
		int currentPage = 1,
		int recordsPerPage = 12)
		{
			var precast = await repository.AllReadonly<Precast>(p => p.Id == id)
				.Select(p => new
				{
					PrecastId = p.Id,
					PrecastName = p.Name,
					PrecastType = p.PrecastType.Name,
					ProjectName = p.Project.Name
				}).FirstAsync();

			var query = repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id);

			var totalRecords = query.Count();

			var precastProduction = await query
				.Skip((currentPage - 1) * recordsPerPage)
				.Take(recordsPerPage)
				.Select(dp => new ProductionDetailsViewModel
				{
					PrecastType = precast.PrecastType,
					PrecastName = precast.PrecastName,
					Date = dp.Date,
					Count = dp.Count,
					Department = dp.Department.Name
				}).ToArrayAsync();

			return new ProductionDetailsQueryModel()
			{
				ProjectName = precast.ProjectName,
				PrecastId = precast.PrecastId,
				PrecastName = precast.PrecastName,
				PrecastType = precast.PrecastType,
				TotalRecords = totalRecords,
				Precast = precastProduction
			};

		}



		public async Task<ProductionQueryModel> GetProductionAsync(int? projectId = null,
			int? precastTypeId = null,
			int? departmentId = null,
			DateTime? fromDate = null,
			DateTime? toDate = null,
			string? searchTerm = null,
			ProductionSorting sorting = ProductionSorting.ProjectName,
			int currentPage = 1, int
			precastPerPage = 12)
		{
			var query = repository.AllReadonly<PrecastDepartment>();


			if (projectId.HasValue)
			{
				query = query.Where(dp => dp.Precast.ProjectId == projectId);
			}

			if (precastTypeId.HasValue)
			{
				query = query.Where(dp => dp.Precast.PrecastTypeId == precastTypeId);
			}

			if (departmentId.HasValue)
			{
				query = query.Where(dp => dp.DepartmentId == departmentId);
			}

			if (fromDate.HasValue)
			{
				query = query.Where(dp => dp.Date >= fromDate.Value.Date);
			}

			if (toDate.HasValue)
			{
				query = query.Where(dp => dp.Date <= toDate.Value.Date);
			}

			var search = searchTerm?.ToLower();

			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(dp => dp.Precast.Name.ToLower().Contains(search)
										|| dp.Precast.Project.Name.ToLower().Contains(search)
										|| dp.Precast.PrecastType.Name.ToLower().Contains(search)
										|| dp.Department.Name.ToLower().Contains(search));
			}


			query = sorting switch
			{
				ProductionSorting.PrecastType => query.OrderBy(dp => dp.Precast.PrecastType.Name).ThenBy(dp => dp.Precast.Project.Name),
				_ => query.OrderBy(dp => dp.Precast.Project.Name).ThenBy(dp => dp.Precast.PrecastType.Name)
			};

			query = query.OrderByDescending(dp => dp.Precast.Name);

			var totalPrecast = query.Count();

			var precast = await query
				.Skip((currentPage - 1) * precastPerPage)
				.Take(precastPerPage)
				.Select(dp => new ProductionInfoViewModel
				{
					ProjectName = dp.Precast.Project.Name,
					PrecastType = dp.Precast.PrecastType.Name,
					PrecastId = dp.PrecastId,
					PrecastName = dp.Precast.Name,
					Count = dp.Count,
					Department = dp.Department.Name
				}).ToArrayAsync();

			precast = precast.GroupBy(dp => new
			{
				dp.ProjectName,
				dp.PrecastType,
				dp.PrecastId,
				dp.PrecastName,
				dp.Department
			})
				.Select(dp => new ProductionInfoViewModel
				{
					ProjectName = dp.Key.ProjectName,
					PrecastType = dp.Key.PrecastType,
					PrecastId = dp.Key.PrecastId,
					PrecastName = dp.Key.PrecastName,
					Count = dp.Sum(p => p.Count),
					Department = dp.Key.Department
				}).ToArray();

			return new ProductionQueryModel()
			{
				Precast = precast,
				TotalProduced = totalPrecast
			};
		}



	}
}
