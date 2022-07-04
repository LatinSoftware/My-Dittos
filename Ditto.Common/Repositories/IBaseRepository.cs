using System.Linq.Expressions;

namespace Ditto.Common.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    Task<TEntity> GetByIDAsync(object id);
    Task InsertAsync(TEntity entity);
    public void Update(TEntity entityToUpdate);
    public void Delete(object id);
    public void Delete(TEntity entityToDelete);
}
