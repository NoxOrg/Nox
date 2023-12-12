# Domain Events for the BankNote entity

This document provides information about the BankNote Domain Events in our application.

## Events

### `BankNoteCreated`

**Description:**
This event is triggered when a new BankNote is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Currency bank note unique identifier
CashNote|Text|Currency's cash bank note identifier
Value|Money|Bank note value


### `BankNoteUpdated`

**Description:** 
This event is triggered when an existing BankNote is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Currency bank note unique identifier
CashNote|Text|Currency's cash bank note identifier
Value|Money|Bank note value


### `BankNoteDeleted`

**Description:**
This event is triggered when an existing BankNote is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Currency bank note unique identifier
CashNote|Text|Currency's cash bank note identifier
Value|Money|Bank note value

