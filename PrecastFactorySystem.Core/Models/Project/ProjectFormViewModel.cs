namespace PrecastFactorySystem.Core.Models.Project;

using System.ComponentModel.DataAnnotations;

using static Constants.DataConstants;

public class ProjectFormViewModel
{
	[Required]
	[StringLength(ProjectNameMaxLength, MinimumLength = ProjectNameMinLength)]
	public string Name { get; set; } = string.Empty;

	[Required]
	[StringLength(ProjectNumberMaxLength, MinimumLength = ProjectNumberMinLength)]
	public string ProdNumber { get; set; } = string.Empty;

	public string AddedOn { get; set; } = string.Empty;
}