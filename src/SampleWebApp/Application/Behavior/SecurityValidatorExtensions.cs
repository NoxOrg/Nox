using FluentValidation;

namespace SampleWebApp.Application.Behavior
{
    public static class SecurityValidatorExtensions
    {
        public static IServiceCollection AddSecurityValidators(this IServiceCollection services)
        {
            return services.AddSingleton<IValidator<Queries.GetStoreByIdQuery>, GetStoreByIdSecurityValidator>();
        }
    }
}
