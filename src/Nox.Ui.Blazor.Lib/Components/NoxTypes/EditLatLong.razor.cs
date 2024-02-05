using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditLatLong : ComponentBase
{

    #region Declarations

    [Parameter]
    public LatLongModel? LatLong { get; set; }

    public double? CurrentLatitude { get; set; }

    public double? CurrentLongitude { get; set; }

    [Parameter]
    public bool DisplayGoogleMap { get; set; } = false;

    [Parameter]
    public string? TitleLatitude { get; set; }

    [Parameter]
    public string? TitleLongitude { get; set; }

    [Parameter]
    public EventCallback<LatLongModel> LatLongChanged { get; set; }

    [Parameter]
    public string Format { get; set; } = "#,##0.########";

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (LatLong != null)
        {
            CurrentLatitude = LatLong.Latitude;
            CurrentLongitude = LatLong.Longitude;
        }
    }

    protected async Task OnLatitudeChanged(string newValue)
    {
        if (double.TryParse(newValue, out double parsedDouble)) 
        {
            CurrentLatitude = parsedDouble;

            double useLongitude = 0;
            if (CurrentLongitude != null)
            {
                useLongitude = (double)CurrentLongitude;
            }

            LatLong = new LatLongModel((double)CurrentLatitude, useLongitude);

            await LatLongChanged.InvokeAsync(LatLong);
        } 
    }

    protected async Task OnLongitudeChanged(string newValue)
    {
        if (double.TryParse(newValue, out double parsedDouble))
        {
            CurrentLongitude = parsedDouble;

            double useLatitude = 0;
            if (CurrentLatitude != null)
            {
                useLatitude = (double)CurrentLatitude;
            }

            LatLong = new LatLongModel(useLatitude, (double)CurrentLongitude);

            await LatLongChanged.InvokeAsync(LatLong);
        }  
    }

    protected async Task OnLatLongChanged(LatLongModel newValue)
    {
        if (newValue != null)
        {
            CurrentLatitude = newValue.Latitude;
            CurrentLongitude = newValue.Longitude;
            LatLong = newValue;

            await LatLongChanged.InvokeAsync(LatLong);
        }
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, CurrentTitle).Trim();
    }
}