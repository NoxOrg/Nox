# Domain Events for the Store entity

This document provides information about the Store Domain Events in our application.

## Events

### `StoreCreated`

**Description:**
This event is triggered when a new Store is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
Address|StreetAddress|Street Address
Location|LatLong|Location
OpeningDay|DateTime|Opening day
Status|Enumeration|Store Status
StoreOwnerId|Text|
ClientId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreUpdated`

**Description:** 
This event is triggered when an existing Store is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
Address|StreetAddress|Street Address
Location|LatLong|Location
OpeningDay|DateTime|Opening day
Status|Enumeration|Store Status
StoreOwnerId|Text|
ClientId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreDeleted`

**Description:**
This event is triggered when an existing Store is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
Name|Text|Store Name
Address|StreetAddress|Street Address
Location|LatLong|Location
OpeningDay|DateTime|Opening day
Status|Enumeration|Store Status
StoreOwnerId|Text|
ClientId|Guid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

