namespace PrecastFactorySystem.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;
	using static PrecastFactorySystem.Infrastructure.DataValidation.ErrorMessages;

	public class UserFormViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
		public string UserName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[EmailAddress]
		[StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
		public string Email { get; set; } = string.Empty;

		public string? Role { get; set; }

		public IEnumerable<ApplicationRole> Roles { get; set; } = Array.Empty<ApplicationRole>();
	}
}
