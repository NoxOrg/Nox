﻿// Generated

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
using CountryLocalName = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application;

public partial class CountryLocalNameMapper : EntityMapperBase<CountryLocalName>
{
    public CountryLocalNameMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryLocalName entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used        
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue == null)
        {
            throw new NullReferenceException("Name is required can not be set to null");
        }     
        entity.Name = noxTypeValue;        
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "NativeName", dto.NativeName);     
        entity.NativeName = noxTypeValue;
    
    }

    public override void PartialMapToEntity(CountryLocalName entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CountryLocalName", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("NativeName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "NativeName", value);
                if(noxTypeValue == null)
                {
                    entity.NativeName = null;
                }
                else
                {
                    entity.NativeName = noxTypeValue;
                }
            }
        }
    
    
    }
}