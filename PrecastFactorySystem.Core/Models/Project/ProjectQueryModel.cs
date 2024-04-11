namespace PrecastFactorySystem.Core.Models.Project
{
	using System;
	using System.Collections.Generic;

	public class ProjectQueryModel
	{
		public int TotalProjects { get; set; }

		public IEnumerable<ProjectInfoViewModel> Projects { get; set; } = Array.Empty<ProjectInfoViewModel>();
	}
}
