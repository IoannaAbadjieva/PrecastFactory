namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			var userData = new SeedUserData();

			builder
				.HasData(new ApplicationUser[] 
				{
					userData.AdminUser,
					userData.ManagerUser,
					userData.ReinforceManagerUser,
					userData.ProductionManagerUser,
					userData.OrdinaryUser
				});
		}
	}
}
