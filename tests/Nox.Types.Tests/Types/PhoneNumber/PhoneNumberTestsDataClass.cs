using System.Collections;

namespace Nox.Types.Tests.Types;

public class PhoneNumberTestsDataClass : IEnumerable<object[]>
{
    private readonly string[] _countryCodes = new[]
    {
        "+1",
        "+10",
        "+101",
    };

    private readonly string[] _areaCodes = new[]
    {
        "2",
        "23",
        "232",
        "(232)",
    };

    private readonly string[] _subscriberNumbers = new[]
    {
        "123456",
        "123 456",
        "123-456",

        "1234567",
        "123 4567",
        "123-4567",
        "123 45 67",
        "123-45-67",
        "12 34 567",
        "12-34-567",

        "12345678",
        "1234-5678",
        "1234 5678",
        "123 456 78",
        "123-456-78",
        "12 34 56 78",
        "12-34-56-78",

        "123456789",
        "123 456 789",
        "123-456-789",

        "1234567890",
        "12345 67890",
        "12345-67890",
    };


    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (var subscriberNumber in _subscriberNumbers)
            yield return new object[] { subscriberNumber };

        foreach (var areaCode in _areaCodes)
            foreach (var subscriberNumber in _subscriberNumbers)
                yield return new object[] { $"{areaCode} {subscriberNumber}" };

        foreach (var countryCode in _countryCodes)
            foreach (var areaCode in _areaCodes)
                foreach (var subscriberNumber in _subscriberNumbers)
                    yield return new object[] { $"{countryCode} {areaCode} {subscriberNumber}" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}