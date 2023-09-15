# Domain Events for the LandLord entity

This document provides information about the LandLord Domain Events in our application.

## Events

### `LandLordCreated`

**Description:**
This event is triggered when a new LandLord is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Landlord unique identifier
Name|Text|Landlord name
Address|StreetAddress|Landlord's street address
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `LandLordUpdated`

**Description:** 
This event is triggered when an existing LandLord is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Landlord unique identifier
Name|Text|Landlord name
Address|StreetAddress|Landlord's street address
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `LandLordDeleted`

**Description:**
This event is triggered when an existing LandLord is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Landlord unique identifier
Name|Text|Landlord name
Address|StreetAddress|Landlord's street address
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

