namespace Microsoft.Extensions.DependencyInjection
{
	using EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IBaseServise, BaseService>();
			services.AddScoped<IProjectService, ProjectService>();
			services.AddScoped<IPrecastService, PrecastService>();
			services.AddScoped<IReinforceService, ReinforceService>();
			services.AddScoped<IDelivererService, DelivererService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IExportService, ExportService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IDepartmentService, DepartmentService>();
			services.AddScoped<IUserService, UserService>();
			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<PrecastFactoryDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddDefaultIdentity<ApplicationUser>(options =>
				{
					options.SignIn.RequireConfirmedAccount = configuration
					.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

					options.Password.RequireDigit = configuration
					.GetValue<bool>("Identity:Password:RequireDigit");

					options.Password.RequireNonAlphanumeric = configuration
					.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

					options.Password.RequireUppercase = configuration
					.GetValue<bool>("Identity:Password:RequireUppercase");
				})
				.AddRoles<ApplicationRole>()
				.AddEntityFrameworkStores<PrecastFactoryDbContext>();
			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/User/Login";
				options.LogoutPath = "/User/Logout";
			});

			return services;
		}
	}
}