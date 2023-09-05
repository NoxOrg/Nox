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
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderCreateDto : PaymentProviderUpdateDto
{

    public PaymentProvider ToEntity()
    {
        var entity = new PaymentProvider();
        entity.PaymentProviderName = PaymentProvider.CreatePaymentProviderName(PaymentProviderName);
        entity.PaymentProviderType = PaymentProvider.CreatePaymentProviderType(PaymentProviderType);
        //entity.CustomerPaymentDetails = CustomerPaymentDetails.ToEntity();
        return entity;
    }
}