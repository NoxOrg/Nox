using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

public class IntegrationDatabaseServerValidator: AbstractValidator<IntegrationDatabaseServer>
{
    public IntegrationDatabaseServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, integration database server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.IntegrationDatabaseServerProviderEmpty, p.Name, DatabaseServerProvider.SqlServer.ToNameList()));
        
        
    }
}