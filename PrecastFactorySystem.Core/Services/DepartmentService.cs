namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Data.Models;
	using PrecastFactorySystem.Infrastructure.Data.Common;

	public class DepartmentService : IDepartmentService
	{
		private readonly IRepository repository;

		public DepartmentService(IRepository _repository)
		{
			repository = _repository;
		}
	
	}
}
