# API Endpoints for the {{entity.Name}} entity

This document provides information about the various endpoints available in our API for the {{entity.Name}} entity.

## {{entity.Name}} Endpoints
{{ if entity.Persistence.Read.IsEnabled }}
### Get {{entity.Name}} by ID
- **GET** `/api/{{entity.PluralName}}/{key}`
  - Description: Retrieve information about a {{entity.Name}} by ID.
  
### Get {{entity.PluralName}}
- **GET** `/api/{{entity.PluralName}}`
  - Description: Retrieve information about {{entity.PluralName}}.
{{ end }}{{ if entity.Persistence.Create.IsEnabled }}
### Create {{entity.Name}}
- **POST** `/api/{{entity.PluralName}}`
  - Description: Create a new {{entity.Name}} with the provided data.
{{ end }}{{ if entity.Persistence.Update.IsEnabled }}
### Update {{entity.Name}}
- **PUT** `/api/{{entity.PluralName}}/{key}`
  - Description: Update an existing {{entity.Name}} by ID with the provided data.
{{ end }}{{ if entity.Persistence.Delete.IsEnabled }} 
### Delete {{entity.Name}}
- **DELETE** `/api/{{entity.PluralName}}/{key}`
  - Description: Delete an existing {{entity.Name}} by its ID.
{{ end }}{{ if entity.OwnedRelationships | array.size > 0 }}
## Owned Relationships Endpoints
{{ for ownedRelationship in entity.OwnedRelationships }}
### {{ownedRelationship.Entity}}

#### Get {{ownedRelationship.EntityPlural}}
- **GET** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Retrieve all {{ownedRelationship.EntityPlural}} for a specific {{entity.Name}}.
  
#### Create {{ownedRelationship.Entity}}
- **POST** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Create a new {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
  
#### Update {{ownedRelationship.Entity}}
- **PUT** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
  
#### Partially Update {{ownedRelationship.Entity}}
- **PATCH** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Partially update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.

#### Delete {{ownedRelationship.Entity}}
- **DELETE** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Delete an existing {{ownedRelationship.Entity}} by its ID for a specific {{entity.Name}}.
{{ end -}}
{{ end}}{{ if entity.Relationships | array.size > 0 }}
## Relationships Endpoints
{{ for relationship in entity.Relationships }}
[{{relationship.Entity}} Endpoints]({{relationship.Entity}}Endpoints.md)
{{ end -}}
{{ end }}{{ if entity.Commands | array.size > 0 }}
## Custom Commands
{{ for command in entity.Commands }}
### {{command.Name}}
- **POST** `/{{command.Name}}`
  - Description: {{command.Description}}
{{ end -}}
{{ end}}{{ if entity.Queries | array.size > 0 }}
## Custom Queries
{{ for query in entity.Queries }}
### {{query.Name}}
- **GET** `/{{query.Name}}`
  - Description: {{query.Description}}
{{ end -}}
{{ end -}}