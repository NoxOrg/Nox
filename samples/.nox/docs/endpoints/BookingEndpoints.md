<<<<<<< main
# API Endpoints for the Booking entity

This document provides information about the various endpoints available in our API for the Booking entity.

## Booking Endpoints

### Get Booking Count
- **GET** `/api/Bookings/$count`
  - Description: Retrieve the number of Bookings.

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

#### Get Customer relations
- **GET** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Retrieve all existing Customers relations for a specific Booking.
  
#### Create Customer relation
- **POST** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Booking.
  
#### Update Customer relation
- **PUT** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Updates an existing Customer relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Updates the Customer relations for a specific Booking.

#### Delete Customer relation
- **DELETE** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Booking.

#### Delete Customer relations
- **DELETE** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Delete all existing Customers relations for a specific Booking.

#### Get Customer
- **GET** `/api/Bookings/{key}/BookingForCustomer`
  - Description: Retrieve all existing Customers for a specific Booking.
  
#### Create Customer
- **POST** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}`
  - Description: Create a new Customer for a specific Booking.
  
#### Update Customer
- **PUT** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}`
  - Description: Updates an existing Customer for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingForCustomer`
  - Description: Updates the Customer for a specific Booking.

#### Delete Customer
- **DELETE** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}`
  - Description: Delete an existing Customer for a specific Booking.

#### Delete Customer
- **DELETE** `/api/Bookings/{key}/BookingForCustomer`
  - Description: Delete all existing Customers for a specific Booking.

### VendingMachine

#### Get VendingMachine relations
- **GET** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific Booking.
  
#### Create VendingMachine relation
- **POST** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific Booking.
  
#### Update VendingMachine relation
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Updates the VendingMachine relations for a specific Booking.

#### Delete VendingMachine relation
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific Booking.

#### Delete VendingMachine relations
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Delete all existing VendingMachines relations for a specific Booking.

#### Get VendingMachine
- **GET** `/api/Bookings/{key}/BookingRelatedVendingMachine`
  - Description: Retrieve all existing VendingMachines for a specific Booking.
  
#### Create VendingMachine
- **POST** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}`
  - Description: Create a new VendingMachine for a specific Booking.
  
#### Update VendingMachine
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}`
  - Description: Updates an existing VendingMachine for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine`
  - Description: Updates the VendingMachine for a specific Booking.

#### Delete VendingMachine
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}`
  - Description: Delete an existing VendingMachine for a specific Booking.

#### Delete VendingMachine
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine`
  - Description: Delete all existing VendingMachines for a specific Booking.

### Commission

#### Get Commission relations
- **GET** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Retrieve all existing Commissions relations for a specific Booking.
  
#### Create Commission relation
- **POST** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Create a new Commission relation for a specific Booking.
  
#### Update Commission relation
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Updates an existing Commission relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Updates the Commission relations for a specific Booking.

#### Delete Commission relation
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Delete an existing Commission relation for a specific Booking.

#### Delete Commission relations
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Delete all existing Commissions relations for a specific Booking.

#### Get Commission
- **GET** `/api/Bookings/{key}/BookingFeesForCommission`
  - Description: Retrieve all existing Commissions for a specific Booking.
  
#### Create Commission
- **POST** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}`
  - Description: Create a new Commission for a specific Booking.
  
#### Update Commission
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}`
  - Description: Updates an existing Commission for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission`
  - Description: Updates the Commission for a specific Booking.

#### Delete Commission
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}`
  - Description: Delete an existing Commission for a specific Booking.

#### Delete Commission
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission`
  - Description: Delete all existing Commissions for a specific Booking.

### Transaction

#### Get Transaction relations
- **GET** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Retrieve all existing Transactions relations for a specific Booking.
  
#### Create Transaction relation
- **POST** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Create a new Transaction relation for a specific Booking.
  
#### Update Transaction relation
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Updates an existing Transaction relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Updates the Transaction relations for a specific Booking.

#### Delete Transaction relation
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Delete an existing Transaction relation for a specific Booking.

#### Delete Transaction relations
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Delete all existing Transactions relations for a specific Booking.

#### Get Transaction
- **GET** `/api/Bookings/{key}/BookingRelatedTransaction`
  - Description: Retrieve all existing Transactions for a specific Booking.
  
#### Create Transaction
- **POST** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}`
  - Description: Create a new Transaction for a specific Booking.
  
#### Update Transaction
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}`
  - Description: Updates an existing Transaction for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction`
  - Description: Updates the Transaction for a specific Booking.

#### Delete Transaction
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}`
  - Description: Delete an existing Transaction for a specific Booking.

#### Delete Transaction
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction`
  - Description: Delete all existing Transactions for a specific Booking.

## Related Entities

[Customer](CustomerEndpoints.md)

[VendingMachine](VendingMachineEndpoints.md)

[Commission](CommissionEndpoints.md)

[Transaction](TransactionEndpoints.md)

=======
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

#### Get Customer relations
- **GET** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Retrieve all existing Customers relations for a specific Booking.
  
#### Create Customer relation
- **POST** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Booking.
  
#### Update Customer relation
- **PUT** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Updates an existing Customer relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Updates the Customer relations for a specific Booking.

#### Delete Customer relation
- **DELETE** `/api/Bookings/{key}/BookingForCustomer/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Booking.

#### Delete Customer relations
- **DELETE** `/api/Bookings/{key}/BookingForCustomer/$ref`
  - Description: Delete all existing Customers relations for a specific Booking.

### VendingMachine

#### Get VendingMachine relations
- **GET** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific Booking.
  
#### Create VendingMachine relation
- **POST** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific Booking.
  
#### Update VendingMachine relation
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Updates the VendingMachine relations for a specific Booking.

#### Delete VendingMachine relation
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific Booking.

#### Delete VendingMachine relations
- **DELETE** `/api/Bookings/{key}/BookingRelatedVendingMachine/$ref`
  - Description: Delete all existing VendingMachines relations for a specific Booking.

### Commission

#### Get Commission relations
- **GET** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Retrieve all existing Commissions relations for a specific Booking.
  
#### Create Commission relation
- **POST** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Create a new Commission relation for a specific Booking.
  
#### Update Commission relation
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Updates an existing Commission relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Updates the Commission relations for a specific Booking.

#### Delete Commission relation
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission/{relatedKey}/$ref`
  - Description: Delete an existing Commission relation for a specific Booking.

#### Delete Commission relations
- **DELETE** `/api/Bookings/{key}/BookingFeesForCommission/$ref`
  - Description: Delete all existing Commissions relations for a specific Booking.

### Transaction

#### Get Transaction relations
- **GET** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Retrieve all existing Transactions relations for a specific Booking.
  
#### Create Transaction relation
- **POST** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Create a new Transaction relation for a specific Booking.
  
#### Update Transaction relation
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Updates an existing Transaction relation for a specific Booking.
- **PUT** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Updates the Transaction relations for a specific Booking.

#### Delete Transaction relation
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction/{relatedKey}/$ref`
  - Description: Delete an existing Transaction relation for a specific Booking.

#### Delete Transaction relations
- **DELETE** `/api/Bookings/{key}/BookingRelatedTransaction/$ref`
  - Description: Delete all existing Transactions relations for a specific Booking.

## Related Entities

[Customer](CustomerEndpoints.md)

[VendingMachine](VendingMachineEndpoints.md)

[Commission](CommissionEndpoints.md)

[Transaction](TransactionEndpoints.md)

>>>>>>> Factory classes refactor has been completed (without tests)
