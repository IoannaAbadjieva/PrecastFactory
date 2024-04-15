namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	public class PrecastProductionQueryModel : PrecastInfoViewModel
	{
		public int TotalPrecast { get; set; }

		public IEnumerable<PrecastProductionViewModel> Precast { get; set; } = Array.Empty<PrecastProductionViewModel>();
	}
}
