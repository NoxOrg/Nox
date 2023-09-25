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
using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using ExchangeRate = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application;

public partial class ExchangeRateMapper : EntityMapperBase<ExchangeRate>
{
    public ExchangeRateMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(ExchangeRate entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("EffectiveRate", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "EffectiveRate", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("ExchangeRate", "EffectiveRate");
                }
                else
                {
                    entity.EffectiveRate = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EffectiveAt", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "EffectiveAt", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("ExchangeRate", "EffectiveAt");
                }
                else
                {
                    entity.EffectiveAt = noxTypeValue;
                }
            }
        }
    
    
    }
}