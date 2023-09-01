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
using CryptocashApi.Application.Dto;
using CryptocashApi.Domain;

namespace CryptocashApi.Application;

public class CurrencyBankNotesMapper : EntityMapperBase<CurrencyBankNotes>
{
    public CurrencyBankNotesMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CurrencyBankNotes entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "BankNote", dto.BankNote);
        if (noxTypeValue != null)
        {        
            entity.BankNote = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "IsRare", dto.IsRare);
        if (noxTypeValue != null)
        {        
            entity.IsRare = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(CurrencyBankNotes entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("BankNote", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "BankNote", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyBankNotes", "BankNote");
                }
                else
                {
                    entity.BankNote = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("IsRare", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "IsRare", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyBankNotes", "IsRare");
                }
                else
                {
                    entity.IsRare = noxTypeValue;
                }
            }
        }
    
    
    }
}