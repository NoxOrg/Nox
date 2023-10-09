# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents

- [Default Integration Events](#default-integration-events)
    - [CountryCreated](#CountryCcreated)
    - [CountryUpdated](#CountryUpdated)
    - [CountryDeleted](#CountryDeleted)
- [Custom Integration Events](#custom-integration-events)
    - [CountryPopulationHigherThan100M](#CountryPopulationHigherThan100M)


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
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://ClientApi.com/ClientApi
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|ClientApi.ClientApi.Country.v1.0.CountryCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://ClientApi.com/schemas/ClientApi/Country/v1.0/CountryCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity

### `CountryUpdated`

**Description:**
This event is triggered when an existing Country is updated.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://ClientApi.com/ClientApi
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|ClientApi.ClientApi.Country.v1.0.CountryUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://ClientApi.com/schemas/ClientApi/Country/v1.0/CountryUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity

### `CountryDeleted`

**Description:**
This event is triggered when an entity Country is deleted.

**Topic:** Default

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://ClientApi.com/ClientApi
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|ClientApi.ClientApi.Country.v1.0.CountryDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://ClientApi.com/schemas/ClientApi/Country/v1.0/CountryDeleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity




### `Country Attributes`
Member|Type|Description
------|----|-----------
Name|Text|The Country Name
Population|Number|Population
CountryDebt|Money|The Money
FirstLanguageCode|LanguageCode|First Official Language
ShortDescription|Formula|The Formula
CountryIsoNumeric|CountryNumber|Country's iso number id
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id
GoogleMapsUrl|Url|Country's map via google maps
StartOfWeek|DayOfWeek|Country's start of week day
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*






## Custom Integration Events




### `CountryPopulationHigherThan100M`

**Description:**
Country Population Updated with Population Higher then 100M

**Topic:** Custom

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/{Nox.Solution.Name}|https://ClientApi.com/ClientApi
type|{Nox.Solution.PlatformId}.{Nox.Solution.Name}.{Trait}.v{Nox.Solution.Version}.{eventName}|ClientApi.ClientApi..v1.0.CountryPopulationHigherThan100M
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Nox.Solution.PlatformId}.com/schemas/{Nox.Solution.Name}/{Trait}/v{Nox.Solution.Version}/{eventName}.json|https://ClientApi.com/schemas/ClientApi//v1.0/CountryPopulationHigherThan100M.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Name|Text|
Population|Number|
CountryDebt|Money|
