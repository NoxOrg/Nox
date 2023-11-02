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
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Factories;

internal abstract class EmailAddressFactoryBase : IEntityFactory<EmailAddressEntity, EmailAddressCreateDto, EmailAddressUpdateDto>
{

    public EmailAddressFactoryBase
    (
        )
    {
    }

    public virtual EmailAddressEntity CreateEntity(EmailAddressCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(EmailAddressEntity entity, EmailAddressUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.EmailAddress ToEntity(EmailAddressCreateDto createDto)
    {
        var entity = new ClientApi.Domain.EmailAddress();
        if (createDto.Email is not null)entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(createDto.Email.NonNullValue<System.String>());
        if (createDto.IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }

    private void UpdateEntityInternal(EmailAddressEntity entity, EmailAddressUpdateDto updateDto)
    {
        if (updateDto.Email == null) { entity.Email = null; } else {
            entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(updateDto.Email.ToValueFromNonNull<System.String>());
        }
        if (updateDto.IsVerified == null) { entity.IsVerified = null; } else {
            entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(updateDto.IsVerified.ToValueFromNonNull<System.Boolean>());
        }
    }

    private void PartialUpdateEntityInternal(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            if (EmailUpdateValue == null) { entity.Email = null; }
            else
            {
                entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(EmailUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("IsVerified", out var IsVerifiedUpdateValue))
        {
            if (IsVerifiedUpdateValue == null) { entity.IsVerified = null; }
            else
            {
                entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(IsVerifiedUpdateValue);
            }
        }
    }
}

internal partial class EmailAddressFactory : EmailAddressFactoryBase
{
}