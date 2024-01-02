// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Queries;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

internal partial class ValidateEntityChainQueryHandler : ValidateEntityChainQueryHandlerBase
{
    public ValidateEntityChainQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class ValidateEntityChainQueryHandlerBase: IValidateEntityChainQueryHandler
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public DtoDbContext DataDbContext { get; }

#region Constructor
    public  ValidateEntityChainQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;

        _entityContextPerEntityName = new Dictionary<string, (object DbSet, string KeyName)>(StringComparer.OrdinalIgnoreCase)
        {
            { "Bookings", (DataDbContext.Bookings, "Id") },
            { "Commissions", (DataDbContext.Commissions, "Id") },
            { "Countries", (DataDbContext.Countries, "Id") },
            { "Currencies", (DataDbContext.Currencies, "Id") },
            { "Customers", (DataDbContext.Customers, "Id") },
            { "PaymentDetails", (DataDbContext.PaymentDetails, "Id") },
            { "Transactions", (DataDbContext.Transactions, "Id") },
            { "Employees", (DataDbContext.Employees, "Id") },
            { "LandLords", (DataDbContext.LandLords, "Id") },
            { "MinimumCashStocks", (DataDbContext.MinimumCashStocks, "Id") },
            { "PaymentProviders", (DataDbContext.PaymentProviders, "Id") },
            { "VendingMachines", (DataDbContext.VendingMachines, "Id") },
            { "CashStockOrders", (DataDbContext.CashStockOrders, "Id") }
        };

        _navigationNameToEntityPluralName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {           
            { "customer", "customers" },           
            { "vendingmachine", "vendingmachines" },           
            { "commission", "commissions" },           
            { "transaction", "transactions" },           
            { "country", "countries" },           
            { "bookings", "bookings" },           
            { "currency", "currencies" },           
            { "commissions", "commissions" },           
            { "vendingmachines", "vendingmachines" },           
            { "customers", "customers" },           
            { "countries", "countries" },           
            { "minimumcashstocks", "minimumcashstocks" },           
            { "paymentdetails", "paymentdetails" },           
            { "transactions", "transactions" },           
            { "paymentprovider", "paymentproviders" },           
            { "booking", "bookings" },           
            { "cashstockorder", "cashstockorders" },           
            { "landlord", "landlords" },           
            { "cashstockorders", "cashstockorders" },           
            { "employee", "employees" }
        };

        _isSingleRelationship = new()
        {           
            { ("bookings", "customer"), true },           
            { ("bookings", "vendingmachine"), true },           
            { ("bookings", "commission"), true },           
            { ("bookings", "transaction"), true },           
            { ("commissions", "country"), true },           
            { ("commissions", "bookings"), false },           
            { ("countries", "currency"), true },           
            { ("countries", "commissions"), false },           
            { ("countries", "vendingmachines"), false },           
            { ("countries", "customers"), false },           
            { ("currencies", "countries"), false },           
            { ("currencies", "minimumcashstocks"), false },           
            { ("customers", "paymentdetails"), false },           
            { ("customers", "bookings"), false },           
            { ("customers", "transactions"), false },           
            { ("customers", "country"), true },           
            { ("paymentdetails", "customer"), true },           
            { ("paymentdetails", "paymentprovider"), true },           
            { ("transactions", "customer"), true },           
            { ("transactions", "booking"), true },           
            { ("employees", "cashstockorder"), true },           
            { ("landlords", "vendingmachines"), false },           
            { ("minimumcashstocks", "vendingmachines"), false },           
            { ("minimumcashstocks", "currency"), true },           
            { ("paymentproviders", "paymentdetails"), false },           
            { ("vendingmachines", "country"), true },           
            { ("vendingmachines", "landlord"), true },           
            { ("vendingmachines", "bookings"), false },           
            { ("vendingmachines", "cashstockorders"), false },           
            { ("vendingmachines", "minimumcashstocks"), false },           
            { ("cashstockorders", "vendingmachine"), true },           
            { ("cashstockorders", "employee"), true }
        };
    }
#endregion Constructor

    public virtual bool Handle(ValidateEntityChainQuery request)
    {
        if (!_entityContextPerEntityName.TryGetValue(request.EntityName, out var context))
            return false;

        var aggregateDbSet = (IQueryable)context.DbSet;

        var query = aggregateDbSet.Where($"{context.KeyName} == {request.EntityKey}");

        var previousAggregateRoot = request.EntityName;

        foreach (var property in request.NavigationProperties)
        {
            if (!_isSingleRelationship.TryGetValue((previousAggregateRoot, property.NavigationName), out var isSingle))
                return false;

            if (isSingle)
                query = query.Select($"{property.NavigationName}");
            else        
                query = query.SelectMany($"{property.NavigationName}");

            if (!_navigationNameToEntityPluralName.TryGetValue(property.NavigationName, out var relatedPluralName))
                return false;

            if (!_entityContextPerEntityName.TryGetValue(relatedPluralName, out var relatedContext))
                return false;
            
            query = query.Where($"{relatedContext.KeyName} == {property.NavigationKey}");
            previousAggregateRoot = relatedPluralName;
        }

        return query.Count() > 0;
    }
}