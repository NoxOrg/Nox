﻿using System;
using System.Linq;
using System.Reflection;
using Nox.Types;

namespace Nox.Solution;

public class NoxSolutionCodeGeneratorState
{
    private readonly NoxSolution _noxSolution;
    private readonly Assembly _entryAssembly;

    public NoxSolutionCodeGeneratorState(NoxSolution noxSolution, Assembly entryAssembly)
    {
        _noxSolution = noxSolution;
        _entryAssembly = entryAssembly;
    }

    public NoxSolution Solution => _noxSolution;
    public string RootNameSpace => _noxSolution.Name;
    public string DomainNameSpace => $"{RootNameSpace}.Domain";
    public string ApplicationNameSpace => $"{RootNameSpace}.Application";
    public string DataTransferObjectsNameSpace => $"{RootNameSpace}.Application.DataTransferObjects";
    public string PersistenceNameSpace => $"{RootNameSpace}.Infrastructure.Persistence";
    public string ODataNameSpace => $"{RootNameSpace}.Presentation.Api.OData";
    public string Events => $"{RootNameSpace}.Application.Events";

    public string GetEntityTypeFullName(string entityName) => $"{DomainNameSpace}.{entityName}";

    public Type? GetEntityType(string entityName) => _entryAssembly.GetType(GetEntityTypeFullName(entityName));

    public string GetForeignKeyPropertyName(string foreignEntityName)
    {
        return $"{foreignEntityName}Id";
    }
}