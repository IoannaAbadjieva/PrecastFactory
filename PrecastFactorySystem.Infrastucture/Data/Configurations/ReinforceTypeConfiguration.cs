namespace PrecastFactorySystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Enums;
    using Models;

    public class ReinforceTypeConfiguration : IEntityTypeConfiguration<ReinforceType>
    {
        private readonly ReinforceType[] reinforceTypes = new ReinforceType[]
       {
            new ReinforceType
            {
                Id = 1,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 6
            },
            new ReinforceType
            {
                Id = 2,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 8
            },
            new ReinforceType
            {
                Id = 3,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 10
            },
            new ReinforceType
            {
                Id = 4,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 12
            },
            new ReinforceType
            {
                Id = 5,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 14
            },
            new ReinforceType
            {
                Id = 6,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 16
            },
            new ReinforceType
            {
                Id = 7,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 18
            },
            new ReinforceType
            {
                Id = 8,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 20
            },
            new ReinforceType
            {
                Id = 9,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 22
            },
            new ReinforceType
            {
                Id = 10,
               ReinforceClass = ReinforceClass.B500B,
                Diameter = 25
            },
            new ReinforceType
            {
                Id = 11,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 28
            },
            new ReinforceType
            {
                Id = 12,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 32
            },
            new ReinforceType
            {
                Id = 13,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 36
            },
            new ReinforceType
            {
                Id = 14,
                ReinforceClass = ReinforceClass.B500B,
                Diameter = 40
            },
            new ReinforceType
            {
                Id = 15,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 6
            },
            new ReinforceType
            {
                Id = 16,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 8
            },
            new ReinforceType
            {
                Id = 17,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 10
            },
            new ReinforceType
            {
                Id = 18,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 12
            },
            new ReinforceType
            {
                Id = 19,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 14
            },
            new ReinforceType
            {
                Id = 20,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 16
            },
            new ReinforceType
            {
                Id = 21,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 18
            },
            new ReinforceType
            {
                Id = 22,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 20
            },
            new ReinforceType
            {
                Id = 23,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 22
            },
            new ReinforceType
            {
                Id = 24,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 25
            },
            new ReinforceType
            {
                Id = 25,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 28
            },
            new ReinforceType
            {
                Id = 26,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 32
            },
            new ReinforceType
            {
                Id = 27,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 36
            },
            new ReinforceType
            {
                Id = 28,
                ReinforceClass = ReinforceClass.B500C,
                Diameter = 40
            },
       };
        public void Configure(EntityTypeBuilder<ReinforceType> builder)
        {
            builder
                 .HasData(reinforceTypes);
        }
    }
}
