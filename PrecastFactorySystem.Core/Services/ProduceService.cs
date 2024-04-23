namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;


	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Base;
	using PrecastFactorySystem.Core.Models.Produce;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	using static PrecastFactorySystem.Core.Constants.MessageConstants;

	public class ProduceService : IProduceService
	{
		private readonly IRepository repository;
		private readonly IPrecastService precastService;
		private readonly IBaseServise baseService;

		public ProduceService(
			IRepository _repository,
			IPrecastService _precastService,
			IBaseServise _baseService)
		{
			repository = _repository;
			baseService = _baseService;
			precastService = _precastService;
		}


		public async Task<ProduceFormViewModel> GetProductionFormAsync(int precastId)
		{
			var maxCount = await GetPrecastToProduceCountAsync(precastId, null);

			if (maxCount == 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

			return new ProduceFormViewModel
			{
				PrecastId = precastId,
				ProducedCount = maxCount,
				Departments = await baseService.GetBaseEntityDataAsync<Department>
				(d => d.DepartmentType == DepartmentType.PrecastProduction)
			};
		}

		public async Task ProducePrecastAsync(int id, ProduceFormViewModel model)
		{

			var maxCount = await GetPrecastToProduceCountAsync(id, null);

			if (maxCount == 0)
			{
				throw new ProduceActionException(NoPrecastToProduceErrorMessage);
			}

			var entity = new PrecastDepartment
			{
				PrecastId = id,
				Count = model.ProducedCount,
				Date = model.Date,
				DepartmentId = model.DepartmentId
			};

			await repository.AddAsync(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<ProduceFormViewModel> GetProductionRecordByIdAsync(int id)
		{
			var model = await repository.AllReadonly<PrecastDepartment>(p => p.Id == id)
					.Select(p => new ProduceFormViewModel
					{
						PrecastId = p.PrecastId,
						ProducedCount = p.Count,
						Date = p.Date,
						DepartmentId = p.DepartmentId,
					}).FirstAsync();

			model.Departments = await baseService.GetBaseEntityDataAsync<Department>
				(d => d.DepartmentType == DepartmentType.PrecastProduction);

			return model;
		}

		public async Task EditProductionRecordAsync(int id, ProduceFormViewModel model)
		{

			int precastId = model.PrecastId;

			int maxCount = await GetPrecastToProduceCountAsync(precastId, id);

			if (model.ProducedCount > maxCount)
			{
				throw new ProduceActionException(InvalidProduceCountErrorMessage);
			}

			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			entity.Count = model.ProducedCount;
			entity.Date = model.Date;
			entity.DepartmentId = model.DepartmentId;

			await repository.SaveChangesAsync();
		}

		public async Task DeleteProductionRecordAsync(int id)
		{
			var entity = await repository.GetByIdAsync<PrecastDepartment>(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<int> GetProducedPrecastCountAsync(int id, int? recordId)
		{
			var produced = 0;

			if (recordId.HasValue)
			{
				produced = await repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id && dp.Id != recordId)
				   .SumAsync(dp => dp.Count);
			}
			else
			{
				produced = await repository.AllReadonly<PrecastDepartment>(dp => dp.PrecastId == id)
				   .SumAsync(dp => dp.Count);
			}

			return produced;
		}

		public async Task<int> GetPrecastToProduceCountAsync(int id, int? recordId)
		{
			var reinforced = await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id && pro.ReinforceOrder.DeliverDate <= DateTime.UtcNow)
				.SumAsync(pro => pro.ReinforceOrder.Count);
			var produced = await GetProducedPrecastCountAsync(id, recordId);

			return reinforced - produced;
		}

		public async Task<DateTime> GetFirstOrderDeliveryDate(int id)
		{
			return await repository.AllReadonly<PrecastReinforceOrder>(pro => pro.PrecastId == id)
				.MinAsync(pro => pro.ReinforceOrder.DeliverDate);
		}

		public async Task<bool> IsProductionRecordExist(int id)
		{
			return await repository.AllReadonly<PrecastDepartment>()
				.AnyAsync(p => p.Id == id);
		}
	}
}
