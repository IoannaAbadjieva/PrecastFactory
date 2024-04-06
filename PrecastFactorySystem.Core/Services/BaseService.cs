namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	public class BaseService : IBaseServise
	{
		private readonly IRepository repository;


		public BaseService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetProjectsAsync()
		{
			return await repository.AllReadonly<Project>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypesAsync()
		{
			return await repository.AllReadonly<PrecastType>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassesAsync()
		{
			return await repository.AllReadonly<ConcreteClass>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetReinforceTypesAsync()
		{
			return await repository.AllReadonly<ReinforceType>()
				.Select(rt => new BaseSelectorViewModel()
				{
					Id = rt.Id,
					Name = $"{rt.ReinforceClass}  {rt.Diameter}"
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetDeliverersAsync()
		{
			return await repository.AllReadonly<Deliverer>()
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name,
				}).ToArrayAsync();
		}

		public async Task<IEnumerable<BaseSelectorViewModel>> GetDepartmentsAsync()
		{
			return await repository.AllReadonly<Department>(d => d.DepartmentType == DepartmentType.Production)
				.Select(p => new BaseSelectorViewModel()
				{
					Id = p.Id,
					Name = p.Name
				}).ToArrayAsync();
		}
	}

}
