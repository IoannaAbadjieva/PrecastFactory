namespace PrecastFactorySystem.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Configurations;
using Models;

public class PrecastFactorySystemDbContext : IdentityDbContext
{
    public PrecastFactorySystemDbContext(DbContextOptions<PrecastFactorySystemDbContext> options)
        : base(options)
    {

    }

    public DbSet<ConcreteClass> ConcreteClasses { get; set; } = null!;

    public DbSet<Deliverer> Deliverers { get; set; } = null!;

    public DbSet<Department> Departments { get; set; } = null!;

    public DbSet<DepartmentEmployee> DepartmentsEmployees { get; set; } = null!;

    public DbSet<Precast> Precast { get; set; } = null!;

    public DbSet<PrecastDepartment> DepartmentsPrecast { get; set; } = null!;

    public DbSet<PrecastReinforce> PrecastReinforce { get; set; } = null!;

    public DbSet<PrecastReinforceOrder> PrecastReinforceOrders { get; set; } = null!;

    public DbSet<PrecastType> PrecastTypes { get; set; } = null!;

    public DbSet<Project> Projects { get; set; } = null!;

    public DbSet<ReinforceOrder> ReinforceOrders { get; set; } = null!;

    public DbSet<ReinforceType> ReinforceTypes { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ConcreteClassConfiguration());

        builder.ApplyConfiguration(new DepartmentConfiguration());
        builder.ApplyConfiguration(new DepartmentEmployeeConfiguration());
        builder.ApplyConfiguration(new PrecastReinforceOrderConfiguration());
        builder.ApplyConfiguration(new PrecastTypeConfiguration());
        builder.ApplyConfiguration(new ReinforceTypeConfiguration());

        base.OnModelCreating(builder);
    }
}