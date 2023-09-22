# Domain Events for the ExchangeRate entity

This document provides information about the ExchangeRate Domain Events in our application.

## Events

### `ExchangeRateCreated`

**Description:**
This event is triggered when a new ExchangeRate is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Exchange rate unique identifier
EffectiveRate|Number|Exchange rate conversion amount
EffectiveAt|DateTime|Exchange rate conversion amount


### `ExchangeRateUpdated`

**Description:** 
This event is triggered when an existing ExchangeRate is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Exchange rate unique identifier
EffectiveRate|Number|Exchange rate conversion amount
EffectiveAt|DateTime|Exchange rate conversion amount


### `ExchangeRateDeleted`

**Description:**
This event is triggered when an existing ExchangeRate is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Exchange rate unique identifier
EffectiveRate|Number|Exchange rate conversion amount
EffectiveAt|DateTime|Exchange rate conversion amount

