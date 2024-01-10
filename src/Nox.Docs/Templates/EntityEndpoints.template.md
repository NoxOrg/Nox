# API Endpoints for the {{entity.Name}} entity

This document provides information about the various endpoints available in our API for the {{entity.Name}} entity.

## {{entity.Name}} Endpoints
{{ if entity.Persistence.Read.IsEnabled }}
### Get {{entity.Name}} Count
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/$count`
  - Description: Retrieve the number of {{entity.PluralName}}.

### Get {{entity.Name}} by ID
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}`
  - Description: Retrieve information about a {{entity.Name}} by ID.
  
### Get {{entity.PluralName}}
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}`
  - Description: Retrieve information about {{entity.PluralName}}.
{{ end }}{{ if entity.Persistence.Create.IsEnabled }}
### Create {{entity.Name}}
- **POST** `{{apiRoutePrefix}}/{{entity.PluralName}}`
  - Description: Create a new {{entity.Name}}.
{{ end }}{{ if entity.Persistence.Update.IsEnabled }}
### Update {{entity.Name}}
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}`
  - Description: Update an existing {{entity.Name}}.

### Partially Update {{entity.Name}}
- **PATCH** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}`
  - Description: Partially update an existing {{entity.Name}}.
{{ end }}{{ if entity.Persistence.Delete.IsEnabled }} 
### Delete {{entity.Name}}
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}`
  - Description: Delete an existing {{entity.Name}}.
{{ end }}{{ if entity.OwnedRelationships | array.size > 0 }}
## Owned Relationships Endpoints
{{ for ownedRelationship in entity.OwnedRelationships }}
{{- if ownedRelationship.ApiGenerateRelatedEndpoint }}
### {{ownedRelationship.Entity}}
{{ if entity.Persistence.Read.IsEnabled && ownedRelationship.Related.Entity.Persistence.Read.IsEnabled }}
#### Get {{ownedRelationship.EntityPlural}}
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Retrieve all {{ownedRelationship.EntityPlural}} for a specific {{entity.Name}}.
{{- if ownedRelationship.WithMultiEntity }}
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Retrieve a {{ownedRelationship.Entity}} by ID for a specific {{entity.Name}}.
{{- end }}
{{ end }}
{{- if entity.Persistence.Create.IsEnabled && ownedRelationship.Related.Entity.Persistence.Create.IsEnabled }}
#### Create {{ownedRelationship.Entity}}
- **POST** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Create a new {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{ end }}{{ if entity.Persistence.Update.IsEnabled && ownedRelationship.Related.Entity.Persistence.Update.IsEnabled }}
#### Update {{ownedRelationship.Entity}}
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
  
#### Partially Update {{ownedRelationship.Entity}}
- **PATCH** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Partially update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{ end }}{{ if entity.Persistence.Delete.IsEnabled && ownedRelationship.Related.Entity.Persistence.Delete.IsEnabled }}
#### Delete {{ownedRelationship.Entity}}
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Delete an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{ end }}{{ end }}{{ end -}}
{{ end}}{{ if entity.Relationships | array.size > 0 }}
## Relationships Endpoints
{{ for relationship in entity.Relationships }}
{{- if relationship.ApiGenerateReferenceEndpoint || relationship.ApiGenerateRelatedEndpoint }}
### {{relationship.Entity}}
{{- if relationship.ApiGenerateReferenceEndpoint }}
{{ if relationship.Related.Entity.Persistence.Read.IsEnabled }}
#### Get {{relationship.Entity}} relations
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/$ref`
  - Description: Retrieve all existing {{relationship.EntityPlural}} relations for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Create.IsEnabled }}  
#### Create {{relationship.Entity}} relation
- **POST** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Create a new {{relationship.Entity}} relation for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Update.IsEnabled }}  
#### Update {{relationship.Entity}} relation
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Updates an existing {{relationship.Entity}} relation for a specific {{entity.Name}}.
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/$ref`
  - Description: Updates the {{relationship.Entity}} relations for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Delete.IsEnabled }}
