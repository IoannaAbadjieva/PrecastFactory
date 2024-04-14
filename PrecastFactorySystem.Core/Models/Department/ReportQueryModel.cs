namespace PrecastFactorySystem.Core.Models.Department
{
	using System;
	using System.Collections.Generic;

	public class ReportQueryModel
	{
		public int TotalPrecast { get; set; }

		public IEnumerable<ReportInfoViewModel> Precast { get; set; } = Array.Empty<ReportInfoViewModel>();
	}
}
