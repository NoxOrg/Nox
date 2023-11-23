using System.Text.Json;

namespace Cryptocash.DataSeed.Seeders;

public class JsonSeedDataReader : ISeedDataReader
{
    public IEnumerable<T> ReadFromFile<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        var json = reader.ReadToEnd();

        return JsonSerializer.Deserialize<IEnumerable<T>>(json) ?? Array.Empty<T>();
    }
}