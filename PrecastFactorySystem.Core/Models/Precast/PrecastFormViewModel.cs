﻿namespace PrecastFactorySystem.Core.Models.Precast
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Models.Base;

	using static Infrastructure.DataValidation.DataConstants;
	using static Infrastructure.DataValidation.ErrorMessages;

	public class PrecastFormViewModel
	{

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(PrecastNameMaxLength, MinimumLength = PrecastNameMinLength)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int PrecastTypeId { get; set; }

		public IEnumerable<BaseInfoViewModel> Types = Array.Empty<BaseInfoViewModel>();

		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range(PrecastCountMinValue, PrecastCountMaxValue, 
			ErrorMessage = NumberRangeErrorMessage)]
		public int Count { get; set; }


		[Required(ErrorMessage = RequiredErrorMessage)]
		public int ProjectId { get; set; }

		public IEnumerable<BaseInfoViewModel> Projects = Array.Empty<BaseInfoViewModel>();

		[Required(ErrorMessage = RequiredErrorMessage)]
		public int ConcreteClassId { get; set; }

		public IEnumerable<BaseInfoViewModel> Concrete = Array.Empty<BaseInfoViewModel>();

		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range(typeof(decimal), ConcreteAmountMinValue, ConcreteAmountMaxValue, 
			ErrorMessage = NumberRangeErrorMessage)]
		public decimal ConcreteProjectAmount { get; set; }
	
		
		[Range(typeof(decimal), ConcreteAmountMinValue, ConcreteAmountMaxValue, 
			ErrorMessage = NumberRangeErrorMessage)]
		public decimal ConcreteActualAmount { get; set; }


		[Required(ErrorMessage = RequiredErrorMessage)]
		[Range(typeof(decimal), ReinforceAmountMinValue, ReinforceAmountMaxValue,
			ErrorMessage = NumberRangeErrorMessage)]
		public decimal ReinforceProjectAmount { get; set; }
	}
}
