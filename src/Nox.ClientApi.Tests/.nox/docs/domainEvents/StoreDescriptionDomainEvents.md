# Domain Events for the StoreDescription entity

This document provides information about the StoreDescription Domain Events in our application.

## Events

### `StoreDescriptionCreated`

**Description:**
This event is triggered when a new StoreDescription is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Description|Text|Store Decsription


### `StoreDescriptionUpdated`

**Description:** 
This event is triggered when an existing StoreDescription is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Description|Text|Store Decsription


### `StoreDescriptionDeleted`

**Description:**
This event is triggered when an existing StoreDescription is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
StoreId|EntityId|
Id|AutoNumber|The unique identifier
Description|Text|Store Decsription

