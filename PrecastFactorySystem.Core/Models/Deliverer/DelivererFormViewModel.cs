namespace PrecastFactorySystem.Core.Models.Deliverer
{
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.DataValidation.DataConstants;
    using static Infrastructure.DataValidation.ErrorMessages;
 
    public class DelivererFormViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(DelivererNameMaxLength,
			MinimumLength = DelivererNameMinLength,
			ErrorMessage = StringLengthErrorMessage)]

		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredErrorMessage)]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
	}
}
