namespace PrecastFactorySystem.Core.Models.Precast
{
	using System;
	using System.Collections.Generic;

	public class PrecastProductionViewModel: PrecastInfoViewModel
	{
		public IEnumerable<PrecastByDepartmentsViewModel> ByDepartments { get; set; } = Array.Empty<PrecastByDepartmentsViewModel>();
	}
}