#### Delete {{relationship.Entity}} relation
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Delete an existing {{relationship.Entity}} relation for a specific {{entity.Name}}.

#### Delete {{relationship.Entity}} relations
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/$ref`
  - Description: Delete all existing {{relationship.EntityPlural}} relations for a specific {{entity.Name}}.
{{ end }}{{ end -}}
{{- if relationship.ApiGenerateRelatedEndpoint -}}
{{ if relationship.Related.Entity.Persistence.Read.IsEnabled }}
#### Get {{relationship.Entity}}
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}`
  - Description: Retrieve all existing {{relationship.EntityPlural}} for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Create.IsEnabled }}  
#### Create {{relationship.Entity}}
- **POST** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}`
  - Description: Create a new {{relationship.Entity}} for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Update.IsEnabled }}  
#### Update {{relationship.Entity}}
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}`
  - Description: Updates an existing {{relationship.Entity}} for a specific {{entity.Name}}.
- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}`
  - Description: Updates the {{relationship.Entity}} for a specific {{entity.Name}}.
{{ end }}{{ if relationship.Related.Entity.Persistence.Delete.IsEnabled }}
#### Delete {{relationship.Entity}}
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}`
  - Description: Delete an existing {{relationship.Entity}} for a specific {{entity.Name}}.

#### Delete {{relationship.Entity}}
- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{relationship.Name}}`
  - Description: Delete all existing {{relationship.EntityPlural}} for a specific {{entity.Name}}.
{{- end }}{{ end }}{{ end }}{{ end }}{{ end }}
{{- if entity.Commands | array.size > 0 }}

## Custom Commands
{{ for command in entity.Commands }}
### {{command.Name}}
- **POST** `/{{command.Name}}`
  - Description: {{command.Description}}
{{- end }}{{ end }}
{{- if entity.Queries | array.size > 0 }}

## Custom Queries
{{ for query in entity.Queries }}
### {{query.Name}}
- **GET** `/{{query.Name}}`
  - Description: {{query.Description}}
{{- end }}{{ end }}
{{- if enumerationAttributes | array.size > 0 }}

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific {{entity.Name}}.
{{- for enumAtt in enumerationAttributes }}
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}`
  - **Description**: Retrieve non-conventional values of {{Pluralize (enumAtt.Attribute.Name)}} for a specific {{entity.Name}}.
{{- if enumAtt.IsLocalized }}
  
- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized`
  - **Description**: Retrieve localized values of {{Pluralize (enumAtt.Attribute.Name)}} for a specific {{entity.Name}}.

- **DELETE** `{{apiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized/{cultureCode}`
  - **Description**: Delete the localized values of {{Pluralize (enumAtt.Attribute.Name)}} for a specific culture code in {{entity.Name}}.

- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized`
  - **Description**: Update or create localized values of {{Pluralize(enumAtt.Attribute.Name)}} for a specific {{entity.Name}}. Requires a payload with the new values.
{{- end }}{{ end }}{{ end }}
{{- if entity.IsLocalized }}

## Localized Endpoints

- **GET** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{entity.PluralName}}Localized`
  - Description: Retrieve all {{entity.PluralName}}Localized for a specific {{entity.Name}}.

- **PUT** `{{apiRoutePrefix}}/{{entity.PluralName}}/{key}/{{entity.PluralName}}Localized/{cultureCode}`
    - Description: Update or create values of {{entity.Name}}Localized for a specific {{entity.Name}}. Requires a payload with the new value of {{entity.Name}}LocalizedUpsertDto.
{{- end }}
{{- if relatedEndpoints | array.size > 0 }}

## Other Related Endpoints
{{- for endpoint in relatedEndpoints}}
{{- for verb in endpoint.Item2}}

- **{{ verb | string.upcase }}** `{{apiRoutePrefix}}/{{endpoint.Item1}}`
{{- end }}{{ end }}{{ end }}
{{- if entity.Relationships | array.size > 0 }}

## Related Entities
{{ for relationship in entity.Relationships }}
[{{relationship.Entity}}]({{relationship.Entity}}Endpoints.md)
{{- end }}{{ end }}