// Generated
{{func pascalCaseToCamelCase(pascal)
		$result = ""
	if pascal != ""
		$first = pascal | string.slice1 0
		$first = $first | string.downcase
		$rest = pascal | string.slice 1
		$result = $first + $rest
	end

	ret $result

end}}
#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.DomainNameSpace}};

internal partial class {{className}} : {{className}}Base{{if entity.HasDomainEvents}}, IEntityHaveDomainEvents{{end}}
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
internal record {{entity.Name}}Created({{entity.Name}} {{entity.Name}}) :  IDomainEvent, INotification;
{{- end}}

{{- if entity.Persistence.Update.RaiseDomainEvents }}
/// <summary>
/// Record for {{entity.Name}} updated event.
/// </summary>
internal record {{entity.Name}}Updated({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{- end}}

{{- if entity.Persistence.Delete.RaiseDomainEvents }}
/// <summary>
/// Record for {{entity.Name}} deleted event.
/// </summary>
internal record {{entity.Name}}Deleted({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{- end}}

/// <summary>
/// {{entity.Description}}.
/// </summary>
internal abstract partial class {{className}}Base{{ if !entity.IsOwnedEntity }} : {{if entity.Persistence?.IsAudited}}AuditableEntityBase, IEntityConcurrent{{else}}EntityBase, IEntityConcurrent{{end}}{{else}} : EntityBase, IOwnedEntity{{end}}
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description | string.rstrip}}
    /// <remarks>Required.</remarks>   
    /// </summary>
    {{ if key.Type == "EntityId" -}}
    public Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;
    {{- # Navigation Property }}

    public virtual {{key.EntityIdTypeOptions.Entity}} {{key.EntityIdTypeOptions.Entity}} { get; set; } = null!;

    {{- else if key.Type == "Nuid" -}}
	{{- prefix = key.NuidTypeOptions.Prefix | object.default entity.Name + key.NuidTypeOptions.Separator -}}
    {{- codeGeneratorNuidGetter = "Nuid.From(\""+prefix+"\" + string.Join(\""+key.NuidTypeOptions.Separator +"\", "+ (key.NuidTypeOptions.PropertyNames | array.join "," @(do; ret $0 + ".Value.ToString()"; end)) +"))" -}}
    public {{key.Type}} {{key.Name}} {get; set;} = null!;
   
	public virtual void Ensure{{ key.Name}}()
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
    public Nox.Types.{{key.Type}} {{key.Name}} {get; set;} = null!;
     /// <summary>
    /// Ensures that a Guid Id is set or will be generate a new one
    /// </summary>
	public virtual void Ensure{{ key.Name}}(System.Guid guid)
	{
		if(System.Guid.Empty.Equals(guid))
		{
			{{key.Name}} = Nox.Types.Guid.From(System.Guid.NewGuid());
		}
		else
		{
			{{key.Name}} = Nox.Types.Guid.From(guid);
		}
	}
    {{- else -}}

    public Nox.Types.{{key.Type}} {{key.Name}} { get; set; } = null!;
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description | string.rstrip}}
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>   
    /// </summary>
    {{ if attribute.Type == "Formula" -}}
    public {{attribute.FormulaTypeOptions.Returns}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}}
{ 
    get { return {{attribute.FormulaTypeOptions.Expression}}; }
    private set { }
}
    {{- else -}}
    public Nox.Types.{{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
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
    {{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationshipName}} { get; private set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}} { get; private set; } = null!;
    {{- if relationship.ShouldGenerateForeignOnThisSide}}

    /// <summary>
    /// Foreign key for relationship {{relationship.Relationship}} to entity {{relationship.Entity}}
    /// </summary>
    public Nox.Types.{{relationship.Related.Entity.Keys[0].Type}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}}Id { get; set; } = null!;
    {{- end}}
    {{-end}}

    public virtual void CreateRefTo{{relationshipName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}
        {{relationshipName}} = related{{relationship.Entity}};
        {{- else}}
        {{relationshipName}}.Add(related{{relationship.Entity}});
        {{- end }}
    }

    {{- if relationship.WithMultiEntity }}

    public virtual void UpdateRefTo{{relationshipName}}(List<{{relationship.Entity}}> related{{relationship.Entity}})
    {
        {{- if relationship.Relationship == "OneOrMany" }}
        if(related{{relationship.Entity}} is null || related{{relationship.Entity}}.Count < 2)
            throw new RelationshipDeletionException($"The relationship cannot be updated.");
        {{- end }}
        {{relationshipName}}.Clear();
        {{relationshipName}}.AddRange(related{{relationship.Entity}});
    }
    {{- end }}

    public virtual void DeleteRefTo{{relationshipName}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}

        {{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- else }}
        {{relationshipName}} = null;
        {{- end }}

        {{- else}}

        {{- if relationship.Relationship == "OneOrMany" }}
        if({{relationshipName}}.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- end }}
        {{relationshipName}}.Remove(related{{relationship.Entity}});

        {{- end }}
    }

    public virtual void DeleteAllRefTo{{relationshipName}}()
    {
        {{- if relationship.WithSingleEntity }}

        {{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- else }}
        {{- if relationship.ShouldGenerateForeignOnThisSide }}
        {{relationshipName}}Id = null;
        {{- else }}
        {{relationshipName}} = null;
        {{- end }}
        {{- end }}

        {{- else}}

        {{- if relationship.Relationship == "OneOrMany" }}
        if({{relationshipName}}.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
        {{- end }}
        {{relationshipName}}.Clear();

        {{- end }}
    }
{{- end }}

{{- ######################################### Owned Relationships ###################################################### -}}

{{- for relationship in entity.OwnedRelationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationship.Name}} { get; private set; } = new();
	{{- else}}
    public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}} { get; private set; }{{if relationship.Relationship == "ExactlyOne"}} = null!;{{end}}
    {{- end }}
    
    /// <summary>
    /// Creates a new {{relationship.Entity}} entity.
    /// </summary>
    public virtual void CreateRefTo{{relationship.Name}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}
        {{relationship.Name}} = related{{relationship.Entity}};
        {{- else}}
        {{relationship.Name}}.Add(related{{relationship.Entity}});
        {{- end }}
    }
    
    /// <summary>
    /// Deletes owned {{relationship.Entity}} entity.
    /// </summary>
    public virtual void DeleteRefTo{{relationship.Name}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}

			{{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- else }}
        {{relationship.Name}} = null;
			{{- end }}

        {{- else}}

			{{- if relationship.Relationship == "OneOrMany" }}
        if({{relationship.Name}}.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- end }}
        {{relationship.Name}}.Remove(related{{relationship.Entity}});

        {{- end }}
    }
    
    /// <summary>
    /// Deletes all owned {{relationship.Entity}} entities.
    /// </summary>
    public virtual void DeleteAllRefTo{{relationship.Name}}()
    {
        {{- if relationship.WithSingleEntity }}

			{{- if relationship.Relationship == "ExactlyOne" }}
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- else }}
        {{relationship.Name}} = null;
			{{- end }}

        {{- else}}

			{{- if relationship.Relationship == "OneOrMany" }}
        if({{relationship.Name}}.Count() < 2)
            throw new RelationshipDeletionException($"The relationship cannot be deleted.");
			{{- end }}
        {{relationship.Name}}.Clear();

        {{- end }}
    }
{{-end}}

{{ if !entity.IsOwnedEntity ~}}
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
{{ end ~}}
}