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
  - Description: Create a new VendingMachine.

### Update VendingMachine
- **PUT** `/api/VendingMachines/{key}`
  - Description: Update an existing VendingMachine.

### Partially Update VendingMachine
- **PATCH** `/api/VendingMachines/{key}`
  - Description: Partially update an existing VendingMachine.
 
### Delete VendingMachine
- **DELETE** `/api/VendingMachines/{key}`
  - Description: Delete an existing VendingMachine.

## Relationships Endpoints

### Country

#### Get Country relation by ID
- **GET** `/api/VendingMachines/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific VendingMachine.

#### Get Country relations
- **GET** `/api/VendingMachines/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific VendingMachine.
  
#### Create Country relation
- **POST** `/api/VendingMachines/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific VendingMachine.
  
#### Update Country relation
- **PUT** `/api/VendingMachines/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific VendingMachine.
  
#### Partially Update Country relation
- **PATCH** `/api/VendingMachines/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific VendingMachine.

#### Delete Country relation
- **DELETE** `/api/VendingMachines/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific VendingMachine.

### LandLord

#### Get LandLord relation by ID
- **GET** `/api/VendingMachines/{key}/LandLords/{relatedKey}/$ref`
  - Description: Retrieve an existing LandLords relation for a specific VendingMachine.

#### Get LandLord relations
- **GET** `/api/VendingMachines/{key}/LandLords/$ref`
  - Description: Retrieve all LandLords relations for a specific VendingMachine.
  
#### Create LandLord relation
- **POST** `/api/VendingMachines/{key}/LandLords/{relatedKey}/$ref`
  - Description: Create a new LandLord relation for a specific VendingMachine.
  
#### Update LandLord relation
- **PUT** `/api/VendingMachines/{key}/LandLords/{relatedKey}/$ref`
  - Description: Update an existing LandLord relation for a specific VendingMachine.
  
#### Partially Update LandLord relation
- **PATCH** `/api/VendingMachines/{key}/LandLords/{relatedKey}/$ref`
  - Description: Partially update an existing LandLord relation for a specific VendingMachine.

#### Delete LandLord relation
- **DELETE** `/api/VendingMachines/{key}/LandLords/{relatedKey}/$ref`
  - Description: Delete an existing LandLord relation for a specific VendingMachine.

### Booking

#### Get Booking relation by ID
- **GET** `/api/VendingMachines/{key}/Bookings/{relatedKey}/$ref`
  - Description: Retrieve an existing Bookings relation for a specific VendingMachine.

#### Get Booking relations
- **GET** `/api/VendingMachines/{key}/Bookings/$ref`
  - Description: Retrieve all Bookings relations for a specific VendingMachine.
  
#### Create Booking relation
- **POST** `/api/VendingMachines/{key}/Bookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific VendingMachine.
  
#### Update Booking relation
- **PUT** `/api/VendingMachines/{key}/Bookings/{relatedKey}/$ref`
  - Description: Update an existing Booking relation for a specific VendingMachine.
  
#### Partially Update Booking relation
- **PATCH** `/api/VendingMachines/{key}/Bookings/{relatedKey}/$ref`
  - Description: Partially update an existing Booking relation for a specific VendingMachine.

#### Delete Booking relation
- **DELETE** `/api/VendingMachines/{key}/Bookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific VendingMachine.

### CashStockOrder

#### Get CashStockOrder relation by ID
- **GET** `/api/VendingMachines/{key}/CashStockOrders/{relatedKey}/$ref`
  - Description: Retrieve an existing CashStockOrders relation for a specific VendingMachine.

#### Get CashStockOrder relations
- **GET** `/api/VendingMachines/{key}/CashStockOrders/$ref`
  - Description: Retrieve all CashStockOrders relations for a specific VendingMachine.
  
#### Create CashStockOrder relation
- **POST** `/api/VendingMachines/{key}/CashStockOrders/{relatedKey}/$ref`
  - Description: Create a new CashStockOrder relation for a specific VendingMachine.
  
#### Update CashStockOrder relation
- **PUT** `/api/VendingMachines/{key}/CashStockOrders/{relatedKey}/$ref`
  - Description: Update an existing CashStockOrder relation for a specific VendingMachine.
  
#### Partially Update CashStockOrder relation
- **PATCH** `/api/VendingMachines/{key}/CashStockOrders/{relatedKey}/$ref`
  - Description: Partially update an existing CashStockOrder relation for a specific VendingMachine.

#### Delete CashStockOrder relation
- **DELETE** `/api/VendingMachines/{key}/CashStockOrders/{relatedKey}/$ref`
  - Description: Delete an existing CashStockOrder relation for a specific VendingMachine.

### MinimumCashStock

#### Get MinimumCashStock relation by ID
- **GET** `/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Retrieve an existing MinimumCashStocks relation for a specific VendingMachine.

#### Get MinimumCashStock relations
- **GET** `/api/VendingMachines/{key}/MinimumCashStocks/$ref`
  - Description: Retrieve all MinimumCashStocks relations for a specific VendingMachine.
  
#### Create MinimumCashStock relation
- **POST** `/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Create a new MinimumCashStock relation for a specific VendingMachine.
  
#### Update MinimumCashStock relation
- **PUT** `/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Update an existing MinimumCashStock relation for a specific VendingMachine.
  
#### Partially Update MinimumCashStock relation
- **PATCH** `/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Partially update an existing MinimumCashStock relation for a specific VendingMachine.

#### Delete MinimumCashStock relation
- **DELETE** `/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Delete an existing MinimumCashStock relation for a specific VendingMachine.

## Related Entities

[Country](CountryEndpoints.md)

[LandLord](LandLordEndpoints.md)

[Booking](BookingEndpoints.md)

[CashStockOrder](CashStockOrderEndpoints.md)

[MinimumCashStock](MinimumCashStockEndpoints.md)
