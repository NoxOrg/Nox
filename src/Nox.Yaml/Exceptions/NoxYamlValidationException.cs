using System.Net;
using System.Runtime.Serialization;
using Nox.Yaml.Validation;

namespace Nox.Yaml.Exceptions;

[Serializable]
public class NoxYamlValidationException : Exception
{
    private readonly List<ValidationFailure> _errors = new();
    public IReadOnlyList<ValidationFailure> Errors => _errors;

    public NoxYamlValidationException(IEnumerable<ValidationFailure> errors)
    : base($"The Nox type validation failed with {errors.Count()} error(s).")
    {
        _errors.AddRange(errors);
    }

    public NoxYamlValidationException(IEnumerable<string> errors)
        : base($"The Nox type validation failed with {errors.Count()} error(s).")
    {
        _errors.AddRange(errors.Select(e => new ValidationFailure(string.Empty, e)));
    }

    protected NoxYamlValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }

    public override string Message => $"{base.Message} {string.Join("\n", Errors.Select(x => $"PropertyName: {x.Variable}. Error: {x.ErrorMessage}"))}";

    public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
}