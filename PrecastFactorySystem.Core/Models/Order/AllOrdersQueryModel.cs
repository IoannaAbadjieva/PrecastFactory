namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Base;

	public class AllOrdersQueryModel
	{
		public const int OrdersPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }

		public int? ProjectId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Projects { get; set; } = Array.Empty<BaseSelectorViewModel>();

		public int? DepartmentId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Departments { get; set; } = Array.Empty<BaseSelectorViewModel>();

		public string? SearchTerm { get; set; } = string.Empty;

		public int TotalOrders { get; set; }

		public IEnumerable<ReinforceOrderInfoViewModel> Orders { get; set; } = Array.Empty<ReinforceOrderInfoViewModel>();
	}
}
