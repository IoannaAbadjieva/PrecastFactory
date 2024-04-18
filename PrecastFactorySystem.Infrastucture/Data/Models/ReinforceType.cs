namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Enums;

	using Microsoft.EntityFrameworkCore;

	[Comment("Тип армировъчна стомана")]
	public class ReinforceType
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Клас на стоманата")]
		[Required]
		public ReinforceClass ReinforceClass { get; set; }

		[Comment("Диаметър на стоманата")]
		[Required]
		public int Diameter { get; set; }

		[Comment("Относително тегло на стоманата")]
		[Required]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal SpecificMass { get; set;}
		

		public ICollection<PrecastReinforce> PrecastReinforce { get; set; } = new HashSet<PrecastReinforce>();


	}
}