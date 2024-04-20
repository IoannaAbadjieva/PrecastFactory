namespace Microsoft.AspNetCore.Builder
{
	using Microsoft.AspNetCore.Identity;

	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	public static class ApplicationBuilderExtension
	{
		public static async Task CreateRolesAsync(this IApplicationBuilder app)
		{
			var scope = app.ApplicationServices.CreateScope();
			var serviceProvider = scope.ServiceProvider;

			var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			string[] roleNames = { "Administrator", "Manager", "ReinforceManager", "PrecastProductionManager", "User" };
			IdentityResult roleResult;

			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					roleResult = await roleManager.CreateAsync(new ApplicationRole(roleName));
				}
			}

			ApplicationUser admin = await userManager.FindByEmailAsync("admin@mail.com");

			if (admin != null)
			{
				await userManager.AddToRoleAsync(admin, "Administrator");
			}

			ApplicationUser manager = await userManager.FindByEmailAsync("manager@mail.com");

			if (manager != null)
			{
				await userManager.AddToRoleAsync(manager, "Manager");
			}


			ApplicationUser reinforceManager = await userManager.FindByEmailAsync("reinforce@mail.com");

			if (reinforceManager != null)
			{
				await userManager.AddToRoleAsync(reinforceManager, "ReinforceManager");
			}


			ApplicationUser productionManager = await userManager.FindByEmailAsync("production@mail.com");

			if (productionManager != null)
			{
				await userManager.AddToRoleAsync(productionManager, "PrecastProductionManager");
			}

			ApplicationUser user = await userManager.FindByEmailAsync("user@mail.com");

			if (user != null)
			{
				await userManager.AddToRoleAsync(user, "User");
			}
		}
	}
}
