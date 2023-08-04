using Azure;
using MediatR;
using Microsoft.Extensions.Logging;
using Nox.Extensions;


namespace Nox.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handling {RequestName} ({@Request})", request.GetGenericTypeName(), request);
                
                var response = await next();
                _logger.LogInformation("{RequestName} handled - response: {@Response}", request.GetGenericTypeName(), response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }
    }
}
