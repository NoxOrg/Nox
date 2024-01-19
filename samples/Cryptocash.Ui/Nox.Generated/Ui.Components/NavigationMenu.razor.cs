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
        .Add(new NavigationItem("Commissions", "Commissions", null))
        .Add(new NavigationItem("Countries", "Countries", null))
        .Add(new NavigationItem("Currencies", "Currencies", null))
        .Add(new NavigationItem("Customers", "Customers", "<path d=\"M14,7h-4C8.9,7,8,7.9,8,9v6h2v7h4v-7h2V9C16,7.9,15.1,7,14,7z\"/><circle cx=\"12\" cy=\"4\" r=\"2\"/>"))
        .Add(new NavigationItem("PaymentDetails", "PaymentDetails", null))
        .Add(new NavigationItem("Transactions", "Transactions", null))
        .Add(new NavigationItem("Employees", "Employees", "<path d=\"M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z\"/>"))
        .Add(new NavigationItem("LandLords", "LandLords", null))
        .Add(new NavigationItem("MinimumCashStocks", "MinimumCashStocks", null))
        .Add(new NavigationItem("PaymentProviders", "PaymentProviders", null))
        .Add(new NavigationItem("VendingMachines", "VendingMachines", "<path d=\"M20.54 5.23l-1.39-1.68C18.88 3.21 18.47 3 18 3H6c-.47 0-.88.21-1.16.55L3.46 5.23C3.17 5.57 3 6.02 3 6.5V19c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V6.5c0-.48-.17-.93-.46-1.27zM12 17.5L6.5 12H10v-2h4v2h3.5L12 17.5zM5.12 5l.81-1h12l.94 1H5.12z\"/>"))
        .Add(new NavigationItem("CashStockOrders", "CashStockOrders", null))
        ;
}