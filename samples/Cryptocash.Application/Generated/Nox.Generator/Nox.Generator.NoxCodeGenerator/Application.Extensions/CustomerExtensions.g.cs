﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class CustomerExtensions
{
    public static CustomerDto ToDto(this Cryptocash.Domain.Customer entity)
    {
        var dto = new CustomerDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.FirstName, (dto) => dto.FirstName =entity!.FirstName!.Value);
        dto.SetIfNotNull(entity?.LastName, (dto) => dto.LastName =entity!.LastName!.Value);
        dto.SetIfNotNull(entity?.EmailAddress, (dto) => dto.EmailAddress =entity!.EmailAddress!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.MobileNumber, (dto) => dto.MobileNumber =entity!.MobileNumber!.Value);

        return dto;
    }
}