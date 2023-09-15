# API Endpoints for the Transaction entity

This document provides information about the various endpoints available in our API for the Transaction entity.

## Transaction Endpoints

### Get Transaction by ID
- **GET** `/api/Transactions/{key}`
  - Description: Retrieve information about a Transaction by ID.
  
### Get Transactions
- **GET** `/api/Transactions`
  - Description: Retrieve information about Transactions.

### Create Transaction
- **POST** `/api/Transactions`
  - Description: Create a new Transaction.

### Update Transaction
- **PUT** `/api/Transactions/{key}`
  - Description: Update an existing Transaction.

### Partially Update Transaction
- **PATCH** `/api/Transactions/{key}`
  - Description: Partially update an existing Transaction.
 
### Delete Transaction
- **DELETE** `/api/Transactions/{key}`
  - Description: Delete an existing Transaction.

## Relationships Endpoints

### Customer

#### Get Customer relation by ID
- **GET** `/api/Transactions/{key}/Customers/{relatedKey}/$ref`
  - Description: Retrieve an existing Customers relation for a specific Transaction.

#### Get Customer relations
- **GET** `/api/Transactions/{key}/Customers/$ref`
  - Description: Retrieve all Customers relations for a specific Transaction.
  
#### Create Customer relation
- **POST** `/api/Transactions/{key}/Customers/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Transaction.
  
#### Update Customer relation
- **PUT** `/api/Transactions/{key}/Customers/{relatedKey}/$ref`
  - Description: Update an existing Customer relation for a specific Transaction.
  
#### Partially Update Customer relation
- **PATCH** `/api/Transactions/{key}/Customers/{relatedKey}/$ref`
  - Description: Partially update an existing Customer relation for a specific Transaction.

#### Delete Customer relation
- **DELETE** `/api/Transactions/{key}/Customers/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Transaction.

### Booking

#### Get Booking relation by ID
- **GET** `/api/Transactions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Retrieve an existing Bookings relation for a specific Transaction.

#### Get Booking relations
- **GET** `/api/Transactions/{key}/Bookings/$ref`
  - Description: Retrieve all Bookings relations for a specific Transaction.
  
#### Create Booking relation
- **POST** `/api/Transactions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Transaction.
  
#### Update Booking relation
- **PUT** `/api/Transactions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Update an existing Booking relation for a specific Transaction.
  
#### Partially Update Booking relation
- **PATCH** `/api/Transactions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Partially update an existing Booking relation for a specific Transaction.

#### Delete Booking relation
- **DELETE** `/api/Transactions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Transaction.

## Related Entities

[Customer](CustomerEndpoints.md)

[Booking](BookingEndpoints.md)
