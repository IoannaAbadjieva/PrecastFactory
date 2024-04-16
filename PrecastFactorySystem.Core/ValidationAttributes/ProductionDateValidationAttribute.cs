namespace PrecastFactorySystem.Core.ValidationAttributes
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Precast;

	public class ProductionDateValidationAttribute : ValidationAttribute
	{
		protected override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
		
			var model = (PrecastProductionFormViewModel)validationContext.ObjectInstance;

			var precastService = (IPrecastService?)validationContext.GetService(typeof(IPrecastService));

			var firstOrderDeliveryDate =  precastService?.GetFirstOrderDeliveryDate(model.PrecastId);
			if (model.Date.Date < firstOrderDeliveryDate?.Result.Date)
			{
				return new ValidationResult("Production date cannot be before the first order delivery date.");
			}

			return ValidationResult.Success;
		}

	}
}
