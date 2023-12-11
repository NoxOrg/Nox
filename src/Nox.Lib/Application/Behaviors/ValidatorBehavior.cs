using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Nox.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var typeName = request.GetGenericTypeName();

            _logger.LogInformation("Validating {CommandType}", typeName);

            var failuresQuery = _validators
                .ToAsyncEnumerable()
                .SelectAwait(async v => await v.ValidateAsync(request, cancellationToken));

            var failures = new ConcurrentBag<ValidationFailure>();
            await foreach (var failure in failuresQuery)
            {
                failure
                    .Errors
                    .Select(x => new ValidationFailure($"{typeName}.{x.PropertyName}", x.ErrorMessage))
                    .ForEach(x => failures.Add(x));
            }

            BadRequestException.ThrowIfNotValid(new ValidationResult(failures.ToArray()));

            return await next();
        }
    }
}
