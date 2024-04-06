namespace PrecastFactorySystem.Core.Models.Reinforce
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Models.Base;

	using static Infrastructure.DataValidation.DataConstants;
	using static Infrastructure.DataValidation.ErrorMessages;

	public class ReinforceFormViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
        public int PrecastId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(ReinforcePositionMaxLength, MinimumLength = ReinforcePositionMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		public string Position { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range( ReinforceCountMinValue, ReinforceCountMaxValue,
						ErrorMessage = NumberRangeErrorMessage)]
		public int Count { get; set; }

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int ReinforceTypeId { get; set; }

		public IEnumerable<BaseSelectorViewModel> ReinforceTypes { get; set; } = Array.Empty<BaseSelectorViewModel>();


		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range(typeof(decimal), ReinforceLengthMinValue, ReinforceLengthMaxValue,
						ErrorMessage = NumberRangeErrorMessage)]
		public decimal Length { get; set; }
	}
}
