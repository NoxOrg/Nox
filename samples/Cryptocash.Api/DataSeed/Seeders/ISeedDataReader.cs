namespace Cryptocash.DataSeed.Seeders;

public interface ISeedDataReader
{
    IEnumerable<T> ReadFromFile<T>(string filePath);
}