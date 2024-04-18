namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Enums;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	[Comment("Тип на сглобяем стоманобетонов елемент")]
	public class PrecastType: IBaseEntity
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Име")]
		[Required]
		[MaxLength(PrecastTypeNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Comment("Начин на армиране")]
		[Required]
		public PrecastReinforceType PrecastReinforceType { get; set; }

		public ICollection<Precast> TypePrecast { get; set; } = new HashSet<Precast>();
	}
}