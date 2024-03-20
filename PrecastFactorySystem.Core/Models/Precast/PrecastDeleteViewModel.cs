namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class PrecastDeleteViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string AddedOn { get; set; } = string.Empty;

		public string Project { get; set; } = string.Empty;

		public string PrecastType { get; set; } = string.Empty;


	}
}
