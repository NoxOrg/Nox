// Generated

#nullable enable

// Found files ->
//  - test.solution.nox.yaml
//  - generator.nox.yaml
// Logging Verbosity Minimal
// Error in Generator: Nox.Generator.Application.Commands.DeleteTranslationCommandGenerator
// Errors ->
//  - <input>(16,28) : error : Cannot get the member codeGeneratorState.PersistenceNameSpace for a null object.   at Scriban.Syntax.ScriptMemberExpression.GetValue(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Syntax\Expressions\ScriptMemberExpression.cs:line 81
   at Scriban.TemplateContext.GetOrSetValue(ScriptExpression targetExpression, Object valueToSet, Boolean setter) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 1118
   at Scriban.TemplateContext.GetValue(ScriptExpression target) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 603
   at Scriban.Syntax.ScriptMemberExpression.Evaluate(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Syntax\Expressions\ScriptMemberExpression.cs:line 52
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode, Boolean aliasReturnedFunction) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 809
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 788
   at Scriban.Syntax.ScriptExpressionStatement.Evaluate(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Syntax\Statements\ScriptExpressionStatement.cs:line 34
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode, Boolean aliasReturnedFunction) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 809
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 788
   at Scriban.Syntax.ScriptBlockStatement.Evaluate(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Syntax\Statements\ScriptBlockStatement.cs:line 66
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode, Boolean aliasReturnedFunction) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 809
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 788
   at Scriban.Syntax.ScriptPage.Evaluate(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Syntax\ScriptPage.cs:line 52
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode, Boolean aliasReturnedFunction) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 809
   at Scriban.TemplateContext.Evaluate(ScriptNode scriptNode) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\TemplateContext.cs:line 788
   at Scriban.Template.EvaluateAndRender(TemplateContext context, Boolean render) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Template.cs:line 251
   at Scriban.Template.Render(TemplateContext context) in C:\Users\emir.sehovic\.nuget\packages\scriban\5.9.0\src\Scriban\Template.cs:line 183
   at Nox.Generator.Common.TemplateBuilderBase.GenerateSourceCode(String template, Object model) in C:\Users\emir.sehovic\source\repos\Nox.Generator\src\Nox.Generator\Common\TemplateBuilderBase.cs:line 143
   at Nox.Generator.Common.TemplateBuilderBase.GenerateSourceCodeFromResource(String templateFileName) in C:\Users\emir.sehovic\source\repos\Nox.Generator\src\Nox.Generator\Common\TemplateBuilderBase.cs:line 106
   at Nox.Generator.Application.Commands.DeleteTranslationCommandGenerator.DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable`1 entities) in C:\Users\emir.sehovic\source\repos\Nox.Generator\src\Nox.Generator\Application\Commands\DeleteTranslationCommandGenerator.cs:line 27
   at Nox.Generator.Application.Commands.ApplicationEntityDependentGeneratorBase.Generate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, GeneratorConfig config, Action`1 log, String projectRootPath) in C:\Users\emir.sehovic\source\repos\Nox.Generator\src\Nox.Generator\Application\Commands\ApplicationEntityDependentGeneratorBase.cs:line 27
   at Nox.Generator.NoxCodeGenerator.GenerateSource(SourceProductionContext context, ImmutableArray`1 noxYamls) in C:\Users\emir.sehovic\source\repos\Nox.Generator\src\Nox.Generator\Nox.Generator.cs:line 164
