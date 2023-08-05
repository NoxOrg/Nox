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
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"TextField",dto.TextField);
            if(noxTypeValue != null)
            {        
                entity.TextField = noxTypeValue;
            }     
    // TODO map CountryCode2Field CountryCode2 remaining types and remove if else     
    // TODO map CountryCode3Field CountryCode3 remaining types and remove if else     
    // TODO map FormulaField Formula remaining types and remove if else     
    // TODO map StreetAddressField StreetAddress remaining types and remove if else     
    // TODO map FileField File remaining types and remove if else     
    // TODO map TranslatedTextField TranslatedText remaining types and remove if else     
    // TODO map VatNumberField VatNumber remaining types and remove if else     
    // TODO map PasswordField Password remaining types and remove if else     
    // TODO map MoneyField Money remaining types and remove if else     
    // TODO map HashedTexField HashedText remaining types and remove if else     
    // TODO map LatLongField LatLong remaining types and remove if else
    }
}