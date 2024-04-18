namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	using static DataValidation.DataConstants;

	[Comment("Армировка на елемент")]
	public class PrecastReinforce
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }


		[Comment("Идентификатор на елемент")]
		[Required]
		[ForeignKey(nameof(Precast))]
		public int PrecastId { get; set; }

		public Precast Precast { get; set; } = null!;

		[Comment("Позиция на армировката")]
		[Required]
		[MaxLength(ReinforcePositionMaxLength)]
		public string Position { get; set; } = string.Empty;

		[Comment("Брой")]
		[Required]
		public int Count { get; set; }


		[Comment("Тип на армировката(клас стомана и диаметър)")]
		[Required]
		[ForeignKey(nameof(ReinforceType))]
		public int ReinforceTypeId { get; set; }

		[Required]
		public ReinforceType ReinforceType { get; set; } = null!;

		[Comment("Дължина на армировката")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Length { get; set; }

		[Comment("Тегло на армировката")]
		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Weight { get; set; }

	}
}