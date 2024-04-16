namespace PrecastFactorySystem.Core.ValidationAttributes
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Models.Order;

	public class DeliverDateValidationAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value , ValidationContext validationContext )
		{
			var model = (OrderPrecastReinforceViewModel)validationContext.ObjectInstance;

			if (model.DeliverDate.Date < DateTime.Now.Date)
			{
				return new ValidationResult("Deliver date cannot be in the past.");
			}

			return ValidationResult.Success;
		}
	}
}
