﻿
# Integration Events

This document provides information about Integration Events. Integration Events are messages that capture various actions and changes within system. They follow the CloudEvent standard for interoperability.

## Contents

- [Default Integration Events](#default-integration-events)
    - [CountryCreated](#CountryCreated)
    - [CountryUpdated](#CountryUpdated)
    - [CountryDeleted](#CountryDeleted)

    - [StoreUpdated](#StoreUpdated)
    - [WorkplaceUpdated](#WorkplaceUpdated)
    - [StoreOwnerCreated](#StoreOwnerCreated)
    - [PersonCreated](#PersonCreated)
    - [PersonUpdated](#PersonUpdated)
    - [PersonDeleted](#PersonDeleted)

    - [UserContactSelectionCreated](#UserContactSelectionCreated)
    - [UserContactSelectionUpdated](#UserContactSelectionUpdated)
- [Custom Integration Events](#custom-integration-events)
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
DebtPerCapita|System.String|national debt per person
CapitalCityLocation|LatLongDto|The capital location
FirstLanguageCode|System.String|First Official Language
ShortDescription|System.String|The Formula
CountryIsoNumeric|System.UInt16|Country's iso number id
CountryIsoAlpha3|System.String|Country's iso alpha3 id
GoogleMapsUrl|System.String|Country's map via google maps
StartOfWeek|System.UInt16|Country's start of week day
Continent|System.Int32|Country Continent
CountryLocalNameId|System.Int64|The unique identifier
CountryTimeZoneId|System.String|Country's related time zone code
HolidayId|System.Guid|Country's holiday unique identifier


### `StoreUpdated`

**Description:**
This event is triggered when an existing Store is updated.

**Topic:** Store

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Store.v1.0.StoreUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Store/v1.0/StoreUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Store|[Store](#Store-Attributes)|Stores




### `Store Attributes`
Member|Type|Description
------|----|-----------
Id|System.Guid|
Name|System.String|Store Name
Address|StreetAddressDto|Street Address
Location|LatLongDto|Location
OpeningDay|System.DateTimeOffset|Opening day
Status|System.Int32|Store Status
CountryId|System.Int64|The unique identifier
StoreOwnerId|System.String|
ClientId|System.Guid|
StoreId|System.Guid|


### `WorkplaceUpdated`

**Description:**
This event is triggered when an existing Workplace is updated.

**Topic:** Workplace

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Workplace.v1.0.WorkplaceUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Workplace/v1.0/WorkplaceUpdated.json
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
Ownership|System.Int32|Workplace Ownership
Type|System.Int32|Workplace Type
WorkplaceAddressId|System.Guid|
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


### `PersonCreated`

**Description:**
This event is triggered when a new Person is created.

**Topic:** Person

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Person.v1.0.PersonCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Person/v1.0/PersonCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Person|[Person](#Person-Attributes)|Person

### `PersonUpdated`

**Description:**
This event is triggered when an existing Person is updated.

**Topic:** Person

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Person.v1.0.PersonUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Person/v1.0/PersonUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
Person|[Person](#Person-Attributes)|Person

### `PersonDeleted`

**Description:**
This event is triggered when an entity Person is deleted.

**Topic:** Person

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.Person.v1.0.PersonDeleted
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/Person/v1.0/PersonDeleted.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**
Attribute|Type|Description
---------|----|-----------
Person|[Person](#Person-Attributes)|Person




### `Person Attributes`
Member|Type|Description
------|----|-----------
Id|System.Guid|The person unique identifier
FirstName|System.String|The user's first name
LastName|System.String|The customer's last name
TenantId|System.Guid|Tenant user bellongs to
PrimaryEmailAddress|System.String|The user's primary email for MFA


### `UserContactSelectionCreated`

**Description:**
This event is triggered when a new UserContactSelection is created.

**Topic:** UserContactSelection

#### Envelope Attributes

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.UserContactSelection.v1.0.UserContactSelectionCreated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/UserContactSelection/v1.0/UserContactSelectionCreated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
UserContactSelection|[UserContactSelection](#UserContactSelection-Attributes)|User Contacts

### `UserContactSelectionUpdated`

**Description:**
This event is triggered when an existing UserContactSelection is updated.

**Topic:** UserContactSelection

**Envelope Attributes**

Attribute|Type|Example
---------|----|-------
specversion|SemanticVersion|1.0
id|Guid|0d02bba1-dbf3-4ba4-93c1-2e416ec0c88d
source|https://{ENVIRONMENT}.{Solution.PlatformId}.com/{Solution.Name}|https://Nox-Tests.com/ClientApi
type|{Solution.PlatformId}.{Solution.Name}.{Trait}.v{Solution.Version}.{eventName}|Nox-Tests.ClientApi.UserContactSelection.v1.0.UserContactSelectionUpdated
datacontenttype|ContentType|application/json
dataschema|https://{ENVIRONMENT}.{Solution.PlatformId}.com/schemas/{Solution.Name}/{Trait}/v{Solution.Version}/{eventName}.json|https://Nox-Tests.com/schemas/ClientApi/UserContactSelection/v1.0/UserContactSelectionUpdated.json
time|DateTimeUtc|2023-10-10T12:11:10.5312500Z
xtenantid|Text|b22ee68e-327f-4550-a077-8fb8426071f5
xuserid|Text|e945e9f9-b0ba-435d-bfe7-8966abeb8763
data|Json|Data Field Attributes

**Data Field Attributes**

Attribute|Type|Description
---------|----|-----------
UserContactSelection|[UserContactSelection](#UserContactSelection-Attributes)|User Contacts




### `UserContactSelection Attributes`
Member|Type|Description
------|----|-----------
ContactId|System.Guid|Contact Id that user switched to
AccountId|System.Guid|Account Id that user switched to
SelectedDate|System.DateTimeOffset|selected date

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
