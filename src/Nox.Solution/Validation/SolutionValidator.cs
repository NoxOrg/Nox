using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Validation
{
    internal class SolutionValidator : AbstractValidator<Solution>
    {
        public SolutionValidator()
        {
            RuleFor(solution => solution.Name)
                .NotEmpty()
                .WithMessage(solution => string.Format(ValidationResources.SolutionNameEmpty));

            RuleForEach(sln => sln.Environments)
                .SetValidator(sln => new EnvironmentValidator(sln.Environments));

            RuleFor(sln => sln.VersionControl!)
                .SetValidator(new VersionControlValidator());

            RuleForEach(sln => sln.Team)
                .SetValidator(sln => new TeamValidator(sln.Team));

            RuleFor(sln => sln.Domain!)
                .SetValidator(sln => new DomainValidator(sln.Application));

            
            RuleFor(sln => sln.Application!)
                .SetValidator(sln =>
                {
                    IEnumerable<DataConnection> dataConnections =
                        sln.Infrastructure?.Dependencies?.DataConnections
                        ?? Enumerable.Empty<DataConnection>();

                    if (sln.Infrastructure?.Persistence.DatabaseServer is not null)
                    {
                        var db = sln.Infrastructure.Persistence.DatabaseServer;
                        var connectionProxyForDatabase = new DataConnection
                        {
                            Name = db.Name,
                            Options = db.Options,
                            User = db.User,
                            Password = db.Password,
                            Port = db.Port,
                            ServerUri = db.ServerUri,
                            Provider = (DataConnectionProvider)Enum.Parse(typeof(DataConnectionProvider),db.Provider.ToString())
                        };
                        dataConnections = dataConnections.Append(connectionProxyForDatabase);
                    }

                    return new ApplicationValidator(dataConnections);
                });

            RuleFor(sln => sln.Infrastructure!)
                .SetValidator(new InfrastructureValidator());
        }
    }
}