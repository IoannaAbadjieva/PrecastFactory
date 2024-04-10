namespace PrecastFactorySystem.Core.Models.Precast
{
	using System.Collections.Generic;

	using Reinforce;

	public class PrecastReinforceViewModel : PrecastInfoViewModel
	{
		public IEnumerable<ReinforceFullInfoViewModel> Reinforce = Array.Empty<ReinforceFullInfoViewModel>();
	}
}
