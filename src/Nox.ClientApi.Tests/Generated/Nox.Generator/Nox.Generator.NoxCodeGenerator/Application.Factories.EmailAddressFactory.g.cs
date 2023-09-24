// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

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
using EmailAddress = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Factories;

public abstract class EmailAddressFactoryBase : IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto>
{

    public EmailAddressFactoryBase
    (
        )
    {
    }

    public virtual EmailAddress CreateEntity(EmailAddressCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(EmailAddress entity, EmailAddressUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(EmailAddress entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.EmailAddress ToEntity(EmailAddressCreateDto createDto)
    {
        var entity = new ClientApi.Domain.EmailAddress();
        if (createDto.Email is not null)entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(createDto.Email.NonNullValue<System.String>());
        if (createDto.IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }

    private void UpdateEntityInternal(EmailAddress entity, EmailAddressUpdateDto updateDto)
    {
        if (updateDto.Email == null) { entity.Email = null; } else {
            entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(updateDto.Email.ToValueFromNonNull<System.String>());
        }
        if (updateDto.IsVerified == null) { entity.IsVerified = null; } else {
            entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(updateDto.IsVerified.ToValueFromNonNull<System.Boolean>());
        }
    }

    private void PartialUpdateEntityInternal(EmailAddress entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            if (EmailUpdateValue == null) { entity.Email = null; }
            else
            {
                entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(EmailUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("IsVerified", out var IsVerifiedUpdateValue))
        {
            if (IsVerifiedUpdateValue == null) { entity.IsVerified = null; }
            else
            {
                entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(IsVerifiedUpdateValue);
            }
        }
    }
}

public partial class EmailAddressFactory : EmailAddressFactoryBase
{
}