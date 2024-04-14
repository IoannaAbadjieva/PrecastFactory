namespace PrecastFactorySystem.Core.Models.Deliverer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class AllDeliverersQueryModel
	{
		public const int DeliverersPerPage = 4;

		public int CurrentPage { get; set; } = 1;

		public string? SearchTerm { get; set; }
		public int TotalDeliverers { get; set; }

		public IEnumerable<DelivererInfoViewModel> Deliverers { get; set; } = Array.Empty<DelivererInfoViewModel>();
	}
}
