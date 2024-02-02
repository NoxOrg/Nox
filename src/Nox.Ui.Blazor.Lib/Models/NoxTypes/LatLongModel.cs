using Nox.Types;
namespace Nox.Ui.Blazor.Lib.Models.NoxTypes;

public class LatLongModel
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public LatLongModel(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
