// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Nox.Lib;
using Cryptocash.Application.Dto;
using DtoNameSpace = Cryptocash.Application.Dto;

namespace Cryptocash.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
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
        builder.EntityType<BookingDto>().ContainsRequired(e => e.Customer);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.VendingMachine);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.Commission);
        builder.EntityType<BookingDto>().ContainsRequired(e => e.Transaction);

        builder.EntityType<BookingDto>();
        builder.ComplexType<BookingUpdateDto>();
        builder.EntityType<BookingDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<BookingDto>().Ignore(e => e.Etag);
        builder.EntitySet<CommissionDto>("Commissions");
        builder.EntityType<CommissionDto>().ContainsOptional(e => e.Country);
        builder.EntityType<CommissionDto>().ContainsMany(e => e.Bookings);

        builder.EntityType<CommissionDto>();
        builder.ComplexType<CommissionUpdateDto>();
        builder.EntityType<CommissionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CommissionDto>().Ignore(e => e.Etag);
        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryTimeZones).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.Holidays).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsRequired(e => e.Currency);
        builder.EntityType<CountryDto>().ContainsMany(e => e.Commissions);
        builder.EntityType<CountryDto>().ContainsMany(e => e.VendingMachines);
        builder.EntityType<CountryDto>().ContainsMany(e => e.Customers);

        builder.EntityType<CountryDto>();
        builder.ComplexType<CountryUpdateDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);
        builder.EntitySet<HolidayDto>("Holidays");

        builder.EntityType<HolidayDto>();
        builder.ComplexType<HolidayUpdateDto>();
        builder.EntitySet<CountryTimeZoneDto>("CountryTimeZones");

        builder.EntityType<CountryTimeZoneDto>();
        builder.ComplexType<CountryTimeZoneUpdateDto>();
        builder.EntitySet<CurrencyDto>("Currencies");
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.BankNotes).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.ExchangeRates).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.Countries);
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.MinimumCashStocks);

        builder.EntityType<CurrencyDto>();
        builder.ComplexType<CurrencyUpdateDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyDto>().Ignore(e => e.Etag);
        builder.EntitySet<BankNoteDto>("BankNotes");

        builder.EntityType<BankNoteDto>();
        builder.ComplexType<BankNoteUpdateDto>();
        builder.EntitySet<CustomerDto>("Customers");
        builder.EntityType<CustomerDto>().ContainsMany(e => e.PaymentDetails);
        builder.EntityType<CustomerDto>().ContainsMany(e => e.Bookings);
        builder.EntityType<CustomerDto>().ContainsMany(e => e.Transactions);
        builder.EntityType<CustomerDto>().ContainsRequired(e => e.Country);

        builder.EntityType<CustomerDto>();
        builder.ComplexType<CustomerUpdateDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CustomerDto>().Ignore(e => e.Etag);
        builder.EntitySet<PaymentDetailDto>("PaymentDetails");
        builder.EntityType<PaymentDetailDto>().ContainsRequired(e => e.Customer);
        builder.EntityType<PaymentDetailDto>().ContainsRequired(e => e.PaymentProvider);

        builder.EntityType<PaymentDetailDto>();
        builder.ComplexType<PaymentDetailUpdateDto>();
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.Etag);
        builder.EntitySet<TransactionDto>("Transactions");
        builder.EntityType<TransactionDto>().ContainsRequired(e => e.Customer);
        builder.EntityType<TransactionDto>().ContainsRequired(e => e.Booking);

        builder.EntityType<TransactionDto>();
        builder.ComplexType<TransactionUpdateDto>();
        builder.EntityType<TransactionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TransactionDto>().Ignore(e => e.Etag);
        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeDto>().ContainsMany(e => e.EmployeePhoneNumbers).AutoExpand = true;
        builder.EntityType<EmployeeDto>().ContainsOptional(e => e.CashStockOrder);

        builder.EntityType<EmployeeDto>();
        builder.ComplexType<EmployeeUpdateDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<EmployeeDto>().Ignore(e => e.Etag);
        builder.EntitySet<EmployeePhoneNumberDto>("EmployeePhoneNumbers");

        builder.EntityType<EmployeePhoneNumberDto>();
        builder.ComplexType<EmployeePhoneNumberUpdateDto>();
        builder.EntitySet<ExchangeRateDto>("ExchangeRates");

        builder.EntityType<ExchangeRateDto>();
        builder.ComplexType<ExchangeRateUpdateDto>();
        builder.EntitySet<LandLordDto>("LandLords");
        builder.EntityType<LandLordDto>().ContainsMany(e => e.VendingMachines);

        builder.EntityType<LandLordDto>();
        builder.ComplexType<LandLordUpdateDto>();
        builder.EntityType<LandLordDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<LandLordDto>().Ignore(e => e.Etag);
        builder.EntitySet<MinimumCashStockDto>("MinimumCashStocks");
        builder.EntityType<MinimumCashStockDto>().ContainsMany(e => e.VendingMachines);
        builder.EntityType<MinimumCashStockDto>().ContainsRequired(e => e.Currency);

        builder.EntityType<MinimumCashStockDto>();
        builder.ComplexType<MinimumCashStockUpdateDto>();
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.Etag);
        builder.EntitySet<PaymentProviderDto>("PaymentProviders");
        builder.EntityType<PaymentProviderDto>().ContainsMany(e => e.PaymentDetails);

        builder.EntityType<PaymentProviderDto>();
        builder.ComplexType<PaymentProviderUpdateDto>();
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.Etag);
        builder.EntitySet<VendingMachineDto>("VendingMachines");
        builder.EntityType<VendingMachineDto>().ContainsRequired(e => e.Country);
        builder.EntityType<VendingMachineDto>().ContainsRequired(e => e.LandLord);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.Bookings);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.CashStockOrders);
        builder.EntityType<VendingMachineDto>().ContainsMany(e => e.MinimumCashStocks);

        builder.EntityType<VendingMachineDto>();
        builder.ComplexType<VendingMachineUpdateDto>();
        builder.EntityType<VendingMachineDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<VendingMachineDto>().Ignore(e => e.Etag);
        builder.EntitySet<CashStockOrderDto>("CashStockOrders");
        builder.EntityType<CashStockOrderDto>().ContainsRequired(e => e.VendingMachine);
        builder.EntityType<CashStockOrderDto>().ContainsRequired(e => e.Employee);

        builder.EntityType<CashStockOrderDto>();
        builder.ComplexType<CashStockOrderUpdateDto>();
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
                    var routeOptions = options.AddRouteComponents(Nox.Presentation.Api.OData.ODataApi.GetRoutePrefix("/api"), builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
