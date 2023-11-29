using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;
using System.Text.Json;
using Cryptocash.Application.Dto;

namespace Cryptocash.Tests;

public class CryptocashDtoDataCreationTests
{
    /// <summary>
    /// Test used to create CurrencyDto JSON data from Currency Reference Data - to use make sure source json file is available otherwise test just returns empty string
    /// </summary>
    [Fact]
    public void Create_CurrencyDto_data_from_CurrencyReferenceData()
    {
        var rootPath = "../../../../.nox";        

        var action = () => Convert_Currency_ReferenceData_to_DtoData($"{rootPath}/Nox.Reference.Currencies.json"); //source json file location

        action.Should().NotThrow();
    }

    private string Convert_Currency_ReferenceData_to_DtoData(string FilePath)
    {
        if (File.Exists(FilePath))
        {
            List<CurrencyReferenceData>? SourceData = new List<CurrencyReferenceData>();
            List<CurrencyDto>? CreatedData = new List<CurrencyDto>();

            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                SourceData = JsonSerializer.Deserialize<List<CurrencyReferenceData>>(json);
            }

            if (SourceData != null)
            {
                foreach (CurrencyReferenceData currentCurrency in SourceData)
                {
                    CreatedData.Add(
                        new()
                        {
                            
                        }
                    );
                }
            }
        }

        return string.Empty;
    }

    public class CurrencyReferenceData
    {

    }
}