namespace PrecastFactorySystem.Core.Models.Reinforce
{
	public class ReinforceInfoViewModel
	{
        public int Id { get; set; }

        public int PrecastId { get; set; }

        public string Position { get; set; } = string.Empty;

		public int Count { get; set; }

		public string ReinforceType { get; set; } = string.Empty;

		public decimal SpecificMass { get; set; }

		public decimal Length { get; set; }

		public decimal Weight { get; set; }
	}
}
