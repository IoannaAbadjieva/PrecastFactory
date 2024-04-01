﻿namespace PrecastFactorySystem.Core.Models.Deliverer
{
	public class DelivererInfoViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public int OrdersCount { get; set; }

	}
}
