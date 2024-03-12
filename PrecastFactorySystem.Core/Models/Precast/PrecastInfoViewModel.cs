namespace PrecastFactorySystem.Core.Models.Precast
{
	public class PrecastInfoViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string PrecastType { get; set; } = string.Empty;

		public int Count { get; set; }

		public string Project { get; set; } = string.Empty;

		public int Reinforced { get; set; }

		public int Produced { get; set; }

	}
}
