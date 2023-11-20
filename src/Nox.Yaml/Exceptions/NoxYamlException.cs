using System.Runtime.Serialization;

namespace Nox.Yaml.Exceptions;

[Serializable]
internal class NoxYamlException : Exception
{

    private readonly IReadOnlyList<string> _errors;

    public IReadOnlyList<string> Errors => _errors;

    public NoxYamlException()
    {
        _errors = new List<string>();
    }

    public NoxYamlException(string? message)
        : base(message)
    {
        var errors = new List<string>();

        if(message != null)
        {
            errors.Add(message);
        };

        _errors = errors;
    }

    public NoxYamlException(string? message, IReadOnlyList<string> errors)
    : base(message)
    {
        _errors = errors;
    }

    public NoxYamlException(string? message, Exception? innerException)
        : base(message, innerException)
    {
        var errors = new List<string>();

        if (message != null)
        {
            errors.Add(message);
        };

        _errors = errors;
    }

    public NoxYamlException(string? message, Exception? innerException, IReadOnlyList<string> errors)
        : base(message, innerException)
    {
        _errors = errors;
    }

    protected NoxYamlException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        var errors = new List<string>();

        _errors = errors;
    }
}