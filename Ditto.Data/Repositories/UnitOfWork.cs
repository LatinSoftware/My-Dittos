using Ditto.Common.Repositories;

namespace Ditto.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext context;
    public ICategoryRepository Categories  { get; }
    public UnitOfWork(ApplicationContext context, ICategoryRepository categoryRepository)
    {
        Categories = categoryRepository;
        this.context = context;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
