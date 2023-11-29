
# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents

- [Default Integration Events](#default-integration-events)
    - [CountryCreated](#CountryCcreated)
    - [CountryUpdated](#CountryUpdated)
    - [CountryDeleted](#CountryDeleted)

    - [WorkplaceDeleted](#WorkplaceDeleted)

    - [StoreOwnerCreated](#StoreOwnerCcreated)- [Custom Integration Events](#custom-integration-events)
    - [CountryPopulationHigherThan100M](#CountryPopulationHigherThan100M)


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
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Country.v1.0.CountryCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Country/v1.0/CountryCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity Country representation for the Client API tests

### `CountryUpdated`

**Description:**
This event is triggered when an existing Country is updated.

**Topic:** Country

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Country.v1.0.CountryUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Country/v1.0/CountryUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity Country representation for the Client API tests

### `CountryDeleted`

**Description:**
This event is triggered when an entity Country is deleted.

**Topic:** Country

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Country.v1.0.CountryDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Country/v1.0/CountryDeleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Country|[Country](#Country-Attributes)|Country Entity Country representation for the Client API tests




### `Country Attributes`
Member|Type|Description
------|----|-----------
Id|System.Int64|The unique identifier
Name|System.String|The Country Name     Set a unique name for the country Do not use abbreviations

Population|System.Int32|Population Number of People living in the country
CountryDebt|MoneyDto|The Money
FirstLanguageCode|System.String|First Official Language
ShortDescription|System.String|The Formula
CountryIsoNumeric|System.UInt16|Country's iso number id
CountryIsoAlpha3|System.String|Country's iso alpha3 id
GoogleMapsUrl|System.String|Country's map via google maps
StartOfWeek|System.UInt16|Country's start of week day
Continent|System.Int32|Country Continent
CountryLocalNameId|System.Int64|The unique identifier
CountryTimeZoneId|System.String|Country's related time zone code


### `WorkplaceDeleted`

**Description:**
This event is triggered when an entity Workplace is deleted.

**Topic:** Workplace

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Workplace.v1.0.WorkplaceDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Workplace/v1.0/WorkplaceDeleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Workplace|[Workplace](#Workplace-Attributes)|Workplace




### `Workplace Attributes`
Member|Type|Description
------|----|-----------
Id|System.Int64|Workplace unique identifier
Name|System.String|Workplace Name
ReferenceNumber|System.String|Workplace Code
Description|System.String|Workplace Description
Greeting|System.String|The Formula
CountryId|System.Int64|The unique identifier
TenantId|System.UInt32|


### `StoreOwnerCreated`

**Description:**
This event is triggered when a new StoreOwner is created.

**Topic:** StoreOwner

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.StoreOwner.v1.0.StoreOwnerCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/StoreOwner/v1.0/StoreOwnerCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
StoreOwner|[StoreOwner](#StoreOwner-Attributes)|Store owners




### `StoreOwner Attributes`
Member|Type|Description
------|----|-----------
Id|System.String|
Name|System.String|Owner Name
TemporaryOwnerName|System.String|Temporary Owner Name
VatNumber|VatNumberDto|Vat Number
StreetAddress|StreetAddressDto|Street Address
LocalGreeting|TranslatedTextDto|Owner Greeting
Notes|System.String|Notes

## Custom Integration Events




### `CountryPopulationHigherThan100M`

**Description:**
Country Population Updated with Population Higher then 100M

**Topic:** TBD - when Trait is implemented

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi..v1.0.CountryPopulationHigherThan100M
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/TBD/v1.0/CountryPopulationHigherThan100M.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Name|System.String|
Population|System.Int32|
CountryDebt|MoneyDto|
