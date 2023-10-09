{{- func memberType(member)
   ret IsNoxTypeSimpleType member.Type ? (SinglePrimitiveTypeForKey member) : (member.Type + "Dto")
end -}}﻿
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

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/{{solution.Name}}
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|{{solution.PlatformId}}.{{solution.Name}}.{{entity.Name}}.v{{solution.Version}}.{{entity.Name}}Created
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/schemas/{{solution.Name}}/{{entity.Name}}/v{{solution.Version}}/{{entity.Name}}Created.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/{{solution.Name}}
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|{{solution.PlatformId}}.{{solution.Name}}.{{entity.Name}}.v{{solution.Version}}.{{entity.Name}}Updated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/schemas/{{solution.Name}}/{{entity.Name}}/v{{solution.Version}}/{{entity.Name}}Updated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/{{solution.Name}}
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|{{solution.PlatformId}}.{{solution.Name}}.{{entity.Name}}.v{{solution.Version}}.{{entity.Name}}Deleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/schemas/{{solution.Name}}/{{entity.Name}}/v{{solution.Version}}/{{entity.Name}}Deleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
{{entity.Name}}|[{{entity.Name}}](#{{entity.Name}}-Attributes)|{{entity.Description}}
{{ end }}

{{ if entity.HasIntegrationEvents }}

### `{{entity.Name}} Attributes`
Member|Type|Description
------|----|-----------
{{ for member in entity.Members -}}
{{member.Name}}|{{memberType member}}|{{member.Description}}
{{ end -}}
{{ end -}}
{{ end -}}
{{ end -}}

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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/{{solution.Name}}
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|{{solution.PlatformId}}.{{solution.Name}}.{{Trait}}.v{{solution.Version}}.{{integrationEvent.Name}}
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://{{if environment != null}}{{environment}}.{{ end }}{{solution.PlatformId}}.com/schemas/{{solution.Name}}/{{Trait}}/v{{solution.Version}}/{{integrationEvent.Name}}.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
{{ if isArray || isCollection -}}
{{nestedClassName}}|{{nestedClassName}}|{{integrationEvent.Description}}

**{{nestedClassName}} Attributes**
Attribute|Type|Description
---------|----|-----------
{{ end -}}
{{ for member in attributes -}}
{{member.Name}}|{{memberType member}}|{{member.Description}}
{{ end -}}
{{ end -}}
{{ end -}}