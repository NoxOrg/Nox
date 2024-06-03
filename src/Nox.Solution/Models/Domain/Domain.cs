using Nox.Types;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Information about the domain including entities and their relationships")]
[Description("Contains definitions of entities, their attributes, events, commands and queries.")]
[AdditionalProperties(false)]
public class Domain : YamlConfigNode<NoxSolution, NoxSolution>
{
    [Required]
    [Title("The entities that describe the domain.")]
    [Description("The collection of entities and their relationships with each other.")]
    [UniqueItemProperties(nameof(Entity.Name))]
    [AdditionalProperties(false)]
    public IReadOnlyList<Entity> Entities { get; internal set; } = Array.Empty<Entity>();

    public Entity GetEntityByName(string entityName) => _entitiesByName![entityName];

    public Entity? GetEntityByTableName(string tableName) => Entities.FirstOrDefault(e => e.Persistence.TableName!.Equals(tableName, StringComparison.OrdinalIgnoreCase));
    
    private Dictionary<string, Entity>? _entitiesByName;

    public override void Initialize(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        _entitiesByName = Entities.ToDictionary(e => e.Name, e => e);
    }

    public override ValidationResult Validate(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        ValidateUniqueReferenceNumberPrefixForAllEntitites(result);

        ValidateOnlyOneAutoNumberPerEntityForSqlLite(topNode, result);

        return result;
    }

    private void ValidateOnlyOneAutoNumberPerEntityForSqlLite(NoxSolution topNode, ValidationResult result)
    {
        if (topNode.Infrastructure.Persistence?.DatabaseServer.Provider != DatabaseServerProvider.SqLite)
            return;

        foreach (var e in Entities)
        {
            if (e.Attributes.Union(e.Keys).Count(a => a.Type == NoxType.AutoNumber) > 1)
            {
                result.Errors.Add(new ValidationFailure(
                    e.Name,
                    $"SQLite only supports one AutoNumber per entity. Please check attributes/keys in entity [{e.Name}]."
                ));
            }
        }
    }
    private void ValidateUniqueReferenceNumberPrefixForAllEntitites(ValidationResult result)
    {
        HashSet<string> usedPrefixs = new HashSet<string>();

        foreach (var e in Entities)
        {
            var referenceNumbers = e.Attributes.Union(e.Keys).Where(a => a.Type == NoxType.ReferenceNumber).ToArray();
            
            foreach (var referenceNumber in referenceNumbers)
            {
                //The user may not set it, this will produce other Validation issue, ignore it
                if(referenceNumber.ReferenceNumberTypeOptions!.Prefix is null)
                {
                    continue;
                }
                //Remove all empty spaces and so "Ref -" is equal to "Ref-"
                var prefixNoWhiteSpaces = string.Concat(referenceNumber.ReferenceNumberTypeOptions!.Prefix.Where(c => !char.IsWhiteSpace(c)));

                if (usedPrefixs.Contains(prefixNoWhiteSpaces))
                {
                    result.Errors.Add(new ValidationFailure(
                        e.Name,
                        $"Reference Number type must have a unique Prefix. Prefix [{referenceNumber.ReferenceNumberTypeOptions!.Prefix}] is duplicated."
                    ));
                }
                else
                    usedPrefixs.Add(prefixNoWhiteSpaces);
            }
        }
    }
}