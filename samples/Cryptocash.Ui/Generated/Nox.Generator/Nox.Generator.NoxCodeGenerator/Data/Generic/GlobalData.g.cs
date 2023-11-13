namespace Cryptocash.Ui.Generated.Data.Generic
{
    using System;

    #nullable enable

    /// <summary>
    /// Class to handle Global Data across app parent and child components
    /// </summary>
    public class GlobalData
    {
        /// <summary>
        /// Property CurrentDomainEntity used to display current selected Domain Entity
        /// </summary>
        public string? CurrentDomainEntity { get; set; }

        /// <summary>
        /// Property DefaultDomainEntity used to display default Domain Entity if not currently selected
        /// </summary>
        public string DefaultDomainEntity { get; set; } = "Test";

        /// <summary>
        /// Property ValuesChanged used to handle trigger events to make sure global data is updated
        /// </summary>
        public Action? ValuesChanged;
    }
}