# Domain Events for the Commission entity

This document provides information about the Commission Domain Events in our application.

## Events

### `CommissionCreated`

**Description:**
This event is triggered when a new Commission is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Commission unique identifier
Rate|Percentage|Commission rate
EffectiveAt|DateTime|Exchange rate conversion amount
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CommissionUpdated`

**Description:** 
This event is triggered when an existing Commission is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Commission unique identifier
Rate|Percentage|Commission rate
EffectiveAt|DateTime|Exchange rate conversion amount
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CommissionDeleted`

**Description:**
This event is triggered when an existing Commission is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Commission unique identifier
Rate|Percentage|Commission rate
EffectiveAt|DateTime|Exchange rate conversion amount
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

