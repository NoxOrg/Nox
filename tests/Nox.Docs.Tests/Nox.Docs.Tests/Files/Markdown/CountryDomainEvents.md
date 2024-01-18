# Domain Events for the Country entity

This document provides information about the Country Domain Events in our application.

## Events

### `CountryCreated`

**Description:**
This event is triggered when a new Country is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|
Name|Text|The country's common name
FormalName|Text|The country's official name
AlphaCode3|Text|The country's official ISO 4217 alpha-3 code
AlphaCode2|Text|The country's official ISO 4217 alpha-2 code
NumericCode|Number|The country's official ISO 4217 alpha-3 code
DialingCodes|Text|The country's phone dialing codes (comma-delimited)
Capital|Text|The capital city of the country
Demonym|Text|Noun denoting the natives of the country
AreaInSquareKilometres|Number|Country area in square kilometers
GeoCoord|LatLong|The the position of the workplace's point on the surface of the Earth
GeoRegion|Text|The region the country is in
GeoSubRegion|Text|The sub-region the country is in
GeoWorldRegion|Text|The world region the country is in
Population|Number|The estimated population of the country
TopLevelDomains|Text|The top level internet domains regitered to the country (comma-delimited)
CountryLocalNamesId|CountryCode2|
ContinentId|AutoNumber|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryUpdated`

**Description:** 
This event is triggered when an existing Country is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|
Name|Text|The country's common name
FormalName|Text|The country's official name
AlphaCode3|Text|The country's official ISO 4217 alpha-3 code
AlphaCode2|Text|The country's official ISO 4217 alpha-2 code
NumericCode|Number|The country's official ISO 4217 alpha-3 code
DialingCodes|Text|The country's phone dialing codes (comma-delimited)
Capital|Text|The capital city of the country
Demonym|Text|Noun denoting the natives of the country
AreaInSquareKilometres|Number|Country area in square kilometers
GeoCoord|LatLong|The the position of the workplace's point on the surface of the Earth
GeoRegion|Text|The region the country is in
GeoSubRegion|Text|The sub-region the country is in
GeoWorldRegion|Text|The world region the country is in
Population|Number|The estimated population of the country
TopLevelDomains|Text|The top level internet domains regitered to the country (comma-delimited)
CountryLocalNamesId|CountryCode2|
ContinentId|AutoNumber|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryDeleted`

**Description:**
This event is triggered when an existing Country is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|
Name|Text|The country's common name
FormalName|Text|The country's official name
AlphaCode3|Text|The country's official ISO 4217 alpha-3 code
AlphaCode2|Text|The country's official ISO 4217 alpha-2 code
NumericCode|Number|The country's official ISO 4217 alpha-3 code
DialingCodes|Text|The country's phone dialing codes (comma-delimited)
Capital|Text|The capital city of the country
Demonym|Text|Noun denoting the natives of the country
AreaInSquareKilometres|Number|Country area in square kilometers
GeoCoord|LatLong|The the position of the workplace's point on the surface of the Earth
GeoRegion|Text|The region the country is in
GeoSubRegion|Text|The sub-region the country is in
GeoWorldRegion|Text|The world region the country is in
Population|Number|The estimated population of the country
TopLevelDomains|Text|The top level internet domains regitered to the country (comma-delimited)
CountryLocalNamesId|CountryCode2|
ContinentId|AutoNumber|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

# Custom Domain Events for the Country entity
### `CountryNameUpdatedDomainEvent`

**Description:**Raised when a country's name is updated

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CountryCode2|
Name|Text|The country's common name
FormalName|Text|The country's official name
AlphaCode3|Text|The country's official ISO 4217 alpha-3 code
AlphaCode2|Text|The country's official ISO 4217 alpha-2 code
NumericCode|Number|The country's official ISO 4217 alpha-3 code
DialingCodes|Text|The country's phone dialing codes (comma-delimited)
Capital|Text|The capital city of the country
Demonym|Text|Noun denoting the natives of the country
AreaInSquareKilometres|Number|Country area in square kilometers
GeoCoord|LatLong|The the position of the workplace's point on the surface of the Earth
GeoRegion|Text|The region the country is in
GeoSubRegion|Text|The sub-region the country is in
GeoWorldRegion|Text|The world region the country is in
Population|Number|The estimated population of the country
TopLevelDomains|Text|The top level internet domains regitered to the country (comma-delimited)
CountryLocalNamesId|CountryCode2|
ContinentId|AutoNumber|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
