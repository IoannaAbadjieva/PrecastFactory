namespace PrecastFactorySystem.Core.Models.Project
{
	using System.ComponentModel.DataAnnotations;

	using static Infrastructure.DataValidation.DataConstants;
	using static Infrastructure.DataValidation.ErrorMessages;

	public class ProjectFormViewModel
	{
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(ProjectNumberMaxLength, MinimumLength = ProjectNumberMinLength, 
			ErrorMessage = StringLengthErrorMessage)]
		public string ProdNumber { get; set; } = string.Empty;

		public string AddedOn { get; set; } = string.Empty;
	}
}