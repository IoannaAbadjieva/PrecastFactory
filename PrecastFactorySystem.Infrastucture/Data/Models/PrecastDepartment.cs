namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.EntityFrameworkCore;

	[Comment("Свързваща таблица между сглобяем стоманобетонов елемент и отдел/цех")]
	public class PrecastDepartment
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }

		[Comment("Сглобяем стоманобетонов елемент")]
		[Required]
		[ForeignKey(nameof(Precast))]
		public int PrecastId { get; set; }

		public Precast Precast { get; set; } = null!;

		[Comment("Отдел/Цех")]
		[Required]
		[ForeignKey(nameof(Department))]
		public int DepartmentId { get; set; }

		public Department Department { get; set; } = null!;

		[Comment("Брой наляти елементи")]
		[Required]
		public int Count { get; set; }

		[Comment("Дата")]
		[Required]
		public DateTime Date { get; set; }
	}
}