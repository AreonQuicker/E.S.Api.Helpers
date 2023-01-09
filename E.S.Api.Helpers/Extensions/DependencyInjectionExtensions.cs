using System;
using System.Linq;
using System.Reflection;
using E.S.Api.Helpers.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace E.S.Api.Helpers.Extensions;

public static class DependencyInjectionExtensions
{
    public static void InjectServices(this IServiceCollection services,
        Assembly assembly)
    {
        var serviceTypes = assembly.GetExportedTypes()
            .Where(i =>
                i.Name.EndsWith("Service") &&
                (i.GetCustomAttributes(typeof(ScopeServiceAttribute),
                         false)
                     .Any() ||
                 i.GetCustomAttributes(typeof(TransientServiceAttribute),
                         false)
                     .Any()) &&
                i.GetInterfaces()
                    .Any(type => type.Name.StartsWith("I") && type.Name.EndsWith("Service")))
            .ToList();

        foreach (Type serviceType in serviceTypes)
        {
            Type interfaceType = serviceType.GetInterfaces()
                .FirstOrDefault(i => i.Name.StartsWith("I") && i.Name.Substring(1) == serviceType.Name);
            if (interfaceType is null)
            {
                continue;
            }
            if (serviceType.GetCustomAttributes(typeof(ScopeServiceAttribute),
                    false)
                .Any())
            {
                services.AddScoped(interfaceType,
                    serviceType);
            }
            if (serviceType.GetCustomAttributes(typeof(TransientServiceAttribute),
                    false)
                .Any())
            {
                services.AddTransient(interfaceType,
                    serviceType);
            }
        }
    }
}