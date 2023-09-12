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
using BankNote = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application;

public partial class BankNoteMapper : EntityMapperBase<BankNote>
{
    public BankNoteMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(BankNote entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used

            
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "CashNote", dto.CashNote);
        if (noxTypeValue == null)
        {
            throw new Exception("CashNote is required can not be set to null");
        }     
            entity.CashNote = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Value", dto.Value);
        if (noxTypeValue == null)
        {
            throw new Exception("Value is required can not be set to null");
        }     
            entity.Value = noxTypeValue;
    
    }

    public override void PartialMapToEntity(BankNote entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("CashNote", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "CashNote", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("BankNote", "CashNote");
                }
                else
                {
                    entity.CashNote = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Value", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Value", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("BankNote", "Value");
                }
                else
                {
                    entity.Value = noxTypeValue;
                }
            }
        }
    
    
    }
}