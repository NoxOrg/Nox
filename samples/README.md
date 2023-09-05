# Cryptocash
## Decription

A sample solution for the imaginary Crypocash business.

## Overview
**Crypocash** is a multi-national foreign exchange operator.  Customers can safely and securely exchange currency and/or crypto-currency for cash at a network  of more than a thousand vending machines in all major city-centre and airport locations. This platform manages the operations of the company, including  registration and setup of new customers, allowing customers to book and pay for cash pick-up at an cash vending machine/ATM, managing physical stock levels at the ATM's and the managing the pricing and fees associated with cash transacting.


## High-Level Domain Model

``` mermaid
erDiagram
    Booking {
    }
    Commission {
    }
    Commission||..o{Booking : "fees for"
    Country {
    }
    Country|o..|{Commission : "used by"
    Country||--|{TimeZone : "owned"
    Country||--o{Holiday : "owned"
    Holiday {
    }
    TimeZone {
    }
    Currency {
    }
    Currency||..|{Country : "used by"
    Currency||--o{BankNote : "commonly used"
    Currency||--|{ExchangeRate : "exchanged from"
    BankNote {
    }
    Customer {
    }
    Customer||..o{Booking : "related to"
    Customer}o..||Country : "based in"
    PaymentDetail {
    }
    PaymentDetail}o..||Customer : "used by"
    Transaction {
    }
    Transaction}o..||Customer : "for"
    Transaction||..||Booking : "for"
    Employee {
    }
    Employee||..||CashStockOrder : "reviewing"
    Employee||--o{EmployeePhoneNumber : "contacted by"
    EmployeePhoneNumber {
    }
    ExchangeRate {
    }
    LandLord {
    }
    MinimumCashStock {
    }
    MinimumCashStock}o..||Currency : "related to"
    PaymentProvider {
    }
    PaymentProvider||..o{PaymentDetail : "related to"
    VendingMachine {
    }
    VendingMachine}o..||Country : "installed in"
    VendingMachine}o..||LandLord : "contracted area leased by"
    VendingMachine||..o{Booking : "related to"
    VendingMachine||..o{CashStockOrder : "related to"
    VendingMachine}o..o{MinimumCashStock : "required"
    CashStockOrder {
    }

```

## Definitions for Domain Entities

### BankNote (Owned by Currency)

Currencies related frequent and rare bank notes. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
<<<<<<< HEAD
Id|DatabaseNumber|Currency bank note unique identifier|Required, Primary Key
CashNote|Text|Currency's cash bank note identifier|Required, MinLength: 4, MaxLength: 63
Value|Money|Bank note value|Required
=======
Id|DatabaseNumber|Currency bank note unique identifier.|Required, Primary Key
BankNote|Text|Currency's bank note identifier.|Required, MinLength: 4, MaxLength: 63
IsRare|Boolean|Is bank note rare or frequent.|Required
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
>>>>>>> origin/main




### Booking

Exchange booking and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseGuid|Booking unique identifier.|Required, Primary Key
AmountFrom|Money|Booking's amount exchanged from.|Required
AmountTo|Money|Booking's amount exchanged to.|Required
RequestedPickUpDate|DateTimeRange|Booking's requested pick up date.|Required
PickedUpDateTime|DateTimeRange|Booking's actual pick up date.|
ExpiryDateTime|DateTime|Booking's expiry date.|
CancelledDateTime|DateTime|Booking's cancelled date.|
Status|Formula|Booking's status.|
VatNumber|VatNumber|Booking's related vat number.|
CustomerId|DatabaseNumber|Customer's unique identifier.|Required, Foreign Key
VendingMachineId|DatabaseGuid|Vending machine unique identifier.|Required, Foreign Key
CommissionId|DatabaseNumber|Commission unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
for|ExactlyOne|Customer|BookingForCustomer|Yes
related to|ExactlyOne|VendingMachine|BookingRelatedVendingMachine|Yes
fees for|ExactlyOne|Commission|BookingFeesForCommission|Yes
related to|ExactlyOne|Transaction|BookingRelatedTransaction|Yes


### CashStockOrder

Vending machine cash stock order and related data

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Vending machine's order unique identifier|Required, Primary Key
Amount|Money|Order amount|Required
RequestedDeliveryDate|Date|Order requested delivery date|Required
DeliveryDateTime|DateTime|Order delivery date|
Status|Formula|Order status|
VendingMachineId|DatabaseGuid|Vending machine unique identifier|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
for|ExactlyOne|VendingMachine|CashStockOrderForVendingMachine|Yes
reviewed by|ExactlyOne|Employee|CashStockOrderReviewedByEmployee|Yes


