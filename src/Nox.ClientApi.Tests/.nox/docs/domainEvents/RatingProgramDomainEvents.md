# Domain Events for the RatingProgram entity

This document provides information about the RatingProgram Domain Events in our application.

## Events

### `RatingProgramCreated`

**Description:**
This event is triggered when a new RatingProgram is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Name|Text|Rating Program Name


### `RatingProgramUpdated`

**Description:** 
This event is triggered when an existing RatingProgram is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Name|Text|Rating Program Name


### `RatingProgramDeleted`

**Description:**
This event is triggered when an existing RatingProgram is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Name|Text|Rating Program Name

