// Generated

#nullable enable

// Found files ->
//  - clientapi.solution.nox.yaml
//  - client.entity.nox.yaml
//  - country-time-zone.entity.nox.yaml
//  - country.entity.nox.yaml
//  - countrybarcode.entity.nox.yaml
//  - countrylocalname.entity.nox.yaml
//  - countryqualityoflifeindex.entity.nox.yaml
//  - currency.entity.nox.yaml
//  - holiday.entity.nox.yaml
//  - ratingprogram.entity.nox.yaml
//  - referencenumber.entity.nox.yaml
//  - store-license.entity.nox.yaml
//  - store-owner.entity.nox.yaml
//  - store.entity.nox.yaml
//  - tenant-brand.entity.nox.yaml
//  - tenant-contact.entity.nox.yaml
//  - tenant.entity.nox.yaml
//  - workplace.entity.nox.yaml
//  - apiConfiguration.nox.yaml
//  - countries.encodedTargetUrl.ApiRouteMapping.nox.yaml
//  - countriesInPortugues.Get.ApiRouteMapping.nox.yaml
//  - countriesInPortugues.GetById.ApiRouteMapping.nox.yaml
//  - countriesInPortugues.Patch.ApiRouteMapping.nox.yaml
//  - countriesInPortugues.Post.ApiRouteMapping.nox.yaml
//  - countriesInPortuguesToWorkplaces.GetRef.ApiRouteMapping.nox.yaml
//  - countriesInPortuguesToWorkplaces.PostRef.ApiRouteMapping.nox.yaml
//  - countryByName.ApiRouteMapping.nox.yaml
//  - countryByName.queryString.ApiRouteMapping.nox.yaml
//  - countryByNameOdataFiltering.ApiRouteMapping.nox.yaml
//  - countryByNameOdataFiltering3Segments.ApiRouteMapping.nox.yaml
//  - getTwoSeqSegProperties.nox.yaml
//  - putRefCountryToWorkplace3Segments.ApiRouteMapping.nox.yaml
//  - workplacesViaTenants.Delete.ApiRouteMapping.nox.yaml
//  - workplacesViaTenants.Patch.ApiRouteMapping.nox.yaml
//  - presentation.nox.yaml
//  - generator.nox.yaml
// Errors ->
//  - [YamlException] Exception during deserialization. Line 1119, column 14.
Requested value 'fr-FR' was not found.   at Nox.Solution.Schema.NoxSchemaValidator.Deserialize[T](YamlReferenceResolver yamlRefResolver) in /home/jan/Projects/IWG/Nox/src/Nox.Yaml/Schema/NoxSchemaValidator.cs:line 92
   at Nox.Yaml.YamlConfigurationReader`2.ResolveAndLoadConfiguration() in /home/jan/Projects/IWG/Nox/src/Nox.Yaml/YamlConfigurationReader.cs:line 273
   at Nox.Yaml.YamlConfigurationReader`2.Read() in /home/jan/Projects/IWG/Nox/src/Nox.Yaml/YamlConfigurationReader.cs:line 150
   at Nox.Solution.NoxSolutionBuilder.Build() in /home/jan/Projects/IWG/Nox/src/Nox.Solution/NoxSolutionBuilder.cs:line 67
   at Nox.Generator.NoxGeneratorBase.TryCreateSolution(IList`1 errorCollection, NoxSolution& solution, Dictionary`2 solutionFileAndContent) in /home/jan/Projects/IWG/Nox/src/Nox.Generator/Nox.Generator.cs:line 47
   at Nox.Generator.NoxCodeGenerator.TryGetNoxSolution(ImmutableArray`1 noxYamls, IList`1 errorCollection, NoxSolution& solution) in /home/jan/Projects/IWG/Nox/src/Nox.Generator/Nox.Generator.cs:line 232
   at Nox.Generator.NoxCodeGenerator.GenerateSource(SourceProductionContext context, ImmutableArray`1 noxYamls) in /home/jan/Projects/IWG/Nox/src/Nox.Generator/Nox.Generator.cs:line 116
