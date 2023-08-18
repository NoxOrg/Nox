// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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
    

        // TODO map NuidField Nuid remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"BooleanField",dto.BooleanField);
        if(noxTypeValue != null)
        {        
            entity.BooleanField = noxTypeValue;
        }

        // TODO map CountryCode2Field CountryCode2 remaining types and remove if else

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
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"DateTimeField",dto.DateTimeField);
        if(noxTypeValue != null)
        {        
            entity.DateTimeField = noxTypeValue;
        }

        // TODO map FormulaField Formula remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Html>(entityDefinition,"HtmlField",dto.HtmlField);
        if(noxTypeValue != null)
        {        
            entity.HtmlField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Markdown>(entityDefinition,"MarkdownField",dto.MarkdownField);
        if(noxTypeValue != null)
        {        
            entity.MarkdownField = noxTypeValue;
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
        noxTypeValue = CreateNoxType<Nox.Types.Weight>(entityDefinition,"WeightField",dto.WeightField);
        if(noxTypeValue != null)
        {        
            entity.WeightField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Volume>(entityDefinition,"VolumeField",dto.VolumeField);
        if(noxTypeValue != null)
        {        
            entity.VolumeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition,"UrlField",dto.UrlField);
        if(noxTypeValue != null)
        {        
            entity.UrlField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Uri>(entityDefinition,"UriField",dto.UriField);
        if(noxTypeValue != null)
        {        
            entity.UriField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition,"TimeZoneCodeField",dto.TimeZoneCodeField);
        if(noxTypeValue != null)
        {        
            entity.TimeZoneCodeField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Temperature>(entityDefinition,"TemperatureField",dto.TemperatureField);
        if(noxTypeValue != null)
        {        
            entity.TemperatureField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Percentage>(entityDefinition,"PercentageField",dto.PercentageField);
        if(noxTypeValue != null)
        {        
            entity.PercentageField = noxTypeValue;
        }

        // TODO map TimeField Time remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"NumberField",dto.NumberField);
        if(noxTypeValue != null)
        {        
            entity.NumberField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TextField",dto.TextField);
        if(noxTypeValue != null)
        {        
            entity.TextField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"StreetAddressField",dto.StreetAddressField);
        if(noxTypeValue != null)
        {        
            entity.StreetAddressField = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.File>(entityDefinition,"FileField",dto.FileField);
        if(noxTypeValue != null)
        {        
            entity.FileField = noxTypeValue;
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

        // TODO map PasswordField Password remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"MoneyField",dto.MoneyField);
        if(noxTypeValue != null)
        {        
            entity.MoneyField = noxTypeValue;
        }

        // TODO map HashedTexField HashedText remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"LatLongField",dto.LatLongField);
        if(noxTypeValue != null)
        {        
            entity.LatLongField = noxTypeValue;
        }

        // TODO map EncryptedTextField EncryptedText remaining types and remove if else
    }

    public override void PartialMapToEntity(AllNoxType entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames)
    {
      
        if(deletedPropertyNames.Contains("NuidField"))
        {
            entity.NuidField = null;
        }  
        if(deletedPropertyNames.Contains("BooleanField"))
        {
            entity.BooleanField = null;
        }  
        if(deletedPropertyNames.Contains("CountryCode2Field"))
        {
            throw new EntityAttributeIsNotNullableException("AllNoxType", "CountryCode2Field");
        }  
        if(deletedPropertyNames.Contains("CountryCode3Field"))
        {
            entity.CountryCode3Field = null;
        }  
        if(deletedPropertyNames.Contains("CountryNumberField"))
        {
            entity.CountryNumberField = null;
        }  
        if(deletedPropertyNames.Contains("CultureCodeField"))
        {
            entity.CultureCodeField = null;
        }  
        if(deletedPropertyNames.Contains("CurrencyCode3Field"))
        {
            entity.CurrencyCode3Field = null;
        }  
        if(deletedPropertyNames.Contains("DateTimeField"))
        {
            entity.DateTimeField = null;
        }  
        if(deletedPropertyNames.Contains("HtmlField"))
        {
            entity.HtmlField = null;
        }  
        if(deletedPropertyNames.Contains("MarkdownField"))
        {
            entity.MarkdownField = null;
        }  
        if(deletedPropertyNames.Contains("YamlField"))
        {
            entity.YamlField = null;
        }  
        if(deletedPropertyNames.Contains("YearField"))
        {
            entity.YearField = null;
        }  
        if(deletedPropertyNames.Contains("WeightField"))
        {
            entity.WeightField = null;
        }  
        if(deletedPropertyNames.Contains("VolumeField"))
        {
            entity.VolumeField = null;
        }  
        if(deletedPropertyNames.Contains("UrlField"))
        {
            entity.UrlField = null;
        }  
        if(deletedPropertyNames.Contains("UriField"))
        {
            entity.UriField = null;
        }  
        if(deletedPropertyNames.Contains("TimeZoneCodeField"))
        {
            entity.TimeZoneCodeField = null;
        }  
        if(deletedPropertyNames.Contains("TemperatureField"))
        {
            entity.TemperatureField = null;
        }  
        if(deletedPropertyNames.Contains("PercentageField"))
        {
            entity.PercentageField = null;
        }  
        if(deletedPropertyNames.Contains("TimeField"))
        {
            entity.TimeField = null;
        }  
        if(deletedPropertyNames.Contains("NumberField"))
        {
            entity.NumberField = null;
        }  
        if(deletedPropertyNames.Contains("TextField"))
        {
            throw new EntityAttributeIsNotNullableException("AllNoxType", "TextField");
        }  
        if(deletedPropertyNames.Contains("StreetAddressField"))
        {
            entity.StreetAddressField = null;
        }  
        if(deletedPropertyNames.Contains("FileField"))
        {
            entity.FileField = null;
        }  
        if(deletedPropertyNames.Contains("TranslatedTextField"))
        {
            entity.TranslatedTextField = null;
        }  
        if(deletedPropertyNames.Contains("VatNumberField"))
        {
            entity.VatNumberField = null;
        }  
        if(deletedPropertyNames.Contains("MoneyField"))
        {
            entity.MoneyField = null;
        }  
        if(deletedPropertyNames.Contains("LatLongField"))
        {
            entity.LatLongField = null;
        }    
    }
}