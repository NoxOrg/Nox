namespace Cryptocash.Ui.Generated.Data
{
    /// <summary>
    /// Class ApiDefinition which defines and manages Api info
    /// </summary>
    public class ApiDefinition
    {
        #region Declarations

        /// <summary>
        /// Property Name used for target Api name display on Ui
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Property IsDefault used for which Api is the default one to display in Ui
        /// </summary>
        public bool IsDefault { get; set; } = false;

        /// <summary>
        /// Property Icon used for display of Api navigation link
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Property Link used for href of Api navigation link
        /// </summary>
        public string? PageLink { get; set; }

        #endregion
    }
}