namespace PrecastFactory.UnitTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Deliverer;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class DelivererServiceTests
	{

		private PrecastFactoryDbContext dbContext;
		private IRepository repository;
		private DelivererService delivererService;

		[SetUp]
		public async Task SetUpAsync()
		{
			var contextOptions = new DbContextOptionsBuilder<PrecastFactoryDbContext>()
				.UseInMemoryDatabase("PrecastFactoryInMemory")
				.Options;
			dbContext = new PrecastFactoryDbContext(contextOptions, false);

			dbContext.Database.EnsureDeleted();
			dbContext.Database.EnsureCreated();

			repository = new Repository(dbContext);
			await SeedData.PopulateTestData(repository);
			delivererService = new DelivererService(repository);
		}

		[Test]
		public async Task GetAllDeliverersAsyncShouldReturnAllDeliverers()
		{
			var result = await delivererService.GetAllDeliverersAsync();

			Assert.That(result.Deliverers.Count(), Is.EqualTo(4));
			Assert.That(result.Deliverers.First().Name, Is.EqualTo("Deliverer 1"));
			Assert.That(result.TotalDeliverers, Is.EqualTo(5));
		}

		[Test]
		public async Task GetAllDeliverersAsync_ShouldReturnAllDeliverersWithSearchTerm()
		{
			var result = await delivererService.GetAllDeliverersAsync("Deliverer 1");

			Assert.That(result.Deliverers.Count(), Is.EqualTo(1));
		}

		[Test]
		public async Task GetAllDeliverersAsync_Should_ShouldReturnAllDeliverersWithPaging()
		{
			var result = await delivererService.GetAllDeliverersAsync(currentPage: 2);

			Assert.That(result.Deliverers.Count(), Is.EqualTo(1));
			Assert.That(result.Deliverers.First().Name, Is.EqualTo("Deliverer 5"));
			Assert.That(result.TotalDeliverers, Is.EqualTo(5));
		}

		[Test]
		public async Task AddDelivererAsync_ShouldAddDeliverer()
		{
			var model = new DelivererFormViewModel()
			{
				Name = "Deliverer 6",
				Email = "mail6@mail.com"
			};

			await delivererService.AddDelivererAsync(model);

			var resultCount = await repository.AllReadonly<Deliverer>().CountAsync();
			var deliverer = await repository.GetByIdAsync<Deliverer>(6);

			Assert.That(resultCount, Is.EqualTo(6));
			Assert.That(deliverer.Name, Is.EqualTo("Deliverer 6"));

		}

		[Test]
		public async Task GetDelivererByIdAsync_ShouldReturnDeliverer()
		{
			var result = await delivererService.GetDelivererByIdAsync(3);

			Assert.That(result.Name, Is.EqualTo("Deliverer 3"));
			Assert.That(result.Email, Is.EqualTo("mail3@mail.com"));
		}

		[Test]
		public async Task EditDelivererAsync_ShouldEditDeliverer()
		{
			var model = new DelivererFormViewModel()
			{
				Name = "Deliverer 1 Edited",
				Email = "mail1@mail.com"
			};

			await delivererService.EditDelivererAsync(1, model);

			var deliverer = await repository.GetByIdAsync<Deliverer>(1);

			Assert.That(deliverer.Name, Is.EqualTo("Deliverer 1 Edited"));

		}
		[Test]
		public async Task GetDelivererToDeleteByIdAsync_ShouldReturnDeliverer()
		{
			var result = await delivererService.GetDelivererToDeleteByIdAsync(5);

			Assert.That(result.Name, Is.EqualTo("Deliverer 5"));
			Assert.That(result.Email, Is.EqualTo("mail5@mail.com"));
		}

		[Test]
		public void GetDelivererToDeleteByIdAsync_ShouldThrowWhenDelivererHasOrder()
		{
			Assert.ThrowsAsync<DeleteActionException>(async () =>
			await delivererService.GetDelivererToDeleteByIdAsync(2));
			
		}

		[Test]
		public async Task DeleteDelivererAsync_ShouldDeleteDeliverer()
		{
			await delivererService.DeleteDelivererAsync(5);

			var resultCount = await repository.AllReadonly<Deliverer>().CountAsync();

			Assert.That(resultCount, Is.EqualTo(4));
		}

		[Test]
		public void DeleteDelivererAsync_ShouldThrowWhenDelivererHasOrder()
		{
			Assert.ThrowsAsync<DeleteActionException>(async () =>
			await delivererService.DeleteDelivererAsync(2));
		}


		[Test]
		public async Task HasOrdersAsync_ShouldReturnTrueWhenDelivererHasOrders()
		{
			var result = await delivererService.HasOrdersAsync(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task HasOrdersAsync_ShouldReturnFalseWhenDelivererHasNoOrders()
		{
			var result = await delivererService.HasOrdersAsync(5);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetDelivererEmailAsync_ShouldReturnDelivererEmail()
		{
			var result = await delivererService.GetDelivererEmailAsync(1);

			Assert.That(result, Is.EqualTo("mail1@mail.com"));
		}

		[Test]
		public async Task IsDelivererExistAsync_ShouldReturnTrueWhenDelivererExist()
		{
			var result = await delivererService.IsDelivererExistAsync(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsDelivererExistAsync_ShouldReturnFalseWhenDelivererNotExist()
		{
			var result = await delivererService.IsDelivererExistAsync(16);

			Assert.That(result, Is.False);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}
	}
}
