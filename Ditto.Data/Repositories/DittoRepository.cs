using Ditto.Common.Models;
using Ditto.Common.Repositories;
using ditto = Ditto.Common.Domain.Ditto;
using Microsoft.EntityFrameworkCore;

namespace Ditto.Data.Repositories;

public class DittoRepository : BaseRepository<Ditto.Common.Domain.Ditto>, IDittoRepository
{
    public DittoRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> ExistAsync(int id) => await dbSet.Where(x => x.Id == id).Select(x => x.Id).FirstOrDefaultAsync() > 0;

    public async Task<PaginationModel<ditto>> FilterAsync(DittoFilterModel filter)
    {
        var query = dbSet.AsQueryable();
        if(!string.IsNullOrEmpty(filter.Name))
            query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        if(filter.ProductId.HasValue)
            query = query.Where(x => x.ProductId == filter.ProductId);
        if(filter.OrderDate.HasValue)
            query = query.Where(x => x.OrderDate.Date == filter.OrderDate.Value.Date);
        var count = await query.CountAsync();
        var data = new List<ditto>();
        if(filter.Limit.HasValue)
        {
            var page = filter.Offset.HasValue ? filter.Offset.Value : 0;
            data = await query.Skip(page  * filter.Limit.Value).Take(filter.Limit.Value).ToListAsync();
        }else
            data = await query.ToListAsync();
        return new PaginationModel<ditto>(data, count);    
    }
}
