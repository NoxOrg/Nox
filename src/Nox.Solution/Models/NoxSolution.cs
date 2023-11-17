using FluentValidation;
using Nox.Solution.Validation;
using Nox.Types;
using Nox.Types.Extensions;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema("solution")]
[Title("Fully describes a NOX solution")]
[Description("Contains all configuration, domain objects and infrastructure declarations that defines a NOX solution. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
public class NoxSolution : YamlConfigNode<NoxSolution>
{
    [Required]
    [Title("The short name for the solution. Contains no spaces.")]
    [Description("The name of the NOX solution, application or service. This value is used extensively by the NOX tooling and libraries and should ideally be unique within an organisation.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string Name { get; set; } = null!;

    [Title("Platform Identifier. Used to build a unique Uri.")]
    [Description("Identify a Platform, that is a set of different services. Use to produce a unique Uri, by encoding the provided value.")]
    public string PlatformId { get; set; } = null!;


    [Title("The version of the NOX solution. Expected a Semantic Version format.")]
    [Description("Required, but if not defined default 1.0.")]
    [Pattern(Nox.Yaml.Constants.VersionStringRegex)]
    public string Version { get; internal set; } = "1.0";

    [Title("A short description of the NOX solution.")]
    [Description("A brief description of the solution with what it's purpose or goals are.")]
    public string? Description { get; internal set; }

    [Title("A short overview or description of the solution.")]
    [Description("A short overview for this solution describing the purpose and responsibility of the solution.")]
    public string? Overview { get; internal set; }

    [Title("URL to the documentation or specification of the solution.")]
    [Description("A URL which contains the requirements, documentation or specification for this solution.")]
    public Uri? DocumentationUrl { get; internal set; }

    [Title("The environment variables used in your solution and default values.")]
    [Description("A key/value pair of environment variables used in your solution and their defaults.")]

    public IReadOnlyDictionary<string, string>? Variables { get; internal set; }

    [Title("Definitions for run-time environments.")]
    [Description("Definitions for the name, production status and other pertinent information pertaining to run-time environments.")]
    [AdditionalProperties(false)]
    [UniqueItemProperties(nameof(Environment.Name))]

    public IReadOnlyList<Environment>? Environments { get; internal set; }

    public VersionControl? VersionControl { get; internal set; }

    [Title("Information about the team working on this solution.")]
    [Description("Specify the members of the team working on the solution including their respective roles.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<TeamMember>? Team { get; internal set; }

    public Domain? Domain { get; internal set; }

    public Infrastructure Infrastructure { get; internal set; } = new();

    public Application? Application { get; internal set; } = new Application();

    [YamlIgnore]
    public string? RootYamlFile { get; internal set; }

    [YamlIgnore]
    public string? RawYamlContent { get; internal set; }

    public override void SetDefaults(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        // Basic property defaulting

        Name ??= "NotSpecified";

        PlatformId ??= Name;

    }

    // Dictionary containing owned entity names and their parent entity
    private Dictionary<string, Entity> _ownedEntities = new();

    // Dictionary containing all data connections including persistence
    private Dictionary<string, DataConnection> _dataConnections = new();

    public override void Initialize(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        // build map of entity names and owners (Entity)

        _ownedEntities = Domain?.Entities
            .Where(e => e.OwnedRelationships is not null)
            .SelectMany(e => e.OwnedRelationships, (e, r) => new { Entity = e, Relationship = r })
            .GroupBy(o => o.Relationship.Entity)
            .ToDictionary(g => g.Key, g => g.ElementAt(0).Entity)
            ?? _ownedEntities;

        // Set the owner of each entity if it has one

        Domain?.Entities.ToList().ForEach(e =>
        {
            e.IsOwnedEntity = IsOwnedEntity(e);
            if (e.IsOwnedEntity)
            {
                e.OwnerEntity = GetEntityOwner(e);
            }
        });

        // Build full DataConnection list

        IEnumerable<DataConnection> dataConnections =
            Infrastructure?.Dependencies?.DataConnections
            ?? Enumerable.Empty<DataConnection>();

        if (Infrastructure?.Persistence?.DatabaseServer is not null)
        {
            var db = Infrastructure.Persistence.DatabaseServer;
            var connectionProxyForDatabase = new DataConnection
            {
                Name = db.Name,
                Options = db.Options,
                User = db.User,
                Password = db.Password,
                Port = db.Port,
                ServerUri = db.ServerUri,
                Provider = (DataConnectionProvider)Enum.Parse(typeof(DataConnectionProvider), db.Provider.ToString())
            };
            dataConnections = dataConnections.Append(connectionProxyForDatabase);
        }

        _dataConnections = dataConnections.ToDictionary(d => d.Name, d => d);

    }

    public override ValidationResult Validate(NoxSolution topNode, NoxSolution parentNode, string yamlPath)
    {
        var result = new ValidationResult();

        // Backwards compatibility, executes fluent validator
        // TODO: refactor this into the new Validate and SetDefault mechanisms
        var validator = new SolutionValidator();
        var fluentResult = validator.Validate(this);
        if (fluentResult is not null)
        {
            foreach (var error in fluentResult.Errors)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, error.ErrorMessage));
            }
        }
        // END

        return result;
    }

    internal bool HasDataConnectionWithName(string name)
        => _dataConnections.ContainsKey(name);

    internal bool IsOwnedEntity(Entity entity)
        => _ownedEntities.ContainsKey(entity.Name);

    internal Entity? GetEntityOwner(Entity entity)
    {
        if (_ownedEntities.TryGetValue(entity.Name, out var result))
        {
            return result;
        }
        return null;
    }

    /// <summary>
    /// Key Nox.Type for and Entity with single key . If NoxType is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public NoxType GetSingleKeyTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }

    /// <summary>
    /// Key Nox.Type for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public NoxType GetSingleTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if (keyDefinition.Type != NoxType.EntityId)
        {
            return keyDefinition.Type;
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityIdTypeOptions!.Entity));

        return GetSingleTypeForKey(entity.Keys![0]);
    }

    /// <summary>
    /// Key Primitive for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public string GetSinglePrimitiveTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if (keyDefinition.Type != NoxType.EntityId)
        {
            return keyDefinition.Type.GetComponents(keyDefinition).Single().Value.ToString();
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityIdTypeOptions!.Entity));

        return GetSinglePrimitiveTypeForKey(entity.Keys![0]);
    }


    /// <summary>
    /// Key Primitive type for and Entity with single key 
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public string GetSingleKeyPrimitiveTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));
        var key = entity.Keys!.Single();
        // Single, because keys cannot be compound type
        return key.Type.GetComponents(key).Single().Value.ToString();
    }
}