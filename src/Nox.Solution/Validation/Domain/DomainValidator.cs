using System.Linq;
using FluentValidation;
using Nox.Types;

namespace Nox.Solution.Validation;

internal class DomainValidator : AbstractValidator<Domain>
{
    public DomainValidator(Application? app, Infrastructure? infra)
    {
        RuleFor(d => d.Entities)
            .NotEmpty()
            .WithMessage(t => string.Format(ValidationResources.DomainEntitiesEmpty));

        RuleForEach(d => d.Entities)
            .SetValidator(v => new EntityValidator(v.Entities, app))
            .SetValidator(e => new UniquePropertyValidator<Entity>(e.Entities, x => x.Name, "entity"));
        
        RuleForEach(d => d.Entities)
            .Must(e => e.Attributes.Union(e.Keys).Count(a => a.Type == NoxType.AutoNumber) <= 1)
            .When((_) => infra is { Persistence.DatabaseServer.Provider: DatabaseServerProvider.SqLite })
            .WithMessage((_,e)=> string.Format(ValidationResources.PersistenceDatabaseSqliteAutoNumberLimitation, e.Name));
    }
}