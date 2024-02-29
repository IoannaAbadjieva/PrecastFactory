namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class DepartmentEmployee
    {
        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Employee))]
        public string EmployeetId { get; set; }=string.Empty;

        public IdentityUser Employee { get; set; } = null!;
    }
}
