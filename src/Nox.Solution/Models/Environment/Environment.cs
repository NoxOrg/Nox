﻿using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("A definition for a run-time environment.")]
[Description("A definition for the name, production status and other pertinent information pertaining to a run-time environment.")]
[AdditionalProperties(false)]
public class Environment
{
    [Required]
    [Title("A short name for the environment. Contains no spaces.")]
    [Description("The name of the run-time environment. Each environment name should be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;

    [Title("A short description of the run-time environment.")]
    [Description("The description of the run-time environment. Try to include the purpose or use of the environment.")]
    public string? Description { get; internal set; }

    [Title("Whether this environment is a production environment (true) or not (false).")]
    [Description("Specifies whether this environment is used for production or not. Affects how devops processes and the NOX runtime is configured.")]
    public bool IsProduction { get; internal set; } = false;
    
    [Title("Whether this environment disaster recovery mirror (true) or not (false).")]
    [Description("Specifies whether this environment has an instance in the disaster recovery environment. Affects how devops processes are configured.")]
    public bool IsDisasterRecovery { get; internal set; } = false;
}