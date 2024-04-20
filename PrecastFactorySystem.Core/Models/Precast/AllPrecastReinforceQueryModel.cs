namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Reinforce;

	public class AllPrecastReinforceQueryModel: PrecastInfoViewModel
	{
		public const int ReinforcePerPage = 7;

		public int CurrentPage { get; set; } = 1;

		public int TotalReinforce { get; set; }

		public IEnumerable<ReinforceInfoViewModel> Reinforce { get; set; } = Array.Empty<ReinforceInfoViewModel>();
	}
}
