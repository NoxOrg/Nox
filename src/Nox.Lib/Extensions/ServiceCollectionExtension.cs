using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets;
using Nox.Secrets.Resolvers;
using Nox.Solution;

namespace Nox;

public static class ServiceCollectionExtension
{
    private static NoxSolution? _solution;
    private static UserSecretResolver? _userSecretResolver;

    public static NoxSolution Solution
    {
        get
        {
            if (_solution == null) CreateSolution();
            return _solution!;
        }
    }
    
    public static IServiceCollection AddNoxLib(this IServiceCollection services)
    {
        //Add secret providers and resolvers
        services.AddPersistedSecretStore();
        _userSecretResolver = services.AddUserSecretResolver(Assembly.GetEntryAssembly()!);
        services.AddSingleton(Solution);
        return services;
    }

    private static void CreateSolution()
    {
        _solution = new NoxSolutionBuilder()
            .OnResolveSecrets((_, args) =>
            {
                var yaml = args.Yaml;
                var secrets = new Dictionary<string, string?>();
                //Resolve org secrets if any
                //Resolve solution secrets if any
                //Resolve the user secrets if any
                if (_userSecretResolver != null)
                {
                    var userSecrets = SecretExtractor.Extract("user", yaml);
                    if (userSecrets != null)
                    {
                        foreach (var userSecret in userSecrets) secrets.Add(userSecret, null);
                    }
                }
                
                _userSecretResolver!.Resolve(secrets);
                
                args.Secrets = secrets;
            })
            .Build();
    }

}