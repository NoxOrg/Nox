using System;

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

    public string GetEntityTypeFullName(string entityName) => $"{DomainNameSpace}.{entityName}";

    public string GetEntityDtoTypeFullName(string dtoName) => $"{DtoNameSpace}.{dtoName}";

    public static string GetForeignKeyPropertyName(string foreignEntityName)
    {
        return $"{foreignEntityName}Id";
    }
}