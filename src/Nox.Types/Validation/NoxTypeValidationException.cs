using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Nox.Types;

[Serializable]
public class NoxTypeValidationException : Exception
{
    private readonly List<ValidationFailure> _errors = new();
    public IReadOnlyList<ValidationFailure> Errors => _errors;

    public NoxTypeValidationException(IEnumerable<ValidationFailure> errors)
    : base($"The Nox type validation failed with {errors.Count()} error(s).")
    {
        _errors.AddRange(errors);
    }

    protected NoxTypeValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }
    public override string Message => $"{base.Message} {string.Join("\n", Errors.Select(x => $"PropertyName: {x.Variable}. Error: {x.ErrorMessage}"))}";
}