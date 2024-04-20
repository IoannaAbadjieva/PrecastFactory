namespace PrecastFactorySystem.Infrastructure.Data.Configurations
{
    using System;

    using Microsoft.AspNetCore.Identity;

    using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

    using static PrecastFactorySystem.Infrastructure.DataValidation.CustomClaims;

    internal class SeedUserData
    {
        public ApplicationUser AdminUser { get; set; } = null!;

        public ApplicationUser ManagerUser { get; set; } = null!;

        public ApplicationUser ReinforceManagerUser { get; set; } = null!;

        public ApplicationUser ProductionManagerUser { get; set; } = null!;


        public ApplicationUser OrdinaryUser { get; set; } = null!;


        public IdentityUserClaim<string> AdminUserClaim { get; set; } = null!;

        public IdentityUserClaim<string> ManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<string> ReinforceManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<string> ProductionManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<string> UserClaim { get; set; } = null!;

        public SeedUserData()
        {
            SeedUsers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                EmailConfirmed = true,
                FirstName = "Chief",
                LastName = "Admin",
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin1427");

            AdminUserClaim = new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = AdminUser.Id.ToString(),
                ClaimType = UserFullName,
                ClaimValue = "Chief Admin"
            };

            ManagerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@mail.com",
                NormalizedEmail = "MANAGER@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                EmailConfirmed = true,
                FirstName = "General",
                LastName = "Manager"
            };

            ManagerUser.PasswordHash = hasher.HashPassword(ManagerUser, "manager247");

            ManagerUserClaim = new IdentityUserClaim<string>
            {
                Id = 2,
                UserId = ManagerUser.Id.ToString(),
                ClaimType = UserFullName,
                ClaimValue = "General Manager"
            };

            ReinforceManagerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "reinforce_manager",
                NormalizedUserName = "REINFORCE_MANAGER",
                Email = "reinforce@mail.com",
                NormalizedEmail = "REINFORCE@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                EmailConfirmed = true,
                FirstName = "Reinforce",
                LastName = "Manager"
            };

            ReinforceManagerUser.PasswordHash = hasher.HashPassword(ReinforceManagerUser, "managerRD");

            ReinforceManagerUserClaim = new IdentityUserClaim<string>
            {
                Id = 3,
                UserId = ReinforceManagerUser.Id.ToString(),
                ClaimType = UserFullName,
                ClaimValue = "Reinforce Manager"
            };

            ProductionManagerUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "production_manager",
                NormalizedUserName = "PRODUCTION_MANAGER",
                Email = "production@mail.com",
                NormalizedEmail = "PRODUCTION@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                EmailConfirmed = true,
                FirstName = "Production",
                LastName = "Manager"
            };

            ProductionManagerUser.PasswordHash = hasher.HashPassword(ProductionManagerUser, "managerPD");

            ProductionManagerUserClaim = new IdentityUserClaim<string>
            {
                Id = 4,
                UserId = ProductionManagerUser.Id.ToString(),
                ClaimType = UserFullName,
                ClaimValue = "Production Manager"
            };

            OrdinaryUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                EmailConfirmed = true,
                FirstName = "Ordinary",
                LastName = "User"
            };

            OrdinaryUser.PasswordHash = hasher.HashPassword(OrdinaryUser, "user427");

            UserClaim = new IdentityUserClaim<string>
            {
                Id = 5,
                UserId = OrdinaryUser.Id.ToString(),
                ClaimType = UserFullName,
                ClaimValue = "Ordinary User"
            };

        }

    }
}
