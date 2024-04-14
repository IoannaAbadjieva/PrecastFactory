namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;
	public class Deliverer: IBaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(DelivererNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MaxLength(DelivererEmailMaxLength)]
		public string Email { get; set; } = string.Empty;

		public ICollection<ReinforceOrder> ReinforceOrders { get; set; } = new HashSet<ReinforceOrder>();


	}
}