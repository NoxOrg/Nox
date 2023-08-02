using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Generator.Common.TemplateScriptsBridges;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace Nox.Generator.Common;


internal class TemplateCodeBuilder

{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    private readonly SourceProductionContext _context;

    private readonly NoxSolutionCodeGeneratorState _codeGeneratorState;

    private string? _className;

    private readonly Dictionary<string, object> _model;


    public TemplateCodeBuilder(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        _context = context;
        _codeGeneratorState = codeGeneratorState;

        _model = new Dictionary<string, object>
        {
            ["codeGeneratorState"] = _codeGeneratorState,
            ["solution"] = _codeGeneratorState.Solution
        };
    }

    /// <summary>
    /// Option class and file name to be generated, for "Entity" will generate a file name Entity.g.cs
    /// Uses template name if undefined
    /// </summary>
    /// <param name="className">the name of the class to be generated</param>
    /// <returns></returns>
    public TemplateCodeBuilder WithClassName(string className) 
    { 
        _className = className;
        return this;
    }
    
    /// <summary>
    /// Extend the default model with a extended property to the extendedModel
    /// </summary>
    public TemplateCodeBuilder WithObject(string name, object value)
    {
        _model[name] = value;
        return this;
    }

    /// <summary>
    /// Generates the class based on a file template 
    /// </summary>
    /// <param name="templateFileName">the file relative namespace without template.cs. <example>Infrastructure.Persistence.DbContextGenerator.DbContext</example></param>
    /// <returns></returns>
    public TemplateCodeBuilder GenerateSourceCodeFromResource(string templateFileName)
    {
        var resourceName = $"Nox.Generator.{templateFileName}.template.cs";

        _className ??= ComputeDefaultClassName(templateFileName);

        _model["className"] = _className;
        
        string template;

        using (var stream = Assembly.GetManifestResourceStream(resourceName)!)
        using (var reader = new StreamReader(stream))
        {
            template = reader.ReadToEnd();
        }

        GenerateSourceCode(template, _model, $"{_className}.g.cs");
     
        return this;
    }

    private string ComputeDefaultClassName(string templateFileName)
    {
        return templateFileName.Split('.').Last();
    }

    private void GenerateSourceCode(string template, object model, string sourceFileName)
    {
        var strongTemplate = Template.Parse(template);

        var context = strongTemplate.LexerOptions.Lang == ScriptLang.Liquid ? new LiquidTemplateContext() : new TemplateContext();

        // Import the model and the member naming convention
        var scriptModelObject = new ScriptObject();
        scriptModelObject.Import(model, renamer: member => member.Name, filter: null);
        context.MemberRenamer = member => member.Name;
        context.MemberFilter = null;
        context.PushGlobal(scriptModelObject);

        // Add Delegate functions to instance objects
        NoxSolutionBridge.AddFunctions(context, _codeGeneratorState.Solution);

        _context.AddSource(sourceFileName,
            SourceText.From(strongTemplate.Render(context),
            Encoding.UTF8));
    }

   
}
