using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditGoogleMap : ComponentBase
{
    #region Declarations

    [Inject]
    public IJSRuntime? JSRuntime { get; set; }

    private DotNetObjectReference<EditGoogleMap>? dotNetHelper;

    [Parameter]
    public LatLongModel? LatLong { get; set; }

    public double? CurrentLatitude { get; set; }

    public double? CurrentLongitude { get; set; }

    private double DefaultLatitude { get; set; } = 51.509865;

    private double DefaultLongitude { get; set; } = -0.118092;

    [Parameter]
    public EventCallback<LatLongModel> LatLongChanged { get; set; }

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

    /// <summary>
    /// Handles Javascript interactions
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender
            && JSRuntime != null)
        {
            if (LatLong != null)
            {
                await JSRuntime.InvokeVoidAsync("updateDefaultLatLong", LatLong.Latitude, LatLong.Longitude, true);
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("updateDefaultLatLong", DefaultLatitude, DefaultLongitude, false);
            }
            await JSRuntime.InvokeVoidAsync("initMap", null);
            dotNetHelper = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("PlaceMarkerCallbackHelpers.setDotNetHelper", dotNetHelper);
            StateHasChanged();
        }
    }

    [JSInvokable]
    public async Task UpdateLatlong(double latitude, double longitude)
    {
        LatLong = new LatLongModel(latitude, longitude);
        await LatLongChanged.InvokeAsync(LatLong);
    }
}