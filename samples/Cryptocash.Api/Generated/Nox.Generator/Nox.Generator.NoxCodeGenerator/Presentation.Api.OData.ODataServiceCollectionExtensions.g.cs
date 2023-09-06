﻿// Generated

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
        builder.EntityType<BookingKeyDto>();
        builder.EntityType<BookingDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<BookingDto>().Ignore(e => e.Etag);

        builder.EntitySet<CommissionDto>("Commissions");

        builder.EntityType<CommissionDto>();
        builder.EntityType<CommissionKeyDto>();
        builder.EntityType<CommissionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CommissionDto>().Ignore(e => e.Etag);

        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryTimeZones).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.Holidays).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryKeyDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);

        builder.EntityType<HolidayDto>();
        builder.EntityType<HolidayKeyDto>();

        builder.EntityType<CountryTimeZoneDto>();
        builder.EntityType<CountryTimeZoneKeyDto>();

        builder.EntitySet<CurrencyDto>("Currencies");
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.BankNotes).AutoExpand = true;
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.ExchangeRates).AutoExpand = true;

        builder.EntityType<CurrencyDto>();
        builder.EntityType<CurrencyKeyDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyDto>().Ignore(e => e.Etag);

        builder.EntityType<BankNoteDto>();
        builder.EntityType<BankNoteKeyDto>();

        builder.EntitySet<CustomerDto>("Customers");

        builder.EntityType<CustomerDto>();
        builder.EntityType<CustomerKeyDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CustomerDto>().Ignore(e => e.Etag);

        builder.EntitySet<PaymentDetailDto>("PaymentDetails");

        builder.EntityType<PaymentDetailDto>();
        builder.EntityType<PaymentDetailKeyDto>();
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentDetailDto>().Ignore(e => e.Etag);

        builder.EntitySet<TransactionDto>("Transactions");

        builder.EntityType<TransactionDto>();
        builder.EntityType<TransactionKeyDto>();
        builder.EntityType<TransactionDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TransactionDto>().Ignore(e => e.Etag);

        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeDto>().ContainsMany(e => e.EmployeePhoneNumbers).AutoExpand = true;

        builder.EntityType<EmployeeDto>();
        builder.EntityType<EmployeeKeyDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<EmployeeDto>().Ignore(e => e.Etag);

        builder.EntityType<EmployeePhoneNumberDto>();
        builder.EntityType<EmployeePhoneNumberKeyDto>();

        builder.EntityType<ExchangeRateDto>();
        builder.EntityType<ExchangeRateKeyDto>();

        builder.EntitySet<LandLordDto>("LandLords");

        builder.EntityType<LandLordDto>();
        builder.EntityType<LandLordKeyDto>();
        builder.EntityType<LandLordDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<LandLordDto>().Ignore(e => e.Etag);

        builder.EntitySet<MinimumCashStockDto>("MinimumCashStocks");

        builder.EntityType<MinimumCashStockDto>();
        builder.EntityType<MinimumCashStockKeyDto>();
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<MinimumCashStockDto>().Ignore(e => e.Etag);

        builder.EntitySet<PaymentProviderDto>("PaymentProviders");

        builder.EntityType<PaymentProviderDto>();
        builder.EntityType<PaymentProviderKeyDto>();
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PaymentProviderDto>().Ignore(e => e.Etag);

        builder.EntitySet<VendingMachineDto>("VendingMachines");

        builder.EntityType<VendingMachineDto>();
        builder.EntityType<VendingMachineKeyDto>();
        builder.EntityType<VendingMachineDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<VendingMachineDto>().Ignore(e => e.Etag);

        builder.EntitySet<CashStockOrderDto>("CashStockOrders");

        builder.EntityType<CashStockOrderDto>();
        builder.EntityType<CashStockOrderKeyDto>();
        builder.EntityType<CashStockOrderDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CashStockOrderDto>().Ignore(e => e.Etag);

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
