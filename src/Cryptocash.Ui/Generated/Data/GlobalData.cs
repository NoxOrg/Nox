namespace Cryptocash.Ui.Generated.Data
{
    using System;

    /// <summary>
    /// Class to handle Global Data across app parent and child components
    /// </summary>
    public class GlobalData
    {
        /// <summary>
        /// Property ApiName used to display current Api name
        /// </summary>
        public string? ApiName { get; set; }

        /// <summary>
        /// Property ApiDefinitions used to hold all Apis and related info for Ui
        /// </summary>
        public List<ApiDefinition>? ApiDefinitions { get; set; }

        /// <summary>
        /// Property CurrentApiDefinition used to handle currently selected Api definition
        /// </summary>
        public ApiDefinition? CurrentApiDefinition { get; set; }

        /// <summary>
        /// Property ValuesChanged used to handle trigger events to make sure global data is updated
        /// </summary>
        public Action? ValuesChanged;
    }
}