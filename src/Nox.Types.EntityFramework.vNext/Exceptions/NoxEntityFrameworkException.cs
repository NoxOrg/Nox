namespace Nox.Types.EntityFramework.vNext.Exceptions
{
    public class NoxEntityFrameworkException : Exception
    {
        public NoxEntityFrameworkException()
        {
        }

        public NoxEntityFrameworkException(string message)
            : base(message)
        {
        }

        public NoxEntityFrameworkException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}