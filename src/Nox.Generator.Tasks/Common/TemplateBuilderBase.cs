using Microsoft.CodeAnalysis;
using Nox.Solution;
using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Tasks.Common;

internal abstract class TemplateBuilderBase
{
    private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

    private readonly NoxCodeGenConventions _codeGeneratorState;

    private readonly Dictionary<string, object> _model;

    private string? _className;
    private string? _fileNamePrefix;
    private string? _fileNameSuffix;

    protected TemplateBuilderBase(NoxCodeGenConventions codeGeneratorState)
    {
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
    public TemplateBuilderBase WithClassName(string className) 
    { 
        _className = className;
        return this;
    }

    /// <summary>
    /// Optional prefix to the generated file, example Domain.Entity.g.cs
    /// Uses template name if undefined
    /// </summary>
    /// <param name="fileNamePrefix">Prefix to add to the file name. A dot will be added between the prefix and the class name</param>
    /// <returns></returns>
    public TemplateBuilderBase WithFileNamePrefix(string fileNamePrefix)
    {
        _fileNamePrefix = fileNamePrefix;
        return this;
    }

    /// <summary>
    /// Oprional suffix to the generated file, for example "Relationships" will generate a file name Entity.Relationships.g.cs
    /// </summary>
    /// <param name="fileNameSuffix">Prefix to add to the file name. A dot will be added between the prefix and the class name</param>
    /// <returns></returns>
    public TemplateBuilderBase WithFileNameSuffix(string fileNameSuffix)
    {
        _fileNameSuffix = fileNameSuffix;
        return this;
    }

    /// <summary>
    /// Extend the default model with a extended property to the extendedModel
    /// </summary>
    public TemplateBuilderBase WithObject(string name, object value)
    {
        _model[name] = value;
        return this;
    }

    /// <summary>
    /// Generates the class based on a file template 
    /// </summary>
    /// <param name="templateFileName">the file relative namespace without template.cs. <example>Infrastructure.Persistence.DbContextGenerator.DbContext</example></param>
    /// <returns></returns>
    public TemplateBuilderBase GenerateSourceCodeFromResource(string templateFileName)
    {
        var resourceName = $"Nox.Generator.Tasks.{templateFileName}.template.cs";

        _className ??= ComputeDefaultClassName(templateFileName);

        _model["className"] = _className;
        
        string template;

        using (var stream = Assembly.GetManifestResourceStream(resourceName)!)
        using (var reader = new StreamReader(stream))
        {
            template = reader.ReadToEnd();
        }

        var fileName = string.Join("/", 
            new[] { _fileNamePrefix, _className, _fileNameSuffix }.Where(x => !string.IsNullOrWhiteSpace(x)));

        var sourceCode = GenerateSourceCode(template, _model);

        SaveSourceCode(fileName, sourceCode);

        return this;
    }

    /// <summary>
    /// Saves generated code based on the implementation in the derived class 
    /// </summary>
    /// <param name="fileName">File Name without extension</param>
    /// <param name="sourceCode">The source code to be saved</param>
    /// <returns></returns>
    public abstract void SaveSourceCode(string fileName, string sourceCode);

    private string ComputeDefaultClassName(string templateFileName)
    {
        var templateNameParts = templateFileName.Split('.');
        return templateNameParts[templateNameParts.Length - 1];
    }

    private string GenerateSourceCode(string template, object model)
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
        ScribanScriptsExtensions.AddFunctions(context, _codeGeneratorState.Solution);

        return strongTemplate.Render(context);
    }    
}