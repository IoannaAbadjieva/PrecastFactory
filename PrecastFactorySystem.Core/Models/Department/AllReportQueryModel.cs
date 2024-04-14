namespace PrecastFactorySystem.Core.Models.Department
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Base;

	public class AllReportQueryModel
	{
		public const int PrecastPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public DateTime? Month { get; set; }


		public int? ProjectId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Projects { get; set; } = Array.Empty<BaseSelectorViewModel>();

		public int? DepartmentId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Departments { get; set; } = Array.Empty<BaseSelectorViewModel>();
				
		public int TotalPrecast { get; set; }

		public decimal TotalReinforceWeight { get; set; }

		public decimal TotalConcreteAmount { get; set; }

		public IEnumerable<ReportInfoViewModel> Precast { get; set; } = Array.Empty<ReportInfoViewModel>();
	}
}
