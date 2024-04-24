namespace PrecastFactorySystem.Core.Services
{
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Core.Models.Deliverer;

	using static Constants.MessageConstants;

	public class DelivererService : IDelivererService
	{
		private readonly IRepository repository;

		public DelivererService(IRepository _repository)
		{
			repository = _repository;
		}


		public async Task<DeliverersQueryModel> GetAllDeliverersAsync(
			string? searchTerm = null,
			int currentPage = 1,
			int deliverersPerPage = 4)

		{
			var query = repository.AllReadonly<Deliverer>();

			var search = searchTerm?.ToLower();

			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(d => d.Name.ToLower().Contains(search)
				|| d.Email.ToLower().Contains(search));
			}

			query = query.OrderBy(d => d.Name);

			var totalDeliverers = await query.CountAsync();

			var deliverers = await query
				.Skip((currentPage - 1) * deliverersPerPage)
				.Take(deliverersPerPage)
				.Select(d => new DelivererInfoViewModel()
				{
					Id = d.Id,
					Name = d.Name,
					Email = d.Email,
					OrdersCount = d.ReinforceOrders.Count(),
				}).ToArrayAsync();

			return new DeliverersQueryModel()
			{
				TotalDeliverers = totalDeliverers,
				Deliverers = deliverers,
			};
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

		public async Task DeleteDelivererAsync(int id)
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

		public Task<string?> GetDelivererEmailAsync(int id)
		{
			return repository.AllReadonly<Deliverer>()
				.Where(d => d.Id == id)
				.Select(d => d.Email)
				.FirstOrDefaultAsync();
		}

		public async Task<bool> IsDelivererExistAsync(int id)
		{
			return await repository.AllReadonly<Deliverer>()
				.AnyAsync(d => d.Id == id);
		}

	}
}
