# API Endpoints for the VendingMachine entity

This document provides information about the various endpoints available in our API for the VendingMachine entity.

## VendingMachine Endpoints

### Get VendingMachine Count
- **GET** `/api/VendingMachines/$count`
  - Description: Retrieve the number of VendingMachines.

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

#### Get Country relations
- **GET** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific VendingMachine.
  
#### Create Country relation
- **POST** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific VendingMachine.
  
#### Update Country relation
- **PUT** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/$ref`
  - Description: Updates the Country relations for a specific VendingMachine.

#### Delete Country relation
- **DELETE** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific VendingMachine.

#### Delete Country relations
- **DELETE** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/$ref`
  - Description: Delete all existing Countries relations for a specific VendingMachine.

#### Get Country
- **GET** `/api/VendingMachines/{key}/VendingMachineInstallationCountry`
  - Description: Retrieve all existing Countries for a specific VendingMachine.
  
#### Create Country
- **POST** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}`
  - Description: Create a new Country for a specific VendingMachine.
  
#### Update Country
- **PUT** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}`
  - Description: Updates an existing Country for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineInstallationCountry`
  - Description: Updates the Country for a specific VendingMachine.

#### Delete Country
- **DELETE** `/api/VendingMachines/{key}/VendingMachineInstallationCountry/{relatedKey}`
  - Description: Delete an existing Country for a specific VendingMachine.

#### Delete Country
- **DELETE** `/api/VendingMachines/{key}/VendingMachineInstallationCountry`
  - Description: Delete all existing Countries for a specific VendingMachine.

### LandLord

#### Get LandLord relations
- **GET** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/$ref`
  - Description: Retrieve all existing LandLords relations for a specific VendingMachine.
  
#### Create LandLord relation
- **POST** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}/$ref`
  - Description: Create a new LandLord relation for a specific VendingMachine.
  
#### Update LandLord relation
- **PUT** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}/$ref`
  - Description: Updates an existing LandLord relation for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/$ref`
  - Description: Updates the LandLord relations for a specific VendingMachine.

#### Delete LandLord relation
- **DELETE** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}/$ref`
  - Description: Delete an existing LandLord relation for a specific VendingMachine.

#### Delete LandLord relations
- **DELETE** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/$ref`
  - Description: Delete all existing LandLords relations for a specific VendingMachine.

#### Get LandLord
- **GET** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord`
  - Description: Retrieve all existing LandLords for a specific VendingMachine.
  
#### Create LandLord
- **POST** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}`
  - Description: Create a new LandLord for a specific VendingMachine.
  
#### Update LandLord
- **PUT** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}`
  - Description: Updates an existing LandLord for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord`
  - Description: Updates the LandLord for a specific VendingMachine.

#### Delete LandLord
- **DELETE** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord/{relatedKey}`
  - Description: Delete an existing LandLord for a specific VendingMachine.

#### Delete LandLord
- **DELETE** `/api/VendingMachines/{key}/VendingMachineContractedAreaLandLord`
  - Description: Delete all existing LandLords for a specific VendingMachine.

### Booking

#### Get Booking relations
- **GET** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/$ref`
  - Description: Retrieve all existing Bookings relations for a specific VendingMachine.
  
#### Create Booking relation
- **POST** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific VendingMachine.
  
#### Update Booking relation
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}/$ref`
  - Description: Updates an existing Booking relation for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/$ref`
  - Description: Updates the Booking relations for a specific VendingMachine.

#### Delete Booking relation
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific VendingMachine.

#### Delete Booking relations
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/$ref`
  - Description: Delete all existing Bookings relations for a specific VendingMachine.

#### Get Booking
- **GET** `/api/VendingMachines/{key}/VendingMachineRelatedBookings`
  - Description: Retrieve all existing Bookings for a specific VendingMachine.
  
