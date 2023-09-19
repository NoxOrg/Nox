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

    public void UpdateEntity(Booking entity, BookingUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
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

    private void MapEntity(Booking entity, BookingUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.AmountFrom = Cryptocash.Domain.Booking.CreateAmountFrom(updateDto.AmountFrom);
        entity.AmountTo = Cryptocash.Domain.Booking.CreateAmountTo(updateDto.AmountTo);
        entity.RequestedPickUpDate = Cryptocash.Domain.Booking.CreateRequestedPickUpDate(updateDto.RequestedPickUpDate);
        if (updateDto.PickedUpDateTime is not null)entity.PickedUpDateTime = Cryptocash.Domain.Booking.CreatePickedUpDateTime(updateDto.PickedUpDateTime.NonNullValue<DateTimeRangeDto>());
        if (updateDto.ExpiryDateTime is not null)entity.ExpiryDateTime = Cryptocash.Domain.Booking.CreateExpiryDateTime(updateDto.ExpiryDateTime.NonNullValue<System.DateTimeOffset>());
        if (updateDto.CancelledDateTime is not null)entity.CancelledDateTime = Cryptocash.Domain.Booking.CreateCancelledDateTime(updateDto.CancelledDateTime.NonNullValue<System.DateTimeOffset>());
        if (updateDto.VatNumber is not null)entity.VatNumber = Cryptocash.Domain.Booking.CreateVatNumber(updateDto.VatNumber.NonNullValue<VatNumberDto>());

        // TODO: discuss about keys
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.Transaction = Transaction.ToEntity();
    }
}

public partial class BookingFactory : BookingFactoryBase
{
}