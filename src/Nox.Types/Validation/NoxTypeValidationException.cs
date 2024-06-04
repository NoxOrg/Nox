using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Nox.Types;

public class NoxTypeValidationException : Exception
{
    private readonly List<ValidationFailure> _errors = new();
    public IReadOnlyList<ValidationFailure> Errors => _errors;

    public NoxTypeValidationException(IEnumerable<ValidationFailure> errors)
    : base($"The Nox type validation failed with {errors.Count()} error(s).")
    {
        _errors.AddRange(errors);
    }

    public override string Message => $"{base.Message} {string.Join("\n", Errors.Select(x => $"PropertyName: {x.Variable}. Error: {x.ErrorMessage}"))}";
}