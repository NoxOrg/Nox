using FluentValidation;
using MediatR;
using Nox.Types;
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
            RuleFor(query => query.key).Must(key => key == Nuid.From("Shippi Tivoli Einkaufscenter.Shopping Center, 8957 Spreitenbach, CH").Value).WithMessage("No permissions to access this store");
        }
    }
}