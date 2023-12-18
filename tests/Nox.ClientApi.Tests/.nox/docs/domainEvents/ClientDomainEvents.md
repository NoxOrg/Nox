# Domain Events for the Client entity

This document provides information about the Client Domain Events in our application.

## Events

### `ClientCreated`

**Description:**
This event is triggered when a new Client is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
StoreId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `ClientUpdated`

**Description:** 
This event is triggered when an existing Client is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
StoreId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `ClientDeleted`

**Description:**
This event is triggered when an existing Client is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
StoreId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

