// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;

namespace SampleWebApp.Application;

public class AllNoxTypeMapper: EntityMapperBase<AllNoxType>
{
    public  AllNoxTypeMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(AllNoxType entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TextId", dto.TextId);        
        if(noxTypeValue != null)
        {        
            entity.TextId = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition,"AreaField",dto.AreaField);
        if(noxTypeValue != null)
        {        
            entity.AreaField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"BooleanField",dto.BooleanField);
        if(noxTypeValue != null)
        {        
            entity.BooleanField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryCode2Field",dto.CountryCode2Field);
        if(noxTypeValue != null)
        {        
            entity.CountryCode2Field = noxTypeValue;
        }

        // TODO map CountryCode3Field CountryCode3 remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.CountryNumber>(entityDefinition,"CountryNumberField",dto.CountryNumberField);
        if(noxTypeValue != null)
        {        
            entity.CountryNumberField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CultureCode>(entityDefinition,"CultureCodeField",dto.CultureCodeField);
        if(noxTypeValue != null)
        {        
            entity.CultureCodeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition,"CurrencyCode3Field",dto.CurrencyCode3Field);
        if(noxTypeValue != null)
        {        
            entity.CurrencyCode3Field = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition,"CurrencyNumberField",dto.CurrencyNumberField);
        if(noxTypeValue != null)
        {        
            entity.CurrencyNumberField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"DateField",dto.DateField);
        if(noxTypeValue != null)
        {        
            entity.DateField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"DateTimeField",dto.DateTimeField);
        if(noxTypeValue != null)
        {        
            entity.DateTimeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTimeDuration>(entityDefinition,"DateTimeDurationField",dto.DateTimeDurationField);
        if(noxTypeValue != null)
        {        
            entity.DateTimeDurationField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTimeSchedule>(entityDefinition,"DateTimeScheduleField",dto.DateTimeScheduleField);
        if(noxTypeValue != null)
        {        
            entity.DateTimeScheduleField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition,"DayOfWeekField",dto.DayOfWeekField);
        if(noxTypeValue != null)
        {        
            entity.DayOfWeekField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Distance>(entityDefinition,"DistanceField",dto.DistanceField);
        if(noxTypeValue != null)
        {        
            entity.DistanceField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"EmailField",dto.EmailField);
        if(noxTypeValue != null)
        {        
            entity.EmailField = noxTypeValue;
        }

        // TODO map FormulaField Formula remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"GuidField",dto.GuidField);
        if(noxTypeValue != null)
        {        
            entity.GuidField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Html>(entityDefinition,"HtmlField",dto.HtmlField);
        if(noxTypeValue != null)
        {        
            entity.HtmlField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.InternetDomain>(entityDefinition,"InternetDomainField",dto.InternetDomainField);
        if(noxTypeValue != null)
        {        
            entity.InternetDomainField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition,"IpAddressField",dto.IpAddressField);
        if(noxTypeValue != null)
        {        
            entity.IpAddressField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Json>(entityDefinition,"JsonField",dto.JsonField);
        if(noxTypeValue != null)
        {        
            entity.JsonField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.JwtToken>(entityDefinition,"JwtTokenField",dto.JwtTokenField);
        if(noxTypeValue != null)
        {        
            entity.JwtTokenField = noxTypeValue;
        }

        // TODO map LanguageCodeField LanguageCode remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Length>(entityDefinition,"LengthField",dto.LengthField);
        if(noxTypeValue != null)
        {        
            entity.LengthField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition,"MacAddressField",dto.MacAddressField);
        if(noxTypeValue != null)
        {        
            entity.MacAddressField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Markdown>(entityDefinition,"MarkdownField",dto.MarkdownField);
        if(noxTypeValue != null)
        {        
            entity.MarkdownField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Month>(entityDefinition,"MonthField",dto.MonthField);
        if(noxTypeValue != null)
        {        
            entity.MonthField = noxTypeValue;
        }

        // TODO map NuidField Nuid remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"NumberField",dto.NumberField);
        if(noxTypeValue != null)
        {        
            entity.NumberField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Percentage>(entityDefinition,"PercentageField",dto.PercentageField);
        if(noxTypeValue != null)
        {        
            entity.PercentageField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition,"PhoneNumberField",dto.PhoneNumberField);
        if(noxTypeValue != null)
        {        
            entity.PhoneNumberField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Temperature>(entityDefinition,"TemperatureField",dto.TemperatureField);
        if(noxTypeValue != null)
        {        
            entity.TemperatureField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TextField",dto.TextField);
        if(noxTypeValue != null)
        {        
            entity.TextField = noxTypeValue;
        }

        // TODO map TimeField Time remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition,"TimeZoneCodeField",dto.TimeZoneCodeField);
        if(noxTypeValue != null)
        {        
            entity.TimeZoneCodeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Uri>(entityDefinition,"UriField",dto.UriField);
        if(noxTypeValue != null)
        {        
            entity.UriField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition,"UrlField",dto.UrlField);
        if(noxTypeValue != null)
        {        
            entity.UrlField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.User>(entityDefinition,"UserField",dto.UserField);
        if(noxTypeValue != null)
        {        
            entity.UserField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Volume>(entityDefinition,"VolumeField",dto.VolumeField);
        if(noxTypeValue != null)
        {        
            entity.VolumeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Weight>(entityDefinition,"WeightField",dto.WeightField);
        if(noxTypeValue != null)
        {        
            entity.WeightField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Yaml>(entityDefinition,"YamlField",dto.YamlField);
        if(noxTypeValue != null)
        {        
            entity.YamlField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Year>(entityDefinition,"YearField",dto.YearField);
        if(noxTypeValue != null)
        {        
            entity.YearField = noxTypeValue;
        }

        // TODO map EncryptedTextField EncryptedText remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.File>(entityDefinition,"FileField",dto.FileField);
        if(noxTypeValue != null)
        {        
            entity.FileField = noxTypeValue;
        }

        // TODO map HashedTexField HashedText remaining types and remove if else

        // TODO map ImageField Image remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"LatLongField",dto.LatLongField);
        if(noxTypeValue != null)
        {        
            entity.LatLongField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"MoneyField",dto.MoneyField);
        if(noxTypeValue != null)
        {        
            entity.MoneyField = noxTypeValue;
        }

        // TODO map PasswordField Password remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"StreetAddressField",dto.StreetAddressField);
        if(noxTypeValue != null)
        {        
            entity.StreetAddressField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.TranslatedText>(entityDefinition,"TranslatedTextField",dto.TranslatedTextField);
        if(noxTypeValue != null)
        {        
            entity.TranslatedTextField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition,"VatNumberField",dto.VatNumberField);
        if(noxTypeValue != null)
        {        
            entity.VatNumberField = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(AllNoxType entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("AreaField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition,"AreaField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "AreaField");
                }
                else
                {
                    entity.AreaField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("BooleanField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"BooleanField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "BooleanField");
                }
                else
                {
                    entity.BooleanField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryCode2Field", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryCode2Field",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CountryCode2Field");
                }
                else
                {
                    entity.CountryCode2Field = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryCode3Field", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode3>(entityDefinition,"CountryCode3Field",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CountryCode3Field");
                }
                else
                {
                    entity.CountryCode3Field = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryNumberField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryNumber>(entityDefinition,"CountryNumberField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CountryNumberField");
                }
                else
                {
                    entity.CountryNumberField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CultureCodeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CultureCode>(entityDefinition,"CultureCodeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CultureCodeField");
                }
                else
                {
                    entity.CultureCodeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CurrencyCode3Field", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition,"CurrencyCode3Field",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CurrencyCode3Field");
                }
                else
                {
                    entity.CurrencyCode3Field = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CurrencyNumberField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition,"CurrencyNumberField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "CurrencyNumberField");
                }
                else
                {
                    entity.CurrencyNumberField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DateField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"DateField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DateField");
                }
                else
                {
                    entity.DateField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DateTimeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"DateTimeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DateTimeField");
                }
                else
                {
                    entity.DateTimeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DateTimeDurationField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTimeDuration>(entityDefinition,"DateTimeDurationField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DateTimeDurationField");
                }
                else
                {
                    entity.DateTimeDurationField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DateTimeScheduleField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTimeSchedule>(entityDefinition,"DateTimeScheduleField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DateTimeScheduleField");
                }
                else
                {
                    entity.DateTimeScheduleField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DayOfWeekField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition,"DayOfWeekField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DayOfWeekField");
                }
                else
                {
                    entity.DayOfWeekField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DistanceField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Distance>(entityDefinition,"DistanceField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "DistanceField");
                }
                else
                {
                    entity.DistanceField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EmailField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"EmailField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "EmailField");
                }
                else
                {
                    entity.EmailField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GuidField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"GuidField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "GuidField");
                }
                else
                {
                    entity.GuidField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("HtmlField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Html>(entityDefinition,"HtmlField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "HtmlField");
                }
                else
                {
                    entity.HtmlField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("InternetDomainField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.InternetDomain>(entityDefinition,"InternetDomainField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "InternetDomainField");
                }
                else
                {
                    entity.InternetDomainField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("IpAddressField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition,"IpAddressField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "IpAddressField");
                }
                else
                {
                    entity.IpAddressField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("JsonField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Json>(entityDefinition,"JsonField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "JsonField");
                }
                else
                {
                    entity.JsonField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("JwtTokenField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.JwtToken>(entityDefinition,"JwtTokenField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "JwtTokenField");
                }
                else
                {
                    entity.JwtTokenField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LanguageCodeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LanguageCode>(entityDefinition,"LanguageCodeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "LanguageCodeField");
                }
                else
                {
                    entity.LanguageCodeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LengthField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Length>(entityDefinition,"LengthField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "LengthField");
                }
                else
                {
                    entity.LengthField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MacAddressField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition,"MacAddressField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "MacAddressField");
                }
                else
                {
                    entity.MacAddressField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MarkdownField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Markdown>(entityDefinition,"MarkdownField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "MarkdownField");
                }
                else
                {
                    entity.MarkdownField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MonthField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Month>(entityDefinition,"MonthField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "MonthField");
                }
                else
                {
                    entity.MonthField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("NuidField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Nuid>(entityDefinition,"NuidField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "NuidField");
                }
                else
                {
                    entity.NuidField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("NumberField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"NumberField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "NumberField");
                }
                else
                {
                    entity.NumberField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PercentageField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Percentage>(entityDefinition,"PercentageField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "PercentageField");
                }
                else
                {
                    entity.PercentageField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PhoneNumberField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition,"PhoneNumberField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "PhoneNumberField");
                }
                else
                {
                    entity.PhoneNumberField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TemperatureField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Temperature>(entityDefinition,"TemperatureField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "TemperatureField");
                }
                else
                {
                    entity.TemperatureField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TextField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TextField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "TextField");
                }
                else
                {
                    entity.TextField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TimeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Time>(entityDefinition,"TimeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "TimeField");
                }
                else
                {
                    entity.TimeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TimeZoneCodeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition,"TimeZoneCodeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "TimeZoneCodeField");
                }
                else
                {
                    entity.TimeZoneCodeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("UriField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Uri>(entityDefinition,"UriField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "UriField");
                }
                else
                {
                    entity.UriField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("UrlField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition,"UrlField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "UrlField");
                }
                else
                {
                    entity.UrlField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("UserField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.User>(entityDefinition,"UserField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "UserField");
                }
                else
                {
                    entity.UserField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("VolumeField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Volume>(entityDefinition,"VolumeField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "VolumeField");
                }
                else
                {
                    entity.VolumeField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("WeightField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Weight>(entityDefinition,"WeightField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "WeightField");
                }
                else
                {
                    entity.WeightField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("YamlField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Yaml>(entityDefinition,"YamlField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "YamlField");
                }
                else
                {
                    entity.YamlField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("YearField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Year>(entityDefinition,"YearField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "YearField");
                }
                else
                {
                    entity.YearField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FileField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.File>(entityDefinition,"FileField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "FileField");
                }
                else
                {
                    entity.FileField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ImageField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Image>(entityDefinition,"ImageField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "ImageField");
                }
                else
                {
                    entity.ImageField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LatLongField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"LatLongField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "LatLongField");
                }
                else
                {
                    entity.LatLongField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MoneyField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"MoneyField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "MoneyField");
                }
                else
                {
                    entity.MoneyField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("StreetAddressField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"StreetAddressField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "StreetAddressField");
                }
                else
                {
                    entity.StreetAddressField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TranslatedTextField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.TranslatedText>(entityDefinition,"TranslatedTextField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "TranslatedTextField");
                }
                else
                {
                    entity.TranslatedTextField = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("VatNumberField", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition,"VatNumberField",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("AllNoxType", "VatNumberField");
                }
                else
                {
                    entity.VatNumberField = noxTypeValue;
                }
            }
        }
    }
}