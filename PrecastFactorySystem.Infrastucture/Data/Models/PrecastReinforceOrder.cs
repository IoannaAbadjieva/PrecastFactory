namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	[Comment("Свързваща таблица между сглобяем стоманобетонов елемент и Заявки за армировъчна стомана")]
	public class PrecastReinforceOrder
	{

		[Comment("Сглобяем стоманотонов елемент")]
		[Required]
		[ForeignKey(nameof(Precast))]
		public int PrecastId { get; set; }

		public Precast Precast { get; set; } = null!;

		[Comment("Заявка за армировъчна стомана")]
		[Required]
		[ForeignKey(nameof(ReinforceOrder))]
		public int ReinforceOrderId { get; set; }

		public ReinforceOrder ReinforceOrder { get; set; } = null!;
	}
}