namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Enums;
    using Models;

    public class PrecastTypeConfiguration : IEntityTypeConfiguration<PrecastType>
    {
        private readonly PrecastType[] precastTypes = new PrecastType[]
        {
            new PrecastType()
            {
                Id = 1,
                Name = "Foundations",
                PrecastReinforceType = PrecastReinforceType.Soft
            },
            new PrecastType()
            {
                Id = 2,
                Name = "Column",
                PrecastReinforceType = PrecastReinforceType.Soft
            },
            new PrecastType()
            {
                Id = 3,
                Name = "Main Beam",
                PrecastReinforceType = PrecastReinforceType.Soft
            },
            new PrecastType()
            {
                Id = 4,
                Name = "Prestressed Main Beam",
                PrecastReinforceType = PrecastReinforceType.Prestressed
            },
            new PrecastType()
            {
                Id = 5,
                Name = "Secondary Beam",
                PrecastReinforceType = PrecastReinforceType.Soft
            },
            new PrecastType()
            {
                Id = 6,
                Name = "Prestressed Secondary Beam",
                PrecastReinforceType = PrecastReinforceType.Prestressed
            },
            new PrecastType()
            {
                Id = 7,
                Name = "Purlin",
                PrecastReinforceType = PrecastReinforceType.Soft
            },
            new PrecastType()
            {
                Id = 8,
                Name = "Prestressed Purlin",
                PrecastReinforceType = PrecastReinforceType.Prestressed,
            },
            new PrecastType
            {
                Id = 9,
                Name = "Panel",
                PrecastReinforceType = PrecastReinforceType.Soft,
            },
            new PrecastType()
            {
                Id = 10,
                Name = "Hollow Core Slab",
                PrecastReinforceType = PrecastReinforceType.PrestressedOnly,
            },
            new PrecastType()
            {
                Id = 11,
                Name = "Production Use",
                PrecastReinforceType = PrecastReinforceType.Soft,
            },
            new PrecastType()
            {
                Id = 12,
                Name = "Other",
                PrecastReinforceType = PrecastReinforceType.Soft,
            }

        };
        public void Configure(EntityTypeBuilder<PrecastType> builder)
        {
            builder
                .HasData(precastTypes);
        }
    }
}
