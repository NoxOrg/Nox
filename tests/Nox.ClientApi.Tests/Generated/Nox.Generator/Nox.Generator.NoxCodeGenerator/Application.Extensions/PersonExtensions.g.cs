// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class PersonExtensions
{
    public static PersonDto ToDto(this ClientApi.Domain.Person entity)
    {
        var dto = new PersonDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.UserName, (dto) => dto.UserName =entity!.UserName!.Value);
        dto.SetIfNotNull(entity?.FirstName, (dto) => dto.FirstName =entity!.FirstName!.Value);
        dto.SetIfNotNull(entity?.LastName, (dto) => dto.LastName =entity!.LastName!.Value);
        dto.SetIfNotNull(entity?.TenantId, (dto) => dto.TenantId =entity!.TenantId!.Value);
        dto.SetIfNotNull(entity?.TenantBrandId, (dto) => dto.TenantBrandId =entity!.TenantBrandId!.Value);
        dto.SetIfNotNull(entity?.PrimaryEmailAddress, (dto) => dto.PrimaryEmailAddress =entity!.PrimaryEmailAddress!.Value);
        dto.SetIfNotNull(entity?.SecondaryEmailAddress, (dto) => dto.SecondaryEmailAddress =entity!.SecondaryEmailAddress!.Value);
        dto.SetIfNotNull(entity?.PhoneNumber, (dto) => dto.PhoneNumber =entity!.PhoneNumber!.Value);
        dto.SetIfNotNull(entity?.PrefferedLanguage, (dto) => dto.PrefferedLanguage =entity!.PrefferedLanguage!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status!.Value);
        dto.SetIfNotNull(entity?.Type, (dto) => dto.Type =entity!.Type!.Value);
        dto.SetIfNotNull(entity?.UserProfileId, (dto) => dto.UserProfileId =entity!.UserProfileId!.Value);
        dto.SetIfNotNull(entity?.PreferredLoginMethod, (dto) => dto.PreferredLoginMethod =entity!.PreferredLoginMethod!.Value);
        dto.SetIfNotNull(entity?.HCountryIsoCode, (dto) => dto.HCountryIsoCode =entity!.HCountryIsoCode!.Value);
        dto.SetIfNotNull(entity?.HAcceptedTerms, (dto) => dto.HAcceptedTerms =entity!.HAcceptedTerms!.Value);
        dto.SetIfNotNull(entity?.HEnablePasswordLess, (dto) => dto.HEnablePasswordLess =entity!.HEnablePasswordLess!.Value);
        dto.SetIfNotNull(entity?.HPrimaryEmailAddressVerified, (dto) => dto.HPrimaryEmailAddressVerified =entity!.HPrimaryEmailAddressVerified!.Value);
        dto.SetIfNotNull(entity?.UserContactSelection, (dto) => dto.UserContactSelection = entity!.UserContactSelection!.ToDto());

        return dto;
    }
}