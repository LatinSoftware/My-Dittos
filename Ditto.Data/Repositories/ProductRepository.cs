using Ditto.Common.Domain;
using Ditto.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ditto.Data.Repositories;

public class ProductRepository : BaseRepository<Category>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }
    public async Task<bool> Exist(int Id) => await dbSet.Where(p => p.Id == Id).Select(x => x.Id).FirstOrDefaultAsync() > 0;
}
