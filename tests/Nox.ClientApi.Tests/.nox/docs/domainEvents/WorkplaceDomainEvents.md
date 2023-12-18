# Domain Events for the Workplace entity

This document provides information about the Workplace Domain Events in our application.

## Events

### `WorkplaceCreated`

**Description:**
This event is triggered when a new Workplace is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Workplace unique identifier
Name|Text|Workplace Name
ReferenceNumber|ReferenceNumber|Workplace Code
Description|Text|Workplace Description
Greeting|Formula|The Formula
Ownership|Enumeration|Workplace Ownership
Type|Enumeration|Workplace Type
CountryId|AutoNumber|The unique identifier
TenantId|Nuid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `WorkplaceUpdated`

**Description:** 
This event is triggered when an existing Workplace is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Workplace unique identifier
Name|Text|Workplace Name
ReferenceNumber|ReferenceNumber|Workplace Code
Description|Text|Workplace Description
Greeting|Formula|The Formula
Ownership|Enumeration|Workplace Ownership
Type|Enumeration|Workplace Type
CountryId|AutoNumber|The unique identifier
TenantId|Nuid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `WorkplaceDeleted`

**Description:**
This event is triggered when an existing Workplace is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Workplace unique identifier
Name|Text|Workplace Name
ReferenceNumber|ReferenceNumber|Workplace Code
Description|Text|Workplace Description
Greeting|Formula|The Formula
Ownership|Enumeration|Workplace Ownership
Type|Enumeration|Workplace Type
CountryId|AutoNumber|The unique identifier
TenantId|Nuid|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

