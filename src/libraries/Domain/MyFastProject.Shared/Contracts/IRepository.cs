namespace MyFastProject.Shared.Contracts;

public interface IRepository< TEntity, IModel, T>
	 where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>, new()
	where T : IEquatable<T>
{
	public Task<IModel> GetById(T id);
	public Task<IEnumerable<IModel>> GetAll();
	public Task Delete(TEntity entity);
	public Task Delete(T id);
	public Task<IModel> Update(T id, TEntity entity);
	public Task<IModel> Add(TEntity entity);
}
