﻿// Generated

#nullable enable

using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;
using Nox.Solution;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public abstract class JsonToTableTransformBase: INoxTransform<JsonToTableSourceDto, JsonToTableTargetDto>
{
    private readonly IMapper _mapper;
    
    protected JsonToTableTransformBase()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<JsonToTableSourceDto, JsonToTableTargetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.NoOfInhabitants))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Parse(src.DateCreated)))
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => src.DateChanged == null ? (DateTime?)null : DateTime.Parse(src.DateChanged)));
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