### Commission

Exchange commission rate and amount. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Commission unique identifier.|Required, Primary Key
Rate|Percentage|Commission rate.|Required
EffectiveAt|DateTime|Exchange rate conversion amount.|Required
CountryId|CountryCode2|Country unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
fees for|ZeroOrOne|Country|CommissionFeesForCountry|Yes
fees for|ZeroOrMany|Booking|CommissionFeesForBooking|Yes


### Country

Country and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
<<<<<<< HEAD
Id|CountryCode2|Country unique identifier|Required, Primary Key
Name|Text|Country's name|Required, MinLength: 4, MaxLength: 63
OfficialName|Text|Country's official name|MinLength: 4, MaxLength: 63
CountryIsoNumeric|CountryNumber|Country's iso number id|
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id|
GeoCoords|LatLong|Country's geo coordinates|
FlagEmoji|Text|Country's flag emoji|MinLength: 4, MaxLength: 63
FlagSvg|Image|Country's flag in svg format|
FlagPng|Image|Country's flag in png format|
CoatOfArmsSvg|Image|Country's coat of arms in svg format|
CoatOfArmsPng|Image|Country's coat of arms in png format|
GoogleMapsUrl|Url|Country's map via google maps|
OpenStreetMapsUrl|Url|Country's map via open street maps|
StartOfWeek|DayOfWeek|Country's start of week day|Required
TimeZoneId|DatabaseNumber|Country's time zone unique identifier|Required, Owned Entity
HolidayId|DatabaseNumber|Country's holiday unique identifier|Required, Owned Entity
CurrencyId|CurrencyCode3|Currency unique identifier|Required, Foreign Key
=======
Id|CountryCode2|Country unique identifier.|Required, Primary Key
Name|Text|Country's name.|Required, MinLength: 4, MaxLength: 63
OfficialName|Text|Country's official name.|MinLength: 4, MaxLength: 63
CountryIsoNumeric|CountryNumber|Country's iso number id.|
CountryIsoAlpha3|CountryCode3|Country's iso alpha3 id.|
GeoCoords|LatLong|Country's geo coordinates.|
FlagEmoji|Text|Country's flag emoji.|MinLength: 4, MaxLength: 63
FlagSvg|Image|Country's flag in svg format.|
FlagPng|Image|Country's flag in png format.|
CoatOfArmsSvg|Image|Country's coat of arms in svg format.|
CoatOfArmsPng|Image|Country's coat of arms in png format.|
GoogleMapsUrl|Url|Country's map via google maps.|
OpenStreetMapsUrl|Url|Country's map via open street maps.|
StartOfWeek|DayOfWeek|Country's start of week day.|Required
CountryTimeZonesId|DatabaseNumber|Country's time zone unique identifier.|Required, Owned Entity
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
>>>>>>> origin/main


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
<<<<<<< HEAD
used by|ExactlyOne|Currency|CountryUsedByCurrency|Yes
used by|OneOrMany|Commission|CountryUsedByCommissions|Yes
used by|ZeroOrMany|VendingMachine|CountryUsedByVendingMachines|Yes
used by|ZeroOrMany|Customer|CountryUsedByCustomers|Yes
=======
Country's primary currency for legal tender|ExactlyOne|Currency|Currency|Yes
Commission rates country|OneOrMany|Commission|Commission|Yes
Vending machine's country|ZeroOrMany|VendingMachine|VendingMachine|Yes
Country's bank and public holidays|ZeroOrMany|CountryHoliday|CountryHolidays|Yes
Customer's country|ZeroOrMany|Customer|Customer|Yes


### Country.CountryTimeZones (Owned by Country)

Time zones related to country.

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Country's time zone unique identifier.|Required, Primary Key
TimeZoneCode|TimeZoneCode|Country's related time zone code.|Required




### CountryHoliday

Holidays related to country. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Country's holiday unique identifier.|Required, Primary Key
Name|Text|Country holiday name.|Required, MinLength: 4, MaxLength: 63
Type|Text|Country holiday type.|Required, MinLength: 4, MaxLength: 63
Date|Date|Country holiday date.|Required
CountryId|CountryCode2|Country unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Country's holidays|ExactlyOne|Country|Country|Yes
>>>>>>> origin/main


### Currency

