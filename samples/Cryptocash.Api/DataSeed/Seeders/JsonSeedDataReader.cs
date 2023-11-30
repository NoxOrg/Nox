using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cryptocash.DataSeed.Seeders;

public class JsonSeedDataReader : ISeedDataReader
{
    public IEnumerable<T> ReadFromFile<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        var json = reader.ReadToEnd();

        var jsonOptions = new JsonSerializerOptions();
        jsonOptions.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<IEnumerable<T>>(json, jsonOptions) ?? Array.Empty<T>();
    }
}