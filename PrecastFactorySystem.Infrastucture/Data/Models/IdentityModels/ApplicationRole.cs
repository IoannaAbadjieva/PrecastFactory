namespace PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels
{
	using System;

	using Microsoft.AspNetCore.Identity;

	public class ApplicationRole : IdentityRole<Guid>
	{
		public ApplicationRole() : base()
		{

		}

		public ApplicationRole(string name) : base(name)
		{

		}
	}
}
