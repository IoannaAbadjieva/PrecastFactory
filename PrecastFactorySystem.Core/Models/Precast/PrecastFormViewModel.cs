namespace PrecastFactorySystem.Core.Models.Precast
{
    using System.ComponentModel.DataAnnotations;
    using PrecastFactorySystem.Core.Models.Base;

    using static Constants.DataConstants;

    public class PrecastFormViewModel
	{

		[Required]
		[StringLength(PrecastNameMaxLength, MinimumLength = PrecastNameMinLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int PrecastTypeId { get; set; }

		public IEnumerable<PrecastTypeViewModel> Types = new PrecastTypeViewModel[] { };

		[Required]
		public int Count { get; set; }


		[Required]
		public int ProjectId { get; set; }

		public IEnumerable<ProjectViewModel> Projects = new ProjectViewModel[] { };
		[Required]
		public int ConcreteClassId { get; set; }

		public IEnumerable<ConcreteClassViewModel> Concrete = new ConcreteClassViewModel[] { };

		[Required]
		public decimal ConcreteProjectAmount { get; set; }


		[Required]
		public decimal ReinforceProjectAmount {  get; set; }
	}
}
