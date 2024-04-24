namespace PrecastFactorySystem.Infrastructure.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Configurations;

	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	public class PrecastFactoryDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public PrecastFactoryDbContext(DbContextOptions<PrecastFactoryDbContext> options)
			: base(options)
		{

		}

		public DbSet<ConcreteClass> ConcreteClasses { get; set; } = null!;

		public DbSet<Deliverer> Deliverers { get; set; } = null!;

		public DbSet<Department> Departments { get; set; } = null!;

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
			builder.ApplyConfiguration(new ReinforceTypeConfiguration());
			builder.ApplyConfiguration(new PrecastTypeConfiguration());
			builder.ApplyConfiguration(new DepartmentConfiguration());
			builder.ApplyConfiguration(new DlivererConfiguration());
			builder.ApplyConfiguration(new ProjectConfiguration());
			builder.ApplyConfiguration(new PrecastConfiguration());
			builder.ApplyConfiguration(new PrecastReinforceConfiguration());
			builder.ApplyConfiguration(new ReinforceOrderConfiguration());
			builder.ApplyConfiguration(new PrecastReinforceOrderConfiguration());
			builder.ApplyConfiguration(new DepartmentPrecastConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new UserClaimsConfiguration());


			base.OnModelCreating(builder);

		}
	}
}
