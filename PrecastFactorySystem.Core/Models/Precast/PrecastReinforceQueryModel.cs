namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Reinforce;

	public class PrecastReinforceQueryModel: PrecastInfoViewModel
	{

		public int TotalReinforce { get; set; }

		public IEnumerable<ReinforceInfoViewModel> Reinforce { get; set; } = Array.Empty<ReinforceInfoViewModel>();
	}
}
