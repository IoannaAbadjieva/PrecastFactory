namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PrecastDepartment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Precast))]
        public int PrecastId { get; set; }

        public Precast Precast { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

        [Required]
        public int Count { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ConcreteAmount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}