namespace PrecastFactorySystem.Core.Services
{
    using PrecastFactorySystem.Core.Contracts;
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
