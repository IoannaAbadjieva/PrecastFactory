namespace PrecastFactory.UnitTests
{
	using Microsoft.EntityFrameworkCore;
	using Moq;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class OrderServiceTests
	{
		private PrecastFactoryDbContext dbContext;
		private IRepository repository;
		private IBaseServise baseServise;
		private IPrecastService precastService;
		private IOrderService orderService;

		[SetUp]
		public void SetUp()
		{
			var contextOptions = new DbContextOptionsBuilder<PrecastFactoryDbContext>()
				.UseInMemoryDatabase("InMemoryDb")
				.Options;

			dbContext = new PrecastFactoryDbContext(contextOptions);

			dbContext.Database.EnsureDeleted();
		
			repository = new Repository(dbContext);
			baseServise = new BaseService(repository);
			precastService = new PrecastService(repository, baseServise);
			orderService = new OrderService(repository, baseServise, precastService);
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
		public async Task GetOrderPrecastReinforceViewModel_ShouldReturnCorrectViewModel()
		{
			var result = await orderService.GetOrderPrecastReinforceViewModel(5);

			Assert.Multiple(() =>
			{
				Assert.That(result.PrecastId, Is.EqualTo(5));
				Assert.That(result.OrderedCount, Is.EqualTo(4));
			});
		}

		[Test]
		public void GetOrderPrecastReinforceViewModel_ShouldThrowExceptionWhenNoReinforce()
		{
			Assert.ThrowsAsync<OrderActionException>(() =>
							orderService.GetOrderPrecastReinforceViewModel(7));
		}

		[Test]
		public void GetOrderPrecastReinforceViewModel_ShouldThrowExceptionWhenNoPrecastCountToBeOrdered()
		{
			Assert.ThrowsAsync<OrderActionException>(() =>
										orderService.GetOrderPrecastReinforceViewModel(4));
		}

		[Test]
		public async Task OrderPrecastAsync_ShouldReturnCorrectViewModel()
		{
			var model = new OrderPrecastReinforceViewModel()
			{

				OrderedCount = 1,
				DepartmentId = 1,
				DelivererId = 1,
				DeliveryDate = DateTime.UtcNow.AddDays(5),
			};

			var result = await orderService.OrderPrecastAsync(2, model);

			Assert.Multiple(() =>
			{
				Assert.That(result.OrderNum, Is.EqualTo(8));
				Assert.That(result.Precast, Is.EqualTo("Precast 2"));
				Assert.That(result.DepartmentId, Is.EqualTo(1));
				Assert.That(result.DelivererId, Is.EqualTo(1));
				Assert.That(result.DeliveryDate.Date, Is.EqualTo(DateTime.UtcNow.AddDays(5).Date));
				Assert.That(result.Reinforce.Count, Is.EqualTo(1));
			});
		}

		[Test]
		public void OrderPrecastAsync_ShouldThrowExceptionWhenNoPrecastCountToBeOrdered()
		{
			Assert.ThrowsAsync<OrderActionException>(async () =>
						await orderService.OrderPrecastAsync(4, new OrderPrecastReinforceViewModel()));
		}

		[Test]
		public void OrderPrecastAsync_ShouldThrowExceptionWhenNoReinforce()
		{
			Assert.ThrowsAsync<OrderActionException>(async () =>
			await orderService.OrderPrecastAsync(10, new OrderPrecastReinforceViewModel()));
		}

		[Test]
		public async Task SaveOrderAsync_ShouldSaveOrder()
		{
			var order = new OrderViewModel()
			{
				PrecastId = 2,
				DepartmentId = 1,
				DelivererId = 1,
				DeliveryDate = DateTime.UtcNow.AddDays(5),
				Count = 1,
				OrderNum = 8
			};

			await orderService.SaveOrderAsync(order);
			var orders = await repository.AllReadonly<ReinforceOrder>().ToArrayAsync();

			Assert.Multiple(() =>
			{
				Assert.That(orders, Has.Length.EqualTo(8));
				Assert.That(orders.Last().Id, Is.EqualTo(8));
				Assert.That(orders.Last().Count, Is.EqualTo(1));
			});
		}

		[Test]
		public async Task GetReinforceOrdersByPrecastAsync_ShouldReturnCorrectOrderDetails()
		{
			var orders = await orderService.GetReinforceOrdersByPrecastAsync(4, currentPage: 1);

			Assert.Multiple(() =>
			{
				Assert.That(orders.TotalOrders, Is.EqualTo(2));
				Assert.That(orders.Orders.Count, Is.EqualTo(2));
				Assert.That(orders.Orders.First().Id, Is.EqualTo(4));
				Assert.That(orders.Orders.Last().Id, Is.EqualTo(7));
			});
		}

		[Test]
		public void CheckOrderToDeleteByIdAsync_ShouldThrowWhenLessThen4DaysToDelivery()
		{
			Assert.ThrowsAsync<DeleteActionException>(() =>
							orderService.CheckOrderToDeleteByIdAsync(1));
		}

		[Test]
		public async Task DeleteAsync_ShouldDeleteOrder()
		{
			await orderService.DeleteAsync(7);
			var orders = await repository.AllReadonly<ReinforceOrder>().ToArrayAsync();

			Assert.Multiple(() =>
			{
				Assert.That(orders, Has.Length.EqualTo(6));
				Assert.That(orders.Any(o => o.Id == 7), Is.False);
			});
		}

		[Test]
		public void DeleteOrderAsync_ShouldThrowWhenLessThan4DaysToDelivery()
		{
			Assert.ThrowsAsync<DeleteActionException>(async () =>
							   await orderService.DeleteOrderAsync(1));
		}

		[Test]
		public async Task IsOrderExistAsync_ShouldReturnTrue()
		{
			var result = await orderService.IsOrderExistAsync(1);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsOrderExistAsync_ShouldReturnFalse()
		{
			var result = await orderService.IsOrderExistAsync(10);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task GetReinforceOrdersAsync_ShouldReturnCorrectOrderDetails()
		{
			var orders = await orderService.GetReinforceOrdersAsync(currentPage: 1, ordersPerPage: 5);

			Assert.Multiple(() =>
			{
				Assert.That(orders.TotalOrders, Is.EqualTo(7));
				Assert.That(orders.Orders.Count, Is.EqualTo(5));
				Assert.That(orders.Orders.First().Id, Is.EqualTo(1));
				Assert.That(orders.Orders.Last().Id, Is.EqualTo(5));
			});
		}

		[Test]
		public async Task GetReinforceOrdersAsync_ShouldReturnCorrectOrderDetailsForSecondPage()
		{
			var orders = await orderService.GetReinforceOrdersAsync(currentPage: 2, ordersPerPage: 5);

			Assert.Multiple(() =>
			{
				Assert.That(orders.TotalOrders, Is.EqualTo(7));
				Assert.That(orders.Orders.Count, Is.EqualTo(2));
				Assert.That(orders.Orders.First().Id, Is.EqualTo(6));
				Assert.That(orders.Orders.Last().Id, Is.EqualTo(7));
			});
		}

		[Test]
		public async Task GetPrecastToReinforceCountAsync_ShouldReturnCorrectWeight()
		{
			decimal countToReinforce = await orderService.GetPrecastToReinforceCountAsync(3);

			Assert.That(countToReinforce, Is.EqualTo(2));
		}
	}
}
