# Domain Events for the ReferenceNumberEntity entity

This document provides information about the ReferenceNumberEntity Domain Events in our application.

## Events

### `ReferenceNumberEntityCreated`

**Description:**
This event is triggered when a new ReferenceNumberEntity is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|ReferenceNumber|
ReferenceNumber|ReferenceNumber|ReferenceNumber
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `ReferenceNumberEntityUpdated`

**Description:** 
This event is triggered when an existing ReferenceNumberEntity is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|ReferenceNumber|
ReferenceNumber|ReferenceNumber|ReferenceNumber
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `ReferenceNumberEntityDeleted`

**Description:**
This event is triggered when an existing ReferenceNumberEntity is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|ReferenceNumber|
ReferenceNumber|ReferenceNumber|ReferenceNumber
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

