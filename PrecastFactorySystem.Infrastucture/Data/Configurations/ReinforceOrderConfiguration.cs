namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System;
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class ReinforceOrderConfiguration : IEntityTypeConfiguration<ReinforceOrder>
	{
		public void Configure(EntityTypeBuilder<ReinforceOrder> builder)
		{
			builder
				.HasData(SeedRenforceOrders());
		}

		private IEnumerable<ReinforceOrder> SeedRenforceOrders()
		{
			return new ReinforceOrder[]
			{
				new ReinforceOrder
				{
					Id = 1,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-9),
					PrecastWeight = 362.34m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-7),
					DepartmentId = 4,
				},
				new ReinforceOrder
				{
					Id = 2,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-9),
					PrecastWeight = 375.35m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-7),
					DepartmentId = 4,
				},
				new ReinforceOrder
				{
					Id = 3,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-9),
					PrecastWeight = 1826.74m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-7),
					DepartmentId = 1,
				},
				new ReinforceOrder
				{
					Id = 4,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-9),
					PrecastWeight = 1575.52m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-6),
					DepartmentId = 1,
				},
				new ReinforceOrder
				{
					Id = 5,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-7),
					PrecastWeight = 1282.15m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-5),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 6,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-7),
					PrecastWeight = 1590.3m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-5),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 7,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-7),
					PrecastWeight = 261.51m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-4),
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 8,
					Count = 3,
					OrderDate = DateTime.Now.AddDays(-7),
					PrecastWeight = 258.45m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-4),
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 9,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-6),
					PrecastWeight = 1826.74m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-3),
					DepartmentId = 1,
				},
				new ReinforceOrder
				{
					Id = 10,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-6),
					PrecastWeight = 362.34m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-3),
					DepartmentId = 4,
				},
				new ReinforceOrder
				{
					Id = 11,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-6),
					PrecastWeight = 375.35m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-3),
					DepartmentId = 4,
				},
				new ReinforceOrder
				{
					Id = 12,
					Count = 2,
					OrderDate = DateTime.Now.AddDays(-5),
					PrecastWeight = 1575.52m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-2),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 13,
					Count = 2,
					OrderDate = DateTime.Now.AddDays(-5),
					PrecastWeight = 1703.67m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-2),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 14,
					Count = 3,
					OrderDate = DateTime.Now.AddDays(-5),
					PrecastWeight = 1282.15m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-2),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 15,
					Count = 6,
					OrderDate = DateTime.Now.AddDays(-4),
					PrecastWeight = 286.16m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-1),
					DepartmentId = 4,
				},
				new ReinforceOrder
				{
					Id = 16,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-4),
					PrecastWeight = 2386.87m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(-1),
					DepartmentId = 1,
				},
				new ReinforceOrder
				{
					Id = 17,
					Count = 3,
					OrderDate = DateTime.Now.AddDays(-3),
					PrecastWeight = 368.88m,
					DelivererId = 1,
					DeliverDate = DateTime.Now,
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 18,
					Count = 1,
					OrderDate = DateTime.Now.AddDays(-3),
					PrecastWeight = 368.31m,
					DelivererId = 1,
					DeliverDate = DateTime.Now,
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 19,
					Count = 1,
					OrderDate = DateTime.Now.AddDays(-3),
					PrecastWeight = 360.01m,
					DelivererId = 1,
					DeliverDate = DateTime.Now,
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 20,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-3),
					PrecastWeight = 1703.67m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(1),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 21,
					Count = 2,
					OrderDate = DateTime.Now.AddDays(-3),
					PrecastWeight = 1295.08m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(1),
					DepartmentId = 3,
				},
				new ReinforceOrder
				{
					Id = 22,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-2),
					PrecastWeight = 1244.27m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(2),
					DepartmentId = 2,
				},
				new ReinforceOrder
				{
					Id = 23,
					Count = 4,
					OrderDate = DateTime.Now.AddDays(-2),
					PrecastWeight = 1411.44m,
					DelivererId = 1,
					DeliverDate = DateTime.Now.AddDays(2),
					DepartmentId = 2,
				},
			};
		}
	}
}
