namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class PrecastReinforceOrder
	{
		[Required]
		[ForeignKey(nameof(Precast))]
		public int PrecastId { get; set; }

		public Precast Precast { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(ReinforceOrder))]
		public int ReinforceOrderId { get; set; }

		public ReinforceOrder ReinforceOrder { get; set; } = null!;
	}
}