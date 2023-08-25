using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using Nox.Types;

namespace Nox.Solution.Validation
{
    internal class DomainValidator: AbstractValidator<Domain>
    {
        public DomainValidator(Application? app)
        {
            RuleFor(d => d.Entities)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.DomainEntitiesEmpty));

            RuleForEach(d => d.Entities)
                .SetValidator(v => new EntityValidator(v.Entities, app))
                .SetValidator(e => new UniquePropertyValidator<Entity>(e.Entities, x => x.Name, "entity"));
            
        }
    }
}