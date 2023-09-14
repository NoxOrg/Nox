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
    CountryLocalName {
    }
    Store {
    }
    Store||--o|EmailAddress : "Verified emails"
    Workplace {
    }
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




### Country.CountryLocalName (Owned by Country)

Local names for countries.

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber|The unique identifier.|Required, Primary Key
Name|Text|Local name.|Required, MinLength: 4, MaxLength: 63




### Store

Stores. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreEndpoints.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Nuid|NuidField Type.|Required, Primary Key, Separator: ., PropertyNames: System.String[]
Name|Text|Store Name.|Required, MinLength: 4, MaxLength: 63
StoreOwnerId|Text||Required, Foreign Key, MinLength: 3, MaxLength: 3, IsUnicode: false
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Store owner relationship|ZeroOrOne|StoreOwner|OwnerRel|Yes


### Store.EmailAddress (Owned by Store)

Verified Email Address.

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Email|Email|Email.|
IsVerified|Boolean|Verified.|




### StoreOwner

Store owners. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/StoreOwnerEndpoints.md)

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
Set of stores that this owner owns|ZeroOrMany|Store|StoreRel|Yes


### Workplace

Workplace.

[Endpoints](./endpoints/WorkplaceEndpoints.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Nuid|Workplace unique identifier.|Required, Primary Key, Separator: -, PropertyNames: System.String[]
Name|Text|Workplace Name.|Required, MinLength: 4, MaxLength: 63
Greeting|Formula|The Formula.|





