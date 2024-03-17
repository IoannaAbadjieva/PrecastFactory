namespace PrecastFactorySystem.Core.Models.Precast
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants;

    public class PrecastFormViewModel
	{

		[Required]
		[StringLength(PrecastNameMaxLength, MinimumLength = PrecastNameMinLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int PrecastTypeId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Types = new BaseSelectorViewModel[] { };

		[Required]
		public int Count { get; set; }


		[Required]
		public int ProjectId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Projects = new BaseSelectorViewModel[] { };

		[Required]
		public int ConcreteClassId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Concrete = new BaseSelectorViewModel[] { };

		[Required]
		public decimal ConcreteProjectAmount { get; set; }


		[Required]
		public decimal ReinforceProjectAmount {  get; set; }
	}
}
