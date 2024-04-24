namespace PrecastFactory.UnitTests
{
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.Reinforce;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class ReinforceServiceTests
	{
		private PrecastFactoryDbContext dbContext;
		private IRepository repository;
		private IBaseServise baseServise;
		private IReinforceService reinforceService;

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
			baseServise = new BaseService(repository);
			reinforceService = new ReinforceService(repository, baseServise);
		}

		[Test]
		public async Task AddReinforceAsync_ShouldAddReinforce()
		{
			var precastId = 1;
			var model = new ReinforceFormViewModel()
			{
				Count = 1,
				Position = "1",
				Length = 1m,
				ReinforceTypeId = 1,
				SpecificMass = 1m
			};

			await reinforceService.AddReinforceAsync(precastId, model);

			var reinforce = await repository.All<PrecastReinforce>()
				.FirstOrDefaultAsync();

			Assert.That(reinforce.PrecastId, Is.EqualTo(precastId));
			Assert.That(reinforce.Count, Is.EqualTo(model.Count));
			Assert.That(reinforce.Position, Is.EqualTo(model.Position));
			Assert.That(reinforce.Length, Is.EqualTo(model.Length));
			Assert.That(reinforce.ReinforceTypeId, Is.EqualTo(model.ReinforceTypeId));
			Assert.That(reinforce.Weight, Is.EqualTo(model.Count * model.Length * model.SpecificMass));
		}

		[Test]
		public async Task GetReinforceByIdAsync_ShouldReturnReinforce()
		{
			var reinforce = await reinforceService.GetReinforceByIdAsync(16);

			Assert.That(reinforce!.PrecastId, Is.EqualTo(5));
			Assert.That(reinforce.Count, Is.EqualTo(1));
			Assert.That(reinforce.Position, Is.EqualTo("16"));
			Assert.That(reinforce.Length, Is.EqualTo(1m));
			Assert.That(reinforce.ReinforceTypeId, Is.EqualTo(5));

		}

		[Test]
		public async Task EditReinforceAsync_ShouldEditReinforce()
		{
			var id = 16;
			var model = new ReinforceFormViewModel()
			{
				Count = 2,
				Position = "16",
				Length = 2m,
				ReinforceTypeId = 2,
				SpecificMass = 2m
			};

			var precastId = await reinforceService.EditReinforceAsync(id, model);

			var reinforce = await repository.GetByIdAsync<PrecastReinforce>(id);

			Assert.That(reinforce.Count, Is.EqualTo(model.Count));
			Assert.That(reinforce.Position, Is.EqualTo(model.Position));
			Assert.That(reinforce.Length, Is.EqualTo(model.Length));
			Assert.That(reinforce.ReinforceTypeId, Is.EqualTo(model.ReinforceTypeId));
			Assert.That(reinforce.Weight, Is.EqualTo(model.Count * model.Length * model.SpecificMass));
			Assert.That(precastId, Is.EqualTo(reinforce.PrecastId));
		}

		[Test]
		public async Task DeleteReinforceAsync_ShouldDeleteReinforce()
		{
			var id = 16;

			await reinforceService.DeleteReinforceAsync(id);

			var reinforce = await repository.GetByIdAsync<PrecastReinforce>(id);

			Assert.That(reinforce, Is.Null);
		}

		[Test]
		public async Task IsReinforceExist_ShouldReturnTrueWhenExists()
		{
			var result = await reinforceService.IsReinforceExist(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsReinforceExist_ShouldReturnFalseWhenNotExists()
		{
			var result = await reinforceService.IsReinforceExist(100);

			Assert.That(result, Is.False);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

	}

}
