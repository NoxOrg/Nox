{{-func pascalCaseToCamelCase(pascal)
		$result = ""
	if pascal != ""
		$first = pascal | string.slice1 0
		$first = $first | string.downcase
		$rest = pascal | string.slice 1
		$result = $first + $rest
	end

	ret $result

end-}}
// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace {{codeGenConventions.DomainNameSpace}};

public partial class {{className}} : {{className}}Base{{if entity.HasDomainEvents}}, IEntityHaveDomainEvents{{end}}
{
{{- if entity.HasDomainEvents}}
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
{{- end}}
}

{{- if entity.Persistence.Create.RaiseDomainEvents }}
/// <summary>
/// Record for {{entity.Name}} created event.
/// </summary>
public record {{entity.Name}}Created({{entity.Name}} {{entity.Name}}) :  IDomainEvent, INotification;
{{- end}}

{{- if entity.Persistence.Update.RaiseDomainEvents }}
/// <summary>
/// Record for {{entity.Name}} updated event.
/// </summary>
public record {{entity.Name}}Updated({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{- end}}

{{- if entity.Persistence.Delete.RaiseDomainEvents }}
/// <summary>
/// Record for {{entity.Name}} deleted event.
/// </summary>
public record {{entity.Name}}Deleted({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{- end}}

/// <summary>
/// {{entity.Description}}.
/// </summary>
public abstract partial class {{className}}Base{{ if !entity.IsOwnedEntity }} : {{if entity.Persistence?.IsAudited}}AuditableEntityBase, IEtag{{else}}EntityBase, IEtag{{end}}{{else}} : EntityBase, IOwnedEntity{{end}}
{
{{- for key in entityKeys }}
    /// <summary>
    /// {{key.Description | string.rstrip}}    
    /// </summary>
    /// <remarks>Required.</remarks>   
    {{ if key.Type == "EntityId" -}}
    public Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;
    {{- # Navigation Property }}

    public virtual {{key.EntityIdTypeOptions.Entity}} {{key.EntityIdTypeOptions.Entity}} { get; set; } = null!;

    {{- else if key.Type == "Nuid" -}}
	{{- prefix = key.NuidTypeOptions.Prefix | object.default entity.Name + key.NuidTypeOptions.Separator -}}
    {{- codeGeneratorNuidGetter = "Nuid.From(\""+prefix+"\" + string.Join(\""+key.NuidTypeOptions.Separator +"\", "+ (key.NuidTypeOptions.PropertyNames | array.join "," @(do; ret $0 + ".Value.ToString()"; end)) +"))" -}}
    public {{key.Type}} {{key.Name}} {get; private set; } = null!;
   
	public virtual void Ensure{{key.Name}}()
	{
		if({{key.Name}} is null)
		{
			{{key.Name}} = {{codeGeneratorNuidGetter}};
		}
		else
		{
			var currentNuid = {{codeGeneratorNuidGetter}};
			if({{key.Name}} != currentNuid)
			{
				throw new NoxNuidTypeException("Immutable nuid property {{key.Name}} value is different since it has been initialized");
			}
		}
	}
	{{- else if key.Type == "Guid" -}}
    public Nox.Types.{{key.Type}} {{key.Name}} {get; private set;} = null!;
    /// <summary>
    /// Ensures that a Guid Id is set or will be generate a new one
    /// </summary>
	public virtual void Ensure{{key.Name}}(System.Guid? guid)
	{
		if(guid is null || System.Guid.Empty.Equals(guid))
		{
			{{key.Name}} = Nox.Types.Guid.From(System.Guid.NewGuid());
		}
		else
		{
			{{key.Name}} = Nox.Types.Guid.From(guid!.Value);
		}
	}    
    {{- else if key.Type == "ReferenceNumber" -}}
    public Nox.Types.{{key.Type}} {{key.Name}} {get; private set;} = null!;
    /// <summary>
    /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
    /// </summary>
	public virtual void Ensure{{key.Name}}(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
	{
		{{key.Name}} = Nox.Types.ReferenceNumber.From(number, typeOptions);
	}
    {{- else -}}
    public Nox.Types.{{key.Type}} {{key.Name}} { get; {{if (!IsNoxTypeCreatable key.Type)}}private{{end}} set; } = null!;
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description | string.rstrip}}    
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>   
    {{ if attribute.Type == "Formula" -}}
    public {{attribute.FormulaTypeOptions.Returns}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}}
    { 
        get { return {{attribute.FormulaTypeOptions.Expression}}; }
        private set { }
    }
    {{- else if attribute.Type == "ReferenceNumber" -}}
    public Nox.Types.{{attribute.Type}} {{attribute.Name}} {get; private set;} = null!;
    /// <summary>
    /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
    /// </summary>
	public virtual void Ensure{{attribute.Name}}(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
	{
		{{attribute.Name}} = Nox.Types.ReferenceNumber.From(number, typeOptions);
	}    
    {{- else -}}
    public Nox.Types.{{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; {{if (!IsNoxTypeCreatable attribute.Type)}}private{{end}} set; } = null!;
    {{- end}}
{{- end }}
{{-if entity.HasDomainEvents}}

	{{- pascalEntityName = entity.Name | pascalCaseToCamelCase }}
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent({{entity.Name}} {{pascalEntityName}})
	{
	{{- if entity.Persistence.Create.RaiseDomainEvents }}
		InternalDomainEvents.Add(new {{entity.Name}}Created({{pascalEntityName}}));     
	{{- end }}
    }
	
	protected virtual void InternalRaiseUpdateEvent({{entity.Name}} {{pascalEntityName}})
	{
	{{- if entity.Persistence.Update.RaiseDomainEvents }}
		InternalDomainEvents.Add(new {{entity.Name}}Updated({{pascalEntityName}}));
    {{- end }}
    }
	
	protected virtual void InternalRaiseDeleteEvent({{entity.Name}} {{pascalEntityName}})
	{
	{{- if entity.Persistence.Delete.RaiseDomainEvents }}
		InternalDomainEvents.Add(new {{entity.Name}}Deleted({{pascalEntityName}})); 
	{{- end }}
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }
{{- end}}
{{- ######################################### Relationships ###################################################### -}}
{{- for relationship in entity.Relationships }}
    {{- navigationName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{navigationName}} { get; private set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{navigationName}} { get; private set; } = null!;
    {{- if relationship.IsForeignKeyOnThisSide}}

    /// <summary>
    /// Foreign key for relationship {{relationship.Relationship}} to entity {{relationship.Entity}}
    /// </summary>
    public Nox.Types.{{relationship.Related.Entity.Keys[0].Type}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{navigationName}}Id { get; set; } = null!;
    {{- end}}
    {{-end}}

    public virtual void CreateRefTo{{navigationName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}
        {{navigationName}} = related{{relationship.Entity}};
        {{- else}}
        {{navigationName}}.Add(related{{relationship.Entity}});
        {{- end }}
    }

    {{- if relationship.WithMultiEntity }}

    public virtual void UpdateRefTo{{navigationName}}(List<{{relationship.Entity}}> related{{relationship.Entity}})
    {
        {{- if relationship.Relationship == "OneOrMany" }}
        if(!related{{relationship.Entity}}.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        {{- end }}
        {{navigationName}}.Clear();
        {{navigationName}}.AddRange(related{{relationship.Entity}});
    }
    {{- end }}

    public virtual void DeleteRefTo{{navigationName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}

        {{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- else }}
        {{navigationName}} = null;
        {{- end }}

        {{- else}}

        {{- if relationship.Relationship == "OneOrMany" }}
        if({{navigationName}}.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- end }}
        {{navigationName}}.Remove(related{{relationship.Entity}});

        {{- end }}
    }

    public virtual void DeleteAllRefTo{{navigationName}}()
    {
        {{- if relationship.WithSingleEntity }}

        {{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- else }}
        {{- if relationship.IsForeignKeyOnThisSide }}
        {{navigationName}}Id = null;
        {{- else }}
        {{navigationName}} = null;
        {{- end }}
        {{- end }}

        {{- else}}

        {{- if relationship.Relationship == "OneOrMany" }}
        if({{navigationName}}.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- end }}
        {{navigationName}}.Clear();

        {{- end }}
    }
{{- end }}

{{- ######################################### Owned Relationships ###################################################### -}}

{{- for relationship in entity.OwnedRelationships }}
    {{- navigationName = GetNavigationPropertyName entity relationship }}﻿

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{navigationName}} { get; private set; } = new();
	{{- else}}
    public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{navigationName}} { get; private set; }{{if relationship.Relationship == "ExactlyOne"}} = null!;{{end}}
    {{- end }}
    
    /// <summary>
    /// Creates a new {{relationship.Entity}} entity.
    /// </summary>
    public virtual void CreateRefTo{{navigationName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}
        {{navigationName}} = related{{relationship.Entity}};
        {{- else}}
        {{navigationName}}.Add(related{{relationship.Entity}});
        {{- end }}
    }

    {{- if relationship.WithMultiEntity }}
    
    /// <summary>
    /// Updates all owned {{relationship.Entity}} entities.
    /// </summary>
    public virtual void UpdateRefTo{{navigationName}}(List<{{relationship.Entity}}> related{{relationship.Entity}})
    {
        {{- if relationship.Relationship == "OneOrMany" }}
        if(!related{{relationship.Entity}}.HasAtLeastOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        {{- end }}
        {{navigationName}}.Clear();
        {{navigationName}}.AddRange(related{{relationship.Entity}});
    }
    {{- end }}
    
    /// <summary>
    /// Deletes owned {{relationship.Entity}} entity.
    /// </summary>
    public virtual void DeleteRefTo{{navigationName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}

			{{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- else }}
        {{navigationName}} = null;
			{{- end }}

        {{- else}}

			{{- if relationship.Relationship == "OneOrMany" }}
        if({{navigationName}}.HasExactlyOneItem())
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- end }}
        {{navigationName}}.Remove(related{{relationship.Entity}});

        {{- end }}
    }
    
    /// <summary>
    /// Deletes all owned {{relationship.Entity}} entities.
    /// </summary>
    public virtual void DeleteAllRefTo{{navigationName}}()
    {
        {{- if relationship.Relationship == "ExactlyOne" || relationship.Relationship == "OneOrMany" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");

        {{- else if relationship.Relationship == "ZeroOrOne" }}
        {{navigationName}} = null;

        {{- else if relationship.Relationship == "ZeroOrMany" }}
        {{navigationName}}.Clear();
        {{- end }}
    }
{{-end}}

    {{ if entity.IsLocalized ~}}
    /// <summary>
    /// {{entity.Name}} localized entities.
    /// </summary>
    public virtual List<{{entity.Name}}Localized> Localized{{entity.PluralName}}  { get; private set; } = new();


	/// <summary>
	/// Creates a new {{entity.Name}}Localized entity.
	/// </summary>
    public virtual void CreateRefToLocalized{{entity.PluralName}}({{entity.Name}}Localized related{{entity.Name}}Localized)
	{
		Localized{{entity.PluralName}}.Add(related{{entity.Name}}Localized);
	}
    {{ end ~}}

{{ if !entity.IsOwnedEntity ~}}
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
{{ end ~}}
}