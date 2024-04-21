namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	[Comment("Сглобяем стоманобетонов елемент")]
	public class Precast : IBaseEntity
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Име")]
		[Required]
		[MaxLength(PrecastNameMaxLength)]
		public string Name { get; set; } = string.Empty;


		[Comment("Тип на елемента")]
		[Required]
		[ForeignKey(nameof(PrecastType))]
		public int PrecastTypeId { get; set; }


		[Required]
		public PrecastType PrecastType { get; set; } = null!;

		[Comment("Количество")]
		[Required]
		public int Count { get; set; }


		[Comment("Дата на добавяне")]
		[Required]
		public DateTime AddedOn { get; set; }


		[Comment("Обект")]
		[Required]
		[ForeignKey(nameof(Project))]
		public int ProjectId { get; set; }

		public Project Project { get; set; } = null!;


		[Comment("Клас на бетона")]
		[Required]
		[ForeignKey(nameof(ConcreteClass))]
		public int ConcreteClassId { get; set; }

		public ConcreteClass ConcreteClass { get; set; } = null!;


		[Comment("Проектно количество бетон")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ConcreteProjectAmount { get; set; }

		[Comment("Реално количество бетон")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal? ConcreteActualAmount { get; set; }


		[Comment("Проектно тегло на армировка")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ReinforceProjectWeight { get; set; }


		public ICollection<PrecastReinforce> PrecastReinforce { get; set; } = new HashSet<PrecastReinforce>();

		public ICollection<PrecastReinforceOrder> PrecastReinforceOrders { get; set; } = new HashSet<PrecastReinforceOrder>();

		public ICollection<PrecastDepartment> DepartmentPrecast { get; set; } = new HashSet<PrecastDepartment>();
	}
}