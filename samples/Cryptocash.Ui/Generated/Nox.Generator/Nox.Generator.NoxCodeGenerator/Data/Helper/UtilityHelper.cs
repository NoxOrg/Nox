using System.Reflection;

namespace Cryptocash.Ui.Generated.Data.Helper
{
    /// <summary>
    /// Helper class to help Ui with repeating helping tasks
    /// </summary>
    public static class UtilityHelper
    {
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

        /// <summary>
        /// Method to format a property value into a defined format for display in Ui
        /// </summary>
        /// <param name="PropertyInfo"></param>
        /// <param name="ContextEntity"></param>
        /// <returns>string?</returns>
        public static string? FormatOutput(PropertyInfo? PropertyInfo, object? ContextEntity)
        {
            if (ContextEntity != null && PropertyInfo != null)
            {
                if (PropertyInfo.PropertyType == typeof(DateTime)
                    || PropertyInfo.PropertyType == typeof(DateTime?))
                {
                    var CurrentDateValue = PropertyInfo?.GetValue(ContextEntity);

                    if (CurrentDateValue != null)
                    {
                        DateTime ConvertedDateTime = Convert.ToDateTime(CurrentDateValue);

                        if (ConvertedDateTime.TimeOfDay.TotalSeconds == 0)
                        {
                            return ConvertedDateTime.ToString("dd-MMM-yy"); //Exception of Midnight (00:00:00) shown without Time
                        }
                        else
                        {
                            return ConvertedDateTime.ToString("dd-MMM-yy HH:mm:ss");
                        }
                    }
                }

                var CurrentValue = PropertyInfo?.GetValue(ContextEntity);

                return CurrentValue?.ToString();
            }

            return string.Empty;
        }
    }
}