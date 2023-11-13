# Domain Events for the Workplace entity

This document provides information about the Workplace Domain Events in our application.

## Events

### `WorkplaceCreated`

**Description:**
This event is triggered when a new Workplace is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|Workplace unique identifier
Name|Text|Workplace Name
Description|Text|Workplace Description
Greeting|Formula|The Formula
CountryId|AutoNumber|The unique identifier
TenantId|Guid|


### `WorkplaceUpdated`

**Description:** 
This event is triggered when an existing Workplace is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|Workplace unique identifier
Name|Text|Workplace Name
Description|Text|Workplace Description
Greeting|Formula|The Formula
CountryId|AutoNumber|The unique identifier
TenantId|Guid|


### `WorkplaceDeleted`

**Description:**
This event is triggered when an existing Workplace is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Nuid|Workplace unique identifier
Name|Text|Workplace Name
Description|Text|Workplace Description
Greeting|Formula|The Formula
CountryId|AutoNumber|The unique identifier
TenantId|Guid|

