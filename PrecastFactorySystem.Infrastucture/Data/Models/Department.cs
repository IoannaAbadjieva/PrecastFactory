namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Enums;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Infrastructure.Data.Contracts;

	using static DataValidation.DataConstants;


	[Comment("Отдел/Цех")]
	public class Department : IBaseEntity
	{
		[Comment("Идентификатор")]
		[Key]
		public int Id { get; set; }


		[Comment("Име")]
		[Required]
		[MaxLength(DepartmentNameMaxLength)]
		public string Name { get; set; } = string.Empty;


		[Comment("Тип на отдела")]
		[Required]
		public DepartmentType DepartmentType { get; set; }

		public ICollection<PrecastDepartment> DepartmentPrecast { get; set; } = new HashSet<PrecastDepartment>();

		public ICollection<ReinforceOrder> ReinforceOrders { get; set; } = new HashSet<ReinforceOrder>();

	}
}