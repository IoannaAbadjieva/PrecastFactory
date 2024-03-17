namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PrecastFactorySystem.Core.Contracts;
using PrecastFactorySystem.Core.Services;
using PrecastFactorySystem.Data;
using PrecastFactorySystem.Infrastructure.Data.Common;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IRepository, Repository>();
		services.AddScoped<IProjectService, ProjectService>();
		services.AddScoped<IPrecastService, PrecastService>();
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