// Generated

#nullable enable

// Found files ->
//  - allnoxtypes.entity.nox.yaml
//  - currency.entity.nox.yaml
//  - currencyCashBalance.entity.nox.yaml
//  - elastic.monitoring.nox.yaml
//  - sample.solution.nox.yaml
//  - store-security-passwords.entity.nox.yaml
//  - store.entity.nox.yaml
//  - generator.nox.yaml
// Errors ->
//  - This template has errors. Check the <Template.HasError> and <Template.Messages> before evaluating a template. Messages:
<input>(85,91) : error : Error while parsing if statement: The <end> statement was not found in: if <expression> ... end|else|else if   at Scriban.Template.CheckErrors()
   at Scriban.Template.EvaluateAndRender(TemplateContext context, Boolean render)
   at Scriban.Template.Render(TemplateContext context)
   at Nox.Generator.Common.TemplateCodeBuilder.GenerateSourceCode(String template, Object model, String sourceFileName)
   at Nox.Generator.Common.TemplateCodeBuilder.GenerateSourceCodeFromResource(String templateFileName)
   at Nox.Generator.Presentation.Api.OData.EntityDtoGenerator.Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
   at Nox.Generator.NoxCodeGenerator.GenerateSource(SourceProductionContext context, ImmutableArray`1 noxYamls)
