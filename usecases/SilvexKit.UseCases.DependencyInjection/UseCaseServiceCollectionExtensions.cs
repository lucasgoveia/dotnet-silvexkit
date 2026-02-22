using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SilvexKit.UseCases.DependencyInjection;

public static class UseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddUseCasesFromAssembly(
        this IServiceCollection services,
        Assembly assembly,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var candidates = assembly
            .GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.GetInterface(typeof(IUseCase<,>).Name) != null)
            .ToArray();

        foreach (var handler in candidates)
        {
            services.AddScoped(handler);
        }

        return services;
    }
}
