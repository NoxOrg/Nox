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
                .ForMember(dest => dest.TargetId, opt => opt.MapFrom(src => src.SourceId))
                .ForMember(dest => dest.TargetDouble, opt => opt.MapFrom(src => src.SourceDouble))
                .ForMember(dest => dest.TargetBool, opt => opt.MapFrom(src => src.SourceBool))
                .ForMember(dest => dest.TargetString, opt => opt.MapFrom(src => src.SourceString))
                .ForMember(dest => dest.RequiredTargetString, opt => opt.MapFrom(src => src.RequiredSourceString))
                .ForMember(dest => dest.TargetDate, opt => opt.MapFrom(src => src.SourceDate == null ? null : DateOnly.Parse(src.SourceDate)))
                .ForMember(dest => dest.TargetDateRequired, opt => opt.MapFrom(src => DateOnly.Parse(src.SourceDateRequired)))
                .ForMember(dest => dest.TargetTime, opt => opt.MapFrom(src => src.SourceTime == null ? null : TimeOnly.Parse(src.SourceTime)))
                .ForMember(dest => dest.TargetTimeRequired, opt => opt.MapFrom(src => TimeOnly.Parse(src.SourceTimeRequired)))
                .ForMember(dest => dest.TargetDateTime, opt => opt.MapFrom(src => src.SourceDateTime == null ? null : DateTime.Parse(src.SourceDateTime)))
                .ForMember(dest => dest.TargetDateTimeRequired, opt => opt.MapFrom(src => DateTime.Parse(src.SourceDateTimeRequired)))
                .ForMember(dest => dest.TargetGuid, opt => opt.MapFrom(src => src.SourceGuid == null ? null : Guid.NewGuid(src.SourceGuid)))
                .ForMember(dest => dest.TargetGuidRequired, opt => opt.MapFrom(src => Guid.NewGuid(src.SourceGuidRequired)));
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