Currency and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
<<<<<<< HEAD
Id|CurrencyCode3|Currency unique identifier|Required, Primary Key
Name|Text|Currency's name|Required, MinLength: 4, MaxLength: 63
CurrencyIsoNumeric|CurrencyNumber|Currency's iso number id|Required
Symbol|Text|Currency's symbol|Required, MinLength: 4, MaxLength: 63
ThousandsSeparator|Text|Currency's numeric thousands notation separator|MinLength: 4, MaxLength: 63
DecimalSeparator|Text|Currency's numeric decimal notation separator|MinLength: 4, MaxLength: 63
SpaceBetweenAmountAndSymbol|Boolean|Currency's numeric space between amount and symbol|Required
DecimalDigits|Number|Currency's numeric decimal digits|Required
MajorName|Text|Currency's major name|Required, MinLength: 4, MaxLength: 63
MajorSymbol|Text|Currency's major display symbol|Required, MinLength: 4, MaxLength: 63
MinorName|Text|Currency's minor name|Required, MinLength: 4, MaxLength: 63
MinorSymbol|Text|Currency's minor display symbol|Required, MinLength: 4, MaxLength: 63
MinorToMajorValue|Money|Currency's minor value when converted to major|Required
BankNoteId|DatabaseNumber|Currency bank note unique identifier|Required, Owned Entity
ExchangeRateId|DatabaseNumber|Exchange rate unique identifier|Required, Owned Entity
=======
Id|CurrencyCode3|Currency unique identifier.|Required, Primary Key
Name|Text|Currency's name.|Required, MinLength: 4, MaxLength: 63
CurrencyIsoNumeric|CurrencyNumber|Currency's iso number id.|Required
Symbol|Text|Currency's symbol.|Required, MinLength: 4, MaxLength: 63
ThousandsSeparator|Text|Currency's numeric thousands notation separator.|MinLength: 4, MaxLength: 63
DecimalSeparator|Text|Currency's numeric decimal notation separator.|MinLength: 4, MaxLength: 63
SpaceBetweenAmountAndSymbol|Boolean|Currency's numeric space between amount and symbol.|Required
DecimalDigits|Number|Currency's numeric decimal digits.|Required
MajorName|Text|Currency's major name.|Required, MinLength: 4, MaxLength: 63
MajorSymbol|Text|Currency's major display symbol.|Required, MinLength: 4, MaxLength: 63
MinorName|Text|Currency's minor name.|Required, MinLength: 4, MaxLength: 63
MinorSymbol|Text|Currency's minor display symbol.|Required, MinLength: 4, MaxLength: 63
MinorToMajorValue|Money|Currency's minor value when converted to major.|Required
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
>>>>>>> origin/main


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
used by|OneOrMany|Country|CurrencyUsedByCountry|Yes
used by|ZeroOrMany|MinimumCashStock|CurrencyUsedByMinimumCashStocks|Yes


### Customer

Customer definition and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Customer's unique identifier.|Required, Primary Key
FirstName|Text|Customer's first name.|Required, MinLength: 4, MaxLength: 63
LastName|Text|Customer's last name.|Required, MinLength: 4, MaxLength: 63
EmailAddress|Email|Customer's email address.|Required
Address|StreetAddress|Customer's street address.|Required
MobileNumber|PhoneNumber|Customer's mobile number.|
CountryId|CountryCode2|Country unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
<<<<<<< HEAD
related to|ZeroOrMany|PaymentDetail|CustomerRelatedPaymentDetails|Yes
related to|ZeroOrMany|Booking|CustomerRelatedBookings|Yes
related to|ZeroOrMany|Transaction|CustomerRelatedTransactions|Yes
based in|ExactlyOne|Country|CustomerBaseCountry|Yes
=======
Customer's payment details|ZeroOrMany|CustomerPaymentDetails|CustomerPaymentDetails|Yes
Customer's booking|ZeroOrMany|Booking|Booking|Yes
Customer's transaction|ZeroOrMany|CustomerTransaction|CustomerTransaction|Yes
Customer's country|ExactlyOne|Country|Country|Yes


### CustomerPaymentDetails

Customer payment account related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Customer payment account unique identifier.|Required, Primary Key
PaymentAccountName|Text|Payment account name.|Required, MinLength: 4, MaxLength: 63
PaymentAccountNumber|Text|Payment account reference number.|Required, MinLength: 4, MaxLength: 63
PaymentAccountSortCode|Text|Payment account sort code.|MinLength: 4, MaxLength: 63
CustomerId|DatabaseNumber|Customer's unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Customer's payment account|ExactlyOne|Customer|Customer|Yes
Payment provider|ExactlyOne|PaymentProvider|PaymentProvider|Yes


