# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents
{{ if entities | array.map "HasIntegrationEvents" | array.contains true }}
- [Default Integration Events](#default-integration-events)
{{- for entity in entities -}}
{{- if entity.Persistence.Create.RaiseIntegrationEvents }}
    - [{{entity.Name}}Created](#{{entity.Name}}Ccreated)
{{- end -}}{{- if entity.Persistence.Update.RaiseIntegrationEvents }}
    - [{{entity.Name}}Updated](#{{entity.Name}}Updated)
{{- end -}}{{- if entity.Persistence.Delete.RaiseIntegrationEvents }}
    - [{{entity.Name}}Deleted](#{{entity.Name}}Deleted)
{{ end -}}
{{ end -}}
{{ end -}}
{{- if customIntegrationEvents | array.size > 0 -}}
- [Custom Integration Events](#custom-integration-events)
{{- for integrationEvent in customIntegrationEvents }}
    - [{{integrationEvent.Name}}](#{{integrationEvent.Name}})
{{- end -}}
{{ end }}

{{ if entities | array.map "HasIntegrationEvents" | array.contains true }}
## Default Integration Events

{{ for entity in entities }}
{{ if entity.Persistence.Create.RaiseIntegrationEvents }}
### `{{entity.Name}}Created`

**Description:**
This event is triggered when a new {{entity.Name}} is created.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
{{entity.Name}}|[{{entity.Name}}](#{{entity.Name}}-Attributes)|{{entity.Description}}
{{ end }}{{ if entity.Persistence.Update.RaiseIntegrationEvents }}
### `{{entity.Name}}Updated`

**Description:**
This event is triggered when an existing {{entity.Name}} is updated.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
{{entity.Name}}|[{{entity.Name}}](#{{entity.Name}}-Attributes)|{{entity.Description}}
{{ end }}{{ if entity.Persistence.Delete.RaiseIntegrationEvents }}
### `{{entity.Name}}Deleted`

**Description:**
This event is triggered when an entity {{entity.Name}} is deleted.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
{{entity.Name}}|[{{entity.Name}}](#{{entity.Name}}-Attributes)|{{entity.Description}}
{{ end }}

{{ if entity.HasIntegrationEvents }}

### `{{entity.Name}} Attributes`
Member|Type|Description
------|----|-----------
{{ for member in entity.Attributes -}}
{{member.Name}}|{{member.Type}}|{{member.Description}}
{{ end -}}
{{- if entity.Persistence.IsAudited -}}
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
{{ end }}
{{ end }}
{{ end }}
{{ end }}


{{ if customIntegrationEvents | array.size > 0 }}
## Custom Integration Events
{{for integrationEvent in customIntegrationEvents }}
{{- if integrationEvent.ArrayTypeOptions -}}
{{ isArray = true -}}
{{ nestedClassName = integrationEvent.ArrayTypeOptions.Name -}}
{{ attributes = integrationEvent.ArrayTypeOptions.ObjectTypeOptions.Attributes -}}
{{- else if integrationEvent.CollectionTypeOptions -}}
{{ isCollection = true -}}
{{ nestedClassName = integrationEvent.CollectionTypeOptions.Name -}}
{{ attributes = integrationEvent.CollectionTypeOptions.ObjectTypeOptions.Attributes -}}
{{- else if integrationEvent.ObjectTypeOptions -}}
{{ isObject = true -}}
{{ attributes = integrationEvent.ObjectTypeOptions.Attributes -}}
{{ end }}



### `{{integrationEvent.Name}}`

**Description:**
{{integrationEvent.Description}}

**Topic:** Custom

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
{{ if isArray || isCollection -}}
{{nestedClassName}}|{{nestedClassName}}|{{integrationEvent.Description}}

**{{nestedClassName}} Attributes**
Attribute|Type|Description
---------|----|-----------
{{ end -}}
{{ for attribute in attributes -}}
{{attribute.Name}}|{{attribute.Type}}|{{attribute.Description}}
{{ end -}}
{{ end -}}
{{ end -}}