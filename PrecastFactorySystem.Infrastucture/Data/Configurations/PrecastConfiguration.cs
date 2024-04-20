namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using System;
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class PrecastConfiguration : IEntityTypeConfiguration<Precast>
	{
		public void Configure(EntityTypeBuilder<Precast> builder)
		{
			builder
				.HasData(SeedPrecast());
		}
		private IEnumerable<Precast> SeedPrecast()
		{
			return new Precast[]
			{

				new Precast()
				{
					Id = 1,
					Name = "K тип 4",
					PrecastTypeId = 2,
					Count = 10,
					AddedOn = DateTime.Now.AddDays(-14),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.32m,
					ConcreteActualAmount = 7.22m,
					ReinforceProjectWeight = 1900m				
				},
				new Precast()
				{
					Id = 2,
					Name = "K тип 6",
					PrecastTypeId = 2,
					Count = 8,
					AddedOn = DateTime.Now.AddDays(-14),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 9.32m,
					ConcreteActualAmount = 9.16m,
					ReinforceProjectWeight = 2412m
				},
				new Precast()
				{
					Id = 3,
					Name = "K тип 5",
					PrecastTypeId = 2,
					Count = 6,
					AddedOn = DateTime.Now.AddDays(-14),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.11m,
					ConcreteActualAmount = 6.98m,
					ReinforceProjectWeight = 1650
				},
				new Precast()
				{
					Id = 4,
					Name = "K тип 3",
					PrecastTypeId = 2,
					Count = 2,
					AddedOn = DateTime.Now.AddDays(-14),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 5.32m,
					ConcreteActualAmount = 5.16m,
					ReinforceProjectWeight = 1495m
				},
				new Precast()
				{
					Id = 5,
					Name = "K тип 1",
					PrecastTypeId = 2,
					Count = 6,
					AddedOn = DateTime.Now.AddDays(-10),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.22m,
					ConcreteActualAmount = 7.22m,
					ReinforceProjectWeight = 1560m
				},
				new Precast()
				{
					Id = 6,
					Name = "K тип 2",
					PrecastTypeId = 2,
					Count = 6,
					AddedOn = DateTime.Now.AddDays(-10),
					ProjectId = 1,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.22m,
					ConcreteActualAmount = 7.22m,
					ReinforceProjectWeight = 1710m
				},

				new Precast()
				{
					Id = 7,
					Name = "СЧ 1",
					PrecastTypeId = 1,
					Count = 24,
					AddedOn = DateTime.Now.AddDays(-10),
					ProjectId = 1,
					ConcreteClassId = 9,
					ConcreteProjectAmount = 1.61m,
					ConcreteActualAmount = 1.61m,
					ReinforceProjectWeight = 384m
				},
				new Precast()
				{
					Id = 8,
					Name = "СЧ 1a",
					PrecastTypeId = 1,
					Count = 10,
					AddedOn = DateTime.Now.AddDays(-10),
					ProjectId = 1,
					ConcreteClassId = 9,
					ConcreteProjectAmount = 1.97m,
					ConcreteActualAmount = 1.97m,
					ReinforceProjectWeight = 400m
				},
				new Precast()
				{
					Id = 9,
					Name = "MЧ 1",
					PrecastTypeId = 1,
					Count = 36,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 9,
					ConcreteProjectAmount = 1.61m,
					ConcreteActualAmount = 1.61m,
					ReinforceProjectWeight = 375m
				},
				new Precast()
				{
					Id = 10,
					Name = "K тип 1,1а,1б",
					PrecastTypeId = 2,
					Count = 9,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.88m,
					ConcreteActualAmount = 7.90m,
					ReinforceProjectWeight = 1291m
				},
				new Precast()
				{
					Id = 11,
					Name = "K тип 2,2а",
					PrecastTypeId = 2,
					Count = 5,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 7.88m,
					ConcreteActualAmount = 7.90m,
					ReinforceProjectWeight = 1312m
				},
				new Precast()
				{
					Id = 12,
					Name = "ГГ 1",
					PrecastTypeId = 4,
					Count = 4,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 14,
					ConcreteProjectAmount = 9.54m,
					ConcreteActualAmount = 9.6m,
					ReinforceProjectWeight = 1620m
				},
				new Precast()
				{
					Id = 13,
					Name = "Ст. 1",
					PrecastTypeId = 8,
					Count = 4,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 14,
					ConcreteProjectAmount = 1.24m,
					ConcreteActualAmount = 1.2m,
					ReinforceProjectWeight = 252m
				},
				new Precast()
				{
					Id = 14,
					Name = "Ст.2A,2B",
					PrecastTypeId = 8,
					Count = 3,
					AddedOn = DateTime.Now.AddDays(-7),
					ProjectId = 2,
					ConcreteClassId = 14,
					ConcreteProjectAmount = 1.24m,
					ConcreteActualAmount = 1.25m,
					ReinforceProjectWeight = 254m
				},
				new Precast()
				{
					Id = 15,
					Name = "Ч 1",
					PrecastTypeId = 1,
					Count = 16,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 9,
					ConcreteProjectAmount = 2.34m,
					ConcreteActualAmount = 2.24m,
					ReinforceProjectWeight = 397m
				},
				new Precast()
				{
					Id = 16,
					Name = "Ч 2",
					PrecastTypeId = 1,
					Count = 37,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 9,
					ConcreteProjectAmount = 1.58m,
					ConcreteActualAmount = 1.46m,
					ReinforceProjectWeight = 274m
				},
				new Precast()
				{
					Id = 17,
					Name = "ПГр.2.1",
					PrecastTypeId = 4,
					Count = 12,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 14,
					ConcreteProjectAmount = 4.10m,
					ConcreteActualAmount = 4.04m,
					ReinforceProjectWeight = 1257m
				},
				new Precast()
				{
					Id = 18,
					Name = "ПГр.1.1",
					PrecastTypeId = 4,
					Count = 20,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 14,
					ConcreteProjectAmount = 4.72m,
					ConcreteActualAmount = 4.54m,
					ReinforceProjectWeight = 1430m
				},
				new Precast()
				{
					Id = 19,
					Name = "ПС 2.1",
					PrecastTypeId = 5,
					Count = 3,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 1.59m,
					ConcreteActualAmount = 1.67m,
					ReinforceProjectWeight = 378m
				},
				new Precast()
				{
					Id = 20,
					Name = "ПС 2.2",
					PrecastTypeId = 5,
					Count = 1,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 1.59m,
					ConcreteActualAmount = 1.65m,
					ReinforceProjectWeight = 374m
				},
				new Precast()
				{
					Id = 21,
					Name = "ПС 2.3",
					PrecastTypeId = 5,
					Count = 1,
					AddedOn = DateTime.Now.AddDays(-4),
					ProjectId = 3,
					ConcreteClassId = 12,
					ConcreteProjectAmount = 1.59m,
					ConcreteActualAmount = 1.65m,
					ReinforceProjectWeight = 364m
				},
			};
		}
	}

}


