using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace Nox.Types;

[Serializable]
public class TypeValidationException : Exception, INoxHttpException
{
    private readonly List<ValidationFailure> _errors = new();
    public IReadOnlyList<ValidationFailure> Errors => _errors;

    public TypeValidationException(IEnumerable<ValidationFailure> errors)
    : base($"The Nox type validation failed with {errors.Count()} error(s).")
    {
        _errors.AddRange(errors);
    }

    protected TypeValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }

    public override string Message => string.Join("\n", Errors.Select(x => $"PropertyName: {x.Variable}. Error: {x.ErrorMessage}"));

    public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
}