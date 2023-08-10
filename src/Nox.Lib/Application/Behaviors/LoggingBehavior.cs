using System.ComponentModel.DataAnnotations;
using Azure;
using Azure.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Nox.Extensions;
using Nox.Types;

namespace Nox.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var typeName = request.GetGenericTypeName();
            _logger.LogInformation("Handling {typeName} ({request})", typeName, request);

            var response = await next();
            var responseData = response?.ToString();
            _logger.LogInformation("{typeName} handled - response: {response}", typeName, responseData);
            return response;
        }
    }
}