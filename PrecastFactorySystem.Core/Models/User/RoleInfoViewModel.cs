namespace PrecastFactorySystem.Core.Models.User
{
	using System;
	using System.Collections.Generic;

	public class RoleInfoViewModel
	{
		public string Id { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public IEnumerable<string> Users { get; set; } = Array.Empty<string>();
	}
}
