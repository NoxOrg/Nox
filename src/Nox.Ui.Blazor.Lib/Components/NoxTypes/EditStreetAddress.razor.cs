using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditStreetAddress : ComponentBase
{

    #region Declarations

    [Parameter]
    public StreetAddressModel? StreetAddress { get; set; }

    public string? CurrentStreetNumber { get; set; }

    public string? CurrentAddressLine1 { get; set; }

    public string? CurrentAddressLine2 { get; set; }

    public string? CurrentRoute { get; set; }

    public string? CurrentLocality { get; set; }

    public string? CurrentNeighborhood { get; set; }

    public string? CurrentAdministrativeArea1 { get; set; }

    public string? CurrentAdministrativeArea2 { get; set; }

    public string? CurrentPostalCode { get; set; }

    public string? CurrentCountryIdStr { get; set; }

    private Nox.Types.CountryCode? _CurrentCountryId { get; set; }

    public Nox.Types.CountryCode? CurrentCountryId
    {
        get
        {
            if (_CurrentCountryId != null)
            {
                return _CurrentCountryId;
            }

            if (!String.IsNullOrWhiteSpace(CurrentCountryIdStr)
                && Enum.IsDefined(typeof(Nox.Types.CountryCode), CurrentCountryIdStr))
            {
                return (Nox.Types.CountryCode?)Enum.Parse(typeof(Nox.Types.CountryCode), CurrentCountryIdStr);
            }
            else
            {
                return null;
            }
        }

        set { _CurrentCountryId = value; }
    }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? TitleAddressLine1 { get; set; } = "Address Line 1";

    [Parameter]
    public string? TitleAddressLine2 { get; set; } = "Address Line 2";

    [Parameter]
    public string? TitleRoute { get; set; } = "Route";

    [Parameter]
    public string? TitleLocality { get; set; } = "Locality";

    [Parameter]
    public string? TitleNeighborhood { get; set; } = "Neighborhood";

    [Parameter]
    public string? TitleAdministrativeArea1 { get; set; } = "Administrative Area 1";

    [Parameter]
    public string? TitleAdministrativeArea2 { get; set; } = "Administrative Area 2";

    [Parameter]
    public string? TitlePostalCode { get; set; } = "Postal Code";

    [Parameter]
    public string? TitleCountryId { get; set; } = "CountryId";

    [Parameter]
    public List<CountryModel> CountrySelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<StreetAddressModel> StreetAddressChanged { get; set; }

    [Parameter]
    public int MaxLengthStreetNumber { get; set; } = 32;

    [Parameter]
    public int MaxLengthAddressLine1 { get; set; } = 128;

    [Parameter]
    public int MaxLengthAddressLine2 { get; set; } = 128;

    [Parameter]
    public int MaxLengthRoute { get; set; } = 64;

    [Parameter]
    public int MaxLengthLocality { get; set; } = 64;

    [Parameter]
    public int MaxLengthNeighborhood { get; set; } = 64;

    [Parameter]
    public int MaxLengthAdministrativeArea1 { get; set; } = 64;

    [Parameter]
    public int MaxLengthAdministrativeArea2 { get; set; } = 64;

    [Parameter]
    public int MaxLengthPostalCode { get; set; } = 32;

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (StreetAddress != null)
        {
            CurrentStreetNumber = StreetAddress.StreetNumber;
            CurrentAddressLine1 = StreetAddress.AddressLine1;
            CurrentAddressLine2 = StreetAddress.AddressLine2;
            CurrentRoute = StreetAddress.Route;
            CurrentLocality = StreetAddress.Locality;
            CurrentNeighborhood = StreetAddress.Neighborhood;
            CurrentAdministrativeArea1 = StreetAddress.AdministrativeArea1;
            CurrentAdministrativeArea2 = StreetAddress.AdministrativeArea2;
            CurrentPostalCode = StreetAddress.PostalCode;
            CurrentCountryIdStr = StreetAddress.CountryId.ToString();
        }
    }

    protected async Task OnStreetNumberChanged(string newValue)
    {
        CurrentStreetNumber = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnAddressLine1Changed(string newValue)
    {
        CurrentAddressLine1 = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnAddressLine2Changed(string newValue)
    {
        CurrentAddressLine2 = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnRouteChanged(string newValue)
    {
        CurrentRoute = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnLocalityChanged(string newValue)
    {
        CurrentLocality = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnNeighborhoodChanged(string newValue)
    {
        CurrentNeighborhood = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnAdministrativeArea1Changed(string newValue)
    {
        CurrentAdministrativeArea1 = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnAdministrativeArea2Changed(string newValue)
    {
        CurrentAdministrativeArea2 = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnPostalCodeChanged(string newValue)
    {
        CurrentPostalCode = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    protected async Task OnCountryIdChanged(string newValue)
    {
        CurrentCountryIdStr = newValue;

        RefreshStreetAddress();

        await StreetAddressChanged.InvokeAsync(StreetAddress);
    }

    private void RefreshStreetAddress()
    {
        if (CurrentCountryId != null)
        {
            StreetAddress = new StreetAddressModel()
            {
                StreetNumber = CurrentStreetNumber,
                AddressLine1 = CurrentAddressLine1,
                AddressLine2 = CurrentAddressLine2,
                Route = CurrentRoute,
                Locality = CurrentLocality,
                Neighborhood = CurrentNeighborhood,
                AdministrativeArea1 = CurrentAdministrativeArea1,
                AdministrativeArea2 = CurrentAdministrativeArea2,
                PostalCode = CurrentPostalCode,
                CountryId = CurrentCountryId
            };
        }
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle);
    }
}