### CustomerTransaction

Customer transaction log and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Customer transaction unique identifier.|Required, Primary Key
TransactionType|Text|Transaction type.|Required, MinLength: 4, MaxLength: 63
ProcessedOnDateTime|DateTime|Transaction processed datetime.|Required
Amount|Money|Transaction amount.|Required
Reference|Text|Transaction external reference.|Required, MinLength: 4, MaxLength: 63
CustomerId|DatabaseNumber|Customer's unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Transaction's customer|ExactlyOne|Customer|Customer|Yes
Transaction's booking|ExactlyOne|Booking|Booking|Yes
>>>>>>> origin/main


### Employee

Employee definition and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Employee's unique identifier.|Required, Primary Key
FirstName|Text|Employee's first name.|Required, MinLength: 4, MaxLength: 63
LastName|Text|Employee's last name.|Required, MinLength: 4, MaxLength: 63
EmailAddress|Email|Employee's email address.|Required
Address|StreetAddress|Employee's street address.|Required
FirstWorkingDay|Date|Employee's first working day.|Required
LastWorkingDay|Date|Employee's last working day.|
EmployeePhoneNumberId|DatabaseNumber|Employee's phone number identifier.|Required, Owned Entity
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
reviewing|ExactlyOne|CashStockOrder|EmployeeReviewingCashStockOrder|Yes


### Employee.EmployeePhoneNumber (Owned by Employee)

<<<<<<< HEAD
Employee phone number and related data
=======
Employee phone numbers and related data.
>>>>>>> origin/main

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Employee's phone number identifier.|Required, Primary Key
PhoneNumberType|Text|Employee's phone number type.|Required, MinLength: 4, MaxLength: 63
PhoneNumber|PhoneNumber|Employee's phone number.|Required




### ExchangeRate (Owned by Currency)

Exchange rate and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
<<<<<<< HEAD
Id|DatabaseNumber|Exchange rate unique identifier|Required, Primary Key
EffectiveRate|Number|Exchange rate conversion amount|Required
EffectiveAt|DateTime|Exchange rate conversion amount|Required
=======
Id|DatabaseNumber|Exchange rate unique identifier.|Required, Primary Key
EffectiveRate|Number|Exchange rate conversion amount.|Required
EffectiveAt|DateTime|Exchange rate conversion amount.|Required
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
>>>>>>> origin/main




### Holiday (Owned by Country)

Holiday related to country

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Country's holiday unique identifier|Required, Primary Key
Name|Text|Country holiday name|Required, MinLength: 4, MaxLength: 63
Type|Text|Country holiday type|Required, MinLength: 4, MaxLength: 63
Date|Date|Country holiday date|Required




### LandLord

Landlord related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Landlord unique identifier.|Required, Primary Key
Name|Text|Landlord name.|Required, MinLength: 4, MaxLength: 63
Address|StreetAddress|Landlord's street address.|Required
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
leases an area to house|ZeroOrMany|VendingMachine|ContractedAreasForVendingMachines|Yes


### MinimumCashStock

Minimum cash stock required for vending machine. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Vending machine cash stock unique identifier.|Required, Primary Key
Amount|Money|Cash stock amount.|Required
VendingMachineId|DatabaseGuid|Vending machine unique identifier.|Required, Foreign Key
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
required by|ZeroOrMany|VendingMachine|MinimumCashStocksRequiredByVendingMachines|Yes
related to|ExactlyOne|Currency|MinimumCashStockRelatedCurrency|Yes


### PaymentDetail

Customer payment account related data

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Customer payment account unique identifier|Required, Primary Key
PaymentAccountName|Text|Payment account name|Required, MinLength: 4, MaxLength: 63
PaymentAccountNumber|Text|Payment account reference number|Required, MinLength: 4, MaxLength: 63
PaymentAccountSortCode|Text|Payment account sort code|MinLength: 4, MaxLength: 63
CustomerId|DatabaseNumber|Customer's unique identifier|Required, Foreign Key
PaymentProviderId|DatabaseNumber|Payment provider unique identifier|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
used by|ExactlyOne|Customer|PaymentDetailsUsedByCustomer|Yes
related to|ExactlyOne|PaymentProvider|PaymentDetailsRelatedPaymentProvider|Yes


