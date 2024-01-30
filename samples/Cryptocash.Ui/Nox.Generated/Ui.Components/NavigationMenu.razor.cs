// Generated

using Microsoft.AspNetCore.Components;
using System.Collections.Immutable;

namespace Cryptocash.Ui.Components;

public record NavigationItem(string Name, string Link, string? Icon = null);

public partial class NavigationMenu : ComponentBase
{
    [Parameter]
    public List<NavigationItem> NavigationItems { get; set; } = DefaultNavigationItems.ToList();

    public static readonly ImmutableList<NavigationItem> DefaultNavigationItems =
        ImmutableList<NavigationItem>.Empty
        .Add(new NavigationItem("Bookings", "Bookings", null))
        .Add(new NavigationItem("CashStockOrders", "CashStockOrders", null))
        .Add(new NavigationItem("Commissions", "Commissions", null))
        .Add(new NavigationItem("Countries", "Countries", null))
        .Add(new NavigationItem("Currencies", "Currencies", null))
        .Add(new NavigationItem("Customers", "Customers", null))
        .Add(new NavigationItem("Employees", "Employees", null))
        .Add(new NavigationItem("LandLords", "LandLords", null))
        .Add(new NavigationItem("MinimumCashStocks", "MinimumCashStocks", null))
        .Add(new NavigationItem("PaymentDetails", "PaymentDetails", null))
        .Add(new NavigationItem("PaymentProviders", "PaymentProviders", null))
        .Add(new NavigationItem("Transactions", "Transactions", null))
        .Add(new NavigationItem("VendingMachines", "VendingMachines", null))
        ;
}