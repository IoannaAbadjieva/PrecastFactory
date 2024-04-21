namespace PrecastFactorySystem.Core.Models.Department
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Base;

	public class AllReportQueryModel
	{
		public const int PrecastPerPage = 4;

		public int CurrentPage { get; set; } = 1;

		public DateTime? Month { get; set; }


		public int? ProjectId { get; set; }

		public IEnumerable<BaseInfoViewModel> Projects { get; set; } = Array.Empty<BaseInfoViewModel>();

		public int? DepartmentId { get; set; }

		public IEnumerable<BaseInfoViewModel> Departments { get; set; } = Array.Empty<BaseInfoViewModel>();
				
		public int TotalPrecast { get; set; }

		public decimal TotalReinforceWeight { get; set; }

		public decimal TotalConcreteAmount { get; set; }

		public IEnumerable<ReportInfoViewModel> Precast { get; set; } = Array.Empty<ReportInfoViewModel>();
	}
}
