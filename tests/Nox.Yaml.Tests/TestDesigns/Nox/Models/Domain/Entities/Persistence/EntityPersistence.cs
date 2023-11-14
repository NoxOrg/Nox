﻿using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Specifies information on storing and retrieving the entity.")]
[Description("Provides hints to the database engine and API as to how this entity should be managed in the persistence store.")]
[AdditionalProperties(false)]
public class EntityPersistence
{
    [Title("Whether all changes to this entity is tracked for  auditing.")]
    [Description("Indicates to the storage engine that all changes to this entity must be tracked over time. Usually used to time-travel, track or audit an entity's state changes.")]
    public bool IsAudited { get; internal set; } = true;

    [Title("Table name in the database to which this entity refers to.")]
    [Description("Indicates to the storage engine which table in the database these entity persistence settings apply to.")]
    public string? TableName { get; internal set; }

    [Title("Schema name in the database to which the Table Name applies to.")]
    [Description("Indicates to the storage engine which schema in the database the entity TableName persistence settings apply to.")]
    public string Schema { get; internal set; } = "dbo";

    public EntityCreateSettings Create { get; internal set; } = new EntityCreateSettings();
    public EntityReadSettings Read { get; internal set; } = new EntityReadSettings();
    public EntityUpdateSettings Update { get; internal set; } = new EntityUpdateSettings();
    public EntityDeleteSettings Delete { get; internal set; } = new EntityDeleteSettings();

    internal bool ApplyDefaults(string entityName)
    {
        if (string.IsNullOrWhiteSpace(TableName)) TableName = entityName;
        if (string.IsNullOrWhiteSpace(Schema)) Schema = "dbo";
        return true;
    }
}

[Title("Specifies persistence behaviour related to creating the entity.")]
[Description("Provides behaviour related to the action of creating an entity, e.g. is the action enabled and whether events are raised when the action is triggered.")]
[AdditionalProperties(false)]
public class EntityCreateSettings
{
    public bool IsEnabled { get; internal set; } = true;
    public RaiseEventsType RaiseEvents { get; internal set; } = RaiseEventsType.DomainEventsOnly;

    [YamlIgnore]
    public bool RaiseDomainEvents => RaiseEvents == RaiseEventsType.DomainEventsOnly || RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;

    [YamlIgnore]
    public bool RaiseIntegrationEvents => RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;
}

[Title("Specifies persistence behaviour related to reading the entity.")]
[Description("Provides behaviour related to the action of reading an entity, e.g. is the action enabled and whether events are raised when the action is triggered.")]
[AdditionalProperties(false)]
public class EntityReadSettings
{
    public bool IsEnabled { get; internal set; } = true;
}

[Title("Specifies persistence behaviour related to updating the entity.")]
[Description("Provides behaviour related to the action of updating an entity, e.g. is the action enabled and whether events are raised when the action is triggered.")]
[AdditionalProperties(false)]
public class EntityUpdateSettings
{
    public bool IsEnabled { get; internal set; } = true;
    public RaiseEventsType RaiseEvents { get; internal set; } = RaiseEventsType.DomainEventsOnly;

    [YamlIgnore]
    public bool RaiseDomainEvents => RaiseEvents == RaiseEventsType.DomainEventsOnly || RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;

    [YamlIgnore]
    public bool RaiseIntegrationEvents => RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;
}

[Title("Specifies persistence behaviour related to deleting the entity.")]
[Description("Provides behaviour related to the action of deleting an entity, e.g. is the action enabled, whether events are raised when the action is triggered and soft deletes are used.")]
[AdditionalProperties(false)]
public class EntityDeleteSettings
{
    public bool IsEnabled { get; internal set; } = true;
    public RaiseEventsType RaiseEvents { get; internal set; } = RaiseEventsType.DomainEventsOnly;

    [YamlIgnore]
    public bool RaiseDomainEvents => RaiseEvents == RaiseEventsType.DomainEventsOnly || RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;

    [YamlIgnore]
    public bool RaiseIntegrationEvents => RaiseEvents == RaiseEventsType.DomainAndIntegrationEvents;
}