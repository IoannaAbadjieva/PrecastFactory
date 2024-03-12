namespace PrecastFactorySystem.Core.Contracts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Data.Models;

	public interface IDepartmentService
	{
		Task<IEnumerable<BaseViewModel>> GetDepartmentsAsync(Expression<Func<Department, bool>> condition);
	}
}
