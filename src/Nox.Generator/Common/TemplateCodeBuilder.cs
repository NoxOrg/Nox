using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using System.Text;

namespace Nox.Generator.Common;

internal class TemplateCodeBuilder : TemplateBuilderBase
{    
    private readonly SourceProductionContext _context;

    public TemplateCodeBuilder(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
        : base(codeGeneratorState)
    {
        _context = context;
    }

    public override void SaveSourceCode(string fileName, string sourceCode)
    {
        _context.AddSource($"{fileName}.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
    }
}
