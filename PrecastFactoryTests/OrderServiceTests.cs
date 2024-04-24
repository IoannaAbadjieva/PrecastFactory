namespace PrecastFactory.UnitTests
{
	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Order;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
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
			precastService = new PrecastService(repository, baseServise);
			orderService = new OrderService(repository, baseServise, precastService);
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
		public void GetOrderToDeleteByIdAsync_ShouldThrowWhenLessThen4DaysToDelivery()
		{
			Assert.ThrowsAsync<DeleteActionException>(() =>
							orderService.GetOrderToDeleteByIdAsync(1));
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
