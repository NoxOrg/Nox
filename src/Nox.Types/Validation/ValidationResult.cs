using System.Collections;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Construcyion Result for a Nox.Type
/// </summary>
public sealed class ValidationResult
{
    public ValidationResult()
    {
        Errors = new List<ValidationFailure>(1);
    }
    public ValidationResult(IList<ValidationFailure> errors)
    {
        Errors = errors;
    }
    public bool IsValid => Errors.Count == 0;

    public IList<ValidationFailure> Errors { get; }
}
