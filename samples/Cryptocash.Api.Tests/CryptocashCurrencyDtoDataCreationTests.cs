using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cryptocash.Application.Dto;

namespace Cryptocash.Tests;

public class CryptocashCurrencyDtoDataCreationTests
{
#nullable enable

    /// <summary>
    /// Test used to create one-off CurrencyDto JSON data from Currency Reference Data - to use make sure source json file is available otherwise test just returns empty string
    /// </summary>
    [Fact]
    public void Create_CurrencyDto_data_from_CurrencyReferenceData()
    {
        var rootPath = "../../../../.nox";        

        var action = () => Convert_Currency_ReferenceData_to_DtoData($"{rootPath}/Nox.Reference.Currencies.json"); //source json file location

        action.Should().NotThrow();
    }

    private static string Convert_Currency_ReferenceData_to_DtoData(string FilePath)
    {
        if (File.Exists(FilePath))
        {
            List<CurrencyReferenceData>? SourceData = new();
            List<CurrencyDto>? CreatedData = new();

            using (StreamReader r = new(FilePath))
            {
                string json = r.ReadToEnd();
                SourceData = System.Text.Json.JsonSerializer.Deserialize<List<CurrencyReferenceData>>(json);
            }

            if (SourceData != null)
            {
                foreach (CurrencyReferenceData currentCurrency in SourceData)
                {
                    if (currentCurrency != null
                        && !String.IsNullOrWhiteSpace(currentCurrency.IsoCode)
                        && !String.IsNullOrWhiteSpace(currentCurrency.IsoNumber)
                        && !String.IsNullOrWhiteSpace(currentCurrency.Symbol)
                        && Enum.IsDefined(typeof(Nox.Types.CurrencyCode), currentCurrency.IsoCode)
                        && Enum.IsDefined(typeof(Nox.Types.CurrencyCode), (int)Convert_IsoNumberReference_to_Dto(currentCurrency.IsoNumber))
                        )
                    {
                        CreatedData.Add(
                        new()
                            {
                                Id = currentCurrency.IsoCode,
                                Name = currentCurrency.Name!,
                                CurrencyIsoNumeric = Convert_IsoNumberReference_to_Dto(currentCurrency.IsoNumber),
                                Symbol = currentCurrency.Symbol,
                                ThousandsSeparator = currentCurrency.ThousandsSeparator,
                                DecimalSeparator = currentCurrency.DecimalSeparator,
                                SpaceBetweenAmountAndSymbol = currentCurrency.SpaceBetweenAmountAndSymbol,
                                SymbolOnLeft = currentCurrency.SymbolOnLeft,
                                DecimalDigits = currentCurrency.DecimalDigits,
                                MajorName = currentCurrency!.Units?.MajorName == null ? String.Empty : currentCurrency.Units.MajorName,
                                MajorSymbol = currentCurrency!.Units?.MajorSymbol == null ? String.Empty : currentCurrency.Units.MajorSymbol,
                                MinorName = currentCurrency!.Units?.MinorName == null ? String.Empty : currentCurrency.Units.MinorName,
                                MinorSymbol = currentCurrency!.Units?.MinorSymbol == null ? String.Empty : currentCurrency.Units.MinorSymbol,
                                MinorToMajorValue = Convert_MoneyReference_to_Dto(currentCurrency!.Units?.MinorMajorValue, currentCurrency!.IsoCode),
                                BankNotes = Convert_BankNoteReference_to_Dto(currentCurrency.Banknotes, currentCurrency.IsoCode)
                            }
                        );
                    }                    
                }

                var jsonOptions = new JsonSerializerOptions()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                };
                jsonOptions.Converters.Add(new JsonStringEnumConverter());

                string rtnJson = System.Text.Json.JsonSerializer.Serialize(CreatedData, jsonOptions);

                return rtnJson;
            }
        }

