# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents

- [Default Integration Events](#default-integration-events)
    - [CountryCreated](#CountryCcreated)
    - [CountryUpdated](#CountryUpdated)
    - [CountryDeleted](#CountryDeleted)
- [Custom Integration Events](#custom-integration-events)
    - [CountryDebtOver1B](#CountryDebtOver1B)
    - [CountryLocalNamesAdded](#CountryLocalNamesAdded)
    - [CountryCurrenciesAdded](#CountryCurrenciesAdded)


## Default Integration Events



### `CountryCreated`

**Description:**
This event is triggered when a new Country is created.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.

### `CountryUpdated`

**Description:**
This event is triggered when an existing Country is updated.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.

### `CountryDeleted`

**Description:**
This event is triggered when an entity Country is deleted.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.




### `Country Attributes`
Member|Type|Description
------|----|-----------
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
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*







## Custom Integration Events




### `CountryDebtOver1B`

**Description:**
Country created or updated with debt over 1B local currency

**Topic:** Custom

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Id|CountryCode2|
Debt|Money|




### `CountryLocalNamesAdded`

**Description:**
Multiple country local names added

**Topic:** Custom

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
CountryLocalNameInfo|CountryLocalNameInfo|Multiple country local names added

**CountryLocalNameInfo Attributes**
Attribute|Type|Description
---------|----|-----------
Id|CountryCode2|
Name|Text|




### `CountryCurrenciesAdded`

**Description:**
Multiple country currencies added

**Topic:** Custom

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|<Id>
source||
type||
datacontenttype|ContentType|application/json
dataschema||
time|DateTimeUtc|<UtcNow>
xtenantid|Text|<TenantId>
xuserid|Text|<User>
data|Json|

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
CountryCurrencyInfo|CountryCurrencyInfo|Multiple country currencies added

**CountryCurrencyInfo Attributes**
Attribute|Type|Description
---------|----|-----------
Id|CountryCode2|
CurrencyCode|CurrencyCode3|
