using FluentValidation;
using MediatR;
using SampleWebApp.Application.Queries;

namespace SampleWebApp.Application.Behavior
{
    public class GetStoreByIdSecurityValidator : AbstractValidator<GetStoreByIdQuery>
    {
        public GetStoreByIdSecurityValidator(ILogger<GetStoreByIdQuery> logger)
        {
            // For the Current User
            // TODO Get Stores that he can see.... 

            // Do Validation The current user can only see EUR Store
            RuleFor(query => query.keyId).Must(key => key == "EUR").WithMessage("No permissions to access this store");
        }
    }
}
