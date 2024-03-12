namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Data.Models;
	using PrecastFactorySystem.Infrastructure.Data.Common;

	public class BaseService : IBaseService
	{
		private readonly IRepository repository;

		public BaseService(IRepository _repository)
		{
			repository = _repository;
		}
		public async Task<IEnumerable<ProjectViewModel>> GetProjectAsync()
		{
			return await repository.AllReadonly<Project>()
				.Select(p => new ProjectViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<PrecastTypeViewModel>> GetPrecastTypeAsync(Expression<Func<PrecastType, bool>> condition)
		{
			return await repository.AllReadonly<PrecastType>()
				.Where(condition)
				.Select(p => new PrecastTypeViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<ConcreteClassViewModel>> GetConcreteClassAsync()
		{
			return await repository.AllReadonly<ConcreteClass>()
				.Select(p => new ConcreteClassViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

	}
}
