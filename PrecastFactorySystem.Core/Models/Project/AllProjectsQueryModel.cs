namespace PrecastFactorySystem.Core.Models.Project
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Enumeration;

	public class AllProjectsQueryModel
	{
		public const int ProjectsPerPage = 4;

		public int CurrentPage { get; init; } = 1;

		public string? SearchTerm { get; set; } = string.Empty;

		public ProjectSorting Sorting { get; init; }

		public int TotalProjects { get; set; }


		public IEnumerable<ProjectInfoViewModel> Projects { get; set; } = Array.Empty<ProjectInfoViewModel>();
	}
}
