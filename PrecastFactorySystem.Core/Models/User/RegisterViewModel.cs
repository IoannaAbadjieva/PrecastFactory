namespace PrecastFactorySystem.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	public class RegisterViewModel
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 5)]
		public string UserName { get; set; } = null!;

		[Required]
		[EmailAddress]
		[StringLength(60, MinimumLength = 10)]
		public string Email { get; set; } = null!;

		[Required]
		[StringLength(20, MinimumLength = 5)]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = null!;

		public string? Role { get; set; }

		public IEnumerable<ApplicationRole> roles { get; set; } = Array.Empty<ApplicationRole>();
	}
}
