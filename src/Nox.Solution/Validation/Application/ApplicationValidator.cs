using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class ApplicationValidator: AbstractValidator<Nox.Solution.Application>
    {
        public ApplicationValidator(IEnumerable<DataConnection>? dataConnections)
        {
            RuleForEach(p => p.DataTransferObjects)
                .SetValidator(v => new DataTransferObjectValidator(v.DataTransferObjects));

            RuleForEach(p => p.Integrations)
                .SetValidator(v => new IntegrationValidator(v.Integrations, dataConnections));
        }
    }
}