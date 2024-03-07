using System.Linq;

namespace Nox.Solution;

/// <summary>
/// Code generation conventions for namespaces, class names, etc...
/// </summary>
public class NoxCodeGenConventions
{
    private readonly NoxSolution _noxSolution;

    public NoxCodeGenConventions(NoxSolution noxSolution, string solutionPath)
    {
        _noxSolution = noxSolution;
        SolutionPath = solutionPath;
    }

    public NoxSolution Solution => _noxSolution;
    /// <summary>
    /// Entry yaml file for the solution
    /// </summary>
    public string SolutionPath { get; }
    public string RootNameSpace => _noxSolution.Name;
    public string DomainNameSpace => $"{RootNameSpace}.Domain";
    public string DomainNamespaceAlias => $"{RootNameSpace}Domain";
    public string DtoNameSpace => $"{ApplicationNameSpace}.Dto";
    public string ApplicationNameSpace => $"{RootNameSpace}.Application";
    public string PresentationNameSpace => $"{RootNameSpace}.Presentation";
    public string ApplicationQueriesNameSpace => $"{ApplicationNameSpace}.Queries";
    public string PersistenceNameSpace => $"{RootNameSpace}.Infrastructure.Persistence";

    public string ODataNameSpace => $"{RootNameSpace}.Presentation.Api.OData";
    public string Events => $"{RootNameSpace}.Application.Events";
    public string UiNameSpace => $"{RootNameSpace}.Ui";

    /// <summary>
    /// Computes the Entity Name that holds the values of an enumeration attribute
    /// </summary>
    public string GetEntityNameForEnumeration(string entityName, string attributeName) => $"{entityName}{attributeName}";
    public string GetEntityDtoNameForEnumeration(string entityName, string attributeName) => $"{entityName}{attributeName}Dto";

    /// <summary>
    /// Gets the name of the enum property ensuring it is a valid C# identifier.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static string GetEnumPropertyName(string name)
    {
        string sanitizedName = new string(name.Replace(" ", "_")
            .Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());

        if (char.IsDigit(sanitizedName.First()))
            sanitizedName = $"_{sanitizedName}";

        return sanitizedName;
    }

    /// <summary>
    /// Computes the Entity Type Full Name that holds the values of an enumeration attribute
    /// </summary>
    public string GetEntityTypeFullNameForEnumeration(string entityName, string attributeName) => $"{DomainNameSpace}.{entityName}{attributeName}";
    /// <summary>
    /// Computes the Entity Name that holds the translated values of an enumeration attribute
    /// </summary>
    public string GetEntityNameForEnumerationLocalized(string entityName, string attributeName) => $"{entityName}{attributeName}Localized";
    public string GetEntityDtoNameForEnumerationLocalized(string entityName, string attributeName) => $"{entityName}{attributeName}LocalizedDto";
    public string GetEntityDtoNameForUpsertLocalizedEnumeration(string entityName, string attributeName) => $"{entityName}{attributeName}LocalizedUpsertDto";
    /// <summary>
    /// Computes the Entity Name that holds the translated values of an localized entity.
    /// </summary>
    public static string GetEntityNameForLocalizedType(string entityName) => $"{entityName}Localized";
    /// <summary>
    /// Computes the Entity DTO Name that holds the translated values of an localized entity.
    /// </summary>
    public static string GetEntityDtoNameForLocalizedType(string entityName) => $"{entityName}LocalizedDto";

    /// <summary>
    /// Computes the Entity DTO Name that holds the translated values of an localized entity.
    /// </summary>
    public static string GetEntityUpsertDtoNameForLocalizedType(string entityName) => $"{entityName}LocalizedUpsertDto";
    /// <summary>
    /// Localization culture field name.
    /// </summary>
    public string LocalizationCultureField => "CultureCode";
    

    public string GetEntityTypeFullName(string entityName) => $"{DomainNameSpace}.{entityName}";

    public string GetEntityDtoTypeFullName(string dtoName) => $"{DtoNameSpace}.{dtoName}";

    public static string GetForeignKeyPropertyName(Entity entity, EntityRelationship relationship) => $"{entity.GetNavigationPropertyName(relationship)}Id";

    /// <summary>
    /// Computes the Database Sequence Name to be used by an Entity Attribute
    /// </summary>
    /// <remarks>lower case so its fully compatible with postgres</remarks>
    public static string GetDatabaseSequenceName(string entityName, string attributeName) => $"Seq{entityName}{attributeName}".ToLowerInvariant();
}