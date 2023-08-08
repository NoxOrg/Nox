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
using File = Nox.Types.File;
using Boolean = Nox.Types.Boolean;
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class AllNoxTypeFactory: EntityFactoryBase<AllNoxTypeCreateDto, AllNoxType>
{
    public  AllNoxTypeFactory(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    protected override void MapEntity(AllNoxType entity, Entity entityDefinition, AllNoxTypeCreateDto dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    

        // TODO map NuidField Nuid remaining types and remove if else
        noxTypeValue =  CreateNoxType<Boolean>(entityDefinition,"BooleanField",dto.BooleanField);
        if(noxTypeValue != null)
        {        
            entity.BooleanField = noxTypeValue;
        }

        // TODO map CountryCode2Field CountryCode2 remaining types and remove if else

        // TODO map CountryCode3Field CountryCode3 remaining types and remove if else

        // TODO map FormulaField Formula remaining types and remove if else
        noxTypeValue =  CreateNoxType<Number>(entityDefinition,"NumberField",dto.NumberField);
        if(noxTypeValue != null)
        {        
            entity.NumberField = noxTypeValue;
        }
        noxTypeValue =  CreateNoxType<Text>(entityDefinition,"TextField",dto.TextField);
        if(noxTypeValue != null)
        {        
            entity.TextField = noxTypeValue;
        }
        noxTypeValue =  CreateNoxType<StreetAddress>(entityDefinition,"StreetAddressField",dto.StreetAddressField);
        if(noxTypeValue != null)
        {        
            entity.StreetAddressField = noxTypeValue;
        }
        noxTypeValue =  CreateNoxType<File>(entityDefinition,"FileField",dto.FileField);
        if(noxTypeValue != null)
        {        
            entity.FileField = noxTypeValue;
        }
        noxTypeValue =  CreateNoxType<TranslatedText>(entityDefinition,"TranslatedTextField",dto.TranslatedTextField);
        if(noxTypeValue != null)
        {        
            entity.TranslatedTextField = noxTypeValue;
        }
        noxTypeValue =  CreateNoxType<VatNumber>(entityDefinition,"VatNumberField",dto.VatNumberField);
        if(noxTypeValue != null)
        {        
            entity.VatNumberField = noxTypeValue;
        }

        // TODO map PasswordField Password remaining types and remove if else
        noxTypeValue =  CreateNoxType<Money>(entityDefinition,"MoneyField",dto.MoneyField);
        if(noxTypeValue != null)
        {        
            entity.MoneyField = noxTypeValue;
        }

        // TODO map HashedTexField HashedText remaining types and remove if else
        noxTypeValue =  CreateNoxType<LatLong>(entityDefinition,"LatLongField",dto.LatLongField);
        if(noxTypeValue != null)
        {        
            entity.LatLongField = noxTypeValue;
        }
    }
}