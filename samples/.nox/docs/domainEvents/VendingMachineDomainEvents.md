# Domain Events for the VendingMachine entity

This document provides information about the VendingMachine Domain Events in our application.

## Events

### `VendingMachineCreated`

**Description:**
This event is triggered when a new VendingMachine is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Vending machine unique identifier
MacAddress|MacAddress|Vending machine mac address
PublicIp|IpAddress|Vending machine public ip
GeoLocation|LatLong|Vending machine geo location
StreetAddress|StreetAddress|Vending machine street address
SerialNumber|Text|Vending machine serial number
InstallationFootPrint|Area|Vending machine installation area
RentPerSquareMetre|Money|Landlord rent amount based on area of the vending machine installation
CountryId|CountryCode2|Country unique identifier
LandLordId|AutoNumber|Landlord unique identifier
MinimumCashStockId|AutoNumber|Vending machine cash stock unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `VendingMachineUpdated`

**Description:** 
This event is triggered when an existing VendingMachine is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Vending machine unique identifier
MacAddress|MacAddress|Vending machine mac address
PublicIp|IpAddress|Vending machine public ip
GeoLocation|LatLong|Vending machine geo location
StreetAddress|StreetAddress|Vending machine street address
SerialNumber|Text|Vending machine serial number
InstallationFootPrint|Area|Vending machine installation area
RentPerSquareMetre|Money|Landlord rent amount based on area of the vending machine installation
CountryId|CountryCode2|Country unique identifier
LandLordId|AutoNumber|Landlord unique identifier
MinimumCashStockId|AutoNumber|Vending machine cash stock unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `VendingMachineDeleted`

**Description:**
This event is triggered when an existing VendingMachine is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|DatabaseGuid|Vending machine unique identifier
MacAddress|MacAddress|Vending machine mac address
PublicIp|IpAddress|Vending machine public ip
GeoLocation|LatLong|Vending machine geo location
StreetAddress|StreetAddress|Vending machine street address
SerialNumber|Text|Vending machine serial number
InstallationFootPrint|Area|Vending machine installation area
RentPerSquareMetre|Money|Landlord rent amount based on area of the vending machine installation
CountryId|CountryCode2|Country unique identifier
LandLordId|AutoNumber|Landlord unique identifier
MinimumCashStockId|AutoNumber|Vending machine cash stock unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

