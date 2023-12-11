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
    Country||--o{CountryTimeZone : "uses"
    Country||--o{Holiday : "owned"
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
    Store}o..o{Client : "clients of the store"
    Store||--o|EmailAddress : "Verified emails"
    Workplace {
    }
    Workplace}o..o|Country : "Workplace country"
    Workplace}o..o{Tenant : "Actve Tenants in the workplace"
    StoreOwner {
    }
    StoreOwner|o..|{Store : "Set of stores that this owner owns"
    StoreLicense {
    }
    StoreLicense|o..||Store : "Store that this license related to"
    StoreLicense}|..o|Currency : "Default currency for this license"
    StoreLicense}|..o|Currency : "Currency this license was sold in"
    Currency {
    }
    Tenant {
    }
    Tenant||--o{TenantBrand : "Brands owned by the tenant"
    Tenant||--o|TenantContact : "Contact information for the tenant"
    TenantBrand {
    }
    TenantContact {
    }
    CountryTimeZone {
    }
    Client {
    }
    Holiday {
    }
    ReferenceNumberEntity {
    }
    EmailAddress {
    }

```

## Integration Events
[IntegrationEvents](./IntegrationEvents.md)

## Definitions for Domain Entities

### Client

Client of a Store. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/ClientEndpoints.md)

[Domain Events](./domainEvents/ClientDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Guid||Required, Primary Key
Name|Text|Store Name.|Required, MinLength: 4, MaxLength: 63
StoreId|Guid||Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Buys in this Store|ZeroOrMany|Store|ClientOf|Yes|Yes


### Country

Country Entity Country representation for the Client API tests. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/CountryEndpoints.md)

[Domain Events](./domainEvents/CountryDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber|The unique identifier.|Required, Primary Key, StartsAt: 10, IncrementsBy: 5
Name|Text|The Country Name     Set a unique name for the country Do not use abbreviations
.|Required, MinLength: 4, MaxLength: 63
Population|Number|Population Number of People living in the country.|MaxValue: 1500000000
CountryDebt|Money|The Money.|MinValue: 100000
CapitalCityLocation|LatLong|The capital location.|
FirstLanguageCode|LanguageCode|First Official Language.|
ShortDescription|Formula|The Formula.|
CountryIsoNumeric|CountryNumber|Country's iso number id.|
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id.|
GoogleMapsUrl|Url|Country's map via google maps.|
StartOfWeek|DayOfWeek|Country's start of week day.|
Continent|Enumeration|Country Continent.|Values: System.Collections.Generic.List`1[Nox.Types.EnumerationValues]
CountryLocalNameId|AutoNumber|The unique identifier.|Required, Owned Entity
CountryTimeZoneId|TimeZoneCode|Country's related time zone code.|Required, Owned Entity
HolidayId|Guid|Country's holiday unique identifier.|Required, Owned Entity
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Country workplaces|ZeroOrMany|Workplace|PhysicalWorkplaces|Yes|Yes


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




### Country.CountryTimeZone (Owned by Country)

Time zone related to country.

[Domain Events](./domainEvents/CountryTimeZoneDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|TimeZoneCode|Country's related time zone code.|Required, Primary Key
Name|Text|Time Zone Name.|MinLength: 4, MaxLength: 63




### Country.Holiday (Owned by Country)

Holiday related to country.

[Domain Events](./domainEvents/HolidayDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Guid|Country's holiday unique identifier.|Required, Primary Key
Name|Text|Country holiday name.|Required, MinLength: 4, MaxLength: 63
Type|Text|Country holiday type.|MinLength: 4, MaxLength: 63
Date|Date|Country holiday date.|




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




### Currency

Currency and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/CurrencyEndpoints.md)

[Domain Events](./domainEvents/CurrencyDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|CurrencyCode3|Currency unique identifier.|Required, Primary Key
Name|Text|Currency's name.|MinLength: 4, MaxLength: 63
Symbol|Text|Currency's symbol.|MinLength: 4, MaxLength: 63
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
List of store licenses where this currency is a default one|OneOrMany|StoreLicense|StoreLicenseDefault|No|No
List of store licenses that were sold in this currency|OneOrMany|StoreLicense|StoreLicenseSoldIn|No|No


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




### ReferenceNumberEntity

ReferenceNumberEntity. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/ReferenceNumberEntityEndpoints.md)

[Domain Events](./domainEvents/ReferenceNumberEntityDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|ReferenceNumber||Required, Primary Key, StartsAt: 10, IncrementsBy: 5
ReferenceNumber|ReferenceNumber|ReferenceNumber.|StartsAt: 10, IncrementsBy: 5
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*




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
Status|Enumeration|Store Status.|Values: System.Collections.Generic.List`1[Nox.Types.EnumerationValues], IsLocalized: false
StoreOwnerId|Text||Required, Foreign Key, MinLength: 3, MaxLength: 3, IsUnicode: false
ClientId|Guid||Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Owner of the Store|ZeroOrOne|StoreOwner|Ownership|Yes|Yes
License that this store uses|ZeroOrOne|StoreLicense|License|Yes|Yes
clients of the store|ZeroOrMany|Client|ClientsOfStore|Yes|Yes


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
ExternalId|AutoNumber|License external id.|Required, StartsAt: 3000000, IncrementsBy: 10
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Store that this license related to|ExactlyOne|Store|StoreWithLicense|Yes|Yes
Default currency for this license|ZeroOrOne|Currency|DefaultCurrency|Yes|Yes
Currency this license was sold in|ZeroOrOne|Currency|SoldInCurrency|Yes|Yes


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

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Set of stores that this owner owns|OneOrMany|Store|Stores|Yes|Yes


### Tenant

Tenant.

[Endpoints](./endpoints/TenantEndpoints.md)

[Domain Events](./domainEvents/TenantDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|Nuid||Required, Primary Key, Separator: -, PropertyNames: System.String[]
Name|Text|Teanant Name.|Required, MinLength: 4, MaxLength: 63
Status|Enumeration|Tenant Status.|Values: System.Collections.Generic.List`1[Nox.Types.EnumerationValues], IsLocalized: false
TenantBrandId|AutoNumber||Required, Owned Entity
WorkplaceId|AutoNumber|Workplace unique identifier.|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Workplaces where the tenant is active|ZeroOrMany|Workplace|TenantWorkplaces|Yes|Yes


### Tenant.TenantBrand (Owned by Tenant)

Tenant Brand.

[Domain Events](./domainEvents/TenantBrandDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber||Required, Primary Key
Name|Text|Teanant Brand Name.|Required, MinLength: 4, MaxLength: 63
Description|Text|Teanant Brand Description.|Required, MinLength: 4, IsLocalized: true




### Tenant.TenantContact (Owned by Tenant)

Tenant Contact.

[Domain Events](./domainEvents/TenantContactDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Name|Text|Teanant Brand Name.|Required, MinLength: 4, MaxLength: 63
Description|Text|Teanant Brand Description.|Required, MinLength: 4, IsLocalized: true
Email|Email|Teanant Brand Email.|Required




### Workplace

Workplace. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

[Endpoints](./endpoints/WorkplaceEndpoints.md)

[Domain Events](./domainEvents/WorkplaceDomainEvents.md)

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Description|Info
---------|----|----------|-------
Id|AutoNumber|Workplace unique identifier.|Required, Primary Key
Name|Text|Workplace Name.|Required, MinLength: 4, MaxLength: 63
ReferenceNumber|ReferenceNumber|Workplace Code.|StartsAt: 10, IncrementsBy: 5
Description|Text|Workplace Description.|MinLength: 4, IsLocalized: true
Greeting|Formula|The Formula.|
Ownership|Enumeration|Workplace Ownership.|Values: System.Collections.Generic.List`1[Nox.Types.EnumerationValues]
Type|Enumeration|Workplace Type.|Values: System.Collections.Generic.List`1[Nox.Types.EnumerationValues], IsLocalized: false
CountryId|AutoNumber|The unique identifier.|Required, Foreign Key, StartsAt: 10, IncrementsBy: 5
TenantId|Nuid||Required, Foreign Key, Separator: -, PropertyNames: System.String[]
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Manage Ref?|Can Manage Entity?
-----------|-----------|--------------|----|---------------|------------------
Workplace country|ZeroOrOne|Country|BelongsToCountry|Yes|Yes
Actve Tenants in the workplace|ZeroOrMany|Tenant|TenantsInWorkplace|Yes|Yes



