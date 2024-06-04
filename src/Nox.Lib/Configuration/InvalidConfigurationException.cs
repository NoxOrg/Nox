using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Nox.Exceptions
{
    /// <summary>
    /// Nox configuration is invalid
    /// </summary>
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(string message)
            : base(message)
        {
        }

        public InvalidConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public static void ThrowIfNull([NotNull] object? argument, string message)
        {
            if (argument is null)
            {
                throw new InvalidConfigurationException(message);
            }
        }
    }
}