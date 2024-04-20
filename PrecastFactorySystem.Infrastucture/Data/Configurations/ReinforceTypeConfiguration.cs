namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	internal class ReinforceTypeConfiguration : IEntityTypeConfiguration<ReinforceType>
	{
		
		public void Configure(EntityTypeBuilder<ReinforceType> builder)
		{
			builder
				 .HasData(SeedReinforceTypes());
		}

		private ReinforceType[] SeedReinforceTypes()
		{
			return new ReinforceType[]
			{
				new ReinforceType()
				{
					Id = 1,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 6,
					SpecificMass = 0.222m
				},
				new ReinforceType()
				{
					Id = 2,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 8,
					SpecificMass = 0.395m
				},
				new ReinforceType()
				{
					Id = 3,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 10,
					SpecificMass = 0.617m
				},
				new ReinforceType()
				{
					Id = 4,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 12,
					SpecificMass = 0.888m
				},
				new ReinforceType()
				{
					Id = 5,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 14,
					SpecificMass = 1.21m
				},
				new ReinforceType()
				{
					Id = 6,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 16,
					SpecificMass = 1.58m
				},
				new ReinforceType()
				{
					Id = 7,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 18,
					SpecificMass = 2.00m
				},
				new ReinforceType()
				{
					Id = 8,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 20,
					SpecificMass = 2.47m
				},
				new ReinforceType()
				{
					Id = 9,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 22,
					SpecificMass = 2.98m
				},
				new ReinforceType()
				{
					Id = 10,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 25,
					SpecificMass = 3.85m
				},
				new ReinforceType()
				{
					Id = 11,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 28,
					SpecificMass = 4.83m
				},
				new ReinforceType()
				{
					Id = 12,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 32,
					SpecificMass = 6.31m
				},
				new ReinforceType()
				{
					Id = 13,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 36,
					SpecificMass = 7.99m
				},
				new ReinforceType()
				{
					Id = 14,
					ReinforceClass = ReinforceClass.B500B,
					Diameter = 40,
					SpecificMass = 9.87m
				},
				new ReinforceType()
				{
					Id = 15,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 6,
					SpecificMass = 0.222m
				},
				new ReinforceType()
				{
					Id = 16,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 8,
					SpecificMass = 0.395m
				},
				new ReinforceType()
				{
					Id = 17,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 10,
					SpecificMass = 0.617m
				},
				new ReinforceType()
				{
					Id = 18,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 12,
					SpecificMass = 0.888m
				},
				new ReinforceType()
				{
					Id = 19,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 14,
					SpecificMass = 1.21m
				},
				new ReinforceType()
				{
					Id = 20,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 16,
					SpecificMass = 1.58m
				},
				new ReinforceType()
				{
					Id = 21,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 18,
					SpecificMass = 2.00m
				},
				new ReinforceType()
				{
					Id = 22,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 20,
					SpecificMass = 2.47m
				},
				new ReinforceType()
				{
					Id = 23,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 22,
					SpecificMass = 2.98m
				},
				new ReinforceType()
				{
					Id = 24,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 25,
					SpecificMass = 3.85m
				},
				new ReinforceType()
				{
					Id = 25,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 28,
					SpecificMass = 4.83m
				},
				new ReinforceType()
				{
					Id = 26,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 32,
					SpecificMass = 6.31m
				},
				new ReinforceType()
				{
					Id = 27,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 36,
					SpecificMass = 7.99m
				},
				new ReinforceType()
				{
					Id = 28,
					ReinforceClass = ReinforceClass.B500C,
					Diameter = 40,
					SpecificMass = 9.87m
				}
			};
		}
	}
}
