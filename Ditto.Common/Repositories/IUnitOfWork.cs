namespace Ditto.Common.Repositories;

public interface IUnitOfWork
{
    public ICategoryRepository Categories {get; }
    public IProductRepository Products {get; }
    public Task<bool> SaveChangesAsync();
}
