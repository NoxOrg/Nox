# Domain Events for the Tenant entity

This document provides information about the Tenant Domain Events in our application.

## Events

### `TenantCreated`

**Description:**
This event is triggered when a new Tenant is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|
Name|Text|Teanant Name
Status|Enumeration|Tenant Status
TenantBrandId|AutoNumber|
WorkplaceId|AutoNumber|Workplace unique identifier


### `TenantUpdated`

**Description:** 
This event is triggered when an existing Tenant is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|
Name|Text|Teanant Name
Status|Enumeration|Tenant Status
TenantBrandId|AutoNumber|
WorkplaceId|AutoNumber|Workplace unique identifier


### `TenantDeleted`

**Description:**
This event is triggered when an existing Tenant is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|
Name|Text|Teanant Name
Status|Enumeration|Tenant Status
TenantBrandId|AutoNumber|
WorkplaceId|AutoNumber|Workplace unique identifier

