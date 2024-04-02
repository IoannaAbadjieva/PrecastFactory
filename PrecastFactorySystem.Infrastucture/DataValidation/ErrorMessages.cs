namespace PrecastFactorySystem.Infrastructure.DataValidation
{
	public class ErrorMessages
	{
		public const string RequiredErrorMessage = "The {0} is required";

		public const string StringLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

		public const string NumberRangeErrorMessage = "The {0} must be number between {2} and {1}.";

	}
}
