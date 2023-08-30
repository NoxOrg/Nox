// Generated

#nullable enable

// Found files ->
//  - clientapi.solution.nox.yaml
//  - country.entity.nox.yaml
//  - countrylocalname.entity.nox.yaml
//  - store.entity.nox.yaml
//  - workplace.entity.nox.yaml
//  - generator.nox.yaml
// Errors ->
//  - Value cannot be null.
Parameter name: stream   at System.IO.StreamReader..ctor(Stream stream, Encoding encoding, Boolean detectEncodingFromByteOrderMarks, Int32 bufferSize, Boolean leaveOpen)
   at System.IO.StreamReader..ctor(Stream stream)
   at Nox.Generator.Common.TemplateCodeBuilder.GenerateSourceCodeFromResource(String templateFileName)
   at Nox.Generator.Domain.ModelGenerator.MetaEntitiesGenerator.Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
   at Nox.Generator.NoxCodeGenerator.GenerateSource(SourceProductionContext context, ImmutableArray`1 noxYamls)
