using System.Linq.Expressions;
using Ditto.Common.Models;
using Ditto.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ditto.Data.Repositories;

public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
{
    internal ApplicationContext context;
    internal DbSet<TEntity> dbSet;

    public BaseRepository(ApplicationContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return await query.ToListAsync();
        }
    }
// LatinSoftware on Jul 5, 2022 at 10:15 AM
// This method allow us to get filtered data from database with relational data if
// necesary and pagination
    public virtual async Task<PaginationModel<TEntity>> GetAsync(int skip, int limit = 10, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
            query = query.Where(filter);

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty);

        if (orderBy != null)
            query = orderBy(query);
        var totalCount = await query.CountAsync();
        var data = await query.Skip(skip).Take(limit).ToListAsync();
        return new PaginationModel<TEntity>(data, totalCount);
    }
    
    public virtual async Task<TEntity> GetByIDAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
