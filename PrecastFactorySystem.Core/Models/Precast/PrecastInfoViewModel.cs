namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Data.Models;

	public class PrecastInfoViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string PrecastType { get; set; } = string.Empty;

		public int Count { get; set; }

		public string Project { get; set; } = string.Empty;

		public string ConcreteClass { get; set; } = string.Empty;

		public decimal ConcreteProjectAmount { get; set; }

		public decimal ReinforceProjectWeight { get; set; }

	}
}
