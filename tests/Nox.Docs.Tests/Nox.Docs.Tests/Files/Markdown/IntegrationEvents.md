﻿# Integration Events

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

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryCreated.json
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

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryUpdated.json
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

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration.Country.v1.0.CountryDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration/Country/v1.0/CountryDeleted.json
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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryDebtOver1B
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration//v1.0/CountryDebtOver1B.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryLocalNamesAdded
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration//v1.0/CountryLocalNamesAdded.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

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
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://SampleForIntegrationEventsMarkdownGeneration.com/SampleForIntegrationEventsMarkdownGeneration
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|SampleForIntegrationEventsMarkdownGeneration.SampleForIntegrationEventsMarkdownGeneration..v1.0.CountryCurrenciesAdded
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://SampleForIntegrationEventsMarkdownGeneration.com/schemas/SampleForIntegrationEventsMarkdownGeneration//v1.0/CountryCurrenciesAdded.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
CountryCurrencyInfo|CountryCurrencyInfo|Multiple country currencies added

**CountryCurrencyInfo Attributes**
Attribute|Type|Description
---------|----|-----------
Id|CountryCode2|
CurrencyCode|CurrencyCode3|
