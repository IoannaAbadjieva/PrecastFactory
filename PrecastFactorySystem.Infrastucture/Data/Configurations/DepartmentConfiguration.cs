namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;
	using Enums;

	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private readonly Department[] departments = new Department[]
        {
            new Department()
            {
                Id = 1,
                Name = "1-st Precast",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 2,
                Name = "2-nd Precast",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 3,
                Name = "3-rd Precast",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 4,
                Name = "Reinforce",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 5,
                Name = "Mould",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 6,
                Name = "EmbeddedParts",
                DepartmentType = DepartmentType.Production
            },
            new Department()
            {
                Id = 7,
                Name = "Management",
                DepartmentType = DepartmentType.Management
            },
            new Department()
            {
                Id = 8,
                Name = "ProjectTechnical",
                DepartmentType = DepartmentType.Management,
            }
        };
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasData(departments);
        }
    }
}
