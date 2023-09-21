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
using ClientApi.Application.Dto;
using ClientApi.Domain;
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application;

public partial class StoreOwnerMapper : EntityMapperBase<StoreOwner>
{
    public StoreOwnerMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(StoreOwner entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("StoreOwner", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TemporaryOwnerName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TemporaryOwnerName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("StoreOwner", "TemporaryOwnerName");
                }
                else
                {
                    entity.TemporaryOwnerName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("VatNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition, "VatNumber", value);
                if(noxTypeValue == null)
                {
                    entity.VatNumber = null;
                }
                else
                {
                    entity.VatNumber = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("StreetAddress", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "StreetAddress", value);
                if(noxTypeValue == null)
                {
                    entity.StreetAddress = null;
                }
                else
                {
                    entity.StreetAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LocalGreeting", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.TranslatedText>(entityDefinition, "LocalGreeting", value);
                if(noxTypeValue == null)
                {
                    entity.LocalGreeting = null;
                }
                else
                {
                    entity.LocalGreeting = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Notes", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Notes", value);
                if(noxTypeValue == null)
                {
                    entity.Notes = null;
                }
                else
                {
                    entity.Notes = noxTypeValue;
                }
            }
        }
    
    
    }
}