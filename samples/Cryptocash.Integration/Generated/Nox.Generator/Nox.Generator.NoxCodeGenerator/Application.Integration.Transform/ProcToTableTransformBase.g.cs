// Generated
#nullable enable

using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;
using Nox.Solution;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public abstract class ProcToTableTransformBase: INoxTransform<ProcToTableSourceDto, ProcToTableTargetDto>
{
    private readonly IMapper _mapper;
    
    protected ProcToTableTransformBase()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProcToTableSourceDto, ProcToTableTargetDto>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population));
        }).CreateMapper();
    }
    
    public virtual ProcToTableTargetDto Invoke(ProcToTableSourceDto source)
    {
        return _mapper.Map<ProcToTableSourceDto, ProcToTableTargetDto>(source);
    }

    public string IntegrationName => "ProcToTable";

    public Type SourceType => typeof(ProcToTableSourceDto);

    public Type TargetType => typeof(ProcToTableTargetDto);
}