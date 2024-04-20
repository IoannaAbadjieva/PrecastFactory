namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System;
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class DepartmentPrecastConfiguration:IEntityTypeConfiguration<PrecastDepartment>
	{
		public void Configure(EntityTypeBuilder<PrecastDepartment> builder)
		{
			builder
				.HasData(SeedDepartmentPrecast());
		}

		private IEnumerable<PrecastDepartment>SeedDepartmentPrecast()
		{
			return new PrecastDepartment[]
			{
				new PrecastDepartment
				{
					Id = 1,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-6),
				},
				new PrecastDepartment
				{
					Id = 2,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-6),
				},
				new PrecastDepartment
				{
					Id = 3,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-6),
				},
				new PrecastDepartment
				{
					Id = 4,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-5),
				},
				new PrecastDepartment
				{
					Id = 5,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-5),
				},
				new PrecastDepartment
				{
					Id = 6,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-5),
				},
				new PrecastDepartment
				{
					Id = 7,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-5),
				},
				new PrecastDepartment
				{
					Id = 8,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-4),
				},
				new PrecastDepartment
				{
					Id = 9,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-4),
				},
				new PrecastDepartment
				{
					Id = 10,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-4),
				},
				new PrecastDepartment
				{
					Id = 11,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-4),
				},
				new PrecastDepartment
				{
					Id = 12,
					PrecastId = 10,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-4),
				},
				new PrecastDepartment
				{
					Id = 13,
					PrecastId = 7,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 14,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 15,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 16,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 17,
					PrecastId = 10,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 18,
					PrecastId = 13,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 19,
					PrecastId = 14,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-3),
				},
				new PrecastDepartment
				{
					Id = 20,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 21,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 22,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 23,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 24,
					PrecastId = 10,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 25,
					PrecastId = 13,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 26,
					PrecastId = 14,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-2),
				},
				new PrecastDepartment
				{
					Id = 27,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 28,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 29,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 30,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 31,
					PrecastId = 10,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 32,
					PrecastId = 12,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 33,
					PrecastId = 13,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 34,
					PrecastId = 14,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now.AddDays(-1),
				},
				new PrecastDepartment
				{
					Id = 35,
					PrecastId = 7,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 36,
					PrecastId = 8,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 37,
					PrecastId = 1,
					DepartmentId = 1,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 38,
					PrecastId = 5,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 39,
					PrecastId = 10,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 40,
					PrecastId = 12,
					DepartmentId = 2,
					Count = 1,
					Date = DateTime.Now,
				},
				new PrecastDepartment
				{
					Id = 41,
					PrecastId = 13,
					DepartmentId = 3,
					Count = 1,
					Date = DateTime.Now,
				}
			};
		}
	}
	
}
