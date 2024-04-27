namespace PrecastFactorySystem.Core.ValidationAttributes
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Project;

	public class ProjectProductionNumberValidationAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var model = (ProjectFormViewModel)validationContext.ObjectInstance;

			var projectService = (IProjectService?)validationContext.GetService(typeof(IProjectService));

			if (projectService?.IsProjectProductionNumberExist(model.ProdNumber).Result == true)
			{
				return new ValidationResult("Project production number already exists.");
			}

			return ValidationResult.Success;
		}
	}
}
