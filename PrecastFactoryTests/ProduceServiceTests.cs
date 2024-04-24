namespace PrecastFactory.UnitTests
{
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Core.Models.Produce;
	using PrecastFactorySystem.Infrastructure.Data.Models;
	using PrecastFactorySystem.Core.Exceptions;

	[TestFixture]
	public class ProduceServiceTests
	{
		private PrecastFactoryDbContext dbContext;
		private IRepository repository;
		private IBaseServise baseService;
		private IPrecastService precastService;
		private IProduceService produceService;

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
			baseService = new BaseService(repository);
			precastService = new PrecastService(repository, baseService);
			produceService = new ProduceService(repository, baseService);

		}

		[Test]
		public async Task GetProductionFormAsync_ShouldReturnProductionForm()
		{
			var result = await produceService.GetProductionFormAsync(1);
			Assert.Multiple(() =>
			{
				Assert.That(result.PrecastId, Is.EqualTo(1));
				Assert.That(result.ProducedCount, Is.EqualTo(9));
			});
		}

		[Test]
		public void GetProductionFormAsync_ShouldThrowExceptionWhenProduced()
		{
			Assert.ThrowsAsync<ProduceActionException>(() => 
			produceService.GetProductionFormAsync(6));
		}

		[Test]
		public void GetProductionFormAsync_ShouldThrowExceptionWhenNoreinforce()
		{
			Assert.ThrowsAsync<ProduceActionException>(() => 
			produceService.GetProductionFormAsync(10));
		}

		[Test]
		public async Task ProducePrecastAsync_ShouldProducePrecast()
		{
			var model = new ProduceFormViewModel()
			{
				ProducedCount = 1,
				DepartmentId = 1
			};

			await produceService.ProducePrecastAsync(1, model);

			var produced = repository.AllReadonly<PrecastDepartment>(p => p.PrecastId == 1);
			Assert.Multiple(() =>
			{
				Assert.That(produced.Count(), Is.EqualTo(2));
				Assert.That(produced.Last().Count, Is.EqualTo(model.ProducedCount));
			});
			Assert.That(produced.Last().Id, Is.EqualTo(16));
		}

		[Test]
		public void ProducePrecastAsync_ShouldThrowExceptionWhenProduced()
		{
			Assert.ThrowsAsync<ProduceActionException>(async () =>
			await produceService.ProducePrecastAsync(6, new ProduceFormViewModel()));
		}

		[Test]
		public void ProducePrecastAsync_ShouldThrowExceptionWhenNoreinforce()
		{
			Assert.ThrowsAsync<ProduceActionException>(async () =>
			await produceService.ProducePrecastAsync(10, new ProduceFormViewModel()));
		}




		[Test]
		public async Task GetProductionRecordByIdAsync_ShouldReturnProductionRecord()
		{
			var result = await produceService.GetProductionRecordByIdAsync(4);
			Assert.Multiple(() =>
			{
				Assert.That(result.PrecastId, Is.EqualTo(4));
				Assert.That(result.ProducedCount, Is.EqualTo(4));
				Assert.That(result.DepartmentId, Is.EqualTo(1));
			});
		}

		[Test]
		public async Task EditProductionRecordAsync_ShouldEditProductionRecord()
		{
			var id = 5;
			var model = new ProduceFormViewModel()
			{
				PrecastId = 5,
				ProducedCount = 2,
				DepartmentId = 1
			};

			await produceService.EditProductionRecordAsync(id, model);

			var record = await repository.GetByIdAsync<PrecastDepartment>(id);

			Assert.Multiple(() =>
			{
				Assert.That(record.Count, Is.EqualTo(model.ProducedCount));
				Assert.That(record.DepartmentId, Is.EqualTo(model.DepartmentId));
			});
		}

		[Test]
		public async Task DeleteProductionRecordAsync_ShouldDeleteRecord()
		{
			var id = 5;

			await produceService.DeleteProductionRecordAsync(id);

			var record = await repository.GetByIdAsync<PrecastDepartment>(id);

			Assert.That(record, Is.Null);
		}

		[Test]
		public async Task GetPrecastToProduceCountAsync_ShouldReturnPrecastToProduceCount_WithoutEditedRecordCount()
		{
			var result = await produceService.GetPrecastToProduceCountAsync(1, 1);

			Assert.That(result, Is.EqualTo(10));
		}

		[Test]
		public async Task GetPrecastToProduceCountAsync_ShouldReturnPrecastToProduceCount()
		{
			var result = await produceService.GetPrecastToProduceCountAsync(1, null);

			Assert.That(result, Is.EqualTo(9));
		}

		[Test]
		public async Task GetProducedPrecastCountAsync_ShouldReturnProducedPrecastCount()
		{
			var result = await produceService.GetProducedPrecastCountAsync(6, null);

			Assert.That(result, Is.EqualTo(10));
		}

		[Test]
		public async Task GetProducedPrecastCountAsync_ShouldReturnProducedPrecastCount_WithoutEditedRecordCount()
		{
			var result = await produceService.GetProducedPrecastCountAsync(6, 10);

			Assert.That(result, Is.EqualTo(9));
		}

		[Test]
		public async Task GetFirstOrderDeliveryDate_ShouldGetCorrectDate()
		{
			var result = await produceService.GetFirstOrderDeliveryDate(4);

			Assert.That(result.Date, Is.EqualTo(DateTime.Now.AddDays(-4).Date));
		}

		[Test]
		public async Task IsProductionRecordExist_ShouldReturnTrueWhenExist()
		{
			var result = await produceService.IsProductionRecordExist(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsProductionRecordExist_ShouldReturnFalseWhenNotExist()
		{
			var result = await produceService.IsProductionRecordExist(100);

			Assert.That(result, Is.False);
		}
	}
}
