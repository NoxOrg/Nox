# API Endpoints for the {{entity.Name}} entity

This document provides information about the various endpoints available in our API for the {{entity.Name}} entity.

## {{entity.Name}} Endpoints
{{if entity.Persistence.Read.IsEnabled}}
### Get {{entity.Name}} by ID
- **GET** `/api/{{entity.PluralName}}/{key}`
  - Description: Retrieve information about a {{entity.Name}} by ID.
  
### Get {{entity.PluralName}}
- **GET** `/api/{{entity.PluralName}}`
  - Description: Retrieve information about {{entity.PluralName}}.
{{end}}{{if entity.Persistence.Create.IsEnabled}}
### Create {{entity.Name}}
- **POST** `/api/{{entity.PluralName}}`
  - Description: Create a new {{entity.Name}}.
{{end}}{{if entity.Persistence.Update.IsEnabled}}
### Update {{entity.Name}}
- **PUT** `/api/{{entity.PluralName}}/{key}`
  - Description: Update an existing {{entity.Name}}.

### Partially Update {{entity.Name}}
- **PATCH** `/api/{{entity.PluralName}}/{key}`
  - Description: Partially update an existing {{entity.Name}}.
{{end}}{{if entity.Persistence.Delete.IsEnabled}} 
### Delete {{entity.Name}}
- **DELETE** `/api/{{entity.PluralName}}/{key}`
  - Description: Delete an existing {{entity.Name}}.
{{end}}{{if entity.OwnedRelationships|array.size>0}}
## Owned Relationships Endpoints
{{for ownedRelationship in entity.OwnedRelationships}}
### {{ownedRelationship.Entity}}
{{if entity.Persistence.Read.IsEnabled&&ownedRelationship.Related.Entity.Persistence.Read.IsEnabled}}
#### Get {{ownedRelationship.EntityPlural}}
- **GET** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}`
  - Description: Retrieve all {{ownedRelationship.EntityPlural}} for a specific {{entity.Name}}.
{{end}}{{if entity.Persistence.Create.IsEnabled&&ownedRelationship.Related.Entity.Persistence.Create.IsEnabled}}
#### Create {{ownedRelationship.Entity}}
- **POST** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Create a new {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{end}}{{if entity.Persistence.Update.IsEnabled&&ownedRelationship.Related.Entity.Persistence.Update.IsEnabled}}
#### Update {{ownedRelationship.Entity}}
- **PUT** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
  
#### Partially Update {{ownedRelationship.Entity}}
- **PATCH** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Partially update an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{end}}{{if entity.Persistence.Delete.IsEnabled&&ownedRelationship.Related.Entity.Persistence.Delete.IsEnabled}}
#### Delete {{ownedRelationship.Entity}}
- **DELETE** `/api/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}`
  - Description: Delete an existing {{ownedRelationship.Entity}} for a specific {{entity.Name}}.
{{end}}{{end-}}{{end}}{{if entity.Relationships|array.size>0}}
## Relationships Endpoints
{{for relationship in entity.Relationships}}
### {{relationship.Entity}}
{{if relationship.Related.Entity.Persistence.Read.IsEnabled}}
#### Get {{relationship.Entity}} relations
- **GET** `/api/{{entity.PluralName}}/{key}/{{relationship.Name}}/$ref`
  - Description: Retrieve all existing {{relationship.EntityPlural}} relations for a specific {{entity.Name}}.
{{end}}{{if relationship.Related.Entity.Persistence.Create.IsEnabled}}  
#### Create {{relationship.Entity}} relation
- **POST** `/api/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Create a new {{relationship.Entity}} relation for a specific {{entity.Name}}.
{{end}}{{if relationship.Related.Entity.Persistence.Update.IsEnabled}}  
#### Update {{relationship.Entity}} relation
- **PUT** `/api/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Updates an existing {{relationship.Entity}} relation for a specific {{entity.Name}}.
{{end}}{{if relationship.Related.Entity.Persistence.Delete.IsEnabled}}
#### Delete {{relationship.Entity}} relation
- **DELETE** `/api/{{entity.PluralName}}/{key}/{{relationship.Name}}/{relatedKey}/$ref`
  - Description: Delete an existing {{relationship.Entity}} relation for a specific {{entity.Name}}.

#### Delete {{relationship.Entity}} relations
- **DELETE** `/api/{{entity.PluralName}}/{key}/{{relationship.Name}}/$ref`
  - Description: Delete all existing {{relationship.EntityPlural}} relations for a specific {{entity.Name}}.
{{end}}{{end-}}{{end}}{{if entity.Commands|array.size>0}}
## Custom Commands
{{for command in entity.Commands}}
### {{command.Name}}
- **POST** `/{{command.Name}}`
  - Description: {{command.Description}}
{{end-}}{{end}}{{if entity.Queries|array.size>0}}
## Custom Queries
{{for query in entity.Queries}}
### {{query.Name}}
- **GET** `/{{query.Name}}`
  - Description: {{query.Description}}
{{end-}}{{end}}{{if entity.Relationships|array.size>0}}
## Related Entities
{{for relationship in entity.Relationships}}
[{{relationship.Entity}}]({{relationship.Entity}}Endpoints.md)
{{end-}}{{end-}}