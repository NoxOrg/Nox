using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Extensions;

namespace Cryptocash.Infrastructure;

internal class CryptocashBookingDataSeeder : DataSeederBase<BookingDto, Booking>
{
    public CryptocashBookingDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashBooking.json";

    protected override Booking TransformToEntity(BookingDto model)
    {
        Booking entity = new() {
            AmountFrom = Money.From(model.AmountFrom!.Amount, model.AmountFrom!.CurrencyCode),
            AmountTo = Money.From(model.AmountTo!.Amount, model.AmountTo!.CurrencyCode),
            RequestedPickUpDate = DateTimeRange.From(model.RequestedPickUpDate.Start, model.RequestedPickUpDate.End),
            ExpiryDateTime = Nox.Types.DateTime.From(model.ExpiryDateTime!.Value),
            VatNumber = model.VatNumber == null ? null : VatNumber.From(model.VatNumber.Number!, model.VatNumber.CountryCode),
            CustomerId = Nox.Types.Guid.From(model.CustomerId!.Value.ToString()),
            VendingMachineId = Nox.Types.Guid.From(model.VendingMachineId!.Value.ToString()),
            CommissionId = Nox.Types.Guid.From(model.CommissionId!.Value.ToString()),
        };

        entity.EnsureId(model.Id);

        return entity;
    }
}