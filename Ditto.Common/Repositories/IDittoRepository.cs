using Ditto.Common.Models;

namespace Ditto.Common.Repositories;

public interface IDittoRepository : IBaseRepository<Ditto.Common.Domain.Ditto>
{
    public Task<bool> ExistAsync(int id);
    public Task<PaginationModel<Ditto.Common.Domain.Ditto>> FilterAsync(DittoFilterModel filter);
}
