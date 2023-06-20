using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System;
using System.Data.SqlTypes;
using System.Text;
using System.Threading;

namespace Nox.Generator;

internal class DbContextGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        var code = new CodeBuilder();

        typeof(DbContextGenerator).ToString();


        context.AddSource($"DbContext.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }
}
