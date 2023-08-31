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

namespace Cryptocash.Application;

public class BankNotesMapper: EntityMapperBase<BankNotes>
{
    public  BankNotesMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(BankNotes entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"BankNote",dto.BankNote);
        if(noxTypeValue != null)
        {        
            entity.BankNote = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"IsRare",dto.IsRare);
        if(noxTypeValue != null)
        {        
            entity.IsRare = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(BankNotes entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("BankNote", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"BankNote",value);
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
            if (updatedProperties.TryGetValue("IsRare", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"IsRare",value);
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
    }
}