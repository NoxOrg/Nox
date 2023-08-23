using FluentValidation;
using MediatR;
using ClientApi.Application.Queries;

namespace Nox.ClientApi.Tests.Application.Queries
{

    /// <summary>
    /// Example of a validator, that is executed before a Query or Command Handler for security checks    
    /// </summary>
    public class GetClientDatabaseNumberByIdQueryValidator : AbstractValidator<GetClientDatabaseNumberByIdQuery>
    {
        public GetClientDatabaseNumberByIdQueryValidator(ILogger<GetClientDatabaseNumberByIdQuery> logger)
        {            
            RuleFor(query => query.keyId).Must(key => key < 50).WithMessage("No permissions for keys greater then 50");
        }
    }
}
