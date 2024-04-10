namespace PrecastFactorySystem.Core.Services
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Infrastructure.Data.Common;
    using Infrastructure.Data.Models;
    using Models.Reinforce;
    using System.Collections.Generic;

    using static Infrastructure.DataValidation.DataConstants;
    using PrecastFactorySystem.Core.Models.Order;

    public class ReinforceService : IReinforceService
	{
		private readonly IRepository repository;
		private readonly IBaseServise baseServise;

		public ReinforceService(IRepository _repository,
			IBaseServise _baseServise)
		{
			repository = _repository;
			baseServise = _baseServise;
		}



		public async Task<int> DeleteReinforceAsync(int id)
		{
			var entity = await repository.GetByIdAsync<PrecastReinforce>(id);

			if (entity == null)
			{
				throw new ArgumentException();
			}

			int precastId = entity.PrecastId;

			repository.Delete(entity);
			await repository.SaveChangesAsync();

			return precastId;
		}

		public async Task<int> EditReinforceAsync(int id, ReinforceFormViewModel model)
		{
			var entity = await repository.GetByIdAsync<PrecastReinforce>(id);

			if (entity == null)
			{
				throw new ArgumentException();
			}

			entity.Count = model.Count;
			entity.Position = model.Position;
			entity.Length = model.Length;
			entity.ReinforceTypeId = model.ReinforceTypeId;

			await repository.SaveChangesAsync();

			return entity.PrecastId;
		}

		public async Task<ReinforceFormViewModel> GetReinforceByIdAsync(int id)
		{
			var model = await repository.All<PrecastReinforce>(pr => pr.Id == id)
				.Select(r => new ReinforceFormViewModel()
				{
					PrecastId = r.PrecastId,
					Count = r.Count,
					Position = r.Position,
					Length = r.Length,
					ReinforceTypeId = r.ReinforceTypeId,
				}).FirstOrDefaultAsync();

			if (model == null)
			{
				throw new ArgumentException();
			}

			model.ReinforceTypes = await baseServise.GetReinforceTypesAsync();
			return model;
		}

		

		public async Task<bool> IsReinforceExist(int id)
		{
			return await repository.AllReadonly<PrecastReinforce>()
				.AnyAsync(r => r.Id == id);
		}
	}
}
