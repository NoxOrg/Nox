# Domain Events for the MinimumCashStock entity

This document provides information about the MinimumCashStock Domain Events in our application.

## Events

### `MinimumCashStockCreated`

**Description:**
This event is triggered when a new MinimumCashStock is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine cash stock unique identifier
Amount|Money|Cash stock amount
VendingMachineId|Guid|Vending machine unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `MinimumCashStockUpdated`

**Description:** 
This event is triggered when an existing MinimumCashStock is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine cash stock unique identifier
Amount|Money|Cash stock amount
VendingMachineId|Guid|Vending machine unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `MinimumCashStockDeleted`

**Description:**
This event is triggered when an existing MinimumCashStock is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine cash stock unique identifier
Amount|Money|Cash stock amount
VendingMachineId|Guid|Vending machine unique identifier
CurrencyId|CurrencyCode3|Currency unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

