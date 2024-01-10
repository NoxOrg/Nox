using FluentValidation;
using Nox.Generator.Validation;

namespace Nox.Generator.Common;

public enum LoggingVerbosity
{         
    Minimal,
    //Normal,
    //Detailed,
    Diagnostic
}
public sealed class GeneratorConfig
{
    public LoggingVerbosity LoggingVerbosity { get; set; } = LoggingVerbosity.Minimal;

    public bool Domain { get; set; } = true;

    public bool Application { get; set; } = true;

    /// <summary>
    /// Dtos (Contracts) for the Api, Commands and Queries
    /// </summary>
    public bool ApplicationDto { get; set; } = true;

    public bool Infrastructure { get; set; } = true;

    public bool Presentation { get; set; } = true;

    public bool Ui { get; set; } = false;

    public void Validate()
    {
        var validator = new GeneratorConfigValidator();
        validator.ValidateAndThrow(this);
    }
}
