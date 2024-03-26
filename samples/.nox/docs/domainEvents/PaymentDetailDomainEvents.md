# Domain Events for the PaymentDetail entity

This document provides information about the PaymentDetail Domain Events in our application.

## Events

### `PaymentDetailCreated`

**Description:**
This event is triggered when a new PaymentDetail is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer payment account unique identifier
PaymentAccountName|Text|Payment account name
PaymentAccountNumber|Text|Payment account reference number
PaymentAccountSortCode|Text|Payment account sort code
CustomerId|Guid|Customer's unique identifier
PaymentProviderId|Guid|Payment provider unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PaymentDetailUpdated`

**Description:** 
This event is triggered when an existing PaymentDetail is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer payment account unique identifier
PaymentAccountName|Text|Payment account name
PaymentAccountNumber|Text|Payment account reference number
PaymentAccountSortCode|Text|Payment account sort code
CustomerId|Guid|Customer's unique identifier
PaymentProviderId|Guid|Payment provider unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PaymentDetailDeleted`

**Description:**
This event is triggered when an existing PaymentDetail is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer payment account unique identifier
PaymentAccountName|Text|Payment account name
PaymentAccountNumber|Text|Payment account reference number
PaymentAccountSortCode|Text|Payment account sort code
CustomerId|Guid|Customer's unique identifier
PaymentProviderId|Guid|Payment provider unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

