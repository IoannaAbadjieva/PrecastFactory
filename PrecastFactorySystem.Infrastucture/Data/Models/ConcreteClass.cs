namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	[Comment("Клас по якост на натиск на бетона")]
	public class ConcreteClass: IBaseEntity
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Име")]
		[Required]
		[MaxLength(ConcreteClassNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Comment("Якост на натиск на бетона")]
		[Required]
		public int CompressiveStrengthRequired { get; set; }

		public ICollection<Precast> Precast { get; set; } = new HashSet<Precast>();
	}
}