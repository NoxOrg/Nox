using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationTransformValidator: AbstractValidator<IntegrationTransform>
    {
        public IntegrationTransformValidator(string integrationName)
        {
            RuleForEach(p => p.Mappings)
                .SetValidator(v => new IntegrationMappingValidator(integrationName));

            RuleForEach(p => p.Lookups)
                .SetValidator(v => new IntegrationLookupValidator(integrationName));
        }
    }
}