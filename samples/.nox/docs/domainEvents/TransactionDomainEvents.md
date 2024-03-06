# Domain Events for the Transaction entity

This document provides information about the Transaction Domain Events in our application.

## Events

### `TransactionCreated`

**Description:**
This event is triggered when a new Transaction is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Customer transaction unique identifier
TransactionType|Text|Transaction type
ProcessedOnDateTime|DateTime|Transaction processed datetime
Amount|Money|Transaction amount
Reference|Text|Transaction external reference
CustomerId|Guid|Customer's unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `TransactionUpdated`

**Description:** 
This event is triggered when an existing Transaction is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Customer transaction unique identifier
TransactionType|Text|Transaction type
ProcessedOnDateTime|DateTime|Transaction processed datetime
Amount|Money|Transaction amount
Reference|Text|Transaction external reference
CustomerId|Guid|Customer's unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `TransactionDeleted`

**Description:**
This event is triggered when an existing Transaction is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Customer transaction unique identifier
TransactionType|Text|Transaction type
ProcessedOnDateTime|DateTime|Transaction processed datetime
Amount|Money|Transaction amount
Reference|Text|Transaction external reference
CustomerId|Guid|Customer's unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

