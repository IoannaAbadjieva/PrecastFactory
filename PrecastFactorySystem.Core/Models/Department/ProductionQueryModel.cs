namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Department;

	public class ProductionQueryModel
	{
		public int TotalProduced { get; set; }

		public IEnumerable<ProductionInfoViewModel> Precast { get; set; } = Array.Empty<ProductionInfoViewModel>();
	}
}
