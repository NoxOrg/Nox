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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Factories;

internal abstract class TenantContactFactoryBase : IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TenantContactFactoryBase()
    {
    }

    public virtual TenantContactEntity CreateEntity(TenantContactUpsertDto createDto)
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

    public virtual void UpdateEntity(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.TenantContact ToEntity(TenantContactUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.TenantContact();
        entity.Name = ClientApi.Domain.TenantContactMetadata.CreateName(createDto.Name);
        entity.Description = ClientApi.Domain.TenantContactMetadata.CreateDescription(createDto.Description);
        entity.Email = ClientApi.Domain.TenantContactMetadata.CreateEmail(createDto.Email);
        return entity;
    }

    private void UpdateEntityInternal(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.TenantContactMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(IsDefaultCultureCode(cultureCode)) entity.Description = ClientApi.Domain.TenantContactMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>());
        entity.Email = ClientApi.Domain.TenantContactMetadata.CreateEmail(updateDto.Email.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.TenantContactMetadata.CreateName(NameUpdateValue);
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Description' can't be null");
            }
            {
                entity.Description = ClientApi.Domain.TenantContactMetadata.CreateDescription(DescriptionUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            if (EmailUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Email' can't be null");
            }
            {
                entity.Email = ClientApi.Domain.TenantContactMetadata.CreateEmail(EmailUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TenantContactFactory : TenantContactFactoryBase
{
}