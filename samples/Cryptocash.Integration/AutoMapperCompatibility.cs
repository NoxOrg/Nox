using System;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

internal sealed class MapperConfiguration
{
    private readonly global::AutoMapper.MapperConfiguration _inner;

    public MapperConfiguration(Action<global::AutoMapper.IMapperConfigurationExpression> configure)
    {
        _inner = new global::AutoMapper.MapperConfiguration(
            configure,
            global::Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);
    }

    public global::AutoMapper.IMapper CreateMapper()
    {
        return _inner.CreateMapper();
    }
}
