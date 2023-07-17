using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class SecretsServerValidator: AbstractValidator<SecretsServer>
    {
        public SecretsServerValidator(IEnumerable<ServerBase>? servers, string secretsName)
        {
            Include(new ServerBaseValidator($"the infrastructure, dependencies, security, secrets, {secretsName} server", servers));
            RuleFor(p => p.Provider)
                .NotNull()
                .WithMessage(p => string.Format(ValidationResources.SecretsServerProviderEmpty, p.Name, SecretsServerProvider.AzureKeyVault.ToNameList()));
            
            RuleFor(p => p.ValidFor!)
                .Must(HaveValidTimespan)
                .WithMessage(string.Format(ValidationResources.SecretsValidForInvalidTimespan, "infrastructure, security, secrets"));
        }
        
        private bool HaveValidTimespan(SecretsValidFor toEvaluate)
        {
            if (toEvaluate.Days == null && toEvaluate.Hours == null && toEvaluate.Minutes == null && toEvaluate.Seconds == null) return false;
            var tally = 0;
            if (toEvaluate.Days.HasValue) tally += toEvaluate.Days.Value;
            if (toEvaluate.Hours.HasValue) tally += toEvaluate.Hours.Value;
            if (toEvaluate.Minutes.HasValue) tally += toEvaluate.Minutes.Value;
            if (toEvaluate.Seconds.HasValue) tally += toEvaluate.Seconds.Value;
            if (tally == 0) return false;
            return true;
        }
    }
}