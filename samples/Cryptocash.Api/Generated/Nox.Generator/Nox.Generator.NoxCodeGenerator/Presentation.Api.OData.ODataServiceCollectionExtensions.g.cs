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
        builder.EntityType<CountryHolidayDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryTimeZonesDto>().HasKey(e => new { e.Id });
        builder.EntityType<CurrencyDto>().HasKey(e => new { e.Id });
        builder.EntityType<BankNotesDto>().HasKey(e => new { e.Id });
        builder.EntityType<CustomerDto>().HasKey(e => new { e.Id });
        builder.EntityType<CustomerPaymentDetailsDto>().HasKey(e => new { e.Id });
        builder.EntityType<CustomerTransactionDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmployeeDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmployeePhoneNumberDto>().HasKey(e => new { e.Id });
        builder.EntityType<ExchangeRateDto>().HasKey(e => new { e.Id });
        builder.EntityType<LandLordDto>().HasKey(e => new { e.Id });
        builder.EntityType<MinimumCashStockDto>().HasKey(e => new { e.Id });
        builder.EntityType<PaymentProviderDto>().HasKey(e => new { e.Id });
        builder.EntityType<VendingMachineDto>().HasKey(e => new { e.Id });
        builder.EntityType<VendingMachineOrderDto>().HasKey(e => new { e.Id });


        builder.EntitySet<BookingDto>("Bookings");

        builder.EntityType<BookingDto>();
        builder.EntityType<BookingKeyDto>();
        builder.EntityType<BookingDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CommissionDto>("Commissions");

        builder.EntityType<CommissionDto>();
        builder.EntityType<CommissionKeyDto>();
        builder.EntityType<CommissionDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryTimeZones).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryKeyDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CountryHolidayDto>("CountryHolidays");

        builder.EntityType<CountryHolidayDto>();
        builder.EntityType<CountryHolidayKeyDto>();
        builder.EntityType<CountryHolidayDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<CountryTimeZonesDto>();
        builder.EntityType<CountryTimeZonesKeyDto>();

        builder.EntitySet<CurrencyDto>("Currencies");

        builder.EntityType<CurrencyDto>();
        builder.EntityType<CurrencyKeyDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<BankNotesDto>("BankNotes");

        builder.EntityType<BankNotesDto>();
        builder.EntityType<BankNotesKeyDto>();
        builder.EntityType<BankNotesDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CustomerDto>("Customers");

        builder.EntityType<CustomerDto>();
        builder.EntityType<CustomerKeyDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CustomerPaymentDetailsDto>("CustomerPaymentDetails");

        builder.EntityType<CustomerPaymentDetailsDto>();
        builder.EntityType<CustomerPaymentDetailsKeyDto>();
        builder.EntityType<CustomerPaymentDetailsDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<CustomerTransactionDto>("CustomerTransactions");

        builder.EntityType<CustomerTransactionDto>();
        builder.EntityType<CustomerTransactionKeyDto>();
        builder.EntityType<CustomerTransactionDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeDto>().ContainsMany(e => e.EmployeePhoneNumbers).AutoExpand = true;

        builder.EntityType<EmployeeDto>();
        builder.EntityType<EmployeeKeyDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<EmployeePhoneNumberDto>();
        builder.EntityType<EmployeePhoneNumberKeyDto>();

        builder.EntitySet<ExchangeRateDto>("ExchangeRates");

        builder.EntityType<ExchangeRateDto>();
        builder.EntityType<ExchangeRateKeyDto>();
        builder.EntityType<ExchangeRateDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<LandLordDto>("LandLords");

        builder.EntityType<LandLordDto>();
        builder.EntityType<LandLordKeyDto>();
        builder.EntityType<LandLordDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<MinimumCashStockDto>("MinimumCashStocks");

        builder.EntityType<MinimumCashStockDto>();
        builder.EntityType<MinimumCashStockKeyDto>();
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<PaymentProviderDto>("PaymentProviders");

        builder.EntityType<PaymentProviderDto>();
        builder.EntityType<PaymentProviderKeyDto>();
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<VendingMachineDto>("VendingMachines");

        builder.EntityType<VendingMachineDto>();
        builder.EntityType<VendingMachineKeyDto>();
        builder.EntityType<VendingMachineDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<VendingMachineOrderDto>("VendingMachineOrders");

        builder.EntityType<VendingMachineOrderDto>();
        builder.EntityType<VendingMachineOrderKeyDto>();
        builder.EntityType<VendingMachineOrderDto>().Ignore(e => e.DeletedAtUtc);

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
