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

public abstract class BookingFactoryBase: IEntityFactory<Booking,BookingCreateDto>
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
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.Transaction = Transaction.ToEntity();
        return entity;
    }
}

public partial class BookingFactory : BookingFactoryBase
{
}