namespace Ditto.Common.Repositories;

public interface IUnitOfWork
{
    public ICategoryRepository Categories {get; }
    public Task<bool> SaveChangesAsync();
}
