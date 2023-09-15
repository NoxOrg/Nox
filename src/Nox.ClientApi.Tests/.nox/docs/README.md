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
    Store {
    }
    Store||--o|EmailAddress : "Verified emails"
    Workplace {
    }
    Workplace}o..o|Country : "Workplace country"
    StoreOwner {
    }
    StoreOwner|o..o{Store : "Set of stores that this owner owns"
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
Population|Number|Population.|
CountryDebt|Money|The Money.|
FirstLanguageCode|LanguageCode|First Official Language.|
ShortDescription|Formula|The Formula.|
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




### Store

Stores. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreEndpoints.md)

[Domain Events](./domainEvents/StoreDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|DatabaseGuid||Required, Primary Key
Name|Text|Store Name.|Required, MinLength: 4, MaxLength: 63
Address|StreetAddress|Street Address.|Required
Location|LatLong|Location.|Required
StoreOwnerId|Text||Required, Foreign Key, MinLength: 3, MaxLength: 3, IsUnicode: false
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Owner of the Store|ZeroOrOne|StoreOwner|Ownership|Yes


### Store.EmailAddress (Owned by Store)

Verified Email Address.

[Domain Events](./domainEvents/EmailAddressDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Email|Email|Email.|
IsVerified|Boolean|Verified.|




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
Greeting|Formula|The Formula.|
CountryId|AutoNumber|The unique identifier.|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Workplace country|ZeroOrOne|Country|BelongsToCountry|Yes



