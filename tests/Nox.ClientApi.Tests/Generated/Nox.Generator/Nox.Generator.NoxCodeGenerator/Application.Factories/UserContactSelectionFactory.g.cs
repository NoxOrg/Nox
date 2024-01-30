
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;

namespace ClientApi.Application.Factories;

internal partial class UserContactSelectionFactory : UserContactSelectionFactoryBase
{
    public UserContactSelectionFactory
    (
    ) : base()
    {}
}

internal abstract class UserContactSelectionFactoryBase : IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto>
{

    public UserContactSelectionFactoryBase(
        )
    {
    }

    public virtual async Task<UserContactSelectionEntity> CreateEntityAsync(UserContactSelectionUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(UserContactSelectionEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(UserContactSelectionEntity entity, UserContactSelectionUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(UserContactSelectionEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(UserContactSelectionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(UserContactSelectionEntity));
        }   
    }

    private async Task<ClientApi.Domain.UserContactSelection> ToEntityAsync(UserContactSelectionUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.UserContactSelection();
        exceptionCollector.Collect("ContactId", () => entity.SetIfNotNull(createDto.ContactId, (entity) => entity.ContactId = 
            Dto.UserContactSelectionMetadata.CreateContactId(createDto.ContactId.NonNullValue<System.Guid>())));
        exceptionCollector.Collect("AccountId", () => entity.SetIfNotNull(createDto.AccountId, (entity) => entity.AccountId = 
            Dto.UserContactSelectionMetadata.CreateAccountId(createDto.AccountId.NonNullValue<System.Guid>())));
        exceptionCollector.Collect("SelectedDate", () => entity.SetIfNotNull(createDto.SelectedDate, (entity) => entity.SelectedDate = 
            Dto.UserContactSelectionMetadata.CreateSelectedDate(createDto.SelectedDate.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(UserContactSelectionEntity entity, UserContactSelectionUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("ContactId",() => entity.ContactId = Dto.UserContactSelectionMetadata.CreateContactId(updateDto.ContactId.NonNullValue<System.Guid>()));
        exceptionCollector.Collect("AccountId",() => entity.AccountId = Dto.UserContactSelectionMetadata.CreateAccountId(updateDto.AccountId.NonNullValue<System.Guid>()));
        exceptionCollector.Collect("SelectedDate",() => entity.SelectedDate = Dto.UserContactSelectionMetadata.CreateSelectedDate(updateDto.SelectedDate.NonNullValue<System.DateTimeOffset>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(UserContactSelectionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("ContactId", out var ContactIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(ContactIdUpdateValue, "Attribute 'ContactId' can't be null.");
            {
                exceptionCollector.Collect("ContactId",() =>entity.ContactId = Dto.UserContactSelectionMetadata.CreateContactId(ContactIdUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("AccountId", out var AccountIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AccountIdUpdateValue, "Attribute 'AccountId' can't be null.");
            {
                exceptionCollector.Collect("AccountId",() =>entity.AccountId = Dto.UserContactSelectionMetadata.CreateAccountId(AccountIdUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SelectedDate", out var SelectedDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SelectedDateUpdateValue, "Attribute 'SelectedDate' can't be null.");
            {
                exceptionCollector.Collect("SelectedDate",() =>entity.SelectedDate = Dto.UserContactSelectionMetadata.CreateSelectedDate(SelectedDateUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}