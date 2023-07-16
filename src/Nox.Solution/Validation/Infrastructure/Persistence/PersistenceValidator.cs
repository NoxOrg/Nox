using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class PersistenceValidator: AbstractValidator<Persistence>
    {
        public PersistenceValidator(IEnumerable<ServerBase>? servers, bool hasIntegrations)
        {
            RuleFor(p => p.DatabaseServer)
                .SetValidator(v => new DatabaseServerValidator(servers));

            RuleFor(p => p.IntegrationDatabaseServer)
                .NotEmpty()
                .WithMessage(p => ValidationResources.IntegrationDatabaseServerMissing)
                .When(_ => hasIntegrations);
            
            RuleFor(p => p.IntegrationDatabaseServer!)
                .SetValidator(v => new IntegrationDatabaseServerValidator(servers));
            
            RuleFor(p => p.CacheServer!)
                .SetValidator(v => new CacheServerValidator(servers));
            
            RuleFor(p => p.SearchServer!)
                .SetValidator(v => new SearchServerValidator(servers));
            
            RuleFor(p => p.EventSourceServer!)
                .SetValidator(v => new EventSourceServerValidator(servers));
        }
    }
}