#### Create Booking
- **POST** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}`
  - Description: Create a new Booking for a specific VendingMachine.
  
#### Update Booking
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}`
  - Description: Updates an existing Booking for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedBookings`
  - Description: Updates the Booking for a specific VendingMachine.

#### Delete Booking
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedBookings/{relatedKey}`
  - Description: Delete an existing Booking for a specific VendingMachine.

#### Delete Booking
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedBookings`
  - Description: Delete all existing Bookings for a specific VendingMachine.

### CashStockOrder

#### Get CashStockOrder relations
- **GET** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/$ref`
  - Description: Retrieve all existing CashStockOrders relations for a specific VendingMachine.
  
#### Create CashStockOrder relation
- **POST** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}/$ref`
  - Description: Create a new CashStockOrder relation for a specific VendingMachine.
  
#### Update CashStockOrder relation
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}/$ref`
  - Description: Updates an existing CashStockOrder relation for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/$ref`
  - Description: Updates the CashStockOrder relations for a specific VendingMachine.

#### Delete CashStockOrder relation
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}/$ref`
  - Description: Delete an existing CashStockOrder relation for a specific VendingMachine.

#### Delete CashStockOrder relations
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/$ref`
  - Description: Delete all existing CashStockOrders relations for a specific VendingMachine.

#### Get CashStockOrder
- **GET** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders`
  - Description: Retrieve all existing CashStockOrders for a specific VendingMachine.
  
#### Create CashStockOrder
- **POST** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}`
  - Description: Create a new CashStockOrder for a specific VendingMachine.
  
#### Update CashStockOrder
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}`
  - Description: Updates an existing CashStockOrder for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders`
  - Description: Updates the CashStockOrder for a specific VendingMachine.

#### Delete CashStockOrder
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders/{relatedKey}`
  - Description: Delete an existing CashStockOrder for a specific VendingMachine.

#### Delete CashStockOrder
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRelatedCashStockOrders`
  - Description: Delete all existing CashStockOrders for a specific VendingMachine.

### MinimumCashStock

#### Get MinimumCashStock relations
- **GET** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/$ref`
  - Description: Retrieve all existing MinimumCashStocks relations for a specific VendingMachine.
  
#### Create MinimumCashStock relation
- **POST** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}/$ref`
  - Description: Create a new MinimumCashStock relation for a specific VendingMachine.
  
#### Update MinimumCashStock relation
- **PUT** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}/$ref`
  - Description: Updates an existing MinimumCashStock relation for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/$ref`
  - Description: Updates the MinimumCashStock relations for a specific VendingMachine.

#### Delete MinimumCashStock relation
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}/$ref`
  - Description: Delete an existing MinimumCashStock relation for a specific VendingMachine.

#### Delete MinimumCashStock relations
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/$ref`
  - Description: Delete all existing MinimumCashStocks relations for a specific VendingMachine.

#### Get MinimumCashStock
- **GET** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks`
  - Description: Retrieve all existing MinimumCashStocks for a specific VendingMachine.
  
#### Create MinimumCashStock
- **POST** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}`
  - Description: Create a new MinimumCashStock for a specific VendingMachine.
  
#### Update MinimumCashStock
- **PUT** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}`
  - Description: Updates an existing MinimumCashStock for a specific VendingMachine.
- **PUT** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks`
  - Description: Updates the MinimumCashStock for a specific VendingMachine.

#### Delete MinimumCashStock
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks/{relatedKey}`
  - Description: Delete an existing MinimumCashStock for a specific VendingMachine.

#### Delete MinimumCashStock
- **DELETE** `/api/VendingMachines/{key}/VendingMachineRequiredMinimumCashStocks`
  - Description: Delete all existing MinimumCashStocks for a specific VendingMachine.

## Related Entities

[Country](CountryEndpoints.md)

[LandLord](LandLordEndpoints.md)

[Booking](BookingEndpoints.md)

[CashStockOrder](CashStockOrderEndpoints.md)

[MinimumCashStock](MinimumCashStockEndpoints.md)

