namespace PrecastFactorySystem.Core.ValidationAttributes
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Produce;

	public class ProductionDateValidationAttribute : ValidationAttribute
	{
		protected override  ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
		
			var model = (ProduceFormViewModel)validationContext.ObjectInstance;

			var produceService = (IProduceService?)validationContext.GetService(typeof(IProduceService));

			var firstOrderDeliveryDate = produceService?.GetFirstOrderDeliveryDate(model.PrecastId);
			if (model.Date.Date < firstOrderDeliveryDate?.Result.Date)
			{
				return new ValidationResult("Production date cannot be before the first order delivery date.");
			}

			return ValidationResult.Success;
		}

	}
}
