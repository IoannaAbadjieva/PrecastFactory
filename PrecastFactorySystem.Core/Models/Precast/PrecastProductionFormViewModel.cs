namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Models.Base;

	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;
	using static PrecastFactorySystem.Infrastructure.DataValidation.ErrorMessages;

	public class PrecastProductionFormViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int PrecastId { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range(PrecastCountMinValue, PrecastCountMaxValue,
			ErrorMessage = NumberRangeErrorMessage)]
		public int ProducedCount { get; set; }


		[Required(ErrorMessage = RequiredErrorMessage)]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int DepartmentId { get; set; }

		public IEnumerable<BaseSelectorViewModel> Departments { get; set; } = Array.Empty<BaseSelectorViewModel>();


	}
}
