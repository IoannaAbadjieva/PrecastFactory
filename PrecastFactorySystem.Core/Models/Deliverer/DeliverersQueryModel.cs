namespace PrecastFactorySystem.Core.Models.Deliverer
{
	using System;
	using System.Collections.Generic;

	public class DeliverersQueryModel
	{
		public const int DeliverersPerPage = 4;

		public int TotalDeliverers { get; set; }

		public IEnumerable<DelivererInfoViewModel> Deliverers { get; set; } = Array.Empty<DelivererInfoViewModel>();
	}
}
