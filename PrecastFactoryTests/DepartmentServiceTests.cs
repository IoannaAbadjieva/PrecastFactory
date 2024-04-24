namespace PrecastFactory.UnitTests
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;

	[TestFixture]
	public class DepartmentServiceTests
	{
		private PrecastFactoryDbContext dbContext;
		private IRepository repository;
		private IDepartmentService departmentService;

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
			departmentService = new DepartmentService(repository);
		}

		[Test]
		public async Task GetDailyProductionAsync_ShouldReturnDailyProduction()
		{

			var result = await departmentService.GetDailyProductionAsync();

			Assert.That(result.Count(), Is.EqualTo(6));
			Assert.That(result.First().ProjectName, Is.EqualTo("Project 1"));
			Assert.That(result.First().PrecastTypeId, Is.EqualTo(1));
			Assert.That(result.First().PrecastId, Is.EqualTo(1));
			Assert.That(result.First().PrecastName, Is.EqualTo("Precast 1"));
			Assert.That(result.First().Count, Is.EqualTo(1));
			Assert.That(result.First().Department, Is.EqualTo("Department 1"));
		}

		[Test]
		public async Task GetMonthlyProductionAsync_ShouldReturnMonthlyProduction()
		{
			var month = DateTime.Now;

			var result = await departmentService.GetMonthlyProductionAsync(month, projectId: null, departmentId: null);

			Assert.That(result.Precast.Count(), Is.EqualTo(6));
			Assert.That(result.Precast.First().ProjectName, Is.EqualTo("Project 1"));
			Assert.That(result.Precast.First().PrecastId, Is.EqualTo(1));
			Assert.That(result.Precast.First().PrecastName, Is.EqualTo("Precast 1"));
			Assert.That(result.Precast.Last().Count, Is.EqualTo(10));
		}

		[Test]
		public async Task GetMonthlyProductionAsync_ShouldReturnMonthlyProductionWithProjectId()
		{
			var month = DateTime.Now;

			var result = await departmentService.GetMonthlyProductionAsync(month, projectId: 2, departmentId: 2);

			Assert.That(result.Precast.Count(), Is.EqualTo(1));
			Assert.That(result.Precast.First().ProjectName, Is.EqualTo("Project 2"));
			Assert.That(result.Precast.First().PrecastId, Is.EqualTo(5));
			Assert.That(result.Precast.Last().Count, Is.EqualTo(1));
		}

		[Test]
		public async Task GetPrecastProductionDetailsAsync_ShouldReturnPrecastProductionDetails()
		{

			var result = await departmentService.GetPrecastProductionDetailsAsync(6);

			Assert.That(result.ProjectName, Is.EqualTo("Project 2"));
			Assert.That(result.PrecastId, Is.EqualTo(6));
			Assert.That(result.PrecastName, Is.EqualTo("Precast 6"));
			Assert.That(result.TotalRecords, Is.EqualTo(10));
			Assert.That(result.Produced.First().Department, Is.EqualTo("Department 3"));
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}
	}


}
