# Domain Events for the CountryTimeZone entity

This document provides information about the CountryTimeZone Domain Events in our application.

## Events

### `CountryTimeZoneCreated`

**Description:**
This event is triggered when a new CountryTimeZone is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|TimeZoneCode|Country's related time zone code
Name|Text|Time Zone Name


### `CountryTimeZoneUpdated`

**Description:** 
This event is triggered when an existing CountryTimeZone is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|TimeZoneCode|Country's related time zone code
Name|Text|Time Zone Name


### `CountryTimeZoneDeleted`

**Description:**
This event is triggered when an existing CountryTimeZone is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|TimeZoneCode|Country's related time zone code
Name|Text|Time Zone Name

