using FluentValidation;
using MediatR;
using SampleWebApp.Application.Queries;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Behavior
{
    public static class SecurityValidatorExtensions
    {
        public static IServiceCollection AddSecurityValidators(this IServiceCollection services)
        {
            return services
                .AddSingleton<IValidator<GetVendingMachineByIdQuery>, GetVendingMachineByIdSecurityValidator>()
                .AddScoped<IPipelineBehavior<GetVendingMachinesQuery, IQueryable<VendingMachineDto>>, GetVendingMachinesQuerySecurityFilter>();
        }
    }
}