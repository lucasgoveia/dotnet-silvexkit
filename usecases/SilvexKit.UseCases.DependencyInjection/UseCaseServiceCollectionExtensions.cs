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
            .Where(t => t is { IsClass: true, IsAbstract: false, IsGenericTypeDefinition: false });

        foreach (var implementationType in candidates)
        {
            var useCaseInterfaces = implementationType
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IUseCase<,>));

            foreach (var serviceType in useCaseInterfaces)
            {
                services.TryAdd(new ServiceDescriptor(serviceType, implementationType, lifetime));
            }
        }

        return services;
    }
}
