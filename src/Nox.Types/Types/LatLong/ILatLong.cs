namespace Nox.Types;

public interface ILatLong
{
    double Latitude { get;  }
    double Longitude { get; }
}
public interface IWritableLatLong
{
    double Latitude { get; set; }
    double Longitude { get; set; }
}