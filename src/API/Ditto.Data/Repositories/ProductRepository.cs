using Ditto.Common.Domain;
using Ditto.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ditto.Data.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationContext context) : base(context)
    {
    }
    public async Task<bool> Exist(int Id) => await dbSet.Where(p => p.Id == Id).Select(x => x.Id).FirstOrDefaultAsync() > 0;
    public async Task<Product> GetByIDAsync(int id) => await dbSet.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
}
