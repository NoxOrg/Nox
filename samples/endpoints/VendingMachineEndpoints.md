# API Endpoints for the VendingMachine entity

This document provides information about the various endpoints available in our API for the VendingMachine entity.

## VendingMachine Endpoints

### Get VendingMachine by ID
- **GET** `/api/VendingMachines/{key}`
  - Description: Retrieve information about a VendingMachine by ID.
  
### Get VendingMachines
- **GET** `/api/VendingMachines`
  - Description: Retrieve information about VendingMachines.

### Create VendingMachine
- **POST** `/api/VendingMachines`
  - Description: Create a new VendingMachine with the provided data.

### Update VendingMachine
- **PUT** `/api/VendingMachines/{key}`
  - Description: Update an existing VendingMachine by ID with the provided data.
 
### Delete VendingMachine
- **DELETE** `/api/VendingMachines/{key}`
  - Description: Delete an existing VendingMachine by its ID.

## Relationships Endpoints

[Country Endpoints](CountryEndpoints.md)

[LandLord Endpoints](LandLordEndpoints.md)

[Booking Endpoints](BookingEndpoints.md)

[CashStockOrder Endpoints](CashStockOrderEndpoints.md)

[MinimumCashStock Endpoints](MinimumCashStockEndpoints.md)
