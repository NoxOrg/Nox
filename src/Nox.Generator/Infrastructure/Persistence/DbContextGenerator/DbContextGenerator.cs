using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Infrastructure.Persistence.DbContextGenerator;

internal static class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }
        
        var dbContextName = $"{codeGeneratorState.Solution.Name}DbContext";

        var code = new TemplateCodeBuilder($"{dbContextName}.g.cs",context);

        code.GenerateSourceCodeFromResource(@"Infrastructure.Persistence.DbContextGenerator.DbContext.g.cs",
            new
            {
                domainNamespace = codeGeneratorState.DomainNameSpace,
                persistenceNamespace = codeGeneratorState.PersistenceNameSpace,
                dbContextName = dbContextName,
                dbSets = GetDbSets(codeGeneratorState.Solution),
                solutionName = codeGeneratorState.Solution.Name
            });
    }
    private static IList<object> GetDbSets(NoxSolution solution)
    {
        List<object> sets = new();
        foreach (var entity in solution.Domain!.Entities)
        {
            sets.Add(new {Name = entity.Name, PropertyName = entity.PluralName });
        }

        return sets;
    }
}