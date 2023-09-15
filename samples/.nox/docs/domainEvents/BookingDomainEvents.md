# Domain Events for the Booking entity

This document provides information about the Booking Domain Events in our application.

## Events

### `BookingCreated`

**Description:**
This event is triggered when a new Booking is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Booking unique identifier
AmountFrom|Money|Booking's amount exchanged from
AmountTo|Money|Booking's amount exchanged to
RequestedPickUpDate|DateTimeRange|Booking's requested pick up date
PickedUpDateTime|DateTimeRange|Booking's actual pick up date
ExpiryDateTime|DateTime|Booking's expiry date
CancelledDateTime|DateTime|Booking's cancelled date
Status|Formula|Booking's status
VatNumber|VatNumber|Booking's related vat number
CustomerId|AutoNumber|Customer's unique identifier
VendingMachineId|DatabaseGuid|Vending machine unique identifier
CommissionId|AutoNumber|Commission unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `BookingUpdated`

**Description:** 
This event is triggered when an existing Booking is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Booking unique identifier
AmountFrom|Money|Booking's amount exchanged from
AmountTo|Money|Booking's amount exchanged to
RequestedPickUpDate|DateTimeRange|Booking's requested pick up date
PickedUpDateTime|DateTimeRange|Booking's actual pick up date
ExpiryDateTime|DateTime|Booking's expiry date
CancelledDateTime|DateTime|Booking's cancelled date
Status|Formula|Booking's status
VatNumber|VatNumber|Booking's related vat number
CustomerId|AutoNumber|Customer's unique identifier
VendingMachineId|DatabaseGuid|Vending machine unique identifier
CommissionId|AutoNumber|Commission unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `BookingDeleted`

**Description:**
This event is triggered when an existing Booking is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Booking unique identifier
AmountFrom|Money|Booking's amount exchanged from
AmountTo|Money|Booking's amount exchanged to
RequestedPickUpDate|DateTimeRange|Booking's requested pick up date
PickedUpDateTime|DateTimeRange|Booking's actual pick up date
ExpiryDateTime|DateTime|Booking's expiry date
CancelledDateTime|DateTime|Booking's cancelled date
Status|Formula|Booking's status
VatNumber|VatNumber|Booking's related vat number
CustomerId|AutoNumber|Customer's unique identifier
VendingMachineId|DatabaseGuid|Vending machine unique identifier
CommissionId|AutoNumber|Commission unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

