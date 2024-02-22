# Domain Events for the CountryLocalName entity

This document provides information about the CountryLocalName Domain Events in our application.

## Events

### `CountryLocalNameCreated`

**Description:**
This event is triggered when a new CountryLocalName is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|Local name
NativeName|Text|Local name in native tongue
Description|Text|Description


### `CountryLocalNameUpdated`

**Description:** 
This event is triggered when an existing CountryLocalName is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|Local name
NativeName|Text|Local name in native tongue
Description|Text|Description


### `CountryLocalNameDeleted`

**Description:**
This event is triggered when an existing CountryLocalName is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|Local name
NativeName|Text|Local name in native tongue
Description|Text|Description

