
using Nox.Types;

namespace Nox.Domain
{
    /// <summary>
    /// Base for localize Nox.Type Enum
    /// </summary>
    public abstract class EnumTypeLocalizedBase
    {
        /// <summary>
        /// Enum value
        /// </summary>
        public int Id { get; set; }

        public CultureCode CultureCode { get; set; } = null!;
        /// <summary>
        /// Translation for the Enum Name
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
