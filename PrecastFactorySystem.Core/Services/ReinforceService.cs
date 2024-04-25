namespace PrecastFactorySystem.Core.Services
{
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Reinforce;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;


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


		public async Task AddReinforceAsync(int precastId, ReinforceFormViewModel model)
		{
			var reinforce = new PrecastReinforce()
			{
				PrecastId = precastId,
				Count = model.Count,
				Position = model.Position,
				Length = model.Length,
				ReinforceTypeId = model.ReinforceTypeId,
				Weight = model.Count * model.Length * model.SpecificMass
			};

			await repository.AddAsync<PrecastReinforce>(reinforce);
			await repository.SaveChangesAsync();
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

				}).FirstAsync();

			model!.ReinforceTypes = await baseServise.GetReinforceTypesAsync();
			return model;
		}

		public async Task<int> EditReinforceAsync(int id, ReinforceFormViewModel model)
		{
			var entity = await repository.GetByIdAsync<PrecastReinforce>(id);

			entity.Count = model.Count;
			entity.Position = model.Position;
			entity.Length = model.Length;
			entity.ReinforceTypeId = model.ReinforceTypeId;
			entity.Weight = model.Count * model.Length * model.SpecificMass;

			await repository.SaveChangesAsync();

			return entity.PrecastId;
		}

		public async Task DeleteReinforceAsync(int id)
		{
			var entity = await repository.GetByIdAsync<PrecastReinforce>(id);

			repository.Delete(entity);
			await repository.SaveChangesAsync();

		}

		public async Task<bool> IsReinforceExist(int id)
		{
			return await repository.AllReadonly<PrecastReinforce>()
				.AnyAsync(r => r.Id == id);
		}
	}
}
