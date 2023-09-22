// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Factories;

public abstract class BookingFactoryBase : IEntityFactory<Booking, BookingCreateDto, BookingUpdateDto>
{

    public BookingFactoryBase
    (
        )
    {
    }

    public virtual Booking CreateEntity(BookingCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(Booking entity, BookingUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.Booking ToEntity(BookingCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Booking();
        entity.AmountFrom = Cryptocash.Domain.Booking.CreateAmountFrom(createDto.AmountFrom);
        entity.AmountTo = Cryptocash.Domain.Booking.CreateAmountTo(createDto.AmountTo);
        entity.RequestedPickUpDate = Cryptocash.Domain.Booking.CreateRequestedPickUpDate(createDto.RequestedPickUpDate);
        if (createDto.PickedUpDateTime is not null)entity.PickedUpDateTime = Cryptocash.Domain.Booking.CreatePickedUpDateTime(createDto.PickedUpDateTime.NonNullValue<DateTimeRangeDto>());
        if (createDto.ExpiryDateTime is not null)entity.ExpiryDateTime = Cryptocash.Domain.Booking.CreateExpiryDateTime(createDto.ExpiryDateTime.NonNullValue<System.DateTimeOffset>());
        if (createDto.CancelledDateTime is not null)entity.CancelledDateTime = Cryptocash.Domain.Booking.CreateCancelledDateTime(createDto.CancelledDateTime.NonNullValue<System.DateTimeOffset>());
        if (createDto.VatNumber is not null)entity.VatNumber = Cryptocash.Domain.Booking.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>());
        entity.EnsureId(createDto.Id);
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.Transaction = Transaction.ToEntity();
        return entity;
    }

    private void UpdateEntityInternal(Booking entity, BookingUpdateDto updateDto)
    {
        entity.AmountFrom = Cryptocash.Domain.Booking.CreateAmountFrom(updateDto.AmountFrom.NonNullValue<MoneyDto>());
        entity.AmountTo = Cryptocash.Domain.Booking.CreateAmountTo(updateDto.AmountTo.NonNullValue<MoneyDto>());
        entity.RequestedPickUpDate = Cryptocash.Domain.Booking.CreateRequestedPickUpDate(updateDto.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>());
        if (updateDto.PickedUpDateTime == null) { entity.PickedUpDateTime = null; } else {
            entity.PickedUpDateTime = Cryptocash.Domain.Booking.CreatePickedUpDateTime(updateDto.PickedUpDateTime.ToValueFromNonNull<DateTimeRangeDto>());
        }
        if (updateDto.ExpiryDateTime == null) { entity.ExpiryDateTime = null; } else {
            entity.ExpiryDateTime = Cryptocash.Domain.Booking.CreateExpiryDateTime(updateDto.ExpiryDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if (updateDto.CancelledDateTime == null) { entity.CancelledDateTime = null; } else {
            entity.CancelledDateTime = Cryptocash.Domain.Booking.CreateCancelledDateTime(updateDto.CancelledDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if (updateDto.VatNumber == null) { entity.VatNumber = null; } else {
            entity.VatNumber = Cryptocash.Domain.Booking.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>());
        }
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.Transaction = Transaction.ToEntity();
    }
}

public partial class BookingFactory : BookingFactoryBase
{
}