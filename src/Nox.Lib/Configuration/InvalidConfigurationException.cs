using System.Runtime.Serialization;

namespace Nox.Exceptions
{
    /// <summary>
    /// Nox configuration is invalid
    /// </summary>
    [Serializable]
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

        protected InvalidConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}