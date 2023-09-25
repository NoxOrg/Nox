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
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application;

public partial class CurrencyMapper : EntityMapperBase<Currency>
{
    public CurrencyMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(Currency entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Currency", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition, "CurrencyIsoNumeric", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "CurrencyIsoNumeric");
                }
                else
                {
                    entity.CurrencyIsoNumeric = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Symbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Symbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "Symbol");
                }
                else
                {
                    entity.Symbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ThousandsSeparator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "ThousandsSeparator", value);
                if(noxTypeValue == null)
                {
                    entity.ThousandsSeparator = null;
                }
                else
                {
                    entity.ThousandsSeparator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DecimalSeparator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DecimalSeparator", value);
                if(noxTypeValue == null)
                {
                    entity.DecimalSeparator = null;
                }
                else
                {
                    entity.DecimalSeparator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "SpaceBetweenAmountAndSymbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "SpaceBetweenAmountAndSymbol");
                }
                else
                {
                    entity.SpaceBetweenAmountAndSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DecimalDigits", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "DecimalDigits", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "DecimalDigits");
                }
                else
                {
                    entity.DecimalDigits = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MajorName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MajorName");
                }
                else
                {
                    entity.MajorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MajorSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorSymbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MajorSymbol");
                }
                else
                {
                    entity.MajorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorName");
                }
                else
                {
                    entity.MinorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorSymbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorSymbol");
                }
                else
                {
                    entity.MinorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorToMajorValue", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "MinorToMajorValue", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorToMajorValue");
                }
                else
                {
                    entity.MinorToMajorValue = noxTypeValue;
                }
            }
        }
    
    
    }
}