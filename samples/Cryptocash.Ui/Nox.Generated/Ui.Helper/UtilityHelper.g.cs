namespace Cryptocash.Ui.Helper;

/// <summary>
/// Helper class to help Ui with repeating helping tasks
/// </summary>
public static class UtilityHelper
{
    #nullable enable

    /// <summary>
    /// Method to return a distinct list of string values from a list and uppercase the first character if required
    /// </summary>
    /// <param name="NameList"></param>
    /// <param name="IsFirstCharacterUppercase"></param>
    /// <returns>List<string>?</returns>
    public static List<string>? GetDistinctNameList(List<string?>? NameList, bool IsFirstCharacterUppercase)
    {
        if (NameList != null)
        {
            var RawNameList = (from string? CurrentName in NameList
                                where CurrentName != null
                                select CurrentName).ToList();
            if (IsFirstCharacterUppercase)
            {
                return RawNameList.DistinctBy(Name => Name)
                        .Select(Name => UppercaseFirstCharacter(Name)).ToList();
            }
            else
            {
                return RawNameList.DistinctBy(Name => Name).ToList();
            }
        }

        return null;
    }

    /// <summary>
    /// Method to uppercase the first letter in a string
    /// </summary>
    /// <param name="Input"></param>
    /// <returns>string</returns>
    public static string UppercaseFirstCharacter(string? Input)
    {
        if (!string.IsNullOrWhiteSpace(Input) && Input.Length > 0)
        {
            return char.ToUpper(Input[0]) + Input[1..];
        }
        else
        {
            return String.Empty;
        }
    }
}