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
    Commission||..o{Booking : "Booking's fee"
    Country {
    }
    Country|o..|{Commission : "Commission rates country"
    Country||--|{CountryTimeZones : "Country's time zones"
    CountryHoliday {
    }
    CountryHoliday}o..||Country : "Country's holidays"
    CountryTimeZones {
    }
    Currency {
    }
    Currency||..|{BankNotes : "Currency's bank notes"
    Currency||..|{Country : "Country's currency"
    BankNotes {
    }
    Customer {
    }
    Customer||..o{Booking : "Customer's booking"
    Customer}o..||Country : "Customer's country"
    CustomerPaymentDetails {
    }
    CustomerPaymentDetails}o..||Customer : "Customer's payment account"
    CustomerTransaction {
    }
    CustomerTransaction}o..||Customer : "Transaction's customer"
    CustomerTransaction||..||Booking : "Transaction's booking"
    Employee {
    }
    Employee||--o{EmployeePhoneNumber : "Employee's phone numbers"
    EmployeePhoneNumber {
    }
    ExchangeRate {
    }
    ExchangeRate}|..||Currency : "Exchange rate relative to CHF (Swiss Franc)"
    LandLord {
    }
    MinimumCashStock {
    }
    MinimumCashStock}o..||Currency : "Cash stock's currency"
    PaymentProvider {
    }
    PaymentProvider||..||CustomerPaymentDetails : "Payment provider"
    VendingMachine {
    }
    VendingMachine}o..||Country : "Vending machine's country"
    VendingMachine}o..||LandLord : "Area of the vending machine installation landlord"
    VendingMachine||..o{Booking : "Booking's vending machine"
    VendingMachine||..o{MinimumCashStock : "Vending machine's minimum cash stock"
    VendingMachineOrder {
    }
    VendingMachineOrder}o..||VendingMachine : "Vending machine's orders"
    VendingMachineOrder||..||Employee : "Reviewed by employee"

```

## Definitions for Domain Entities

### BankNotes

Currencies related frequent and rare bank notes. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Currency bank note unique identifier.|Required, Primary Key
BankNote|Text|Currency's bank note identifier.|Required, MinLength: 4, MaxLength: 63
IsRare|Boolean|Is bank note rare or frequent.|Required
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Currency's bank notes|ExactlyOne|Currency|Currency|Yes


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
Booking's customer|ExactlyOne|Customer|Customer|Yes
Booking's vending machine|ExactlyOne|VendingMachine|VendingMachine|Yes
Booking's fee|ExactlyOne|Commission|Fee|Yes
Transaction's booking|ExactlyOne|CustomerTransaction|CustomerTransaction|Yes


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
Commission's country|ZeroOrOne|Country|Country|Yes
Booking's fee|ZeroOrMany|Booking|Booking|Yes


### Country

Country and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
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


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
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


### Currency

Currency and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
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


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Currency's bank notes|OneOrMany|BankNotes|BankNotes|Yes
Country's currency|OneOrMany|Country|Country|Yes
Cash stock currency|ZeroOrMany|MinimumCashStock|MinimumCashStock|Yes
Exchanged from currency|OneOrMany|ExchangeRate|ExchangeRateFrom|Yes


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
Reviewed by employee|ExactlyOne|VendingMachineOrder|VendingMachineOrder|Yes


### Employee.EmployeePhoneNumber (Owned by Employee)

Employee phone numbers and related data.

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Employee's phone number identifier.|Required, Primary Key
PhoneNumberType|Text|Employee's phone number type.|Required, MinLength: 4, MaxLength: 63
PhoneNumber|PhoneNumber|Employee's phone number.|Required




### ExchangeRate

Exchange rate and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
Id|DatabaseNumber|Exchange rate unique identifier.|Required, Primary Key
EffectiveRate|Number|Exchange rate conversion amount.|Required
EffectiveAt|DateTime|Exchange rate conversion amount.|Required
CurrencyId|CurrencyCode3|Currency unique identifier.|Required, Foreign Key
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
Exchange rate relative to CHF (Swiss Franc)|ExactlyOne|Currency|CurrencyFrom|Yes


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
Landlord's area of the vending machine installation|ZeroOrMany|VendingMachine|VendingMachine|Yes


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
Vending machine's minimum cash stock|ExactlyOne|VendingMachine|VendingMachine|Yes
Cash stock's currency|ExactlyOne|Currency|Currency|Yes


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
Payment provider|ExactlyOne|CustomerPaymentDetails|CustomerPaymentDetails|Yes


### VendingMachine

Vending machine definition and related data. *This entity is auditable and tracks info about who, which system and when state changes (create/update/delete) were effected.*

#### <u>Members (Keys, Attributes & Relationships)</u>

Member|Type|Decription|Info
---------|----|----------|-------
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


#### <u>Relationships</u>

Description|Cardinality|Related Entity|Name|Can Navigate?
-----------|-----------|--------------|----|-------------
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



