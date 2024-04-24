namespace PrecastFactory.UnitTests
{
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class PrecastServiceTests
	{
		private IRepository repository;
		private IBaseServise baseService;
		private IPrecastService precastService;
		private PrecastFactoryDbContext dbContext;

		[SetUp]
		public async Task SetupAsync()
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

		}

		[Test]
		public async Task GetAllPrecastAsync_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync();
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(12));
				Assert.That(precast.Precast.Any(p => p.Id == 14), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 1), Is.False);
				Assert.That(precast.TotalPrecast, Is.EqualTo(14));
			});
		}

		[Test]
		public async Task GetAllPrecastAsync_WithSearchTerm_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync("Precast 2");
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(1));
				Assert.That(precast.Precast.Any(p => p.Id == 2), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 1), Is.False);
				Assert.That(precast.TotalPrecast, Is.EqualTo(1));
			});
		}

		[Test]
		public async Task GetAllPrecastAsync_WithProjectId_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync(projectId: 1);
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(2));
				Assert.That(precast.Precast.Any(p => p.Id == 1), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 2), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 3), Is.False);
				Assert.That(precast.TotalPrecast, Is.EqualTo(2));
			});
		}

		[Test]
		public async Task GetAllPrecastAsync_WithPrecastTypeId_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync(precastTypeId: 1);
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(12));
				Assert.That(precast.Precast.Any(p => p.Id == 10), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 3), Is.True);
				Assert.That(precast.Precast.Any(p => p.Id == 2), Is.False);
				Assert.That(precast.TotalPrecast, Is.EqualTo(14));
			});
		}

		[Test]
		public async Task GetAllPrecastAsync_WithSorting_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync(sorting: PrecastSorting.ByProject);
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(12));
				Assert.That(precast.Precast.First().Id, Is.EqualTo(1));
				Assert.That(precast.Precast.Last().Id, Is.EqualTo(7));
				Assert.That(precast.TotalPrecast, Is.EqualTo(14));
			});
		}

		[Test]
		public async Task GetAllPrecastAsync_WithPaging_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetAllPrecastAsync(currentPage: 2);
			Assert.Multiple(() =>
			{
				Assert.That(precast.Precast.Count(), Is.EqualTo(2));
				Assert.That(precast.Precast.First().Id, Is.EqualTo(2));
				Assert.That(precast.TotalPrecast, Is.EqualTo(14));
			});
		}

		[Test]
		public async Task AddPrecastAsync_ShouldAddPrecastAsync()
		{
			var precast = new PrecastFormViewModel
			{
				Name = "Precast 15",
				PrecastTypeId = 1,
				ProjectId = 2,
				Count = 10,
				ConcreteClassId = 9,
				ConcreteProjectAmount = 1.62m,
				ReinforceProjectAmount = 100m
			};

			await precastService.AddPrecastAsync(precast);

			var precastFromDb = await repository.GetByIdAsync<Precast>(15);

			Assert.Multiple(() =>
			{
				Assert.That(precastFromDb, Is.Not.Null);
				Assert.That(precastFromDb.Name, Is.EqualTo("Precast 15"));
				Assert.That(precastFromDb.PrecastTypeId, Is.EqualTo(1));
				Assert.That(precastFromDb.ProjectId, Is.EqualTo(2));
				Assert.That(precastFromDb.Count, Is.EqualTo(10));
				Assert.That(precastFromDb.AddedOn, Is.EqualTo(DateTime.Now).Within(1).Seconds);
				Assert.That(precastFromDb.ConcreteClassId, Is.EqualTo(9));
				Assert.That(precastFromDb.ConcreteProjectAmount, Is.EqualTo(1.62m));
				Assert.That(precastFromDb.ReinforceProjectWeight, Is.EqualTo(100m));
			});
		}

		[Test]
		public async Task GetPrecastByIdAsync_ShouldReturnCorrectPrecastAsync()
		{
			var precast = await precastService.GetPrecastByIdAsync(2);

			Assert.That(precast.Name, Is.EqualTo("Precast 2"));
		}

		[Test]
		public async Task EditPrecastAsync_ShouldEditPrecastAsync()
		{
			var model = new PrecastFormViewModel
			{
				Name = "Precast 15",
				PrecastTypeId = 1,
				ProjectId = 2,
				Count = 10,
				ConcreteClassId = 9,
				ConcreteProjectAmount = 1.62m,
				ReinforceProjectAmount = 100m
			};

			await precastService.EditPrecastAsync(2, model);

			var precast
				= await repository.GetByIdAsync<Precast>(2);

			Assert.Multiple(() =>
			{
				Assert.That<string>(precast.Name, Is.EqualTo("Precast 15"));
				Assert.That(precast.PrecastTypeId, Is.EqualTo(1));
				Assert.That(precast.ProjectId, Is.EqualTo(2));
				Assert.That(precast.Count, Is.EqualTo(10));
				Assert.That(precast.ConcreteClassId, Is.EqualTo(9));
				Assert.That(precast.ConcreteProjectAmount, Is.EqualTo(1.62m));
				Assert.That((decimal)precast.ReinforceProjectWeight, Is.EqualTo(100m));
			});
		}
		[Test]
		public void GetPrecastToDeleteByIdAsync_ShouldThrowWhenReinforced()
		{
			Assert.ThrowsAsync<DeleteActionException>(() =>
			precastService.GetPrecastToDeleteByIdAsync(2));
		}

		[Test]
		public async Task GetPrecastToDeleteByIdAsync_ShouldReturnCorrectModel()
		{
			await precastService.GetPrecastToDeleteByIdAsync(7);

			var precast = await repository.GetByIdAsync<Precast>(7);
			Assert.Multiple(() =>
			{
				Assert.That(precast.Id, Is.EqualTo(7));
				Assert.That(precast.Name, Is.EqualTo("Precast 7"));
			});
		}

		[Test]
		public void DeletePrecastAsync_ShouldThrowWhenReinforced()
		{
			Assert.ThrowsAsync<DeleteActionException>(() =>
			precastService.DeletePrecastAsync(2));

		}

		[Test]
		public async Task DeletePrecastAsync_ShouldDeletePrecastAsync()
		{
			await precastService.DeletePrecastAsync(7);

			var precast = await repository.GetByIdAsync<Precast>(7);

			Assert.That(precast, Is.Null);
		}

		[Test]
		public async Task GetPrecastDetails_ShouldReturnCorrectPrecastDetailsAsync()
		{
			var precastDetails = await precastService.GetPrecastDetailsAsync(3);

			Assert.Multiple(() =>
			{
				Assert.That(precastDetails!.Id, Is.EqualTo(3));
				Assert.That(precastDetails.Name, Is.EqualTo("Precast 3"));
				Assert.That(precastDetails.PrecastType, Is.EqualTo("PrecastType 1"));
				Assert.That(precastDetails.Project, Is.EqualTo("Project 2"));
				Assert.That(precastDetails.Count, Is.EqualTo(10));
				Assert.That(precastDetails.ConcreteClass, Is.EqualTo("ConcreteClass 9"));
				Assert.That(precastDetails.ConcreteProjectAmount, Is.EqualTo(1.62m));
				Assert.That(precastDetails.ReinforceProjectAmount, Is.EqualTo(100m));
			});
		}

		[Test]
		public async Task GetReinforceAsync_ShouldReturnCorrectReinforceAsync()
		{
			var reinforce = await precastService.GetPrecastReinforceAsync(3);

			Assert.Multiple(() =>
			{
				Assert.That(reinforce.TotalReinforce, Is.EqualTo(1));
				Assert.That(reinforce.Reinforce.First().Id, Is.EqualTo(3));
				Assert.That(reinforce.Reinforce.First().PrecastId, Is.EqualTo(3));

			});
		}

		[Test]
		public async Task GetReinforceAsync_WithPaging_ShouldReturnCorrectReinforceAsync()
		{
			var reinforce = await precastService.GetPrecastReinforceAsync(5);

			Assert.Multiple(() =>
			{
				Assert.That(reinforce.TotalReinforce, Is.EqualTo(12));
				Assert.That(reinforce.Reinforce.Count, Is.EqualTo(7));
				Assert.That(reinforce.Reinforce.First().Id, Is.EqualTo(5));
				Assert.That(reinforce.Reinforce.First().PrecastId, Is.EqualTo(5));
			});
		}

		[Test]
		public async Task GetReinforceAsync_WithPaging_ShouldReturnCorrectReinforceRecordsAsync()
		{
			var reinforce = await precastService.GetPrecastReinforceAsync(5, currentPage: 2);

			Assert.Multiple(() =>
			{
				Assert.That(reinforce.TotalReinforce, Is.EqualTo(12));
				Assert.That(reinforce.Reinforce.Count, Is.EqualTo(5));
				Assert.That(reinforce.Reinforce.First().Id, Is.EqualTo(12));
				Assert.That(reinforce.Reinforce.First().PrecastId, Is.EqualTo(5));
			});
		}

		[Test]
		public async Task GetPrecastProductionAsync_ShouldReturnCorrectProductionRecordsAsync()
		{
			var production = await precastService.GetPrecastProductionAsync(6);

			Assert.Multiple(() =>
			{
				Assert.That(production.Precast.Count, Is.EqualTo(7));
				Assert.That(production.TotalPrecast, Is.EqualTo(10));
				Assert.That(production.Precast.First().Id, Is.EqualTo(6));
				Assert.That(production.Precast.First().PrecastId, Is.EqualTo(6));
			});
		}

		[Test]
		public async Task GetPrecastProductionAsync_WithPaging_ShouldReturnCorrectProductionRecordsAsync()
		{
			var production = await precastService.GetPrecastProductionAsync(6, currentPage: 2);

			Assert.Multiple(() =>
			{
				Assert.That(production.Precast.Count, Is.EqualTo(3));
				Assert.That(production.TotalPrecast, Is.EqualTo(10));
				Assert.That(production.Precast.First().Id, Is.EqualTo(13));
				Assert.That(production.Precast.First().PrecastId, Is.EqualTo(6));
			});
		}

		[Test]
		public async Task GetReinforcedPrecastCountAsync_ShouldReturnCorrectCountAsync()
		{
			var reinforcedCount = await precastService.GetReinforcedPrecastCountAsync(5);

			Assert.That(reinforcedCount, Is.EqualTo(6));
		}

		[Test]
		public async Task GetReinforcedPrecastCountAsync_ShouldReturnZeroWhenNoReinforcedAsync()
		{
			var reinforcedCount = await precastService.GetReinforcedPrecastCountAsync(10);

			Assert.That(reinforcedCount, Is.EqualTo(0));
		}

		[Test]
		public async Task IsPrecastExist_ShouldReturnTrueWhenExistAsync()
		{
			var isExist = await precastService.IsPrecastExist(5);

			Assert.That(isExist, Is.True);
		}

		[Test]
		public async Task IsPrecastExist_ShouldReturnFalseWhenNotExistAsync()
		{
			var isExist = await precastService.IsPrecastExist(25);

			Assert.That(isExist, Is.False);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

	}

}