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
using StoreLicense = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application;

public partial class StoreLicenseMapper : EntityMapperBase<StoreLicense>
{
    public StoreLicenseMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(StoreLicense entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Issuer", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Issuer", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("StoreLicense", "Issuer");
                }
                else
                {
                    entity.Issuer = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// StoreLicense Store that this license related to ExactlyOne Stores
        /// </summary>
        if (updatedProperties.TryGetValue("StoreId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition, "StoreWithLicense", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.StoreWithLicenseId = noxRelationshipTypeValue;
            }
        }
    }
}