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

    public Cryptocash.Domain.PaymentProvider ToEntity()
    {
        var entity = new Cryptocash.Domain.PaymentProvider();
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderName(PaymentProviderName);
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderType(PaymentProviderType);
        //entity.PaymentDetails = PaymentDetails.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}