using Ditto.Common.Domain;

namespace Ditto.Common.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<bool> Exist(int Id);
    Task<Product> GetByIDAsync(int id);
    
}
