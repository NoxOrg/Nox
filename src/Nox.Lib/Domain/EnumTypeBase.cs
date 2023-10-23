namespace Nox.Domain
{
    /// <summary>
    /// Base for Nox.Type Enum
    /// </summary>
    public abstract partial class EnumTypeBase
    {
        /// <summary>
        /// Enum value
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Default Translation for the Enum Name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
