
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
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Factories;

internal partial class PersonFactory : PersonFactoryBase
{
    public PersonFactory
    (
        IRepository repository,
        IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> usercontactselectionfactory
    ) : base(repository, usercontactselectionfactory)
    {}
}

internal abstract class PersonFactoryBase : IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> UserContactSelectionFactory {get;}

    public PersonFactoryBase(
        IRepository repository,
        IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> usercontactselectionfactory
        )
    {
        _repository = repository;
        UserContactSelectionFactory = usercontactselectionfactory;
    }

    public virtual async Task<PersonEntity> CreateEntityAsync(PersonCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(PersonEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }   
    }

    private async Task<ClientApi.Domain.Person> ToEntityAsync(PersonCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Person();
        exceptionCollector.Collect("UserName", () => entity.SetIfNotNull(createDto.UserName, (entity) => entity.UserName = 
            Dto.PersonMetadata.CreateUserName(createDto.UserName.NonNullValue<System.String>())));
        exceptionCollector.Collect("FirstName", () => entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Dto.PersonMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>())));
        exceptionCollector.Collect("LastName", () => entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Dto.PersonMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>())));
        exceptionCollector.Collect("TenantId", () => entity.SetIfNotNull(createDto.TenantId, (entity) => entity.TenantId = 
            Dto.PersonMetadata.CreateTenantId(createDto.TenantId.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("TenantBrandId", () => entity.SetIfNotNull(createDto.TenantBrandId, (entity) => entity.TenantBrandId = 
            Dto.PersonMetadata.CreateTenantBrandId(createDto.TenantBrandId.NonNullValue<System.Guid>())));
        exceptionCollector.Collect("PrimaryEmailAddress", () => entity.SetIfNotNull(createDto.PrimaryEmailAddress, (entity) => entity.PrimaryEmailAddress = 
            Dto.PersonMetadata.CreatePrimaryEmailAddress(createDto.PrimaryEmailAddress.NonNullValue<System.String>())));
        exceptionCollector.Collect("SecondaryEmailAddress", () => entity.SetIfNotNull(createDto.SecondaryEmailAddress, (entity) => entity.SecondaryEmailAddress = 
            Dto.PersonMetadata.CreateSecondaryEmailAddress(createDto.SecondaryEmailAddress.NonNullValue<System.String>())));
        exceptionCollector.Collect("PhoneNumber", () => entity.SetIfNotNull(createDto.PhoneNumber, (entity) => entity.PhoneNumber = 
            Dto.PersonMetadata.CreatePhoneNumber(createDto.PhoneNumber.NonNullValue<System.String>())));
        exceptionCollector.Collect("PrefferedLanguage", () => entity.SetIfNotNull(createDto.PrefferedLanguage, (entity) => entity.PrefferedLanguage = 
            Dto.PersonMetadata.CreatePrefferedLanguage(createDto.PrefferedLanguage.NonNullValue<System.String>())));
        exceptionCollector.Collect("Status", () => entity.SetIfNotNull(createDto.Status, (entity) => entity.Status = 
            Dto.PersonMetadata.CreateStatus(createDto.Status.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("Type", () => entity.SetIfNotNull(createDto.Type, (entity) => entity.Type = 
            Dto.PersonMetadata.CreateType(createDto.Type.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("PreferredLoginMethod", () => entity.SetIfNotNull(createDto.PreferredLoginMethod, (entity) => entity.PreferredLoginMethod = 
            Dto.PersonMetadata.CreatePreferredLoginMethod(createDto.PreferredLoginMethod.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("HCountryIsoCode", () => entity.SetIfNotNull(createDto.HCountryIsoCode, (entity) => entity.HCountryIsoCode = 
            Dto.PersonMetadata.CreateHCountryIsoCode(createDto.HCountryIsoCode.NonNullValue<System.String>())));
        exceptionCollector.Collect("HAcceptedTerms", () => entity.SetIfNotNull(createDto.HAcceptedTerms, (entity) => entity.HAcceptedTerms = 
            Dto.PersonMetadata.CreateHAcceptedTerms(createDto.HAcceptedTerms.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("HEnablePasswordLess", () => entity.SetIfNotNull(createDto.HEnablePasswordLess, (entity) => entity.HEnablePasswordLess = 
            Dto.PersonMetadata.CreateHEnablePasswordLess(createDto.HEnablePasswordLess.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("HPrimaryEmailAddressVerified", () => entity.SetIfNotNull(createDto.HPrimaryEmailAddressVerified, (entity) => entity.HPrimaryEmailAddressVerified = 
            Dto.PersonMetadata.CreateHPrimaryEmailAddressVerified(createDto.HPrimaryEmailAddressVerified.NonNullValue<System.Boolean>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);
        if (createDto.UserContactSelection is not null)
        {
            var userContactSelection = await UserContactSelectionFactory.CreateEntityAsync(createDto.UserContactSelection, cultureCode);
            entity.CreateRefToUserContactSelection(userContactSelection);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.UserName is null)
        {
             entity.UserName = null;
        }
        else
        {
            exceptionCollector.Collect("UserName",() =>entity.UserName = Dto.PersonMetadata.CreateUserName(updateDto.UserName.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("FirstName",() => entity.FirstName = Dto.PersonMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>()));
        exceptionCollector.Collect("LastName",() => entity.LastName = Dto.PersonMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>()));
        exceptionCollector.Collect("TenantId",() => entity.TenantId = Dto.PersonMetadata.CreateTenantId(updateDto.TenantId.NonNullValue<System.Int32>()));
        if(updateDto.TenantBrandId is null)
        {
             entity.TenantBrandId = null;
        }
        else
        {
            exceptionCollector.Collect("TenantBrandId",() =>entity.TenantBrandId = Dto.PersonMetadata.CreateTenantBrandId(updateDto.TenantBrandId.ToValueFromNonNull<System.Guid>()));
        }
        exceptionCollector.Collect("PrimaryEmailAddress",() => entity.PrimaryEmailAddress = Dto.PersonMetadata.CreatePrimaryEmailAddress(updateDto.PrimaryEmailAddress.NonNullValue<System.String>()));
        if(updateDto.SecondaryEmailAddress is null)
        {
             entity.SecondaryEmailAddress = null;
        }
        else
        {
            exceptionCollector.Collect("SecondaryEmailAddress",() =>entity.SecondaryEmailAddress = Dto.PersonMetadata.CreateSecondaryEmailAddress(updateDto.SecondaryEmailAddress.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.PhoneNumber is null)
        {
             entity.PhoneNumber = null;
        }
        else
        {
            exceptionCollector.Collect("PhoneNumber",() =>entity.PhoneNumber = Dto.PersonMetadata.CreatePhoneNumber(updateDto.PhoneNumber.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.PrefferedLanguage is null)
        {
             entity.PrefferedLanguage = null;
        }
        else
        {
            exceptionCollector.Collect("PrefferedLanguage",() =>entity.PrefferedLanguage = Dto.PersonMetadata.CreatePrefferedLanguage(updateDto.PrefferedLanguage.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("Status",() => entity.Status = Dto.PersonMetadata.CreateStatus(updateDto.Status.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Type",() => entity.Type = Dto.PersonMetadata.CreateType(updateDto.Type.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("PreferredLoginMethod",() => entity.PreferredLoginMethod = Dto.PersonMetadata.CreatePreferredLoginMethod(updateDto.PreferredLoginMethod.NonNullValue<System.Int32>()));
        if(updateDto.HCountryIsoCode is null)
        {
             entity.HCountryIsoCode = null;
        }
        else
        {
            exceptionCollector.Collect("HCountryIsoCode",() =>entity.HCountryIsoCode = Dto.PersonMetadata.CreateHCountryIsoCode(updateDto.HCountryIsoCode.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.HAcceptedTerms is null)
        {
             entity.HAcceptedTerms = null;
        }
        else
        {
            exceptionCollector.Collect("HAcceptedTerms",() =>entity.HAcceptedTerms = Dto.PersonMetadata.CreateHAcceptedTerms(updateDto.HAcceptedTerms.ToValueFromNonNull<System.Boolean>()));
        }
        if(updateDto.HEnablePasswordLess is null)
        {
             entity.HEnablePasswordLess = null;
        }
        else
        {
            exceptionCollector.Collect("HEnablePasswordLess",() =>entity.HEnablePasswordLess = Dto.PersonMetadata.CreateHEnablePasswordLess(updateDto.HEnablePasswordLess.ToValueFromNonNull<System.Boolean>()));
        }
        if(updateDto.HPrimaryEmailAddressVerified is null)
        {
             entity.HPrimaryEmailAddressVerified = null;
        }
        else
        {
            exceptionCollector.Collect("HPrimaryEmailAddressVerified",() =>entity.HPrimaryEmailAddressVerified = Dto.PersonMetadata.CreateHPrimaryEmailAddressVerified(updateDto.HPrimaryEmailAddressVerified.ToValueFromNonNull<System.Boolean>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(PersonEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("UserName", out var UserNameUpdateValue))
        {
            if (UserNameUpdateValue == null) { entity.UserName = null; }
            else
            {
                exceptionCollector.Collect("UserName",() =>entity.UserName = Dto.PersonMetadata.CreateUserName(UserNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(FirstNameUpdateValue, "Attribute 'FirstName' can't be null.");
            {
                exceptionCollector.Collect("FirstName",() =>entity.FirstName = Dto.PersonMetadata.CreateFirstName(FirstNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(LastNameUpdateValue, "Attribute 'LastName' can't be null.");
            {
                exceptionCollector.Collect("LastName",() =>entity.LastName = Dto.PersonMetadata.CreateLastName(LastNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TenantId", out var TenantIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TenantIdUpdateValue, "Attribute 'TenantId' can't be null.");
            {
                exceptionCollector.Collect("TenantId",() =>entity.TenantId = Dto.PersonMetadata.CreateTenantId(TenantIdUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TenantBrandId", out var TenantBrandIdUpdateValue))
        {
            if (TenantBrandIdUpdateValue == null) { entity.TenantBrandId = null; }
            else
            {
                exceptionCollector.Collect("TenantBrandId",() =>entity.TenantBrandId = Dto.PersonMetadata.CreateTenantBrandId(TenantBrandIdUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PrimaryEmailAddress", out var PrimaryEmailAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PrimaryEmailAddressUpdateValue, "Attribute 'PrimaryEmailAddress' can't be null.");
            {
                exceptionCollector.Collect("PrimaryEmailAddress",() =>entity.PrimaryEmailAddress = Dto.PersonMetadata.CreatePrimaryEmailAddress(PrimaryEmailAddressUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SecondaryEmailAddress", out var SecondaryEmailAddressUpdateValue))
        {
            if (SecondaryEmailAddressUpdateValue == null) { entity.SecondaryEmailAddress = null; }
            else
            {
                exceptionCollector.Collect("SecondaryEmailAddress",() =>entity.SecondaryEmailAddress = Dto.PersonMetadata.CreateSecondaryEmailAddress(SecondaryEmailAddressUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumber", out var PhoneNumberUpdateValue))
        {
            if (PhoneNumberUpdateValue == null) { entity.PhoneNumber = null; }
            else
            {
                exceptionCollector.Collect("PhoneNumber",() =>entity.PhoneNumber = Dto.PersonMetadata.CreatePhoneNumber(PhoneNumberUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PrefferedLanguage", out var PrefferedLanguageUpdateValue))
        {
            if (PrefferedLanguageUpdateValue == null) { entity.PrefferedLanguage = null; }
            else
            {
                exceptionCollector.Collect("PrefferedLanguage",() =>entity.PrefferedLanguage = Dto.PersonMetadata.CreatePrefferedLanguage(PrefferedLanguageUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Status", out var StatusUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(StatusUpdateValue, "Attribute 'Status' can't be null.");
            {
                exceptionCollector.Collect("Status",() =>entity.Status = Dto.PersonMetadata.CreateStatus(StatusUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TypeUpdateValue, "Attribute 'Type' can't be null.");
            {
                exceptionCollector.Collect("Type",() =>entity.Type = Dto.PersonMetadata.CreateType(TypeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PreferredLoginMethod", out var PreferredLoginMethodUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PreferredLoginMethodUpdateValue, "Attribute 'PreferredLoginMethod' can't be null.");
            {
                exceptionCollector.Collect("PreferredLoginMethod",() =>entity.PreferredLoginMethod = Dto.PersonMetadata.CreatePreferredLoginMethod(PreferredLoginMethodUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("HCountryIsoCode", out var HCountryIsoCodeUpdateValue))
        {
            if (HCountryIsoCodeUpdateValue == null) { entity.HCountryIsoCode = null; }
            else
            {
                exceptionCollector.Collect("HCountryIsoCode",() =>entity.HCountryIsoCode = Dto.PersonMetadata.CreateHCountryIsoCode(HCountryIsoCodeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("HAcceptedTerms", out var HAcceptedTermsUpdateValue))
        {
            if (HAcceptedTermsUpdateValue == null) { entity.HAcceptedTerms = null; }
            else
            {
                exceptionCollector.Collect("HAcceptedTerms",() =>entity.HAcceptedTerms = Dto.PersonMetadata.CreateHAcceptedTerms(HAcceptedTermsUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("HEnablePasswordLess", out var HEnablePasswordLessUpdateValue))
        {
            if (HEnablePasswordLessUpdateValue == null) { entity.HEnablePasswordLess = null; }
            else
            {
                exceptionCollector.Collect("HEnablePasswordLess",() =>entity.HEnablePasswordLess = Dto.PersonMetadata.CreateHEnablePasswordLess(HEnablePasswordLessUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("HPrimaryEmailAddressVerified", out var HPrimaryEmailAddressVerifiedUpdateValue))
        {
            if (HPrimaryEmailAddressVerifiedUpdateValue == null) { entity.HPrimaryEmailAddressVerified = null; }
            else
            {
                exceptionCollector.Collect("HPrimaryEmailAddressVerified",() =>entity.HPrimaryEmailAddressVerified = Dto.PersonMetadata.CreateHPrimaryEmailAddressVerified(HPrimaryEmailAddressVerifiedUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.UserContactSelection is null)
        {
            if(entity.UserContactSelection is not null) 
                _repository.DeleteOwned(entity.UserContactSelection);
			entity.DeleteAllRefToUserContactSelection();
        }
		else
		{
            if(entity.UserContactSelection is not null)
                await UserContactSelectionFactory.UpdateEntityAsync(entity.UserContactSelection, updateDto.UserContactSelection, cultureCode);
            else
			    entity.CreateRefToUserContactSelection(await UserContactSelectionFactory.CreateEntityAsync(updateDto.UserContactSelection, cultureCode));
		}
	}
}