using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace MyFastProject.Shared.Contracts;

public abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
	where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>, new()
	where T : IEquatable<T>
{
	protected readonly IMapper _mapper;
	private readonly DbContext _dbContext;

	public RepositoryBase(IMapper mapper, DbContext dbContext)
	{
		_mapper = mapper;
		_dbContext = dbContext;
		DbSet = _dbContext.Set<TEntity>();
	}
	/// <summary>
	/// Gets the database set.
	/// </summary>
	/// <value>
	/// The database set.
	/// </value>
	public DbSet<TEntity> DbSet { get; }

	/// <summary>
	/// Adds the specified entity.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public async Task<IModel> Add(TEntity entity)
	{
		await DbSet.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return _mapper.Map<IModel>(entity);
	}

	/// <summary>
	/// Deletes the specified entity.
	/// </summary>
	/// <param name="entity">The entity.</param>
	public async Task Delete(TEntity entity)
	{
		DbSet.Remove(entity);
		await _dbContext.SaveChangesAsync();
	}
	/// <summary>
	/// Deletes the specified identifier.
	/// </summary>
	/// <param name="id">The identifier.</param>
	public async Task Delete(T id)
	{
		var entity = await DbSet.FindAsync(id);
		if (entity != null)
		{
			DbSet.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
	}

	/// <summary>Gets all.</summary>
	/// <returns>
	///  all List
	/// </returns>
	public Task<IEnumerable<IModel>> GetAll()
	{
		
		var data = DbSet.AsEnumerable();
		var models = _mapper.Map<IEnumerable<IModel>>(data);
		return Task.FromResult(models);
	}

	/// <summary>
	/// Gets the by identifier.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	public async Task<IModel> GetById(T id)
	{
		var data = await DbSet.FindAsync(id);
		return _mapper.Map<IModel>(data);
	}
	/// <summary>
	/// Updates the specified identifier.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentNullException">entity</exception>
	public async Task<IModel> Update(T id, TEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		var exist = await DbSet.FindAsync(id);
		if (exist != null)
		{
			DbSet.Entry(exist).CurrentValues.SetValues(entity);
		   await	_dbContext.SaveChangesAsync();
		}
		return _mapper.Map<IModel>(entity);
	}


}
