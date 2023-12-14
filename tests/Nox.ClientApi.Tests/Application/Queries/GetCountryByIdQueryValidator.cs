using FluentValidation;
using ClientApi.Application.Queries;

namespace Nox.ClientApi.Tests.Application.Queries
{

    /// <summary>
    /// Example of a validator, that is executed before a Query or Command Handler for validation or security checks    
    /// </summary>
    public class GetCountryByIdQueryValidator : AbstractValidator<GetCountryByIdQuery>
    {
        public GetCountryByIdQueryValidator(ILogger<GetCountryByIdQuery> logger)
        {            
            RuleFor(query => query.keyId).Must(key => key < 300).WithMessage("No permissions for keys greater than 300");
        }
    }
}
