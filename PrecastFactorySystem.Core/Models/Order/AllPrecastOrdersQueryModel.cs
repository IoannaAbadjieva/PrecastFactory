namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	public class AllPrecastOrdersQueryModel
	{
		public const int OrdersPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public int TotalOrders { get; set; }

		public IEnumerable<ReinforceOrderInfoViewModel> Orders { get; set; } = Array.Empty<ReinforceOrderInfoViewModel>();
	}
}
