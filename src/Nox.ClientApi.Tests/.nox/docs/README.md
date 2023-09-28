# ClientApi
## Description

Project for Nox System Testing

## Overview


## High-Level Domain Model

``` mermaid
erDiagram
    Country {
    }
    Country||--o{CountryLocalName : "is also know as"
    Country||--o|CountryBarCode : "is also coded as"
    CountryLocalName {
    }
    CountryBarCode {
    }
    RatingProgram {
    }
    CountryQualityOfLifeIndex {
    }
    Store {
    }
    Store||--o|EmailAddress : "Verified emails"
    Workplace {
    }
    Workplace}o..o|Country : "Workplace country"
    StoreOwner {
    }
    StoreOwner|o..o{Store : "Set of stores that this owner owns"
    StoreLicense {
    }
    StoreLicense|o..||Store : "Store that this license related to"
    EmailAddress {
    }

```

## Definitions for Domain Entities

### Country

Country Entity. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/CountryEndpoints.md)

[Domain Events](./domainEvents/CountryDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber|The unique identifier.|Required, Primary Key
Name|Text|The Country Name.|Required, MinLength: 4, MaxLength: 63
Population|Number|Population.|MaxValue: 1500000000
CountryDebt|Money|The Money.|MinValue: 100000
FirstLanguageCode|LanguageCode|First Official Language.|
ShortDescription|Formula|The Formula.|
CountryIsoNumeric|CountryNumber|Country's iso number id.|
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id.|
GoogleMapsUrl|Url|Country's map via google maps.|
StartOfWeek|DayOfWeek|Country's start of week day.|
CountryLocalNameId|AutoNumber|The unique identifier.|Required, Owned Entity
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Country workplaces|ZeroOrMany|Workplace|PhysicalWorkplaces|Yes


### Country.CountryBarCode (Owned by Country)

Bar code for country.

[Domain Events](./domainEvents/CountryBarCodeDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
BarCodeName|Text|Bar code name.|Required, MinLength: 1, MaxLength: 63
BarCodeNumber|Number|Bar code number.|




### Country.CountryLocalName (Owned by Country)

Local names for countries.

[Domain Events](./domainEvents/CountryLocalNameDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber|The unique identifier.|Required, Primary Key
Name|Text|Local name.|Required, MinLength: 4, MaxLength: 63
NativeName|Text|Local name in native tongue.|MinLength: 4, MaxLength: 63




### CountryQualityOfLifeIndex

Country Quality Of Life Index.

[Endpoints](./endpoints/CountryQualityOfLifeIndexEndpoints.md)

[Domain Events](./domainEvents/CountryQualityOfLifeIndexDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
CountryId|EntityId||Required, Primary Key
Id|AutoNumber|The unique identifier.|Required, Primary Key
IndexRating|Number|Rating Index.|Required, MinValue: 1




### RatingProgram

Rating program for store.

[Endpoints](./endpoints/RatingProgramEndpoints.md)

[Domain Events](./domainEvents/RatingProgramDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
StoreId|EntityId||Required, Primary Key
Id|AutoNumber|The unique identifier.|Required, Primary Key
Name|Text|Rating Program Name.|MinLength: 2, MaxLength: 256




### Store

Stores. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreEndpoints.md)

[Domain Events](./domainEvents/StoreDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Guid||Required, Primary Key
Name|Text|Store Name.|Required, MinLength: 4, MaxLength: 63
Address|StreetAddress|Street Address.|Required
Location|LatLong|Location.|Required
OpeningDay|DateTime|Opening day.|
StoreOwnerId|Text||Required, Foreign Key, MinLength: 3, MaxLength: 3, IsUnicode: false
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Owner of the Store|ZeroOrOne|StoreOwner|Ownership|Yes
License that this store uses|ZeroOrOne|StoreLicense|License|Yes


### Store.EmailAddress (Owned by Store)

Verified Email Address.

[Domain Events](./domainEvents/EmailAddressDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Email|Email|Email.|
IsVerified|Boolean|Verified.|




### StoreLicense

Store license info. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreLicenseEndpoints.md)

[Domain Events](./domainEvents/StoreLicenseDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber||Required, Primary Key
Issuer|Text|License issuer.|Required, MinLength: 4, MaxLength: 63
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Store that this license related to|ExactlyOne|Store|StoreWithLicense|Yes


### StoreOwner

Store owners. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreOwnerEndpoints.md)

[Domain Events](./domainEvents/StoreOwnerDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Text||Required, Primary Key, MinLength: 3, MaxLength: 3, IsUnicode: false
Name|Text|Owner Name.|Required, MinLength: 4, MaxLength: 63
TemporaryOwnerName|Text|Temporary Owner Name.|Required
VatNumber|VatNumber|Vat Number.|
StreetAddress|StreetAddress|Street Address.|
LocalGreeting|TranslatedText|Owner Greeting.|MinLength: 4, MaxLength: 63
Notes|Text|Notes.|
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Set of stores that this owner owns|ZeroOrMany|Store|Stores|Yes


### Workplace

Workplace.

[Endpoints](./endpoints/WorkplaceEndpoints.md)

[Domain Events](./domainEvents/WorkplaceDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Nuid|Workplace unique identifier.|Required, Primary Key, Separator: -, PropertyNames: System.String[]
Name|Text|Workplace Name.|Required, MinLength: 4, MaxLength: 63
Description|Text|Workplace Description.|MinLength: 4, MaxLength: 63
Greeting|Formula|The Formula.|
CountryId|AutoNumber|The unique identifier.|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Workplace country|ZeroOrOne|Country|BelongsToCountry|Yes



