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
using CountryHoliday = Cryptocash.Domain.CountryHoliday;

namespace Cryptocash.Application;

public class CountryHolidayMapper : EntityMapperBase<CountryHoliday>
{
    public CountryHolidayMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryHoliday entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Type", dto.Type);
        if (noxTypeValue != null)
        {        
            entity.Type = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "Date", dto.Date);
        if (noxTypeValue != null)
        {        
            entity.Date = noxTypeValue;
        }
    

        /// <summary>
        /// CountryHoliday Country's holidays ExactlyOne Countries
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Country", dto.CountryId);
        if (noxTypeValue != null)
        {        
            entity.CountryId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CountryHoliday entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CountryHoliday", "Name");
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
                    throw new EntityAttributeIsNotNullableException("CountryHoliday", "Type");
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
                    throw new EntityAttributeIsNotNullableException("CountryHoliday", "Date");
                }
                else
                {
                    entity.Date = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// CountryHoliday Country's holidays ExactlyOne Countries
        /// </summary>
        if (updatedProperties.TryGetValue("CountryId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Country", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CountryId = noxRelationshipTypeValue;
            }
        }
    }
}