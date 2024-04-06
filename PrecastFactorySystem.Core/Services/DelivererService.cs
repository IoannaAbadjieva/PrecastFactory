namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Exceptions;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Deliverer;

	using static Constants.MessageConstants;

	public class DelivererService : IDelivererService
	{
		private readonly IRepository repository;

		public DelivererService(IRepository _repository)
		{
			repository = _repository;
		}


		public async Task<IEnumerable<DelivererInfoViewModel>> GetAllDeliverersAsync()
		{
			return await repository.AllReadonly<Deliverer>()
				.Select(d => new DelivererInfoViewModel()
				{
					Id = d.Id,
					Name = d.Name,
					Email = d.Email,
					OrdersCount = d.ReinforceOrders.Count(),
				}).ToArrayAsync();
		}

		public async Task AddDelivererAsync(DelivererFormViewModel model)
		{
			var entity = new Deliverer()
			{
				Name = model.Name,
				Email = model.Email,
			};

			await repository.AddAsync(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<DelivererFormViewModel> GetDelivererByIdAsync(int id)
		{
			var entity = await repository.GetByIdAsync<Deliverer>(id);

			return new DelivererFormViewModel()
			{
				Name = entity.Name,
				Email = entity.Email,
			};
		}

		public async Task EditDelivererAsync(int id, DelivererFormViewModel model)
		{
			var entity = await repository.GetByIdAsync<Deliverer>(id);

			entity.Name = model.Name;
			entity.Email = model.Email;

			await repository.SaveChangesAsync();
		}
		public async Task<DelivererDeleteViewModel> GetDelivererToDeleteByIdAsync(int id)
		{
			var entity = await repository.GetByIdAsync<Deliverer>(id);

			if (await HasOrdersAsync(id))
			{
				throw new DeleteActionException(DeleteDelivererErrorMessage);
			}

			return new DelivererDeleteViewModel()
			{
				Name = entity.Name,
				Email = entity.Email,
			};

		}

		public async Task DeletePrecastAsync(int id)
		{
			var entity = await repository.GetByIdAsync<Deliverer>(id);

			if (await HasOrdersAsync(id))
			{
				throw new DeleteActionException(DeleteDelivererErrorMessage);
			}

			repository.Delete(entity);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> HasOrdersAsync(int id)
		{
			return await repository.AllReadonly<Deliverer>()
				.AnyAsync(d => d.Id == id && d.ReinforceOrders.Count > 0);
		}

		public async Task<bool> IsDelivererExistAsync(int id)
		{
			return await repository.AllReadonly<Deliverer>()
				.AnyAsync(d => d.Id == id);
		}
	}
}
