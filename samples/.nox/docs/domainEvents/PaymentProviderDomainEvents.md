# Domain Events for the PaymentProvider entity

This document provides information about the PaymentProvider Domain Events in our application.

## Events

### `PaymentProviderCreated`

**Description:**
This event is triggered when a new PaymentProvider is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Payment provider unique identifier
PaymentProviderName|Text|Payment provider name
PaymentProviderType|Text|Payment provider account type
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PaymentProviderUpdated`

**Description:** 
This event is triggered when an existing PaymentProvider is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Payment provider unique identifier
PaymentProviderName|Text|Payment provider name
PaymentProviderType|Text|Payment provider account type
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PaymentProviderDeleted`

**Description:**
This event is triggered when an existing PaymentProvider is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|Payment provider unique identifier
PaymentProviderName|Text|Payment provider name
PaymentProviderType|Text|Payment provider account type
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

