using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class DomainQueryValidator: AbstractValidator<DomainQuery>
    {
        private readonly IEnumerable<DomainQuery>? _queries;

        public DomainQueryValidator(IEnumerable<DomainQuery>? queries, string entityName)
        {
            if (queries == null) return;
            _queries = queries;

            RuleFor(q => q.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainQueryNameEmpty, entityName));

            RuleFor(q => q.Name).Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.DomainQueryNameDuplicate, m.Name, entityName));
                

            RuleForEach(q => q.RequestInput)
                .SetValidator(v => new DomainQueryRequestInputValidator(v.Name));

            RuleFor(q => q.ResponseOutput)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DomainQueryResponseOutputEmpty, m.Name, entityName));

            RuleFor(q => q.ResponseOutput!)
                .SetValidator(v => new DomainQueryResponseOutputValidator(v.Name));
        }
        
        private bool HaveUniqueName(DomainQuery toEvaluate, string name)
        {
            return _queries!.All(q => q.Equals(toEvaluate) || q.Name != name);
        }
    }
}