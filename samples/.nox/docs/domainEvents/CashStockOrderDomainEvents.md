# Domain Events for the CashStockOrder entity

This document provides information about the CashStockOrder Domain Events in our application.

## Events

### `CashStockOrderCreated`

**Description:**
This event is triggered when a new CashStockOrder is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine's order unique identifier
Amount|Money|Order amount
RequestedDeliveryDate|Date|Order requested delivery date
DeliveryDateTime|DateTime|Order delivery date
Status|Formula|Order status
VendingMachineId|Guid|Vending machine unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CashStockOrderUpdated`

**Description:** 
This event is triggered when an existing CashStockOrder is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine's order unique identifier
Amount|Money|Order amount
RequestedDeliveryDate|Date|Order requested delivery date
DeliveryDateTime|DateTime|Order delivery date
Status|Formula|Order status
VendingMachineId|Guid|Vending machine unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CashStockOrderDeleted`

**Description:**
This event is triggered when an existing CashStockOrder is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Vending machine's order unique identifier
Amount|Money|Order amount
RequestedDeliveryDate|Date|Order requested delivery date
DeliveryDateTime|DateTime|Order delivery date
Status|Formula|Order status
VendingMachineId|Guid|Vending machine unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