        return string.Empty;
    }

    public class CurrencyReferenceData
    {
        [JsonPropertyName("isoCode")]
        public System.String? IsoCode { get; set; }

        [JsonPropertyName("name")]
        public System.String? Name { get; set; }

        [JsonPropertyName("isoNumber")]
        public System.String? IsoNumber { get; set; }

        [JsonPropertyName("symbol")]
        public System.String? Symbol { get; set; }

        [JsonPropertyName("thousandsSeparator")]
        public System.String? ThousandsSeparator { get; set; }

        [JsonPropertyName("decimalSeparator")]
        public System.String? DecimalSeparator { get; set; }

        [JsonPropertyName("spaceBetweenAmountAndSymbol")]
        public System.Boolean SpaceBetweenAmountAndSymbol { get; set; }

        [JsonPropertyName("symbolOnLeft")]
        public System.Boolean SymbolOnLeft { get; set; }

        [JsonPropertyName("decimalDigits")]
        public System.Int32 DecimalDigits { get; set; }

        [JsonPropertyName("units")]
        public UnitData? Units { get; set; }

        [JsonPropertyName("banknotes")]
        public BankNoteData? Banknotes { get; set; }

    }

    public class MoneyReferenceData
    {
        public System.String? CurrencyCode { get; set; }
        public Decimal Amount { get; set; }
    }

    public class BankNoteData
    {
        [JsonPropertyName("frequent")]
        public List<System.String>? FrequentBankNotes { get; set; }
    }

    public class ExchangeRatesData
    {
        public System.String? CurrencyCode { get; set; }

        public Decimal EffectiveRate { get; set; }
        public DateTime EffectiveAt { get; set; }
    }

    public class UnitData
    {
        [JsonPropertyName("major")]
        public UnitMajorData? Major { get; set; }

        [JsonPropertyName("minor")]
        public UnitMinorData? Minor { get; set; }

        public System.String? MajorName { 
            
            get {
                return Major?.Name;
            } 
        }

        public System.String? MajorSymbol
        {

            get
            {
                return Major?.Symbol;
            }
        }

        public System.String? MinorName
        {

            get
            {
                return Minor?.Name;
            }
        }

        public System.String? MinorSymbol
        {

            get
            {
                return Minor?.Symbol;
            }
        }

        public System.Decimal MinorMajorValue
        {

            get
            {
                return Minor!.MajorValue;
            }
        }
    }

    public class UnitMajorData
    {
        [JsonPropertyName("name")]
        public System.String? Name { get; set; }

        [JsonPropertyName("symbol")]
        public System.String? Symbol { get; set; }
    }

    public class UnitMinorData
    {
        [JsonPropertyName("name")]
        public System.String? Name { get; set; }

        [JsonPropertyName("symbol")]
        public System.String? Symbol { get; set; }

        [JsonPropertyName("majorValue")]
        public System.Decimal MajorValue { get; set; }
    }

    private static short Convert_IsoNumberReference_to_Dto(string CurrentIsoNumber)
    {
        return short.Parse(CurrentIsoNumber);
    }

    private static MoneyDto Convert_MoneyReference_to_Dto(Decimal? CurrentAmount, string CurrentCurrencyCode)
    {
        _ = Enum.TryParse(CurrentCurrencyCode, out Nox.Types.CurrencyCode TempCurrencyCode);

        if (CurrentAmount == null)
        {
            throw new Exception("Convert_MoneyReference_to_Dto Error: CurrencyAmount not defined");
        }

        if (!Enum.IsDefined(typeof(Nox.Types.CurrencyCode), CurrentCurrencyCode))
        {
            throw new Exception("Convert_MoneyReference_to_Dto Error: Enum CurrencyCode not defined");
        }

        return new((decimal)CurrentAmount, TempCurrencyCode);
    }

    private static List<BankNoteDto> Convert_BankNoteReference_to_Dto(BankNoteData? CurrentBankNoteList, string CurrentCurrencyCode)
    {
        List<BankNoteDto> rtnBankNoteList = new();

        if (CurrentBankNoteList != null
            && CurrentBankNoteList.FrequentBankNotes != null)
        {
            foreach (string CurrentBankNote in CurrentBankNoteList.FrequentBankNotes)
            {
                string GetAmountStr = new(CurrentBankNote.Where(Char.IsDigit).ToArray());
                if (Decimal.TryParse(GetAmountStr, out decimal GetAmount))
                {
                    rtnBankNoteList.Add(
                    new()
                    {
                        CashNote = CurrentBankNote,
                        Value = Convert_MoneyReference_to_Dto(GetAmount, CurrentCurrencyCode)
                    }
                    );
                }
            }
        }        

        return rtnBankNoteList;
    }
}