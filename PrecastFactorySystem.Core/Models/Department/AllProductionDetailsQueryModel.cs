namespace PrecastFactorySystem.Core.Models.Department
{
	using System;
	using System.Collections.Generic;

	public class AllProductionDetailsQueryModel
	{
		public const int RecordsPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public  int TotalRecords {get;set;}

		public string ProjectName { get; set; } = string.Empty;

		public string PrecastType { get; set; } = string.Empty;


		public int PrecastId { get; set; }

		public string PrecastName { get; set; } = string.Empty;

		public IEnumerable<ProductionDetailsViewModel> Precast { get; set; } = Array.Empty<ProductionDetailsViewModel>();
	}
}
