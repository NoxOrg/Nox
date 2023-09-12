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
using Holiday = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application;

public partial class HolidayMapper : EntityMapperBase<Holiday>
{
    public HolidayMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Holiday entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used

            
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue == null)
        {
            throw new Exception("Name is required can not be set to null");
        }     
            entity.Name = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Type", dto.Type);
        if (noxTypeValue == null)
        {
            throw new Exception("Type is required can not be set to null");
        }     
            entity.Type = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "Date", dto.Date);
        if (noxTypeValue == null)
        {
            throw new Exception("Date is required can not be set to null");
        }     
            entity.Date = noxTypeValue;
    
    }

    public override void PartialMapToEntity(Holiday entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Holiday", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Type", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Type", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Holiday", "Type");
                }
                else
                {
                    entity.Type = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Date", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "Date", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Holiday", "Date");
                }
                else
                {
                    entity.Date = noxTypeValue;
                }
            }
        }
    
    
    }
}