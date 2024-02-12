# Introduction

Nox.Yaml is a dotnet standard wrapper to YamlDotnet that takes the pain out of using YAML configuration files for your projects.

The library features:-

- Annotations for easily creating and documenting C# objects to deserialize YAML files into
- The ability to organize and split your YAML configuration files into multiple files
- Automatic generation of json schemas for linting, hints and auto-completion in VS Code and Visual Studio
- Validation of yaml files on deserialization
- Automatic replacement of environment and secret variables from a key vault
- Advanced defaulting, initialization and validation of variables

# Attributes

Use annotations to define and document your YAML structure.

``` csharp
[GenerateJsonSchema("solution")]
[Title("Fully describes a solution")]
[Description("Contains all configuration, domain objects and infrastructure declarations that defines a solution.")]
[AdditionalProperties(false)]
public class NoxSolution : YamlConfigNode<NoxSolution, NoxSolution>
{
    [Required]
    [Title("The short name for the solution. Contains no spaces.")]
    [Description("The name of the  solution, application or service.")]
    [Pattern(Constants.StringWithNoSpacesRegex)]
    public string Name { get; set; } = null!;

    [Title("A short description of the solution.")]
    [Description("A brief description of the solution with what it's purpose or goals are.")]
    public string? Description { get; internal set; }

    [Title("The version of the solution. Expected a Semantic Version format.")]
    [Description("This value is required, but if not defined it will default to '1.0'.")]
    [Pattern(Constants.VersionStringRegex)]
    public string Version { get; internal set; } = "1.0";

    [YamlIgnore]
    public int InternalValue {get; internal set; }
}
```

## Supported Attributes

### Title
`[Title(string title)]` - provides a short intro for classes (objects) and properties.

### Description
`[Description(string description)]` - is a more lengthy description of the purpose and usage of the class or property.

### Pattern
`[Pattern(string pattern)]` - specifies a regular expression that describes allowed values for a property.

### Required
`[Required]` - is used on properties to indicate that they are - you've guessed it - 'required'.

### AdditionalProperties
`[AdditionalProperties(bool isAllowed)]` - specifies whether a YAML can containe properties not specified in the class.

### GenerateJsonSchema
`[GenerateJsonSchema(string filePrefix)]` - indicates if the schema for this class should be stored in it's own file. `filePrefix` defaults to camel cased class name and is optional.

### IfEquals
`IfEquals(string propertyName, object value)` - conditionally includes a schema based on the value of another property.

### AllowVariable
`[AllowVariable]` - specifies that the value in the YAML file can either contain a constant, or may also contain a special YAML variable like `${{ env.path }}` to specify the `PATH` value in the running environment.

### Ignore
`[Ignore]` - indicates that a property should be ignored and not contained in the schema or validation. Typically used for helper properties. `[YamlIgnore]` from the YamDotnet library is also honoured and behaves the same.

### ExistInCollection
`[ExistInCollection(params string[] propertyPathAndKey)]` - is used to validate that a value on a property is contained in a key of a collection (or list) of objects. The last string in the parameter list indicates the key, whilst the path from the root is specified first. Eg. `[ExistsInCollection("Solution","Domain","Entities","Name")]` scans all objects defined in the path Solution.Domain.Entities and ensures it contains an object with key 'Name' that has a matching value.

### UniqueItemProperties
`[UniqueItemProperties(params string[] propertyKeys)]` - ensures that a list or collection contains unique entries based on one or more keys. Typically used with a single key like "Name" or "Id" but multiple keys can be defined and their concatenation must then be unique across items.

### UniqueChildProperty
`[UniqueChildProperty(string propertyKey)]` - ensures that all objects or collections/lists of objects contained in this class are unique for a key if it is contained in those objects. For example `[UniqueChildProperty("Id")]` will ensure that the key named `id` (note the camelCase conversion) is unique for all child objects and collections of objects.

# Multi-file YAML

Nox.YAML supports the organization of YAML definitions in multiple files using the `$ref` keyword. This work for both objects, or objects in an array/list. The file is specified relative to the main file folder.

``` yaml
# main.yaml

author: Douglas Adams

genre: Sci-Fi

lastKnownAddress:
  $ref: ./address.yaml

books:
  - $ref: ./books/thgttg.yaml
  - $ref: ./books/trateotu.yaml
  - $ref: ./books/ltuae.yaml
  - $ref: ./books/slatfatf.yaml
  - $ref: ./books/mh.yaml
  - $ref: ./books/aat.yaml 
```

and then defining the address in a new file

``` yaml
# address.yaml

street: Arlington Ave
number: 29 
city: London
postCode: N1 7BE
country: United Kingdom
```

and the books collection as

``` yaml
# ./books/thgttg.yaml
name: The Hitchhiker's Guide to the Galaxy
year: 1979
```
``` yaml
# ./books/trateotu.yaml
name: The Restaurant at the End of the Universe
year: 1980
```
``` yaml
# ./books/ltuae.yaml
name: Life, the Universe and Everything
year: 1982
```
``` yaml
# ./books/slatfatf.yaml
name: So Long, and Thanks for All the Fish
year: 1984
```
``` yaml
# ./books/mh.yaml
name: Mostly Harmless
year: 1992
```
``` yaml
# ./books/aat.yaml 
name: And Another Thing…
year: 2009    
```