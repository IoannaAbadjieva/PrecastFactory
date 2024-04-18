namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;

	[Comment("Обект")]
	[Index(nameof(ProdNumber), IsUnique = true)]
	public class Project : IBaseEntity
	{
		[Comment("Идентификатор на обекта")]
		[Key]
		public int Id { get; set; }

		[Comment("Име на обекта")]
		[Required]
		[MaxLength(ProjectNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Comment("Административен номер на обекта")]
		[Required]
		[MaxLength(ProjectNumberMaxLength)]
		public string ProdNumber { get; set; } = string.Empty;

		[Comment("Дата на добавяне")]
		[Required]
		public DateTime AddedOn { get; set; }


		[Comment("Изтрит")]
		[Required]
		public bool IsDeleted { get; set; }

		public ICollection<Precast> ProjectPrecast { get; set; } = new HashSet<Precast>();
	}
}