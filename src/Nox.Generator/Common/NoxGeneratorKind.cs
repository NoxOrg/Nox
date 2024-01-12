namespace Nox.Generator.Common;

public enum NoxGeneratorKind
{
    None,
    Domain,
    Infrastructure,
    Presentation,
    Application,
    /// <summary>
    /// Dtos (Contracts) for the Api, Commands and Queries
    /// </summary>
    ApplicationDto,
    Ui
}