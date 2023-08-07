using MediatR;

namespace Nox.Application.Commands
{
        /// <summary>
    /// Identifies the request as a commands
    /// </summary>
    /// <typeparam name="T">The Actual Command</typeparam>
    /// <typeparam name="R">The Response type</typeparam>
    public class RequestCommand<T, R> : IRequest<R>
        where T : IRequest<R>
    {
        public T Command { get; }
        public RequestCommand(T command)
        {
            Command = command;
        }
    }
}
