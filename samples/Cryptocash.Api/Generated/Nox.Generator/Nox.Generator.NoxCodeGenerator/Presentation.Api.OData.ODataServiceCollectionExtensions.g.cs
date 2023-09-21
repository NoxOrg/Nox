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
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
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
        builder.EntityType<BookingDto>().ContainsRequired(e => e.BookingForCustomer);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.BookingRelatedVendingMachine);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.BookingFeesForCommission);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.BookingRelatedTransaction);

        builder.EntityType<BookingDto>();
        builder.EntityType<BookingDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<BookingDto>().Ignore(e => e.Etag);
        builder.EntitySet<CommissionDto>("Commissions");
        builder.EntityType<CommissionDto>().ContainsOptional(e => e.CommissionFeesForCountry);
        builder.EntityType<CommissionDto>().ContainsMany(e => e.CommissionFeesForBooking);

        builder.EntityType<CommissionDto>();
        builder.EntityType<CommissionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CommissionDto>().Ignore(e => e.Etag);
        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryOwnedTimeZones).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryOwnedHolidays).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsRequired(e => e.CountryUsedByCurrency);
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryUsedByCommissions);
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryUsedByVendingMachines);
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryUsedByCustomers);

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);
        builder.EntitySet<HolidayDto>("Holidays");

        builder.EntityType<HolidayDto>();
        builder.EntitySet<CountryTimeZoneDto>("CountryTimeZones");

        builder.EntityType<CountryTimeZoneDto>();
        builder.EntitySet<CurrencyDto>("Currencies");
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.CurrencyCommonBankNotes).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.CurrencyExchangedFromRates).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.CurrencyUsedByCountry);
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.CurrencyUsedByMinimumCashStocks);

        builder.EntityType<CurrencyDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyDto>().Ignore(e => e.Etag);
        builder.EntitySet<BankNoteDto>("BankNotes");

        builder.EntityType<BankNoteDto>();
        builder.EntitySet<CustomerDto>("Customers");
        builder.EntityType<CustomerDto>().ContainsMany(e => e.CustomerRelatedPaymentDetails);
        builder.EntityType<CustomerDto>().ContainsMany(e => e.CustomerRelatedBookings);
        builder.EntityType<CustomerDto>().ContainsMany(e => e.CustomerRelatedTransactions);
        builder.EntityType<CustomerDto>().ContainsRequired(e => e.CustomerBaseCountry);

        builder.EntityType<CustomerDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CustomerDto>().Ignore(e => e.Etag);
        builder.EntitySet<PaymentDetailDto>("PaymentDetails");
        builder.EntityType<PaymentDetailDto>().ContainsRequired(e => e.PaymentDetailsUsedByCustomer);
        builder.EntityType<PaymentDetailDto>().ContainsRequired(e => e.PaymentDetailsRelatedPaymentProvider);

        builder.EntityType<PaymentDetailDto>();
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.Etag);
        builder.EntitySet<TransactionDto>("Transactions");
        builder.EntityType<TransactionDto>().ContainsRequired(e => e.TransactionForCustomer);
        builder.EntityType<TransactionDto>().ContainsRequired(e => e.TransactionForBooking);

        builder.EntityType<TransactionDto>();
        builder.EntityType<TransactionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TransactionDto>().Ignore(e => e.Etag);
        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeDto>().ContainsMany(e => e.EmployeeContactPhoneNumbers).AutoExpand = true;
        builder.EntityType<EmployeeDto>().ContainsRequired(e => e.EmployeeReviewingCashStockOrder);

        builder.EntityType<EmployeeDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<EmployeeDto>().Ignore(e => e.Etag);
        builder.EntitySet<EmployeePhoneNumberDto>("EmployeePhoneNumbers");

        builder.EntityType<EmployeePhoneNumberDto>();
        builder.EntitySet<ExchangeRateDto>("ExchangeRates");

        builder.EntityType<ExchangeRateDto>();
        builder.EntitySet<LandLordDto>("LandLords");
        builder.EntityType<LandLordDto>().ContainsMany(e => e.ContractedAreasForVendingMachines);

        builder.EntityType<LandLordDto>();
        builder.EntityType<LandLordDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<LandLordDto>().Ignore(e => e.Etag);
        builder.EntitySet<MinimumCashStockDto>("MinimumCashStocks");
        builder.EntityType<MinimumCashStockDto>().ContainsMany(e => e.MinimumCashStocksRequiredByVendingMachines);
        builder.EntityType<MinimumCashStockDto>().ContainsRequired(e => e.MinimumCashStockRelatedCurrency);

        builder.EntityType<MinimumCashStockDto>();
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.Etag);
        builder.EntitySet<PaymentProviderDto>("PaymentProviders");
        builder.EntityType<PaymentProviderDto>().ContainsMany(e => e.PaymentProviderRelatedPaymentDetails);

        builder.EntityType<PaymentProviderDto>();
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.Etag);
        builder.EntitySet<VendingMachineDto>("VendingMachines");
        builder.EntityType<VendingMachineDto>().ContainsRequired(e => e.VendingMachineInstallationCountry);
        builder.EntityType<VendingMachineDto>().ContainsRequired(e => e.VendingMachineContractedAreaLandLord);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.VendingMachineRelatedBookings);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.VendingMachineRelatedCashStockOrders);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.VendingMachineRequiredMinimumCashStocks);

        builder.EntityType<VendingMachineDto>();
        builder.EntityType<VendingMachineDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<VendingMachineDto>().Ignore(e => e.Etag);
        builder.EntitySet<CashStockOrderDto>("CashStockOrders");
        builder.EntityType<CashStockOrderDto>().ContainsRequired(e => e.CashStockOrderForVendingMachine);
        builder.EntityType<CashStockOrderDto>().ContainsRequired(e => e.CashStockOrderReviewedByEmployee);

        builder.EntityType<CashStockOrderDto>();
        builder.EntityType<CashStockOrderDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CashStockOrderDto>().Ignore(e => e.Etag);

        if(configure != null) configure(builder);

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
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
