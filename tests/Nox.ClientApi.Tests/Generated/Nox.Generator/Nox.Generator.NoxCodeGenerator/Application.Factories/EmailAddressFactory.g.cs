
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

internal partial class EmailAddressFactory : EmailAddressFactoryBase
{
    public EmailAddressFactory
    (
    ) : base()
    {}
}

internal abstract class EmailAddressFactoryBase : IEntityFactory<EmailAddressEntity, EmailAddressUpsertDto, EmailAddressUpsertDto>
{

    public EmailAddressFactoryBase(
        )
    {
    }

    public virtual async Task<EmailAddressEntity> CreateEntityAsync(EmailAddressUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(EmailAddressEntity entity, EmailAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<ClientApi.Domain.EmailAddress> ToEntityAsync(EmailAddressUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.EmailAddress();
        exceptionCollector.Collect("Email", () => entity.SetIfNotNull(createDto.Email, (entity) => entity.Email = 
            ClientApi.Domain.EmailAddressMetadata.CreateEmail(createDto.Email.NonNullValue<System.String>())));
        exceptionCollector.Collect("IsVerified", () => entity.SetIfNotNull(createDto.IsVerified, (entity) => entity.IsVerified = 
            ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmailAddressEntity entity, EmailAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.Email is null)
        {
             entity.Email = null;
        }
        else
        {
            exceptionCollector.Collect("Email",() =>entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(updateDto.Email.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.IsVerified is null)
        {
             entity.IsVerified = null;
        }
        else
        {
            exceptionCollector.Collect("IsVerified",() =>entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(updateDto.IsVerified.ToValueFromNonNull<System.Boolean>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EmailAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            if (EmailUpdateValue == null) { entity.Email = null; }
            else
            {
                exceptionCollector.Collect("Email",() =>entity.Email = ClientApi.Domain.EmailAddressMetadata.CreateEmail(EmailUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("IsVerified", out var IsVerifiedUpdateValue))
        {
            if (IsVerifiedUpdateValue == null) { entity.IsVerified = null; }
            else
            {
                exceptionCollector.Collect("IsVerified",() =>entity.IsVerified = ClientApi.Domain.EmailAddressMetadata.CreateIsVerified(IsVerifiedUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}