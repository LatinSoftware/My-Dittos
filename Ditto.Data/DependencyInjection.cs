using Ditto.Common.Repositories;
using Ditto.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ditto.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(IServiceCollection  services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
