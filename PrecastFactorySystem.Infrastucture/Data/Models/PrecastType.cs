namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Enums;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	public class PrecastType: IBaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(PrecastTypeNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[System.ComponentModel.DataAnnotations.Required]
		public PrecastReinforceType PrecastReinforceType { get; set; }

		public ICollection<Precast> TypePrecast { get; set; } = new HashSet<Precast>();
	}
}