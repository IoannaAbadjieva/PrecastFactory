namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ReinforceOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecastWeight { get; set; }

        [Required]
        public DateTime DeliverDate { get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Deliverer))]
        public int DelivererId { get; set; }

        public Deliverer Deliverer { get; set; } = null!;

        public ICollection<PrecastReinforceOrder> PrecastReinforceOrders = new HashSet<PrecastReinforceOrder>();
    }
}