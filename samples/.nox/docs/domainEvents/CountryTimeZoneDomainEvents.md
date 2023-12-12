# Domain Events for the CountryTimeZone entity

This document provides information about the CountryTimeZone Domain Events in our application.

## Events

### `CountryTimeZoneCreated`

**Description:**
This event is triggered when a new CountryTimeZone is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's time zone unique identifier
TimeZoneCode|TimeZoneCode|Country's related time zone code


### `CountryTimeZoneUpdated`

**Description:** 
This event is triggered when an existing CountryTimeZone is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's time zone unique identifier
TimeZoneCode|TimeZoneCode|Country's related time zone code


### `CountryTimeZoneDeleted`

**Description:**
This event is triggered when an existing CountryTimeZone is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Country's time zone unique identifier
TimeZoneCode|TimeZoneCode|Country's related time zone code

