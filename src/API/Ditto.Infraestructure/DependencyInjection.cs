using Ditto.Common.Services;
using Ditto.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ditto.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure (this IServiceCollection services, string jsonCredentiaslPath)
    {
        services.AddScoped<ICalendarService>(service => new GoogleCalendarService(jsonCredentiaslPath));
        return services;
    }
}
