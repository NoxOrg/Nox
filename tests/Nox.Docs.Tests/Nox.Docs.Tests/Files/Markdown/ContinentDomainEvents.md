# Domain Events for the Continent entity

This document provides information about the Continent Domain Events in our application.

## Events

### `ContinentCreated`

**Description:**
This event is triggered when a new Continent is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|
Name|Text|The continent's common name
CountryId|CountryCode2|


### `ContinentUpdated`

**Description:** 
This event is triggered when an existing Continent is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|
Name|Text|The continent's common name
CountryId|CountryCode2|

