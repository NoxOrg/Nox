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
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Factories;

internal abstract class TenantBrandFactoryBase : IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TenantBrandFactoryBase()
    {
    }

    public virtual TenantBrandEntity CreateEntity(TenantBrandUpsertDto createDto)
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

    public virtual void UpdateEntity(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.TenantBrand ToEntity(TenantBrandUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.TenantBrand();
        entity.Name = ClientApi.Domain.TenantBrandMetadata.CreateName(createDto.Name);
        entity.Description = ClientApi.Domain.TenantBrandMetadata.CreateDescription(createDto.Description);
        return entity;
    }

    private void UpdateEntityInternal(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.TenantBrandMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(IsDefaultCultureCode(cultureCode)) entity.Description = ClientApi.Domain.TenantBrandMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.TenantBrandMetadata.CreateName(NameUpdateValue);
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Description' can't be null");
            }
            {
                entity.Description = ClientApi.Domain.TenantBrandMetadata.CreateDescription(DescriptionUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TenantBrandFactory : TenantBrandFactoryBase
{
}