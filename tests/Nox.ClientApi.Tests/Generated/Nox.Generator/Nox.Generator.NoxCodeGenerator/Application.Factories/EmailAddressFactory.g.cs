﻿// Generated

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

internal partial class EmailAddressFactory : EmailAddressFactoryBase
{
    public EmailAddressFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class EmailAddressFactoryBase : IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public EmailAddressFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<EmailAddressEntity> CreateEntityAsync(EmailAddressUpsertDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(EmailAddressEntity entity, EmailAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<ClientApi.Domain.EmailAddress> ToEntityAsync(EmailAddressUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.EmailAddress();
        entity.SetIfNotNull(createDto.Email, (entity) => entity.Email = 
            ClientApi.Domain.EmailAddressMetadata.CreateEmail(createDto.Email.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.IsVerified, (entity) => entity.IsVerified = 
            ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmailAddressEntity entity, EmailAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.Email is null)
        {
             entity.Email = null;
        }
        else
        {
            entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(updateDto.Email.ToValueFromNonNull<System.String>());
        }
        if(updateDto.IsVerified is null)
        {
             entity.IsVerified = null;
        }
        else
        {
            entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(updateDto.IsVerified.ToValueFromNonNull<System.Boolean>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}