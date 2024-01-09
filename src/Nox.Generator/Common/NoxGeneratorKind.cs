namespace Nox.Generator.Common;

internal enum NoxGeneratorKind
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