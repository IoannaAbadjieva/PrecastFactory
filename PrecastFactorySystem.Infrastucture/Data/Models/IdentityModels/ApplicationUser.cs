namespace PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static DataValidation.DataConstants;

    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [PersonalData]
        [MaxLength(UserNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [PersonalData]
        [MaxLength(UserNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
    }
}
