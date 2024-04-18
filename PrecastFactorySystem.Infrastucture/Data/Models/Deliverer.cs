namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	[Comment("Доставчик на армировъчна стомана")]
	public class Deliverer : IBaseEntity
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Име")]
		[Required]
		[MaxLength(DelivererNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		
		[Required]
		[MaxLength(DelivererEmailMaxLength)]
		public string Email { get; set; } = string.Empty;

		public ICollection<ReinforceOrder> ReinforceOrders { get; set; } = new HashSet<ReinforceOrder>();


	}
}