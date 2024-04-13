namespace PrecastFactorySystem.Core.Models.Department
{
	public class ProductionInfoViewModel
	{
		public string ProjectName { get; set; } = string.Empty;

        public int PrecastTypeId { get; set; }

        public string PrecastType { get; set; } = string.Empty;

        public int PrecastId { get; set; }

        public string PrecastName { get; set; } = string.Empty;

		public int Count { get; set; }

        public string Department { get; set; } = string.Empty;
	}
}
