namespace PrecastFactorySystem.Core.Models.Project;

public class ProjectInfoViewModel
{
	public int Id { get; set; }

	public string Name { get; set; } = string.Empty;

	public string ProdNumber { get; set; } = string.Empty;

	public string AddedOn { get; set; } = string.Empty;

	public int PrecastCount { get; set; }

	public int PrecastTotalCount { get; set; }
}