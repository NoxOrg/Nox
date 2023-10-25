namespace Nox.Solution;

/// <summary>
/// Code generation conventions for namespaces, class names, etc...
/// </summary>
public class NoxCodeGenConventions
{
    private readonly NoxSolution _noxSolution;

    public NoxCodeGenConventions(NoxSolution noxSolution)
    {
        _noxSolution = noxSolution;
    }

    public NoxSolution Solution => _noxSolution;
    public string RootNameSpace => _noxSolution.Name;
    public string DomainNameSpace => $"{RootNameSpace}.Domain";
    public string DtoNameSpace => $"{ApplicationNameSpace}.Dto";
    public string ApplicationNameSpace => $"{RootNameSpace}.Application";
    public string DataTransferObjectsNameSpace => $"{RootNameSpace}.Application.DataTransferObjects";
    public string PersistenceNameSpace => $"{RootNameSpace}.Infrastructure.Persistence";

    public string ODataNameSpace => $"{RootNameSpace}.Presentation.Api.OData";
    public string Events => $"{RootNameSpace}.Application.Events";
    public string UiNameSpace => $"{RootNameSpace}.Ui";

    /// <summary>
    /// Computes the Entity Name that holds the values of an enumeration attribute
    /// </summary>
    public string GetEntityNameForEnumeration(string entityName, string attributeName) => $"{entityName}{attributeName}";
    /// <summary>
    /// Computes the Entity Type Full Name that holds the values of an enumeration attribute
    /// </summary>
    public string GetEntityTypeFullNameForEnumeration(string entityName, string attributeName) => $"{DomainNameSpace}.{entityName}{attributeName}";
    /// <summary>
    /// Computes the Entity Name that holds the translated values of an enumeration attribute
    /// </summary>
    public string GetEntityNameForEnumerationLocalized(string entityName, string attributeName) => $"{entityName}{attributeName}Localized";
    /// <summary>
    /// Computes the Entity Name that holds the translated values of an localized entity.
    /// </summary>
    public static string GetEntityNameForLocalizedType(string entityName) => $"{entityName}Localized";
    /// <summary>
    /// Computes the Entity DTO Name that holds the translated values of an localized entity.
    /// </summary>
    public static string GetEntityDtoNameForLocalizedType(string entityName) => $"{entityName}LocalizedDto";
    /// <summary>
    /// Localization culture field name.
    /// </summary>
    public string LocalizationCultureField => "CultureCode";

    public string GetEntityTypeFullName(string entityName) => $"{DomainNameSpace}.{entityName}";

    public string GetEntityDtoTypeFullName(string dtoName) => $"{DtoNameSpace}.{dtoName}";

    public static string GetForeignKeyPropertyName(string foreignEntityName) => $"{foreignEntityName}Id";
}