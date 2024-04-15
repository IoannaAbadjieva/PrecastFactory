namespace PrecastFactorySystem.Core.Models.Precast
{
	public class PrecastProductionViewModel
	{
		public int Id { get; set; }

		public int PrecastId { get; set; }

		public string Department { get; set; } = string.Empty;

		public int Count { get; set; }

		public string Date { get; set; } = string.Empty;
	}
}
