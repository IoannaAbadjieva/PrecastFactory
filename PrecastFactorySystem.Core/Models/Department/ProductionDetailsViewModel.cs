namespace PrecastFactorySystem.Core.Models.Department
{
	using System;

	public class ProductionDetailsViewModel
	{
		public string PrecastType { get; set; } = string.Empty;
	
		public string PrecastName { get; set; } = string.Empty;

		public int Count { get; set; }

		public string Department { get; set; } = string.Empty;

		public DateTime Date { get; set; }
	}
}
