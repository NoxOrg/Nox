using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;

namespace Cryptocash.Integration;

public abstract class TestTransformBase: INoxTransform<JsonToTableSourceDto, JsonToTableTargetDto>
{
    private readonly IMapper _mapper;
    
    protected TestTransformBase()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<JsonToTableSourceDto, JsonToTableTargetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.NoOfInhabitants))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => src.DateChanged));
        }).CreateMapper();
    }
    
    public virtual JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        return _mapper.Map<JsonToTableSourceDto, JsonToTableTargetDto>(source);
    }

    public string IntegrationName => "JsonToTable";

    public Type SourceType => typeof(JsonToTableSourceDto);

    public Type TargetType => typeof(JsonToTableTargetDto);
}