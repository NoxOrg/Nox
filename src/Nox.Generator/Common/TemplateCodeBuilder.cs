using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;

namespace Nox.Generator.Common;

internal class TemplateCodeBuilder
{

    private readonly string _sourceFileName;

    private readonly SourceProductionContext _context;

    public TemplateCodeBuilder(string sourceFileName, SourceProductionContext context)
    {
        _sourceFileName = sourceFileName;
        _context = context;
    }
    public void GenerateSourceCode(string template, object model)
    {
        var strongTemplate = Template.Parse(template); 
        _context.AddSource(_sourceFileName, SourceText.From(strongTemplate.Render(model, member => member.Name), Encoding.UTF8));
    }
    public void GenerateSourceCodeFromResource(string fileName, object model)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"Nox.Generator.{fileName}";

        string template;

        using (var stream = assembly.GetManifestResourceStream(resourceName)!)
        using (var reader = new StreamReader(stream))
        {
            template = reader.ReadToEnd();
        }

        GenerateSourceCode(template, model);
    }
}