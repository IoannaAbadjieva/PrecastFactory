namespace PrecastFactory.UnitTests
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
	using PrecastFactorySystem.Infrastructure.Data.Models;

	[TestFixture]
	public class ProjectServiceTest
	{
		private IRepository repository;
		private IProjectService projectService;
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
			projectService = new ProjectService(repository);

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
