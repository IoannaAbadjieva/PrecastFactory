namespace Microsoft.Extensions.DependencyInjection
{
	using AspNetCore.Identity;
	using EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;

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
				.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<PrecastFactoryDbContext>();

			return services;
		}
	}
}