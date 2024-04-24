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
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class PrecastServiceTests
	{
		private IRepository repository;
		private IBaseServise baseService;
		private IPrecastService precastService;
		private PrecastFactoryDbContext dbContext;

		[SetUp]
		public void Setup()
		{
			var contextOptions = new DbContextOptionsBuilder<PrecastFactoryDbContext>()
				.UseInMemoryDatabase("InMemoryDb")
				.Options;

			dbContext = new PrecastFactoryDbContext(contextOptions);

			dbContext.Database.EnsureDeleted();
		
			repository = new Repository(dbContext);
			baseService = new BaseService(repository);
			precastService = new PrecastService(repository, baseService);

		}

		[SetUp]
		public async Task PopulateTestData()
		{
			await repository.AddRangeAsync<ConcreteClass>(new HashSet<ConcreteClass>
			{
				new ConcreteClass { Id = 1, Name = "ConcreteClass 1" },
				new ConcreteClass { Id = 2, Name = "ConcreteClass 2" },
				new ConcreteClass { Id = 3, Name = "ConcreteClass 3" },
				new ConcreteClass { Id = 4, Name = "ConcreteClass 4" },
				new ConcreteClass { Id = 5, Name = "ConcreteClass 5" },
				new ConcreteClass { Id = 6, Name = "ConcreteClass 6" },
				new ConcreteClass { Id = 7, Name = "ConcreteClass 7" },
				new ConcreteClass { Id = 8, Name = "ConcreteClass 8" },
				new ConcreteClass { Id = 9, Name = "ConcreteClass 9" },
				new ConcreteClass { Id = 10, Name = "ConcreteClass 10" }
			});

			await repository.AddRangeAsync<PrecastType>(new HashSet<PrecastType>
			{
				new PrecastType { Id = 1, Name = "PrecastType 1", PrecastReinforceType = PrecastReinforceType.None },
				new PrecastType { Id = 2, Name = "PrecastType 2", PrecastReinforceType = PrecastReinforceType.None },
				new PrecastType { Id = 3, Name = "PrecastType 3", PrecastReinforceType = PrecastReinforceType.None },
				new PrecastType { Id = 4, Name = "PrecastType 4", PrecastReinforceType = PrecastReinforceType.None },
				new PrecastType { Id = 5, Name = "PrecastType 5", PrecastReinforceType = PrecastReinforceType.None }
			});

			await repository.AddRangeAsync<ReinforceType>(new HashSet<ReinforceType>
			{
				new ReinforceType { Id = 1, ReinforceClass = ReinforceClass.B500C, Diameter = 8, SpecificMass = 0.395m },
				new ReinforceType { Id = 2, ReinforceClass = ReinforceClass.B500C, Diameter = 10, SpecificMass = 0.395m },
				new ReinforceType { Id = 3, ReinforceClass = ReinforceClass.B500B, Diameter = 12, SpecificMass = 0.395m },
				new ReinforceType { Id = 4, ReinforceClass = ReinforceClass.B500B, Diameter = 14, SpecificMass = 0.395m },
				new ReinforceType { Id = 5, ReinforceClass = ReinforceClass.B500C, Diameter = 16, SpecificMass = 0.395m }
			});
			await repository.AddRangeAsync<Project>(new HashSet<Project>()
			{
					new Project { Id = 1, Name = "Project 1" },
					new Project { Id = 2, Name = "Project 2" },
					new Project { Id = 3, Name = "Project 3" },
					new Project { Id = 4, Name = "Project 4" },
					new Project { Id = 5, Name = "Project 5" }
			});

			await repository.AddRangeAsync<Department>(new HashSet<Department>()
			{
					new Department { Id = 1, Name = "Department 1" },
					new Department { Id = 2, Name = "Department 2" },
					new Department { Id = 3, Name = "Department 3" },
					new Department { Id = 4, Name = "Department 4" },

			});

			await repository.AddRangeAsync<Precast>(new HashSet<Precast>()
			{
				new Precast { Id = 1, Name = "Precast 1",PrecastTypeId = 1, ProjectId = 1, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 2, Name = "Precast 2",PrecastTypeId = 1, ProjectId = 1, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 3, Name = "Precast 3",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 4, Name = "Precast 4",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 5, Name = "Precast 5",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 6, Name = "Precast 6",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 7, Name = "Precast 7",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 8, Name = "Precast 8",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 9, Name = "Precast 9",PrecastTypeId = 1, ProjectId = 2, Count = 10 ,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9,ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 10, Name = "Precast 10",PrecastTypeId = 1, ProjectId = 2, Count = 10,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9, ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 11, Name = "Precast 11",PrecastTypeId = 1, ProjectId = 2, Count = 10,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9, ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 12, Name = "Precast 12",PrecastTypeId = 1, ProjectId = 2, Count = 10,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9, ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 13, Name = "Precast 13",PrecastTypeId = 1, ProjectId = 2, Count = 10,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9, ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m},
				new Precast { Id = 14, Name = "Precast 14",PrecastTypeId = 1, ProjectId = 2, Count = 10,AddedOn = DateTime.Now.AddDays(-7),ConcreteClassId = 9, ConcreteProjectAmount = 1.62m,ReinforceProjectWeight = 100m}
			});

			await repository.AddRangeAsync<ReinforceOrder>(new HashSet<ReinforceOrder>()
			{
				new ReinforceOrder { Id = 1, DelivererId = 1, DepartmentId = 1, Count = 10, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4) },
				new ReinforceOrder { Id = 2, DelivererId = 1, DepartmentId = 2, Count = 9, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4)  },
				new ReinforceOrder { Id = 3, DelivererId = 1, DepartmentId = 3, Count = 8, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4)  },
				new ReinforceOrder { Id = 4, DelivererId = 1, DepartmentId = 1, Count = 7, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4)  },
				new ReinforceOrder { Id = 5, DelivererId = 2, DepartmentId = 2, Count = 6, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4)  },
				new ReinforceOrder { Id = 6, DelivererId = 1, DepartmentId = 3, Count = 10, OrderDate = DateTime.Now.AddDays(-6), DeliverDate = DateTime.Now.AddDays(-4)  },
				new ReinforceOrder { Id = 7, DelivererId = 1, DepartmentId = 4, Count = 3, OrderDate = DateTime.Now.AddDays(-2), DeliverDate = DateTime.Now.AddDays(2) ,},
			});

			await repository.AddRangeAsync<PrecastReinforceOrder>(new HashSet<PrecastReinforceOrder>()
			{
					new PrecastReinforceOrder { ReinforceOrderId = 1 ,PrecastId = 1 },
					new PrecastReinforceOrder { ReinforceOrderId = 2 ,PrecastId = 2 },
					new PrecastReinforceOrder { ReinforceOrderId = 3 ,PrecastId = 3 },
					new PrecastReinforceOrder { ReinforceOrderId = 4 ,PrecastId = 4 },
					new PrecastReinforceOrder { ReinforceOrderId = 5 ,PrecastId = 5 },
					new PrecastReinforceOrder { ReinforceOrderId = 6 ,PrecastId = 6 },
					new PrecastReinforceOrder { ReinforceOrderId = 7, PrecastId = 4 },
			});

			await repository.AddRangeAsync<Deliverer>(new HashSet<Deliverer>()
			{
					new Deliverer { Id = 1, Name = "Deliverer 1",Email = "mail1@mail.com"},
					new Deliverer { Id = 2, Name = "Deliverer 2",Email = "mail2@mail.com"},
					new Deliverer { Id = 3, Name = "Deliverer 3",Email = "mail3@mail.com"},
					new Deliverer { Id = 4, Name = "Deliverer 4",Email = "mail4@mail.com"},
					new Deliverer { Id = 5, Name = "Deliverer 5",Email = "mail5@mail.com"}
			});

			await repository.AddRangeAsync<PrecastDepartment>(new HashSet<PrecastDepartment>()
			{
					new PrecastDepartment { Id = 1, DepartmentId = 1, PrecastId = 1, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 2, DepartmentId = 2, PrecastId = 2, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 3, DepartmentId = 3, PrecastId = 3, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 4, DepartmentId = 1, PrecastId = 4, Count = 4, Date = DateTime.Now },
					new PrecastDepartment { Id = 5, DepartmentId = 2, PrecastId = 5, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 6, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 7, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 8, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 9, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 10, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 11, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 12, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 13, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 14, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
					new PrecastDepartment { Id = 15, DepartmentId = 3, PrecastId = 6, Count = 1, Date = DateTime.Now },
			});

			await repository.AddRangeAsync<PrecastReinforce>(new HashSet<PrecastReinforce>()
			{
				new PrecastReinforce {Id = 1, PrecastId = 1, Position = "1", Count = 1, ReinforceTypeId = 1, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 2, PrecastId = 2, Position = "2", Count = 1, ReinforceTypeId = 2, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 3, PrecastId = 3, Position = "3", Count = 1, ReinforceTypeId = 3, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 4, PrecastId = 4, Position = "4", Count = 1, ReinforceTypeId = 4, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 5, PrecastId = 5, Position = "5", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 6, PrecastId = 5, Position = "6", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 7, PrecastId = 5, Position = "7", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 8, PrecastId = 5, Position = "8", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 9, PrecastId = 5, Position = "9", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 10, PrecastId = 5, Position = "10", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 11, PrecastId = 5, Position = "11", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 12, PrecastId = 5, Position = "12", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 13, PrecastId = 5, Position = "13", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 14, PrecastId = 5, Position = "14", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 15, PrecastId = 5, Position = "15", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
				new PrecastReinforce {Id = 16, PrecastId = 5, Position = "16", Count = 1, ReinforceTypeId = 5, Length = 1m, Weight = 1m },
			});

			await repository.SaveChangesAsync();
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