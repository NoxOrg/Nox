﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CurrencyMapper: EntityMapperBase<Currency>
{
    public  CurrencyMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Currency entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Currency entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, List<string> deletedPropertyNames)
    {

    }
}