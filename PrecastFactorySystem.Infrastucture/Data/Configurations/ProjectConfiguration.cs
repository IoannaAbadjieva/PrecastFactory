namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System;
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder
				.HasData(SeedProjects());
		}

		private IEnumerable<Project> SeedProjects()
		{
			return new Project[]
			{
					new Project()
				{
					Id = 1,
					Name = "Yung Solent",
					ProdNumber = "24-101",
					AddedOn = DateTime.Now.AddDays(-10),
				},
				new Project()
				{
					Id = 2,
					Name = "Argus",
					ProdNumber = "24-102",
					AddedOn = DateTime.Now.AddDays(-7),
				},
			
				new Project()
				{
					Id = 3,
					Name = "DM",
					ProdNumber = "24-103",
					AddedOn = DateTime.Now.AddDays(-4),
				},
				new Project()
				{
					Id = 4,
					Name = "Delita",
					ProdNumber = "24-104",
					AddedOn = DateTime.Now,
				},

			};
		}
	}

}
