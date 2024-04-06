namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using static DataValidation.DataConstants;

	public class PrecastReinforce
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Precast))]
		public int PrecastId { get; set; }

		public Precast Precast { get; set; } = null!;

		[Required]
		[MaxLength(ReinforcePositionMaxLength)]
		public string Position { get; set; } = string.Empty;

		[Required]
		public int Count { get; set; }

		[Required]
		[ForeignKey(nameof(ReinforceType))]
		public int ReinforceTypeId { get; set; }

		public ReinforceType ReinforceType { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Length { get; set; }
	}
}