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
using ClientApi.Application.Dto;
using ClientApi.Domain;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application;

public partial class CountryMapper : EntityMapperBase<Country>
{
    public CountryMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(Country entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Name", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Population", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "Population", value);
                if(noxTypeValue == null)
                {
                    entity.Population = null;
                }
                else
                {
                    entity.Population = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryDebt", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "CountryDebt", value);
                if(noxTypeValue == null)
                {
                    entity.CountryDebt = null;
                }
                else
                {
                    entity.CountryDebt = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FirstLanguageCode", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LanguageCode>(entityDefinition, "FirstLanguageCode", value);
                if(noxTypeValue == null)
                {
                    entity.FirstLanguageCode = null;
                }
                else
                {
                    entity.FirstLanguageCode = noxTypeValue;
                }
            }
        }
    
    
    }
}