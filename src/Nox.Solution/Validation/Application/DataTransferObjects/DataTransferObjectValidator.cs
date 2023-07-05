using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution;

namespace Nox.Solution.Validation
{
    internal class DataTransferObjectValidator: AbstractValidator<DataTransferObject>
    {
        private readonly IEnumerable<DataTransferObject>? _dtos;

        public DataTransferObjectValidator(IEnumerable<DataTransferObject>? dtos)
        {
            if (dtos == null) return;
            _dtos = dtos;
            
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DtoNameEmpty));

            RuleFor(p => p.Name).Must(HaveUniqueName)
                .WithMessage(m => string.Format(ValidationResources.DtoNameDuplicate, m.Name));

            RuleFor(p => p.Attributes)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.DtoAttributesEmpty, m.Name));

            RuleForEach(p => p.Attributes)
                .SetValidator(v => new SimpleTypeValidator($"The dto '{v.Name}' has an attribute that", "data transfer object attributes"));
        }
        
        private bool HaveUniqueName(DataTransferObject toEvaluate, string name)
        {
            return _dtos!.All(dto => dto.Equals(toEvaluate) || dto.Name != name);
        }
    }
}