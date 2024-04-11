namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class OrdersQueryModel
	{
		public int TotalOrders { get; set; }

		public IEnumerable<ReinforceOrderInfoViewModel> Orders { get; set; } = Array.Empty<ReinforceOrderInfoViewModel>();
	}
}
