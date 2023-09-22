# API Endpoints for the Booking entity

This document provides information about the various endpoints available in our API for the Booking entity.

## Booking Endpoints

### Get Booking by ID
- **GET** `/api/Bookings/{key}`
  - Description: Retrieve information about a Booking by ID.
  
### Get Bookings
- **GET** `/api/Bookings`
  - Description: Retrieve information about Bookings.

### Create Booking
- **POST** `/api/Bookings`
  - Description: Create a new Booking.

### Update Booking
- **PUT** `/api/Bookings/{key}`
  - Description: Update an existing Booking.

### Partially Update Booking
- **PATCH** `/api/Bookings/{key}`
  - Description: Partially update an existing Booking.
 
### Delete Booking
- **DELETE** `/api/Bookings/{key}`
  - Description: Delete an existing Booking.

## Relationships Endpoints

### Customer

#### Get Customer relation by ID
- **GET** `/api/Bookings/{key}/Customers/{relatedKey}/$ref`
  - Description: Retrieve an existing Customers relation for a specific Booking.

#### Get Customer relations
- **GET** `/api/Bookings/{key}/Customers/$ref`
  - Description: Retrieve all Customers relations for a specific Booking.
  
#### Create Customer relation
- **POST** `/api/Bookings/{key}/Customers/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Booking.

#### Update Customer relation
- **PUT** `/api/Bookings/{key}/Customers/{relatedKey}/$ref`
  - Description: Update an existing Customer relation for a specific Booking.
  
#### Partially Update Customer relation
- **PATCH** `/api/Bookings/{key}/Customers/{relatedKey}/$ref`
  - Description: Partially update an existing Customer relation for a specific Booking.

#### Delete Customer relation
- **DELETE** `/api/Bookings/{key}/Customers/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Booking.

### VendingMachine

#### Get VendingMachine relation by ID
- **GET** `/api/Bookings/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Retrieve an existing VendingMachines relation for a specific Booking.

#### Get VendingMachine relations
- **GET** `/api/Bookings/{key}/VendingMachines/$ref`
  - Description: Retrieve all VendingMachines relations for a specific Booking.
  
#### Create VendingMachine relation
- **POST** `/api/Bookings/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific Booking.

#### Update VendingMachine relation
- **PUT** `/api/Bookings/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Update an existing VendingMachine relation for a specific Booking.
  
#### Partially Update VendingMachine relation
- **PATCH** `/api/Bookings/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Partially update an existing VendingMachine relation for a specific Booking.

#### Delete VendingMachine relation
- **DELETE** `/api/Bookings/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific Booking.

### Commission

#### Get Commission relation by ID
- **GET** `/api/Bookings/{key}/Commissions/{relatedKey}/$ref`
  - Description: Retrieve an existing Commissions relation for a specific Booking.

#### Get Commission relations
- **GET** `/api/Bookings/{key}/Commissions/$ref`
  - Description: Retrieve all Commissions relations for a specific Booking.
  
#### Create Commission relation
- **POST** `/api/Bookings/{key}/Commissions/{relatedKey}/$ref`
  - Description: Create a new Commission relation for a specific Booking.

#### Update Commission relation
- **PUT** `/api/Bookings/{key}/Commissions/{relatedKey}/$ref`
  - Description: Update an existing Commission relation for a specific Booking.
  
#### Partially Update Commission relation
- **PATCH** `/api/Bookings/{key}/Commissions/{relatedKey}/$ref`
  - Description: Partially update an existing Commission relation for a specific Booking.

#### Delete Commission relation
- **DELETE** `/api/Bookings/{key}/Commissions/{relatedKey}/$ref`
  - Description: Delete an existing Commission relation for a specific Booking.

### Transaction

#### Get Transaction relation by ID
- **GET** `/api/Bookings/{key}/Transactions/{relatedKey}/$ref`
  - Description: Retrieve an existing Transactions relation for a specific Booking.

#### Get Transaction relations
- **GET** `/api/Bookings/{key}/Transactions/$ref`
  - Description: Retrieve all Transactions relations for a specific Booking.
  
#### Create Transaction relation
- **POST** `/api/Bookings/{key}/Transactions/{relatedKey}/$ref`
  - Description: Create a new Transaction relation for a specific Booking.

#### Update Transaction relation
- **PUT** `/api/Bookings/{key}/Transactions/{relatedKey}/$ref`
  - Description: Update an existing Transaction relation for a specific Booking.
  
#### Partially Update Transaction relation
- **PATCH** `/api/Bookings/{key}/Transactions/{relatedKey}/$ref`
  - Description: Partially update an existing Transaction relation for a specific Booking.

#### Delete Transaction relation
- **DELETE** `/api/Bookings/{key}/Transactions/{relatedKey}/$ref`
  - Description: Delete an existing Transaction relation for a specific Booking.

## Related Entities

[Customer](CustomerEndpoints.md)

[VendingMachine](VendingMachineEndpoints.md)

[Commission](CommissionEndpoints.md)

[Transaction](TransactionEndpoints.md)
