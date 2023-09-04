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
using BankNotes = Cryptocash.Domain.BankNotes;

namespace Cryptocash.Application;

public class BankNotesMapper : EntityMapperBase<BankNotes>
{
    public BankNotesMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(BankNotes entity, Entity entityDefinition, dynamic dto)
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
    

        /// <summary>
        /// BankNotes Currency's bank notes ExactlyOne Currencies
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Currency", dto.CurrencyId);
        if (noxTypeValue != null)
        {        
            entity.CurrencyId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(BankNotes entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("BankNotes", "BankNote");
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
                    throw new EntityAttributeIsNotNullableException("BankNotes", "IsRare");
                }
                else
                {
                    entity.IsRare = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// BankNotes Currency's bank notes ExactlyOne Currencies
        /// </summary>
        if (updatedProperties.TryGetValue("CurrencyId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Currency", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CurrencyId = noxRelationshipTypeValue;
            }
        }
    }
}