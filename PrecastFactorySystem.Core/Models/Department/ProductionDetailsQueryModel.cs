namespace PrecastFactorySystem.Core.Models.Department
{
	using System;
	using System.Collections.Generic;

	public class ProductionDetailsQueryModel
	{
		public string ProjectName { get; set; } = string.Empty;

		public string PrecastType { get; set; } = string.Empty;


		public int PrecastId { get; set; }

		public string PrecastName { get; set; } = string.Empty;

		public int TotalRecords { get; set; }

		public IEnumerable<ProductionDetailsViewModel> Produced { get; set; } = Array.Empty<ProductionDetailsViewModel>();
	}
}
