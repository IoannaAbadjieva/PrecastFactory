﻿namespace PrecastFactory.UnitTests
{
	using System.Linq;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;

	using NUnit.Framework.Internal;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Enumeration;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.Precast;
	using PrecastFactorySystem.Core.Models.Project;
	using PrecastFactorySystem.Core.Services;
	using PrecastFactorySystem.Infrastructure.Data;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Enums;
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class ProjectServiceTest
	{
		private IRepository repository;
		private IProjectService projectService;
		private PrecastFactoryDbContext dbContext;

		[SetUp]
		public void SetUp()
		{
			var contextOptions = new DbContextOptionsBuilder<PrecastFactoryDbContext>()
				.UseInMemoryDatabase("InMemoryDb")
				.Options;
			dbContext = new PrecastFactoryDbContext(contextOptions);

			dbContext.Database.EnsureDeleted();
			
			repository = new Repository(dbContext);
			projectService = new ProjectService(repository);

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
					new Project { Id = 1,ProdNumber = "24 - 101", Name = "Project 1" },
					new Project { Id = 2,ProdNumber = "24 - 102", Name = "Project 2" },
					new Project { Id = 3,ProdNumber = "24 - 103", Name = "Project 3" },
					new Project { Id = 4,ProdNumber = "24 - 104", Name = "Project 4" },
					new Project { Id = 5,ProdNumber = "24 - 105", Name = "Project 5" }
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
		public async Task GetAllProjectsAsync_ShouldReturnCorrectProjectsAsync()
		{
			var projects = await projectService.GetAllProjectsAsync();

			
			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(4));
				Assert.That(projects.Projects.Any(p => p.Id == 5), Is.True);
				Assert.That(projects.Projects.Any(p => p.Id == 1), Is.False);
				Assert.That(projects.TotalProjects, Is.EqualTo(5));
			});
		}

		[Test]
		public async Task GetAllProjectsAsync_WithSearchTerm_ShouldReturnCorrectProjectsAsync()
		{
			var projects = await projectService.GetAllProjectsAsync("Project 2");

			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(1));
				Assert.That(projects.Projects.Any(p => p.Id == 2), Is.True);
				Assert.That(projects.TotalProjects, Is.EqualTo(1));
			});
		}

		[Test]
		public async Task GetAllProjectsAsync_WithSorting_ShouldReturnCorrectProjectsAsync()
		{
			var projects = await projectService.GetAllProjectsAsync(sorting: ProjectSorting.Name);

			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(4));
				Assert.That(projects.Projects.First().Id, Is.EqualTo(1));
				Assert.That(projects.Projects.Last().Id, Is.EqualTo(4));
				Assert.That(projects.TotalProjects, Is.EqualTo(5));
			});
		}

		[Test]
		public async Task GetAllProjectsAsync_WithPaging_ShouldReturnCorrectProjectsAsync()
		{
			var projects = await projectService.GetAllProjectsAsync(currentPage: 2);

			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(1));
				Assert.That(projects.Projects.First().Id, Is.EqualTo(1));
				Assert.That(projects.TotalProjects, Is.EqualTo(5));
			});

		}

		[Test]
		public async Task AddProjectAsync_ShouldAddProjectAsync()
		{
			var model = new ProjectFormViewModel()
			{
				Name = "Project 6",
			};

			await projectService.AddProjectAsync(model);

			var projects = await projectService.GetAllProjectsAsync();
			var project = await repository.GetByIdAsync<Project>(6);
			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(4));
				Assert.That(projects.Projects.Any(p => p.Name == "Project 6"), Is.True);
				Assert.That(projects.TotalProjects, Is.EqualTo(6));
			});
		}

		[Test]
		public async Task GetProjectByIdAsync_ShouldReturnCorrectProjectAsync()
		{
			var project = await projectService.GetProjectByIdAsync(2);

			Assert.That(project.Name, Is.EqualTo("Project 2"));
		}

		[Test]
		public async Task EditProjectAsync_ShouldEditProjectAsync()
		{
			var model = new ProjectFormViewModel()
			{
				Name = "Project 6",
			};

			await projectService.EditProjectAsync(2, model);

			var project = await repository.GetByIdAsync<Project>(2);

			Assert.That(project.Name, Is.EqualTo("Project 6"));
		}

		[Test]
		public async Task AddPrecastToProjectAsync_ShouldAddPrecastToProjectAsync()
		{
			var model = new PrecastFormViewModel()
			{
				Name = "Precast 15",
				Count = 10,
				PrecastTypeId = 1,
			};

			await projectService.AddPrecastToProjectAsync(model, 1);

			var project = await repository.GetByIdAsync<Project>(1);

			Assert.Multiple(() =>
			{
				Assert.That(project.ProjectPrecast, Has.Count.EqualTo(3));
				Assert.That(project.ProjectPrecast.Any(p => p.Name == "Precast 15"), Is.True);
			});
		}

		[Test]
		public async Task GetProjectDetails_ShouldReturnCorrectProjectDetailsAsync()
		{
			var projectDetails = await projectService.GetProjectDetails(1);

			Assert.Multiple(() =>
				{
					Assert.That(projectDetails.Id, Is.EqualTo(1));
					Assert.That(projectDetails.Name, Is.EqualTo("Project 1"));
				});
		}

		[Test]
		public async Task GetProjectToDeleteByIdAsync_ShouldReturnCorrectProjectInfoViewModel()
		{
			var project = await projectService.GetProjectToDeleteByIdAsync(4);

			Assert.Multiple(() =>
			{
				Assert.That(project.Id, Is.EqualTo(4));
				Assert.That(project.Name, Is.EqualTo("Project 4"));
				Assert.That(project.PrecastCount, Is.EqualTo(0));
			});
		}

		[Test]
		public void GetProjectToDeleteByIdAsync_ShouldThrow_WhenPrecastReinforced()
		{
			Assert.ThrowsAsync<DeleteActionException>(async () => 
			await projectService.GetProjectToDeleteByIdAsync(1));
		}

		[Test]
		public async Task DeleteProjectAsync_ShouldDeleteProjectAsync()
		{
			await projectService.DeleteProjectAsync(5);

			var projects = await projectService.GetAllProjectsAsync();
			Assert.Multiple(() =>
			{
				Assert.That(projects.Projects.Count(), Is.EqualTo(4));
				Assert.That(projects.Projects.Any(p => p.Id == 5), Is.False);
				Assert.That(projects.TotalProjects, Is.EqualTo(4));
			});
		}

		[Test]
		public void DeleteProject_ShouldThrow_WhenPrecastReinforced()
		{
			Assert.ThrowsAsync<DeleteActionException>(async () => 
			await projectService.DeleteProjectAsync(1));
		}

		[Test]
		public async Task IsReinforcedPrecastAsync_ShouldReturnTrueWhenIsReinforcedPrecast()
		{
			var result = await projectService.IsReinforcedProjectPrecastAsync(1);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsReinforcedPrecastAsync_ShouldReturnFalseWhenIsNotReinforcedPrecast()
		{
			var result = await projectService.IsReinforcedProjectPrecastAsync(4);
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task IsReinforcedPrecastAsync_ShouldReturnFalseWhenProjectDoesNotExist()
		{
			var result = await projectService.IsReinforcedProjectPrecastAsync(10);
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task IsProjectProductionNumberExists_ShouldReturnTrueWhenExists()
		{
			var result = await projectService.IsProjectProductionNumberExist("24 - 103");
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsProjectProductionNumberExists_ShouldReturnFalseWhenDoesNotExist()
		{
			var result = await projectService.IsProjectProductionNumberExist("24 - 106");
			Assert.That(result, Is.False);
		}

		[Test]
		public async Task IsProjectExists_ShouldReturnTrueWhenProjectExists()
		{
			var result = await projectService.IsProjectExistAsync(1);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task IsProjectExists_ShouldReturnFalseWhenProjectDoesNotExist()
		{
			var result = await projectService.IsProjectExistAsync(10);
			Assert.That(result, Is.False);
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}
	}
}
