using Ditto.Common.Domain;

namespace Ditto.Common.Repositories;

public interface IProductRepository : IBaseRepository<Category>
{
    public Task<bool> Exist(int Id);
}
