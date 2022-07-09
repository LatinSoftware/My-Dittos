namespace Ditto.Common.Repositories;

public interface IUnitOfWork
{
    public ICategoryRepository Categories {get; }
    public IProductRepository Products {get; }
    public IDittoRepository Dittos {get; }
    public Task<bool> SaveChangesAsync();
}
