namespace PrecastFactorySystem.Core.Models.Order
{
	using System;

	public class DeleteOrderViewModel
	{
		public int Id { get; set; }

		public string Precast { get; set; } = string.Empty;

		public string Project { get; set; } = string.Empty;

		public int OrderedCount { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime DeliverDate { get; set; }

		public int DelivererId { get; set; }

		public string DelivererEmail { get; set; } = string.Empty;

		public int DepartmentId { get; set; }

		public string Department { get; set; } = string.Empty;

	}
}
