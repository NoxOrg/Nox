# Domain Events for the {{entity.Name}} entity

This document provides information about the {{entity.Name}} Domain Events in our application.

## Events
{{ if entity.Persistence.Create.RaiseEvents == "DomainEventsOnly" ||  entity.Persistence.Create.RaiseEvents == "DomainAndIntegrationEvents" }}
### `{{entity.Name}}Created`

**Description:**
This event is triggered when a new {{entity.Name}} is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
{{ for member in entityMembers -}}
{{member.Name}}|{{member.Type}}|{{member.Description}}
{{ end -}}
{{- if entity.Persistence.IsAudited -}}
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
{{ end }}
{{ end }}{{ if entity.Persistence.Update.RaiseEvents == "DomainEventsOnly" ||  entity.Persistence.Update.RaiseEvents == "DomainAndIntegrationEvents" }}
### `{{entity.Name}}Updated`

**Description:** 
This event is triggered when an existing {{entity.Name}} is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
{{ for member in entityMembers -}}
{{member.Name}}|{{member.Type}}|{{member.Description}}
{{ end -}}
{{- if entity.Persistence.IsAudited -}}
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
{{ end }}
{{ end }}{{ if entity.Persistence.Delete.RaiseEvents == "DomainEventsOnly" ||  entity.Persistence.Delete.RaiseEvents == "DomainAndIntegrationEvents" }}
### `{{entity.Name}}Deleted`

**Description:**
This event is triggered when an existing {{entity.Name}} is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
{{ for member in entityMembers -}}
{{member.Name}}|{{member.Type}}|{{member.Description}}
{{ end -}}
{{- if entity.Persistence.IsAudited -}}
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
{{ end }}
{{ end -}}