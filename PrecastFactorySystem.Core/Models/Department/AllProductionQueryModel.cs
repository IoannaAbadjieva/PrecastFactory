namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Core.Models.Department;

	public class AllProductionQueryModel
	{
		public const int PrecastPerPage = 9;

		public int CurrentPage { get; set; } = 1;

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }

		public int? ProjectId { get; set; }

		public IEnumerable<BaseInfoViewModel> Projects { get; set; } = Array.Empty<BaseInfoViewModel>();

		public int? PrecastTypeId { get; set; }

		public IEnumerable<BaseInfoViewModel> PrecastTypes { get; set; } = Array.Empty<BaseInfoViewModel>();
		
		public int? DepartmentId { get; set; }

		public IEnumerable<BaseInfoViewModel> Departments { get; set; } = Array.Empty<BaseInfoViewModel>();

		public string? SearchTerm { get; set; } = string.Empty;

		public ProductionSorting Sorting { get; set; }


		public int TotalPrecast { get; set; }


		public IEnumerable<ProductionInfoViewModel> Precast { get; set; } = Array.Empty<ProductionInfoViewModel>();
	}
}
