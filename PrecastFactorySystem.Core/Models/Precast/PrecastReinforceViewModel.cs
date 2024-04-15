namespace PrecastFactorySystem.Core.Models.Precast
{
	using System.Collections.Generic;

	using Reinforce;

	public class PrecastReinforceViewModel : PrecastInfoViewModel
	{
		public IEnumerable<ReinforceInfoViewModel> Reinforce = Array.Empty<ReinforceInfoViewModel>();
	}
}
