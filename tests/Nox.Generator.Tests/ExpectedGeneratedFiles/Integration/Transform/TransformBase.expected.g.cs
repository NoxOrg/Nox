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
                //Integer -> Integer?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> Integer
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> Double?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> Double
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> Bool?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> Bool
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Integer -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Double -> Integer?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Double -> Integer
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Double -> Double?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Double -> Double
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Double -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Double -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> Integer?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> Integer
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> Bool?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> Bool
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Bool -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //String -> Integer?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (int?)null : int.Parse(src.SourceField)))
                //String -> Integer
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => int.Parse(src.SourceField)))
                //String -> Double?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (double?)null : double.Parse(src.SourceField)))
                //String -> Double
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => double.Parse(src.SourceField)))
                //String -> Bool?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (bool?)null : bool.Parse(src.SourceField)))
                //String -> Bool
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => bool.Parse(src.SourceField)))
                //String -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (string?)null : src.SourceField))
                //String -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //String -> Date?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (DateOnly?)null : DateOnly.Parse(src.SourceField)))
                //String -> Date
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => DateOnly.Parse(src.SourceField)))
                //String -> Time?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (TimeOnly?)null : TimeOnly.Parse(src.SourceField)))
                //String -> Time
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => TimeOnly.Parse(src.SourceField)))
                //String -> DateTime?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (DateTime?)null : DateTime.Parse(src.SourceField)))
                //String -> DateTime
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => DateTime.Parse(src.SourceField)))
                //String -> Guid?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SourceField) ? (Guid?)null : Guid.Parse(src.SourceField)))
                //String -> Guid
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => Guid.Parse(src.SourceField)))
                //Date -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Date -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Date -> Date?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Date -> Date
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Date -> DateTime?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src == null ? (DateTime?)null : src.SourceField.ToDateTime(new TimeOnly(0, 0))))
                //Date -> DateTime
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField.ToDateTime(new TimeOnly(0, 0))))
                //Time -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Time -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Time -> Time?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Time -> Time
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //DateTime -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //DateTime -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //DateTime -> Date?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src == null ? (DateOnly?)null : DateOnly.FromDateTime(src.SourceField)))
                //DateTime -> Date
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.SourceField)))
                //DateTime -> Time?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src == null ? (TimeOnly?)null : TimeOnly.FromDateTime(src.SourceField)))
                //DateTime -> Time
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.SourceField)))
                //DateTime -> DateTime?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //DateTime -> DateTime
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Guid -> String?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Guid -> String
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField))
                //Guid -> Guid?
                .ForMember(dest => dest.TargetField, opt => opt.MapFrom(src => src.SourceField))
                //Guid -> Guid
                .ForMember(dest => dest.TargetFieldRequired, opt => opt.MapFrom(src => src.SourceField));
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