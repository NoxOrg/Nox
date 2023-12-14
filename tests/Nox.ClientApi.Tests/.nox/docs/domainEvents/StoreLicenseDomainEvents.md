# Domain Events for the StoreLicense entity

This document provides information about the StoreLicense Domain Events in our application.

## Events

### `StoreLicenseCreated`

**Description:**
This event is triggered when a new StoreLicense is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|
Issuer|Text|License issuer
ExternalId|AutoNumber|License external id
CurrencyId|CurrencyCode3|Currency unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreLicenseUpdated`

**Description:** 
This event is triggered when an existing StoreLicense is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|
Issuer|Text|License issuer
ExternalId|AutoNumber|License external id
CurrencyId|CurrencyCode3|Currency unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `StoreLicenseDeleted`

**Description:**
This event is triggered when an existing StoreLicense is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|
Issuer|Text|License issuer
ExternalId|AutoNumber|License external id
CurrencyId|CurrencyCode3|Currency unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