### PaymentProvider

Payment provider related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Payment provider unique identifier.|Required, Primary Key
PaymentProviderName|Text|Payment provider name.|Required, MinLength: 4, MaxLength: 63
PaymentProviderType|Text|Payment provider account type.|Required, MinLength: 4, MaxLength: 63
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
related to|ZeroOrMany|PaymentDetail|PaymentProviderRelatedPaymentDetails|Yes


### TimeZone (Owned by Country)

Time zone related to country

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Country's time zone unique identifier|Required, Primary Key
TimeZoneCode|TimeZoneCode|Country's related time zone code|Required




### Transaction

Customer transaction log and related data

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Customer transaction unique identifier|Required, Primary Key
TransactionType|Text|Transaction type|Required, MinLength: 4, MaxLength: 63
ProcessedOnDateTime|DateTime|Transaction processed datetime|Required
Amount|Money|Transaction amount|Required
Reference|Text|Transaction external reference|Required, MinLength: 4, MaxLength: 63
CustomerId|DatabaseNumber|Customer's unique identifier|Required, Foreign Key


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
for|ExactlyOne|Customer|TransactionForCustomer|Yes
for|ExactlyOne|Booking|TransactionForBooking|Yes


### VendingMachine

Vending machine definition and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
<<<<<<< HEAD
Id|DatabaseGuid|Vending machine unique identifier|Required, Primary Key
MacAddress|MacAddress|Vending machine mac address|Required
PublicIp|IpAddress|Vending machine public ip|Required
GeoLocation|LatLong|Vending machine geo location|Required
StreetAddress|StreetAddress|Vending machine street address|Required
SerialNumber|Text|Vending machine serial number|Required, MinLength: 4, MaxLength: 63
InstallationFootPrint|Area|Vending machine installation area|
RentPerSquareMetre|Money|Landlord rent amount based on area of the vending machine installation|
CountryId|CountryCode2|Country unique identifier|Required, Foreign Key
LandLordId|DatabaseNumber|Landlord unique identifier|Required, Foreign Key
MinimumCashStockId|DatabaseNumber|Vending machine cash stock unique identifier|Required, Foreign Key
=======
Id|DatabaseGuid|Vending machine unique identifier.|Required, Primary Key
MacAddress|MacAddress|Vending machine mac address.|Required
PublicIp|IpAddress|Vending machine public ip.|Required
GeoLocation|LatLong|Vending machine geo location.|Required
StreetAddress|StreetAddress|Vending machine street address.|Required
SerialNumber|Text|Vending machine serial number.|Required, MinLength: 4, MaxLength: 63
InstallationFootPrint|Area|Vending machine installation area.|
RentPerSquareMetre|Money|Landlord rent amount based on area of the vending machine installation.|
CountryId|CountryCode2|Country unique identifier.|Required, Foreign Key
LandLordId|DatabaseNumber|Landlord unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
>>>>>>> origin/main


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
<<<<<<< HEAD
installed in|ExactlyOne|Country|VendingMachineInstallationCountry|Yes
contracted area leased by|ExactlyOne|LandLord|VendingMachineContractedAreaLandLord|Yes
related to|ZeroOrMany|Booking|VendingMachineRelatedBookings|Yes
related to|ZeroOrMany|CashStockOrder|VendingMachineRelatedCashStockOrders|Yes
required|ZeroOrMany|MinimumCashStock|VendingMachineRequiredMinimumCashStocks|Yes
=======
Vending machine's country|ExactlyOne|Country|Country|Yes
Area of the vending machine installation landlord|ExactlyOne|LandLord|LandLord|Yes
Booking's vending machine|ZeroOrMany|Booking|Booking|Yes
Order's vending machine|ZeroOrMany|VendingMachineOrder|VendingMachineOrder|Yes
Vending machine's minimum cash stock|ZeroOrMany|MinimumCashStock|MinimumCashStock|Yes


### VendingMachineOrder

Vending machine currency order and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Vending machine's order unique identifier.|Required, Primary Key
Amount|Money|Order amount.|Required
RequestedDeliveryDate|Date|Order requested delivery date.|Required
DeliveryDateTime|DateTime|Order delivery date.|
Status|Formula|Order status.|
VendingMachineId|DatabaseGuid|Vending machine unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Vending machine's orders|ExactlyOne|VendingMachine|VendingMachine|Yes
Reviewed by employee|ExactlyOne|Employee|Employee|Yes
>>>>>>> origin/main



