namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class ConcreteClassConfiguration : IEntityTypeConfiguration<ConcreteClass>
    {
        private readonly ConcreteClass[] concreteClasses = new ConcreteClass[]
        {
            new ConcreteClass()
            {
                Id = 1,
                Name = "C 6/8",
                CompressiveStrengthRequired = 8
            },
            new ConcreteClass()
            {
                Id = 2,
                Name = "C 8/10",
                CompressiveStrengthRequired = 10
            },
            new ConcreteClass()
            {
                Id = 3,
                Name = "C 10/12",
                CompressiveStrengthRequired = 12
            },
            new ConcreteClass()
            {
                Id = 4,
                Name = "C 12/15",
                CompressiveStrengthRequired = 15
            },
            new ConcreteClass()
            {
                Id = 5,
                Name = "C 16/20",
                CompressiveStrengthRequired = 20
            },
            new ConcreteClass()
            {
                Id = 6,
                Name = "C 20/25",
                CompressiveStrengthRequired = 25
            },
            new ConcreteClass()
            {
                Id = 7,
                Name = "C 25/30",
                CompressiveStrengthRequired = 30
            },
            new ConcreteClass()
            {
                Id = 8,
                Name = "C 28/35",
                CompressiveStrengthRequired = 35
            },
            new ConcreteClass()
            {
                Id = 9,
                Name = "C 30/37",
                CompressiveStrengthRequired = 37
            },
            new ConcreteClass()
            {
                Id = 10,
                Name = "C 32/40",
                CompressiveStrengthRequired = 40
            },
            new ConcreteClass()
            {
                Id = 11,
                Name = "C 35/45",
                CompressiveStrengthRequired = 45
            },
            new ConcreteClass()
            {
                Id = 12,
                Name = "C 40/50",
                CompressiveStrengthRequired = 55
            },
            new ConcreteClass()
            {
                Id = 13,
                Name = "C 45/55",
                CompressiveStrengthRequired = 55
            },
            new ConcreteClass()
            {
                Id = 14,
                Name = "C 50/60",
                CompressiveStrengthRequired = 60
            },
        };
        public void Configure(EntityTypeBuilder<ConcreteClass> builder)
        {
            builder
                 .HasData(concreteClasses);
        }
    }
}
