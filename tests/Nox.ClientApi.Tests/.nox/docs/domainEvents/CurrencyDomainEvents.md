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
Symbol|Text|Currency's symbol
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CurrencyUpdated`

**Description:** 
This event is triggered when an existing Currency is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CurrencyCode3|Currency unique identifier
Name|Text|Currency's name
Symbol|Text|Currency's symbol
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CurrencyDeleted`

**Description:**
This event is triggered when an existing Currency is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|CurrencyCode3|Currency unique identifier
Name|Text|Currency's name
Symbol|Text|Currency's symbol
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

