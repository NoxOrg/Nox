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

    public Customer ToEntity()
    {
        var entity = new Customer();
        entity.FirstName = Customer.CreateFirstName(FirstName);
        entity.LastName = Customer.CreateLastName(LastName);
        entity.EmailAddress = Customer.CreateEmailAddress(EmailAddress);
        entity.Address = Customer.CreateAddress(Address);
        if (MobileNumber is not null)entity.MobileNumber = Customer.CreateMobileNumber(MobileNumber.NonNullValue<System.String>());
        //entity.CustomerPaymentDetails = CustomerPaymentDetails.Select(dto => dto.ToEntity()).ToList();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.CustomerTransactions = CustomerTransactions.Select(dto => dto.ToEntity()).ToList();
        //entity.Country = Country.ToEntity();
        return entity;
    }
}