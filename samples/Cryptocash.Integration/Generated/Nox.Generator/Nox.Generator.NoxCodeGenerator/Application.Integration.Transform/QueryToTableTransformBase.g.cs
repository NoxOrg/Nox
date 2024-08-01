// Generated
#nullable enable

using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;
using Nox.Solution;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public abstract class QueryToTableTransformBase: INoxTransform<QueryToTableSourceDto, QueryToTableTargetDto>
{
    private readonly IMapper _mapper;
    
    protected QueryToTableTransformBase()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<QueryToTableSourceDto, QueryToTableTargetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population));
        }).CreateMapper();
    }
    
    public virtual QueryToTableTargetDto Invoke(QueryToTableSourceDto source)
    {
        return _mapper.Map<QueryToTableSourceDto, QueryToTableTargetDto>(source);
    }

    public string IntegrationName => "QueryToTable";

    public Type SourceType => typeof(QueryToTableSourceDto);

    public Type TargetType => typeof(QueryToTableTargetDto);
}