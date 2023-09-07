// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using Cryptocash.Application.Dto;

namespace Cryptocash.Presentation.Api.OData;

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<BookingDto>().HasKey(e => new { e.Id });
        builder.EntityType<CommissionDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryDto>().HasKey(e => new { e.Id });
        builder.EntityType<HolidayDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryTimeZoneDto>().HasKey(e => new { e.Id });
        builder.EntityType<CurrencyDto>().HasKey(e => new { e.Id });
        builder.EntityType<BankNoteDto>().HasKey(e => new { e.Id });
        builder.EntityType<CustomerDto>().HasKey(e => new { e.Id });
        builder.EntityType<PaymentDetailDto>().HasKey(e => new { e.Id });
        builder.EntityType<TransactionDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmployeeDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmployeePhoneNumberDto>().HasKey(e => new { e.Id });
        builder.EntityType<ExchangeRateDto>().HasKey(e => new { e.Id });
        builder.EntityType<LandLordDto>().HasKey(e => new { e.Id });
        builder.EntityType<MinimumCashStockDto>().HasKey(e => new { e.Id });
        builder.EntityType<PaymentProviderDto>().HasKey(e => new { e.Id });
        builder.EntityType<VendingMachineDto>().HasKey(e => new { e.Id });
        builder.EntityType<CashStockOrderDto>().HasKey(e => new { e.Id });


        builder.EntitySet<BookingDto>("Bookings");

        builder.EntityType<BookingDto>();
        builder.EntityType<BookingDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CommissionDto>("Commissions");

        builder.EntityType<CommissionDto>();
        builder.EntityType<CommissionDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryTimeZones).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.Holidays).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<HolidayDto>();

        builder.EntityType<CountryTimeZoneDto>();

        builder.EntitySet<CurrencyDto>("Currencies");
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.BankNotes).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.ExchangeRates).AutoExpand = true;

        builder.EntityType<CurrencyDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<BankNoteDto>();

        builder.EntitySet<CustomerDto>("Customers");

        builder.EntityType<CustomerDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<PaymentDetailDto>("PaymentDetails");

        builder.EntityType<PaymentDetailDto>();
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<TransactionDto>("Transactions");

        builder.EntityType<TransactionDto>();
        builder.EntityType<TransactionDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeDto>().ContainsMany(e => e.EmployeePhoneNumbers).AutoExpand = true;

        builder.EntityType<EmployeeDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<EmployeePhoneNumberDto>();

        builder.EntityType<ExchangeRateDto>();

        builder.EntitySet<LandLordDto>("LandLords");

        builder.EntityType<LandLordDto>();
        builder.EntityType<LandLordDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<MinimumCashStockDto>("MinimumCashStocks");

        builder.EntityType<MinimumCashStockDto>();
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<PaymentProviderDto>("PaymentProviders");

        builder.EntityType<PaymentProviderDto>();
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<VendingMachineDto>("VendingMachines");

        builder.EntityType<VendingMachineDto>();
        builder.EntityType<VendingMachineDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CashStockOrderDto>("CashStockOrders");

        builder.EntityType<CashStockOrderDto>();
        builder.EntityType<CashStockOrderDto>().Ignore(e => e.DeletedAtUtc);

        services.AddControllers()
            .AddOData(options =>
                {
                    options.Select()
                        .EnableQueryFeatures(null)
                        .Filter()
                        .OrderBy()
                        .Count()
                        .Expand()
                        .SkipToken()
                        .SetMaxTop(100);
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(), service => service.AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>()).RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
