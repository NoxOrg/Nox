using Nox.Solution.Constants;
using Nox.Types.Schema;
using System;
using System.Collections.Generic;
using Nox.Solution.Validation;
using Nox.Types;
using Nox.Types.Extensions;
using System.Collections.Concurrent;
using System.Linq;
using YamlDotNet.Serialization;
using FluentValidation;

namespace Nox.Solution;

[GenerateJsonSchema("solution")]
[Title("Fully describes a NOX solution")]
[Description("Contains all configuration, domain objects and infrastructure declarations that defines a NOX solution. See https://noxorg.dev for more.")]
[AdditionalProperties(false)]
public class NoxSolution
{
    private string _platformId = null!;

    [Required]
    [Title("The short name for the solution. Contains no spaces.")]
    [Description("The name of the NOX solution, application or service. This value is used extensively by the NOX tooling and libraries and should ideally be unique within an organisation.")]
    [Pattern(RegexConstants.SolutionNamePattern)]
    public string Name { get; set; } = null!;

    [Title("Platform Identifier. Used to build a unique Uri.")]
    [Description("Identify a Platform, that is a set of different services. Use to produce a unique Uri, by encoding the provided value.")]
    public string PlatformId
    {
        get => _platformId ?? Name;
        internal set => _platformId = value;
    }

    [Title("The version of the NOX solution. Expected a Semantic Version format.")]
    [Description("Required, but if not defined default 1.0.")]
    [Pattern(RegexConstants.SolutionVersionPattern)]
    public string Version { get; internal set; } = "1.0";

    [Title("A short description of the NOX solution.")]
    [Description("A brief description of the solution with what it's purpose or goals are.")]
    public string? Description { get; internal set; }

    [Title("URL to the documentation or specification of the solution.")]
    [Description("A URL which contains the requirements, documentation or specification for this solution.")]
    public Uri? Overview { get; internal set; }

    [Title("The environment variables used in your solution and default values.")]
    [Description("A key/value pair of environment variables used in your solution and their defaults.")]
    public IReadOnlyDictionary<string, string>? Variables { get; internal set; }

    [Title("Definitions for run-time environments.")]
    [Description("Definitions for the name, production status and other pertinent information pertaining to run-time environments.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<Environment>? Environments { get; internal set; }

    public VersionControl? VersionControl { get; internal set; }

    [Title("Information about the team working on this solution.")]
    [Description("Specify the members of the team working on the solution including their respective roles.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<TeamMember>? Team { get; internal set; }

    public Domain? Domain { get; internal set; }

    public Infrastructure Infrastructure { get; internal set; } = new();

    public Application? Application { get; internal set; } = new Application();

    internal void ApplyDefaults()
    {
        Infrastructure!.ApplyDefaults(Version);
    }

    [YamlIgnore]
    public string? RootYamlFile { get; internal set; }

    [YamlIgnore]
    public string? RawYamlContent { get; internal set; }

    // The dictionary value contains the parent entity
    private ConcurrentDictionary<string, Entity> _ownedEntities = null!;

    internal void Validate()
    {
        var validator = new SolutionValidator();
        validator.ValidateAndThrow(this);
    }

    internal bool IsOwnedEntity(Entity entity)
    {
        // Cannot rely on constructor in this scenario as
        // constructor execution during deserialization doesn't contain a Domain set
        if (_ownedEntities == null)
        {
            InitOwnedEntitiesList();
        }

        return _ownedEntities!.ContainsKey(entity.Name);
    }

    internal Entity? GetEntityOwner(Entity entity)
    {
        // Cannot rely on constructor in this scenario as
        // constructor execution during deserialization doesn't contain a Domain set
        if (_ownedEntities == null)
        {
            InitOwnedEntitiesList();
        }

        if (_ownedEntities != null && _ownedEntities.TryGetValue(entity.Name, out var result))
        {
            return result;
        }

        return null;
    }
    private void InitOwnedEntitiesList()
    {
        if (Domain == null)
        {
            return;
        }

        lock (this)
        {
            if (_ownedEntities is null)
            {
                _ownedEntities = new();

                foreach (var entity in Domain.Entities)
                {
                    if (entity.OwnedRelationships is null) continue;
                    foreach (var relationship in entity.OwnedRelationships)
                    {
                        _ownedEntities.TryAdd(relationship.Entity, entity);
                    }
                }
            }
        }
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