# Custom API Routes

This document provides information about custom API routes. Custom API routes are custom endpoints that are mapped to existing OData endpoints.

## Contents
{{- for apiRoute in apiRoutes}}
- [{{apiRoute.Name}}](#{{apiRoute.Name}})
{{end}}

{{- for apiRoute in apiRoutes}}
### {{apiRoute.Name}}
- **{{apiRoute.HttpVerbString}}** `{{apiRoute.Route}}`
  - Description: {{apiRoute.Description}}
{{end}}