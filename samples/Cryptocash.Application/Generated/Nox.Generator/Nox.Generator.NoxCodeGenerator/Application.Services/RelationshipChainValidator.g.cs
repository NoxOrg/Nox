// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;

namespace Cryptocash.Application.Services;

internal partial class RelationshipChainValidator : RelationshipChainValidatorBase
{
    public RelationshipChainValidator(AppDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class RelationshipChainValidatorBase: IRelationshipChainValidator
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public AppDbContext DataDbContext { get; }

#region Constructor
    public  RelationshipChainValidatorBase(AppDbContext dataDbContext)
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

    public virtual bool IsValid(RelationshipChain relationshipChain)
    {
        if (!_entityContextPerEntityName.TryGetValue(relationshipChain.EntityName, out var context))
            return false;

        var aggregateDbSet = (IQueryable)context.DbSet;

        if (!TryParseKey(relationshipChain.EntityName, relationshipChain.EntityKey, out var aggregateParsedKey))
            return false;

        var query = aggregateDbSet.Where($"{context.KeyName} == @0", aggregateParsedKey);

        var previousAggregateRoot = relationshipChain.EntityName;
        var previousKeyName = context.KeyName;

        foreach (var property in relationshipChain.SortedNavigationProperties)
        {
            if (!_isSingleRelationship.TryGetValue((previousAggregateRoot, property.NavigationName), out var isSingle))
                return false;

            query = query.Select($"new ({previousKeyName}, {property.NavigationName})");
            if (isSingle)
                query = query.Select($"{property.NavigationName}");
            else        
                query = query.SelectMany($"{property.NavigationName}");

            if (!_navigationNameToEntityPluralName.TryGetValue(property.NavigationName, out var relatedPluralName))
                return false;

            if (!_entityContextPerEntityName.TryGetValue(relatedPluralName, out var relatedContext))
                return false;
            
            if (!TryParseKey(relatedPluralName, property.NavigationKey, out var navigationParsedKey))
                return false;

            query = query.Where($"{relatedContext.KeyName} == @0", navigationParsedKey);
            previousAggregateRoot = relatedPluralName;
            previousKeyName = relatedContext.KeyName;
        }

        return query.Select($"{previousKeyName}").Any();
    }

    private bool TryParseKey(string entityName, string key, out Nox.Types.INoxType parsedKey)
    {
        parsedKey = null;
        if (entityName.Equals("Bookings", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = BookingMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Commissions", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = CommissionMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Countries", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = CountryMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("Currencies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = CurrencyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("Customers", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = CustomerMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("PaymentDetails", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = PaymentDetailMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Transactions", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = TransactionMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Employees", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = EmployeeMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("LandLords", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = LandLordMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("MinimumCashStocks", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = MinimumCashStockMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("PaymentProviders", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = PaymentProviderMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("VendingMachines", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = VendingMachineMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("CashStockOrders", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = CashStockOrderMetadata.CreateId(value);
            return true;
        }
        return false;
    }
}