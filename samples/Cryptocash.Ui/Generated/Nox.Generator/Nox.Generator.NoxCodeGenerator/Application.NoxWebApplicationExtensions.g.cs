// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OData.ModelBuilder;
using Nox;
using Nox.Solution;
using Nox.EntityFramework.SqlServer;
using Nox.Types.EntityFramework.Abstractions;

public static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
                        {
                            return services.AddNox(null);
                        }
                        
    public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)
    {
        services.AddNoxLib((builder) => builder.SetClientAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
    
}
