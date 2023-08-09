using FluentValidation;
using MediatR;
using Nox.Types;
using SampleWebApp.Application.Queries;

namespace SampleWebApp.Application.Behavior
{
    public class GetVendingMachineByIdSecurityValidator : AbstractValidator<GetVendingMachineByIdQuery>
    {
        public GetVendingMachineByIdSecurityValidator(ILogger<GetVendingMachineByIdQuery> logger)
        {
            // For the Current User
            // TODO Get vending machines that he can see....

            // Do Validation The current user can only see vending machine with Id equals 1
            RuleFor(query => query.key).Must(key => key == 1).WithMessage("No permissions to access this vending machine");
        }
    }
}