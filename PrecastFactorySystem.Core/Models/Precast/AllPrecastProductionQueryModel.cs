namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	public class AllPrecastProductionQueryModel : PrecastInfoViewModel
	{
		public const int PrecastPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public int TotalPrecast { get; set; }

		public IEnumerable<PrecastProductionViewModel> Precast { get; set; } = Array.Empty<PrecastProductionViewModel>();
	}
}
