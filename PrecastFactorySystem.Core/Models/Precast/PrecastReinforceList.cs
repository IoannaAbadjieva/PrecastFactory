namespace PrecastFactorySystem.Core.Models.Precast
{

	public class PrecastReinforceList : PrecastInfoViewModel

	{
		public decimal ProjectWeight { get; set; }

		public decimal? ActualWeight { get; set; }

		public int FirstPrecastOrderedAmount { get; set; }

		public int SecondPrecastOrderedAmount { get; set; }

		public int ThirdPrecastOrderedAmount { get; set; }
	}
}
