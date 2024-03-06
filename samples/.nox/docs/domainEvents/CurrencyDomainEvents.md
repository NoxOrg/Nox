# Domain Events for the Currency entity

This document provides information about the Currency Domain Events in our application.

## Events

### `CurrencyCreated`

**Description:**
This event is triggered when a new Currency is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CurrencyCode3|Currency unique identifier
Name|Text|Currency's name
CurrencyIsoNumeric|CurrencyNumber|Currency's iso number id
Symbol|Text|Currency's symbol
ThousandsSeparator|Text|Currency's numeric thousands notation separator
DecimalSeparator|Text|Currency's numeric decimal notation separator
SpaceBetweenAmountAndSymbol|Boolean|Currency's numeric space between amount and symbol
SymbolOnLeft|Boolean|Currency's symbol position
DecimalDigits|Number|Currency's numeric decimal digits
MajorName|Text|Currency's major name
MajorSymbol|Text|Currency's major display symbol
MinorName|Text|Currency's minor name
MinorSymbol|Text|Currency's minor display symbol
MinorToMajorValue|Money|Currency's minor value when converted to major
BankNoteId|AutoNumber|Currency bank note unique identifier
ExchangeRateId|AutoNumber|Exchange rate unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CurrencyUpdated`

**Description:** 
This event is triggered when an existing Currency is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CurrencyCode3|Currency unique identifier
Name|Text|Currency's name
CurrencyIsoNumeric|CurrencyNumber|Currency's iso number id
Symbol|Text|Currency's symbol
ThousandsSeparator|Text|Currency's numeric thousands notation separator
DecimalSeparator|Text|Currency's numeric decimal notation separator
SpaceBetweenAmountAndSymbol|Boolean|Currency's numeric space between amount and symbol
SymbolOnLeft|Boolean|Currency's symbol position
DecimalDigits|Number|Currency's numeric decimal digits
MajorName|Text|Currency's major name
MajorSymbol|Text|Currency's major display symbol
MinorName|Text|Currency's minor name
MinorSymbol|Text|Currency's minor display symbol
MinorToMajorValue|Money|Currency's minor value when converted to major
BankNoteId|AutoNumber|Currency bank note unique identifier
ExchangeRateId|AutoNumber|Exchange rate unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CurrencyDeleted`

**Description:**
This event is triggered when an existing Currency is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CurrencyCode3|Currency unique identifier
Name|Text|Currency's name
CurrencyIsoNumeric|CurrencyNumber|Currency's iso number id
Symbol|Text|Currency's symbol
ThousandsSeparator|Text|Currency's numeric thousands notation separator
DecimalSeparator|Text|Currency's numeric decimal notation separator
SpaceBetweenAmountAndSymbol|Boolean|Currency's numeric space between amount and symbol
SymbolOnLeft|Boolean|Currency's symbol position
DecimalDigits|Number|Currency's numeric decimal digits
MajorName|Text|Currency's major name
MajorSymbol|Text|Currency's major display symbol
MinorName|Text|Currency's minor name
MinorSymbol|Text|Currency's minor display symbol
MinorToMajorValue|Money|Currency's minor value when converted to major
BankNoteId|AutoNumber|Currency bank note unique identifier
ExchangeRateId|AutoNumber|Exchange rate unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

