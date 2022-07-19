using Ditto.Common.Domain;
using Ditto.Common.Repositories;

namespace Ditto.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}
