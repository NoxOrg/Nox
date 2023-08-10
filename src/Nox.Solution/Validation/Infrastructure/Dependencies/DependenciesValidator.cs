using System.Collections.Generic;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class DependenciesValidator: AbstractValidator<Dependencies>
    {
        public DependenciesValidator(IEnumerable<ServerBase>? servers)
        {
            RuleFor(p => p.Notifications!)
                .SetValidator(v => new NotificationsValidator(servers));
            
            RuleFor(p => p.Monitoring!)
                .SetValidator(v => new ServerBaseValidator("the infrastructure, dependencies, monitoring server", servers));
            
            RuleFor(p => p.UiLocalizations!)
                .SetValidator(v => new LocalizationsValidator(servers));

            RuleForEach(p => p.DataConnections)
                .SetValidator(v => new DataConnectionValidator(servers));
        }
    }
}