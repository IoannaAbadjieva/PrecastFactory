namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
		{
			var userClaimsData = new SeedUserData();

			builder
				.HasData(
					userClaimsData.AdminUserClaim,
					userClaimsData.ManagerUserClaim,
					userClaimsData.ReinforceManagerUserClaim,
					userClaimsData.ProductionManagerUserClaim,
					userClaimsData.UserClaim
				);
		}
	}

}
