﻿
# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents

- [Default Integration Events](#default-integration-events)
    - [CountryCreated](#CountryCreated)
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

**Topic:** Country

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.

### `CountryUpdated`

**Description:**
This event is triggered when an existing Country is updated.

**Topic:** Country

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.

### `CountryDeleted`

**Description:**
This event is triggered when an entity Country is deleted.

**Topic:** Country

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryDeleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|A country is a distinct territorial body or political entity.




### `Country Attributes`
Member|Type|Description
------|----|-----------
Id|System.String|
Name|System.String|The country's common name
FormalName|System.String|The country's official name
AlphaCode3|System.String|The country's official ISO 4217 alpha-3 code
AlphaCode2|System.String|The country's official ISO 4217 alpha-2 code
NumericCode|System.Int16|The country's official ISO 4217 alpha-3 code
DialingCodes|System.String|The country's phone dialing codes (comma-delimited)
Capital|System.String|The capital city of the country
Demonym|System.String|Noun denoting the natives of the country
AreaInSquareKilometres|System.Int32|Country area in square kilometers
GeoCoord|LatLongDto|The the position of the workplace's point on the surface of the Earth
GeoRegion|System.String|The region the country is in
GeoSubRegion|System.String|The sub-region the country is in
GeoWorldRegion|System.String|The world region the country is in
Population|System.Int32|The estimated population of the country
TopLevelDomains|System.String|The top level internet domains regitered to the country (comma-delimited)
CountryLocalNamesId|System.String|
ContinentId|System.Int64|

## Custom Integration Events




### `CountryDebtOver1B`

**Description:**
Country created or updated with debt over 1B local currency

**Topic:** TBD - when Trait is implemented

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryDebtOver1B
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/TBD/v1.0/CountryDebtOver1B.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Id|System.String|
Debt|MoneyDto|




### `CountryLocalNamesAdded`

**Description:**
Multiple country local names added

**Topic:** TBD - when Trait is implemented

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryLocalNamesAdded
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/TBD/v1.0/CountryLocalNamesAdded.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
CountryLocalNameInfo|CountryLocalNameInfo[]|Multiple country local names added

**CountryLocalNameInfo Attributes**
Attribute|Type|Description
---------|----|-----------
Id|System.String|
Name|System.String|




### `CountryCurrenciesAdded`

**Description:**
Multiple country currencies added

**Topic:** TBD - when Trait is implemented

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryCurrenciesAdded
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/TBD/v1.0/CountryCurrenciesAdded.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
CountryCurrencyInfo|IEnumerable\<CountryCurrencyInfo>|Multiple country currencies added

**CountryCurrencyInfo Attributes**
Attribute|Type|Description
---------|----|-----------
Id|System.String|
CurrencyCode|System.String|
