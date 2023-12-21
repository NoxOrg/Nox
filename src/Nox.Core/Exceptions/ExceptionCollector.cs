using Nox.Types;

namespace Nox.Exceptions
{
    /// <summary>
    /// Collects exceptions when executing an Action for an attribute
    /// </summary>
    public sealed class ExceptionCollector<T> where T : Exception
    {
        /// <summary>
        /// Dictionary of attribute name with single T Exception
        /// </summary>
        public IReadOnlyDictionary<string, T> ValidationErrors => _exceptionsPerAttribute;
        private readonly Dictionary<string, T> _exceptionsPerAttribute = new(2);

        public void Collect(string attributeName, Action execute)
        {
            try
            {
                execute.Invoke();
            }
            catch (T ex)
            {
                _exceptionsPerAttribute.Add(attributeName, ex);
            }
        }
    }
}
