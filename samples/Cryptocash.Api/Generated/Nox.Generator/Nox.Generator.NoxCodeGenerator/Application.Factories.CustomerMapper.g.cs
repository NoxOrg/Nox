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
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application;

public partial class CustomerMapper : EntityMapperBase<Customer>
{
    public CustomerMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(Customer entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("FirstName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FirstName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "FirstName");
                }
                else
                {
                    entity.FirstName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "LastName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EmailAddress", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "EmailAddress", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "EmailAddress");
                }
                else
                {
                    entity.EmailAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Address", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "Address", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "Address");
                }
                else
                {
                    entity.Address = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MobileNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition, "MobileNumber", value);
                if(noxTypeValue == null)
                {
                    entity.MobileNumber = null;
                }
                else
                {
                    entity.MobileNumber = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Customer based in ExactlyOne Countries
        /// </summary>
        if (updatedProperties.TryGetValue("CountryId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "CustomerBaseCountry", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CustomerBaseCountryId = noxRelationshipTypeValue;
            }
        }
    }
}