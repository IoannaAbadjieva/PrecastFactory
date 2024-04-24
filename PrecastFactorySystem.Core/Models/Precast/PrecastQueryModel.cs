namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	public class PrecastQueryModel
	{
		public int TotalPrecast { get; set; }

		public IEnumerable<PrecastInfoViewModel> Precast { get; set; } = Array.Empty<PrecastInfoViewModel>();
	}
}
