// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerCreateDto : CustomerUpdateDto
{

    public Cryptocash.Domain.Customer ToEntity()
    {
        var entity = new Cryptocash.Domain.Customer();
        entity.FirstName = Cryptocash.Domain.Customer.CreateFirstName(FirstName);
        entity.LastName = Cryptocash.Domain.Customer.CreateLastName(LastName);
        entity.EmailAddress = Cryptocash.Domain.Customer.CreateEmailAddress(EmailAddress);
        entity.Address = Cryptocash.Domain.Customer.CreateAddress(Address);
        if (MobileNumber is not null)entity.MobileNumber = Cryptocash.Domain.Customer.CreateMobileNumber(MobileNumber.NonNullValue<System.String>());
        //entity.PaymentDetails = PaymentDetails.Select(dto => dto.ToEntity()).ToList();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.Transactions = Transactions.Select(dto => dto.ToEntity()).ToList();
        //entity.Country = Country.ToEntity();
        return entity;
    }
}