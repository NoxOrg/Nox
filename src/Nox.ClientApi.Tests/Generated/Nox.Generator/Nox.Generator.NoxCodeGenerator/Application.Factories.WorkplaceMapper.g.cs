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
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application;

public partial class WorkplaceMapper : EntityMapperBase<Workplace>
{
    public WorkplaceMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void PartialMapToEntity(Workplace entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Workplace", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Workplace Workplace country ZeroOrOne Countries
        /// </summary>
        if (updatedProperties.TryGetValue("CountryId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.AutoNumber>(entityDefinition, "BelongsToCountry", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.BelongsToCountryId = noxRelationshipTypeValue;
            }
        }
    }
}