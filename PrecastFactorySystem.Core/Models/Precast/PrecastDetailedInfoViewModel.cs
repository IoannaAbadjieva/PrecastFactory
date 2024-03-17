namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class PrecastDetailedInfoViewModel : PrecastInfoViewModel
	{
		public string ConcreteClass {  get; set; } = string.Empty;

		public decimal ConcreteProjectAmount {  get; set; }

		public decimal ReinforceProjectAmount { get; set; }

	}
}
