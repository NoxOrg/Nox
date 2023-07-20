using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

public class TypeValidationException : Exception
{

    private IList<ValidationFailure> _errors = new List<ValidationFailure>();

    public IReadOnlyList<ValidationFailure> Errors => _errors.ToList();
    
    public TypeValidationException(IList<ValidationFailure> errors)
    : base($"The Nox type validation failed with {errors.Count} error(s).")
    {
        _errors = errors;
    }

}
