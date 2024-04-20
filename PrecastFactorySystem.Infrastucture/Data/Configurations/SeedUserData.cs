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


        public IdentityUserClaim<Guid> AdminUserClaim { get; set; } = null!;

        public IdentityUserClaim<Guid> ManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<Guid> ReinforceManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<Guid> ProductionManagerUserClaim { get; set; } = null!;

        public IdentityUserClaim<Guid> UserClaim { get; set; } = null!;

        public SeedUserData()
        {
            SeedUsers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser
            {
                Id = Guid.Parse("13a26afc-8c31-4777-b202-89966774aaa5"),
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

            AdminUserClaim = new IdentityUserClaim<Guid>
            {
                Id = 1,
                UserId = Guid.Parse("13a26afc-8c31-4777-b202-89966774aaa5"),
                ClaimType = UserFullName,
                ClaimValue = "Chief Admin"
            };

            ManagerUser = new ApplicationUser
            {
                Id = Guid.Parse("344ef066-7d16-480d-b1d3-6face05c7c62"),
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

            ManagerUserClaim = new IdentityUserClaim<Guid>
            {
                Id = 2,
                UserId = Guid.Parse("344ef066-7d16-480d-b1d3-6face05c7c62"),
                ClaimType = UserFullName,
                ClaimValue = "General Manager"
            };

            ReinforceManagerUser = new ApplicationUser
            {
                Id = Guid.Parse("af7811c7-760b-42c4-b3ed-42cd794e5153"),
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

            ReinforceManagerUserClaim = new IdentityUserClaim<Guid>
            {
                Id = 3,
                UserId = Guid.Parse("af7811c7-760b-42c4-b3ed-42cd794e5153"),
                ClaimType = UserFullName,
                ClaimValue = "Reinforce Manager"
            };

            ProductionManagerUser = new ApplicationUser
            {
                Id = Guid.Parse("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe"),
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

            ProductionManagerUserClaim = new IdentityUserClaim<Guid>
            {
                Id = 4,
                UserId = Guid.Parse("ed91d639-dfe6-4d7f-9a19-bc8a1f3a1fbe"),
                ClaimType = UserFullName,
                ClaimValue = "Production Manager"
            };

            OrdinaryUser = new ApplicationUser
            {
                Id = Guid.Parse("f8927215-501c-43ab-92da-972bf9934a93"),
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

            UserClaim = new IdentityUserClaim<Guid>
            {
                Id = 5,
                UserId = Guid.Parse("f8927215-501c-43ab-92da-972bf9934a93"),
                ClaimType = UserFullName,
                ClaimValue = "Ordinary User"
            };

        }

    }
}
