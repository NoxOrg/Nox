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
using CountryQualityOfLifeIndex = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application;

public partial class CountryQualityOfLifeIndexMapper : EntityMapperBase<CountryQualityOfLifeIndex>
{
    public CountryQualityOfLifeIndexMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(CountryQualityOfLifeIndex entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("IndexRating", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "IndexRating", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CountryQualityOfLifeIndex", "IndexRating");
                }
                else
                {
                    entity.IndexRating = noxTypeValue;
                }
            }
        }
    
    
    }
}