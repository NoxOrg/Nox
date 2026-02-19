using System;
using System.Linq;
using System.Reflection;

namespace Cryptocash.Ui.Generated.Pages.Generic
{
    internal sealed class MapperConfiguration
    {
        internal global::AutoMapper.IConfigurationProvider ConfigurationProvider { get; }

        public MapperConfiguration(Action<global::AutoMapper.IMapperConfigurationExpression> configure)
        {
            ConfigurationProvider = new global::AutoMapper.MapperConfiguration(
                configure,
                global::Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);
        }
    }

    internal sealed class Mapper
    {
        private readonly global::AutoMapper.Mapper _inner;

        public Mapper(MapperConfiguration configuration)
        {
            _inner = new global::AutoMapper.Mapper(configuration.ConfigurationProvider);
        }

        public TDestination Map<TDestination>(object source)
        {
            return _inner.Map<TDestination>(source);
        }
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class AutoMapperCompatibilityExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
        {
            Assembly[] assemblies = profileAssemblyMarkerTypes
                .Select(t => t.Assembly)
                .Distinct()
                .ToArray();

            var configuration = new global::AutoMapper.MapperConfiguration(
                cfg => cfg.AddMaps(assemblies),
                global::Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);

            services.AddSingleton<global::AutoMapper.IConfigurationProvider>(configuration);
            services.AddSingleton<global::AutoMapper.IMapper>(
                sp => new global::AutoMapper.Mapper(configuration, sp.GetService));

            return services;
        }
    }
}
