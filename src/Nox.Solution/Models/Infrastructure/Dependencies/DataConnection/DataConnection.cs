using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for a data connection pertaining to a Nox solution.")]
[Description("Configure properties pertinent to a data connection in a Nox solution here. Properties include name, serverUri, Port, connection credentials and provider.")]
[AdditionalProperties(false)]
public class DataConnection : ServerBase
{
    [Required]
    [Title("The data connection provider/format.")]
    [Description("The provider/format used for this data connection. Possible data formats include Json, Excel, CSV, XML and Parquet.")]
    [AdditionalProperties(false)]
    public DataConnectionProvider? Provider { get; internal set; }

    public override ValidationResult Validate(NoxSolution topNode, object parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        if (!IsValidUri())
        {
            result.Errors.Add(new ValidationFailure(nameof(Provider), 
                $"The data connection {Name}; must have a valid Uri specified. Valid Uri schemes are one of file, http, https or blob."));
        }

        return result;
    }

    private bool IsValidUri()
    {

        var isFileProvider = Provider switch 
        {
            DataConnectionProvider.CsvFile => true,
            DataConnectionProvider.ExcelFile => true,
            DataConnectionProvider.JsonFile => true,
            DataConnectionProvider.ParquetFile => true,
            DataConnectionProvider.XmlFile => true,
            _ => false
        };

        if (!isFileProvider) return true;

        var isValid = Uri.TryCreate(ServerUri, UriKind.Absolute, out var uri);
        
        if (!isValid) return false;
        
        return (uri!.Scheme.ToLower()) switch
        {
            "http" => true,
            "https" => true,
            "file" => true,
            "blob" => true,
            _ => false
        };
    }
}