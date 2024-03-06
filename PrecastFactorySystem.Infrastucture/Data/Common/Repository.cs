namespace PrecastFactorySystem.Infrastructure.Data.Common
{
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.ChangeTracking;

	using PrecastFactorySystem.Data;

	/// <summary>
	/// Implementation of repository access methods
	/// for Relational Database Engine
	/// </summary>
	/// <typeparam name="T">Type of the data table to which 
	/// current repository is attached</typeparam>
	public class Repository : IRepository
	{
		/// <summary>
		/// Entity framework DB context holding connection information and properties
		/// and tracking entity states 
		/// </summary>
		private readonly DbContext context;

		public Repository(PrecastFactoryDbContext _context)
		{
			context = _context;
		}
	
		/// <summary>
		/// Representation of table in database
		/// </summary>
		private DbSet<T> DbSet<T>() where T : class
		{
			return context.Set<T>();
		}


		/// <summary>
		/// Adds entity to the database
		/// </summary>
		/// <param name="entity">Entity to add</param>
		public async Task AddAsync<T>(T entity) where T : class
		{
			await DbSet<T>().AddAsync(entity);
		}

		/// <summary>
		/// Ads collection of entities to the database
		/// </summary>
		/// <param name="entities">Enumerable list of entities</param>
		public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
		{
			await DbSet<T>().AddRangeAsync(entities);
		}

		/// <summary>
		/// All records in a table
		/// </summary>
		/// <returns>Queryable expression tree</returns>
		public IQueryable<T> All<T>() where T : class
		{
			return DbSet<T>().AsQueryable();
		}

		/// <summary>
		/// All records in a table meeting condition
		/// </summary>
		/// <returns>Queryable expression tree</returns>

		public IQueryable<T> All<T>(Expression<Func<T, bool>> condition) where T : class
		{
			return DbSet<T>().Where(condition);
		}

		/// <summary>
		/// The result collection won't be tracked by the context
		/// </summary>
		/// <returns>Expression tree</returns>
		public IQueryable<T> AllReadonly<T>() where T : class
		{
			return DbSet<T>()
				.AsNoTracking();
		}

		/// <summary>
		/// All records in a table meeting condition
		/// The result collection won't be tracked by the context
		/// </summary>
		/// <returns>Expression tree</returns>
		public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> condition) where T : class
		{
			return DbSet<T>()
				.Where(condition)
				.AsNoTracking();
		}

		/// <summary>
		/// Deletes a record from database
		/// </summary>
		/// <param name="id">Identifier of record to be deleted</param>
		public async Task DeleteAsync<T>(object id) where T : class
		{
			T entity = await GetByIdAsync<T>(id);

			Delete<T>(entity);
		}

		/// <summary>
		/// Deletes a record from database
		/// </summary>
		/// <param name="entity">Entity representing record to be deleted</param>
		public void Delete<T>(T entity) where T : class
		{
			EntityEntry entry = context.Entry(entity);

			if (entry.State == EntityState.Detached)
			{
				DbSet<T>().Attach(entity);
			}

			entry.State = EntityState.Deleted;
		}

		/// <summary>
		/// Detaches given entity from the context
		/// </summary>
		/// <param name="entity">Entity to be detached</param>
		public void Detach<T>(T entity) where T : class
		{
			EntityEntry entry = context.Entry(entity);

			entry.State = EntityState.Detached;
		}

		/// <summary>
		/// Disposing the context when it is not needed
		/// Don't have to call this method explicitly
		/// Leave it to the IoC container
		/// </summary>
		public void Dispose()
		{
			context.Dispose();
		}

		/// <summary>
		/// Gets specific record from database by primary key
		/// </summary>
		/// <param name="id">record identifier</param>
		/// <returns>Single record</returns>
		public async Task<T> GetByIdAsync<T>(object id) where T : class
		{
			return await DbSet<T>().FindAsync(id);
		}

		public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
		{
			return await DbSet<T>().FindAsync(id);
		}

		/// <summary>
		/// Saves all made changes in transaction
		/// </summary>
		/// <returns>Error code</returns>
		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates a record in database
		/// </summary>
		/// <param name="entity">Entity for record to be updated</param>
		public void Update<T>(T entity) where T : class
		{
			DbSet<T>().Update(entity);
		}

		/// <summary>
		/// Updates set of records in the database
		/// </summary>
		/// <param name="entities">Enumerable collection of entities to be updated</param>
		public void UpdateRange<T>(IEnumerable<T> entities) where T : class
		{
			DbSet<T>().UpdateRange(entities);
		}


		/// <summary>
		/// Deletes set of records in the database
		/// </summary>
		/// <param name="entities">Enumerable collection of entities to be deleted</param>
		public void DeleteRange<T>(IEnumerable<T> entities) where T : class
		{
			DbSet<T>().RemoveRange(entities);
		}

		/// <summary>
		/// Deletes set of records, meeting a condition, in the database 
		/// </summary>
		/// <param name="entities">Enumerable collection of entities to be deleted</param>
		public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
		{
			var entities = All<T>(deleteWhereClause);
			DeleteRange(entities);
		}
	}
}
