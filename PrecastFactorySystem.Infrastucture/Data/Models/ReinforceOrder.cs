namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	[Comment("Заявки за армировъчна стомана")]
	public class ReinforceOrder
	{
		[Comment("Идентификатор на заявка")]
		[Key]
		public int Id { get; set; }

		[Comment("Заявен брой от елемента")]
		[Required]
		public int Count { get; set; }

		[Comment("Дата на заявка")]
		[Required]
		public DateTime OrderDate { get; set; }

		[Comment("Тегло на заявения елемент")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal PrecastWeight { get; set; }

		[Comment("Дата на доставка")]
		[Required]
		public DateTime DeliverDate { get; set; }

		[Comment("Цех за доставка")]
		[Required]
		[ForeignKey(nameof(Department))]
		public int DepartmentId { get; set; }

		public Department Department { get; set; } = null!;

		[Comment("Доставчик")]
		[Required]
		[ForeignKey(nameof(Deliverer))]
		public int DelivererId { get; set; }

		public Deliverer Deliverer { get; set; } = null!;

		public ICollection<PrecastReinforceOrder> PrecastReinforceOrders { get; set; } = new HashSet<PrecastReinforceOrder>();
	}
}