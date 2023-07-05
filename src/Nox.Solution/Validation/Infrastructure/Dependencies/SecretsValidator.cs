using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class SecretsValidator: AbstractValidator<Secrets>
    {
        public SecretsValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.SecretsServer!)
                .SetValidator(v => new SecretsServerValidator(servers));

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