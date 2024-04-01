namespace PrecastFactorySystem.Core.Models.Precast
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Models.Base;

	using static Infrastructure.DataValidation.DataConstants;

	public class PrecastFormViewModel
	{

		[Required]
		[StringLength(PrecastNameMaxLength, MinimumLength = PrecastNameMinLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int PrecastTypeId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Types = Array.Empty<BaseSelectorViewModel>();

		[Required]
		public int Count { get; set; }


		[Required]
		public int ProjectId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Projects = Array.Empty< BaseSelectorViewModel>();

		[Required]
		public int ConcreteClassId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Concrete = Array.Empty<BaseSelectorViewModel>();

		[Required]
		public decimal ConcreteProjectAmount { get; set; }


		[Required]
		public decimal ReinforceProjectAmount { get; set; }
	}
}
