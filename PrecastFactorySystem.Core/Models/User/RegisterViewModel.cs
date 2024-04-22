namespace PrecastFactorySystem.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;
	using static PrecastFactorySystem.Infrastructure.DataValidation.ErrorMessages;

	public class RegisterViewModel : UserFormViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
		public string Password { get; set; } = string.Empty;

		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = string.Empty;
	}

}
