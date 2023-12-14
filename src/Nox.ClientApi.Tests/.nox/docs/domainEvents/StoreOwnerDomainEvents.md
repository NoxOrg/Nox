# Domain Events for the StoreOwner entity

This document provides information about the StoreOwner Domain Events in our application.

## Events

### `StoreOwnerCreated`

**Description:**
This event is triggered when a new StoreOwner is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Text|
Name|Text|Owner Name
TemporaryOwnerName|Text|Temporary Owner Name
VatNumber|VatNumber|Vat Number
StreetAddress|StreetAddress|Street Address
LocalGreeting|TranslatedText|Owner Greeting
Notes|Text|Notes
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreOwnerUpdated`

**Description:** 
This event is triggered when an existing StoreOwner is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Text|
Name|Text|Owner Name
TemporaryOwnerName|Text|Temporary Owner Name
VatNumber|VatNumber|Vat Number
StreetAddress|StreetAddress|Street Address
LocalGreeting|TranslatedText|Owner Greeting
Notes|Text|Notes
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreOwnerDeleted`

**Description:**
This event is triggered when an existing StoreOwner is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Text|
Name|Text|Owner Name
TemporaryOwnerName|Text|Temporary Owner Name
VatNumber|VatNumber|Vat Number
StreetAddress|StreetAddress|Street Address
LocalGreeting|TranslatedText|Owner Greeting
Notes|Text|Notes
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

