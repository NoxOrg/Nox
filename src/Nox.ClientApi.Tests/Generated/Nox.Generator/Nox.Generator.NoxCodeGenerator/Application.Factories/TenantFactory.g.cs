// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Factories;

internal abstract class TenantFactoryBase : IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TenantFactoryBase
    (
        )
    {
    }

    public virtual TenantEntity CreateEntity(TenantCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Tenant ToEntity(TenantCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Tenant();
        entity.Name = ClientApi.Domain.TenantMetadata.CreateName(createDto.Name);
		entity.EnsureId();
        return entity;
    }

    private void UpdateEntityInternal(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.TenantMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
    }

    private void PartialUpdateEntityInternal(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.TenantMetadata.CreateName(NameUpdateValue);
            }
        }
		entity.EnsureId();
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TenantFactory : TenantFactoryBase
{
}