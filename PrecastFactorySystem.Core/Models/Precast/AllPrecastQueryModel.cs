namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Models.Base;

	public class AllPrecastQueryModel
	{
		public const int PrecastsPerPage = 12;

		public int CurrentPage { get; set; } = 1;

		public  int? ProjectId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Projects { get; set; } = Array.Empty<BaseSelectorViewModel>();

		public int? PrecastTypeId { get; set; }

		public IEnumerable<BaseSelectorViewModel> PrecastTypes { get; set; } = Array.Empty<BaseSelectorViewModel>();

		public string? SearchTerm { get; set; } = string.Empty;

		public PrecastSorting Sorting { get; set; }

		public int TotalPrecast { get; set; }

		public IEnumerable<PrecastInfoViewModel> Precast { get; set; } = Array.Empty<PrecastInfoViewModel>();
	}
}
