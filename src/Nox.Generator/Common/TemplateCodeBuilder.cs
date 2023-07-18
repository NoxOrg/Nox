using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Scriban;

namespace Nox.Generator.Common;


internal class TemplateCodeBuilder

{
    private static Assembly _assembly = Assembly.GetExecutingAssembly();

    private readonly SourceProductionContext _context;

    private readonly NoxSolutionCodeGeneratorState _codeGeneratorState;

    private string? _className;

    public TemplateCodeBuilder(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        _context = context;
        _codeGeneratorState = codeGeneratorState;
    }

    public TemplateCodeBuilder WithClassName(string className) 
    { 
        _className = className;
    }

    public TemplateCodeBuilder GenerateSourceCodeFromResource(string fileName)
    {
        var resourceName = $"Nox.Generator.{fileName}";

        var model = new { 
            codeGeneratorState = _codeGeneratorState, 
            className = _className, 
            solution = _codeGeneratorState.Solution
        };

        string template;

        using (var stream = _assembly.GetManifestResourceStream(resourceName)!)
        using (var reader = new StreamReader(stream))
        {
            template = reader.ReadToEnd();
        }

        GenerateSourceCode(template, model, $"{_className}.g.cs");
     
        return this;
    }

    private void GenerateSourceCode(string template, object model, string sourceFileName)
    {
        var strongTemplate = Template.Parse(template);

        _context.AddSource(sourceFileName!,
            SourceText.From(strongTemplate.Render(model, member => member.Name),
            Encoding.UTF8));
    }

}
