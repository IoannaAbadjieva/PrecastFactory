namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Enums;

	using static DataValidation.DataConstants;
	public class Department
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(DepartmentNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public DepartmentType DepartmentType { get; set; }

		public ICollection<PrecastDepartment> DepartmentPrecast { get; set; } = new HashSet<PrecastDepartment>();

		public ICollection<ReinforceOrder> ReinforceOrders { get; set; } = new HashSet<ReinforceOrder>();

		public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; } = new HashSet<DepartmentEmployee>();
	}
}