# Domain Events for the WorkplaceAddress entity

This document provides information about the WorkplaceAddress Domain Events in our application.

## Events

### `WorkplaceAddressCreated`

**Description:**
This event is triggered when a new WorkplaceAddress is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
AddressLine|Text|Address line


### `WorkplaceAddressUpdated`

**Description:** 
This event is triggered when an existing WorkplaceAddress is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
AddressLine|Text|Address line


### `WorkplaceAddressDeleted`

**Description:**
This event is triggered when an existing WorkplaceAddress is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|
AddressLine|Text|Address line

