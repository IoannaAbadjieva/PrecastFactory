namespace PrecastFactorySystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class DepartmentEmployeeConfiguration : IEntityTypeConfiguration<DepartmentEmployee>
    {
        public void Configure(EntityTypeBuilder<DepartmentEmployee> builder)
        {
            builder
                .HasKey(de => new { de.DepartmentId, de.EmployeetId });

            builder
                .HasOne(de => de.Department)
                .WithMany(d => d.DepartmentEmployees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
