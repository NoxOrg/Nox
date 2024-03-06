# Domain Events for the Holiday entity

This document provides information about the Holiday Domain Events in our application.

## Events

### `HolidayCreated`

**Description:**
This event is triggered when a new Holiday is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's holiday unique identifier
Name|Text|Country holiday name
Type|Text|Country holiday type
Date|Date|Country holiday date


### `HolidayUpdated`

**Description:** 
This event is triggered when an existing Holiday is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's holiday unique identifier
Name|Text|Country holiday name
Type|Text|Country holiday type
Date|Date|Country holiday date


### `HolidayDeleted`

**Description:**
This event is triggered when an existing Holiday is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's holiday unique identifier
Name|Text|Country holiday name
Type|Text|Country holiday type
Date|Date|Country holiday date

