namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    using static Constants.DataConstants;
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DepartmentNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DepartmentType DepartmentType { get; set; }

        public ICollection<PrecastDepartment> DepartmentPrecast = new HashSet<PrecastDepartment>();

        public ICollection<ReinforceOrder> ReinforceOrders = new HashSet<ReinforceOrder>();

        public ICollection<DepartmentEmployee> DepartmentEmployees = new HashSet<DepartmentEmployee>();
    }
}
