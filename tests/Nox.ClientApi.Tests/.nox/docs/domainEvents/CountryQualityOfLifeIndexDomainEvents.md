# Domain Events for the CountryQualityOfLifeIndex entity

This document provides information about the CountryQualityOfLifeIndex Domain Events in our application.

## Events

### `CountryQualityOfLifeIndexCreated`

**Description:**
This event is triggered when a new CountryQualityOfLifeIndex is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
CountryId|EntityId|
Id|AutoNumber|The unique identifier
IndexRating|Number|Rating Index


### `CountryQualityOfLifeIndexUpdated`

**Description:** 
This event is triggered when an existing CountryQualityOfLifeIndex is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
CountryId|EntityId|
Id|AutoNumber|The unique identifier
IndexRating|Number|Rating Index


### `CountryQualityOfLifeIndexDeleted`

**Description:**
This event is triggered when an existing CountryQualityOfLifeIndex is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
CountryId|EntityId|
Id|AutoNumber|The unique identifier
IndexRating|Number|Rating Index

