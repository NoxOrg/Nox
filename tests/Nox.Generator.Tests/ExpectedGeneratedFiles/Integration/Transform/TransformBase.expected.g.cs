// Generated
#nullable enable

using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;
using Nox.Solution;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public abstract class TestIntegrationTransformBase: INoxTransform<TestIntegrationSourceDto, TestIntegrationTargetDto>
{
    private readonly IMapper _mapper;
    
    protected TestIntegrationTransformBase()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TestIntegrationSourceDto, TestIntegrationTargetDto>()
                .ForMember(dest => dest.IdTarget, opt => opt.MapFrom(src => src.IdSource))
                .ForMember(dest => dest.NameTarget, opt => opt.MapFrom(src => src.AreaSource))
                .ForMember(dest => dest.NameTargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.NameSource) ? (string?)null : src.NameSource))
                .ForMember(dest => dest.AreaTarget, opt => opt.MapFrom(src => src.AreaTarget))
                .ForMember(dest => dest.AreaTargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.AreaSourceNull) ? (string?)null : src.AreaSourceNull))
                .ForMember(dest => dest.BoolTarget, opt => opt.MapFrom(src => src.BoolTarget))
                .ForMember(dest => dest.BoolTargetNull, opt => opt.MapFrom(src => src.BoolTargetNull))
                .ForMember(dest => dest.ColorTarget, opt => opt.MapFrom(src => src.ColorTarget))
                .ForMember(dest => dest.ColorTargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.ColorTargetNull) ? (string?)null : src.ColorTargetNull))
                .ForMember(dest => dest.CountryCode2Target, opt => opt.MapFrom(src => src.CountryCode2Target))
                .ForMember(dest => dest.CountryCode2TargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.CountryCode2TargetNull) ? (string?)null : src.CountryCode2TargetNull))
                .ForMember(dest => dest.CountryCode3Target, opt => opt.MapFrom(src => src.CountryCode3Target))
                .ForMember(dest => dest.CountryCode3TargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.CountryCode3TargetNull) ? (string?)null : src.CountryCode3TargetNull))
                .ForMember(dest => dest.CountryNimberTarget, opt => opt.MapFrom(src => src.CountryNimberTarget))
                .ForMember(dest => dest.CountryNimberTargetNull, opt => opt.MapFrom(src => src.CountryNimberTargetNull))
                .ForMember(dest => dest.CultureCodeTarget, opt => opt.MapFrom(src => src.CultureCodeTarget))
                .ForMember(dest => dest.CultureCodeTargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.CultureCodeTargetNull) ? (string?)null : src.CultureCodeTargetNull))
                .ForMember(dest => dest.CurrencyCode3Target, opt => opt.MapFrom(src => src.CurrencyCode3Target))
                .ForMember(dest => dest.CurrencyCode3TargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.CurrencyCode3TargetNull) ? (string?)null : src.CurrencyCode3TargetNull))
                .ForMember(dest => dest.CurrencyNumberTarget, opt => opt.MapFrom(src => src.CurrencyNumberTarget))
                .ForMember(dest => dest.CurrencyNumberTargetNull, opt => opt.MapFrom(src => src.CurrencyNumberTargetNull))
                .ForMember(dest => dest.DateTarget, opt => opt.MapFrom(src => src.DateTarget))
                .ForMember(dest => dest.DateTargetNull, opt => opt.MapFrom(src => src.DateTargetNull))
                .ForMember(dest => dest.DateTimeTarget, opt => opt.MapFrom(src => src.DateTimeTarget))
                .ForMember(dest => dest.DateTimeTargetNull, opt => opt.MapFrom(src => src.DateTimeTargetNull))
                .ForMember(dest => dest.DateTimeDurationTarget, opt => opt.MapFrom(src => src.DateTimeDurationTarget))
                .ForMember(dest => dest.DateTimeDurationTargetNull, opt => opt.MapFrom(src => src.DateTimeDurationTargetNull))
                .ForMember(dest => dest.DateTimeRangeTarget_Start, opt => opt.MapFrom(src => src.DateTimeRangeTarget_Start))
                .ForMember(dest => dest.DateTimeRangeTarget_End, opt => opt.MapFrom(src => src.DateTimeRangeTarget_End))
                .ForMember(dest => dest.DateTimeRangeTargetNull_Start, opt => opt.MapFrom(src => src.DateTimeRangeTargetNull_Start))
                .ForMember(dest => dest.DateTimeRangeTargetNull_End, opt => opt.MapFrom(src => src.DateTimeRangeTargetNull_End))
                .ForMember(dest => dest.DateTimeScheduleTarget, opt => opt.MapFrom(src => src.DateTimeScheduleTarget))
                .ForMember(dest => dest.DateTimeScheduleTargetNull, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.DateTimeScheduleTargetNull) ? (string?)null : src.DateTimeScheduleTargetNull))
                .ForMember(dest => dest.DistanceTarget, opt => opt.MapFrom(src => src.DistanceTarget))
                .ForMember(dest => dest.DistanceTargetNull, opt => opt.MapFrom(src => src.DistanceTargetNull))
                .ForMember(dest => dest.GuidTarget, opt => opt.MapFrom(src => src.GuidTarget))
                .ForMember(dest => dest.GuidTargetNull, opt => opt.MapFrom(src => src.GuidTargetNull))
                .ForMember(dest => dest.LatLongTarget_Latitude, opt => opt.MapFrom(src => src.LatLongTarget_Latitude))
                .ForMember(dest => dest.LatLongTarget_Longitude, opt => opt.MapFrom(src => src.LatLongTarget_Longitude))
                .ForMember(dest => dest.LatLongTargetNull_Latitude, opt => opt.MapFrom(src => src.LatLongTargetNull_Latitude))
                .ForMember(dest => dest.LatLongTargetNull_Longitude, opt => opt.MapFrom(src => src.LatLongTargetNull_Longitude))
                .ForMember(dest => dest.MoneyTarget_Amount, opt => opt.MapFrom(src => src.MoneyTarget_Amount))
                .ForMember(dest => dest.MoneyTarget_CurrencyCode, opt => opt.MapFrom(src => src.MoneyTarget_CurrencyCode))
                .ForMember(dest => dest.MoneyTargetNull_Amount, opt => opt.MapFrom(src => src.MoneyTargetNull_Amount))
                .ForMember(dest => dest.MoneyTargetNull_CurrencyCode, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.MoneyTargetNull_CurrencyCode) ? (string?)null : src.MoneyTargetNull_CurrencyCode))
                .ForMember(dest => dest.TimeTarget, opt => opt.MapFrom(src => src.TimeTarget))
                .ForMember(dest => dest.TimeTargetNull, opt => opt.MapFrom(src => src.TimeTargetNull));
        }).CreateMapper();
    }
    
    public virtual TestIntegrationTargetDto Invoke(TestIntegrationSourceDto source)
    {
        return _mapper.Map<TestIntegrationSourceDto, TestIntegrationTargetDto>(source);
    }

    public string IntegrationName => "TestIntegration";

    public Type SourceType => typeof(TestIntegrationSourceDto);

    public Type TargetType => typeof(TestIntegrationTargetDto);
}