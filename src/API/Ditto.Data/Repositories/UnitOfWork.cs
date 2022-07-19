using Ditto.Common.Repositories;

namespace Ditto.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext context;
    public ICategoryRepository Categories  { get; }
    public IProductRepository Products { get; }
    public IDittoRepository Dittos { get; private set; }

    public UnitOfWork(ApplicationContext context, ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        this.context = context;
        Categories = categoryRepository;
        Products = productRepository;
        Dittos = new DittoRepository(context);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
