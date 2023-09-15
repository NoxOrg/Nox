# Domain Events for the Country entity

This document provides information about the Country Domain Events in our application.

## Events

### `CountryCreated`

**Description:**
This event is triggered when a new Country is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|Country unique identifier
Name|Text|Country's name
OfficialName|Text|Country's official name
CountryIsoNumeric|CountryNumber|Country's iso number id
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id
GeoCoords|LatLong|Country's geo coordinates
FlagEmoji|Text|Country's flag emoji
FlagSvg|Image|Country's flag in svg format
FlagPng|Image|Country's flag in png format
CoatOfArmsSvg|Image|Country's coat of arms in svg format
CoatOfArmsPng|Image|Country's coat of arms in png format
GoogleMapsUrl|Url|Country's map via google maps
OpenStreetMapsUrl|Url|Country's map via open street maps
StartOfWeek|DayOfWeek|Country's start of week day
CountryTimeZoneId|AutoNumber|Country's time zone unique identifier
HolidayId|AutoNumber|Country's holiday unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryUpdated`

**Description:** 
This event is triggered when an existing Country is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|Country unique identifier
Name|Text|Country's name
OfficialName|Text|Country's official name
CountryIsoNumeric|CountryNumber|Country's iso number id
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id
GeoCoords|LatLong|Country's geo coordinates
FlagEmoji|Text|Country's flag emoji
FlagSvg|Image|Country's flag in svg format
FlagPng|Image|Country's flag in png format
CoatOfArmsSvg|Image|Country's coat of arms in svg format
CoatOfArmsPng|Image|Country's coat of arms in png format
GoogleMapsUrl|Url|Country's map via google maps
OpenStreetMapsUrl|Url|Country's map via open street maps
StartOfWeek|DayOfWeek|Country's start of week day
CountryTimeZoneId|AutoNumber|Country's time zone unique identifier
HolidayId|AutoNumber|Country's holiday unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryDeleted`

**Description:**
This event is triggered when an existing Country is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|Country unique identifier
Name|Text|Country's name
OfficialName|Text|Country's official name
CountryIsoNumeric|CountryNumber|Country's iso number id
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id
GeoCoords|LatLong|Country's geo coordinates
FlagEmoji|Text|Country's flag emoji
FlagSvg|Image|Country's flag in svg format
FlagPng|Image|Country's flag in png format
CoatOfArmsSvg|Image|Country's coat of arms in svg format
CoatOfArmsPng|Image|Country's coat of arms in png format
GoogleMapsUrl|Url|Country's map via google maps
OpenStreetMapsUrl|Url|Country's map via open street maps
StartOfWeek|DayOfWeek|Country's start of week day
CountryTimeZoneId|AutoNumber|Country's time zone unique identifier
HolidayId|AutoNumber|Country's holiday unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

