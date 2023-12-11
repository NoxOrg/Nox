using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

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
        return new() {
        };
    }
}