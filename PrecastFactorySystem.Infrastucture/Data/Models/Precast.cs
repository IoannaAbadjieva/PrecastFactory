namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using static DataValidation.DataConstants;

	public class Precast
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(PrecastNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[ForeignKey(nameof(PrecastType))]
		public int PrecastTypeId { get; set; }

		[Required]
		public PrecastType PrecastType { get; set; } = null!;

		[Required]
		public int Count { get; set; }

		[Required]
		public DateTime AddedOn { get; set; }

		[Required]
		[ForeignKey(nameof(Project))]
		public int ProjectId { get; set; }

		public Project Project { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(ConcreteClass))]
		public int ConcreteClassId { get; set; }

		public ConcreteClass ConcreteClass { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ConcreteProjectAmount { get; set; }

		[NotMapped]
		public decimal ConcreteActualAmount
			=> this.DepartmentPrecast.Count > 0 ?
				this.DepartmentPrecast.Average(dp => dp.ConcreteAmount)
				: default;


		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ReinforceProjectWeight { get; set; }

		[NotMapped]
		public decimal ReinforceActualWeight
			=> this.PrecastReinforceOrders.Count > 0 ?
				this.PrecastReinforceOrders.Average(pro => pro.ReinforceOrder.PrecastWeight)
				: default;

		[NotMapped]
		public int Reinforced
			=> this.PrecastReinforceOrders.Count > 0 ?
				this.PrecastReinforceOrders.Sum(pro => pro.ReinforceOrder.Count)
				: default;

		[NotMapped]
		public int Produced
			=> this.DepartmentPrecast.Count > 0 ?
				this.DepartmentPrecast.Sum(dp => dp.Count)
				: default;

		public ICollection<PrecastReinforce> PrecastReinforce { get; set; } = new HashSet<PrecastReinforce>();

		public ICollection<PrecastReinforceOrder> PrecastReinforceOrders { get; set; } = new HashSet<PrecastReinforceOrder>();

		public ICollection<PrecastDepartment> DepartmentPrecast { get; set; } = new HashSet<PrecastDepartment>();
	}
}