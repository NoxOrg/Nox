# API Endpoints for the Transaction entity

This document provides information about the various endpoints available in our API for the Transaction entity.

## Transaction Endpoints

### Get Transaction Count
- **GET** `/api/Transactions/$count`
  - Description: Retrieve the number of Transactions.

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

#### Get Customer relations
- **GET** `/api/Transactions/{key}/TransactionForCustomer/$ref`
  - Description: Retrieve all existing Customers relations for a specific Transaction.
  
#### Create Customer relation
- **POST** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Transaction.
  
#### Update Customer relation
- **PUT** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}/$ref`
  - Description: Updates an existing Customer relation for a specific Transaction.
- **PUT** `/api/Transactions/{key}/TransactionForCustomer/$ref`
  - Description: Updates the Customer relations for a specific Transaction.

#### Delete Customer relation
- **DELETE** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Transaction.

#### Delete Customer relations
- **DELETE** `/api/Transactions/{key}/TransactionForCustomer/$ref`
  - Description: Delete all existing Customers relations for a specific Transaction.

#### Get Customer
- **GET** `/api/Transactions/{key}/TransactionForCustomer`
  - Description: Retrieve all existing Customers for a specific Transaction.
  
#### Create Customer
- **POST** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}`
  - Description: Create a new Customer for a specific Transaction.
  
#### Update Customer
- **PUT** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}`
  - Description: Updates an existing Customer for a specific Transaction.
- **PUT** `/api/Transactions/{key}/TransactionForCustomer`
  - Description: Updates the Customer for a specific Transaction.

#### Delete Customer
- **DELETE** `/api/Transactions/{key}/TransactionForCustomer/{relatedKey}`
  - Description: Delete an existing Customer for a specific Transaction.

#### Delete Customer
- **DELETE** `/api/Transactions/{key}/TransactionForCustomer`
  - Description: Delete all existing Customers for a specific Transaction.
### Booking

#### Get Booking relations
- **GET** `/api/Transactions/{key}/TransactionForBooking/$ref`
  - Description: Retrieve all existing Bookings relations for a specific Transaction.
  
#### Create Booking relation
- **POST** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Transaction.
  
#### Update Booking relation
- **PUT** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}/$ref`
  - Description: Updates an existing Booking relation for a specific Transaction.
- **PUT** `/api/Transactions/{key}/TransactionForBooking/$ref`
  - Description: Updates the Booking relations for a specific Transaction.

#### Delete Booking relation
- **DELETE** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Transaction.

#### Delete Booking relations
- **DELETE** `/api/Transactions/{key}/TransactionForBooking/$ref`
  - Description: Delete all existing Bookings relations for a specific Transaction.

#### Get Booking
- **GET** `/api/Transactions/{key}/TransactionForBooking`
  - Description: Retrieve all existing Bookings for a specific Transaction.
  
#### Create Booking
- **POST** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}`
  - Description: Create a new Booking for a specific Transaction.
  
#### Update Booking
- **PUT** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}`
  - Description: Updates an existing Booking for a specific Transaction.
- **PUT** `/api/Transactions/{key}/TransactionForBooking`
  - Description: Updates the Booking for a specific Transaction.

#### Delete Booking
- **DELETE** `/api/Transactions/{key}/TransactionForBooking/{relatedKey}`
  - Description: Delete an existing Booking for a specific Transaction.

#### Delete Booking
- **DELETE** `/api/Transactions/{key}/TransactionForBooking`
  - Description: Delete all existing Bookings for a specific Transaction.

## Other Related Endpoints

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}`

- **PATCH** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/$ref`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/$ref`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/$ref`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}/$ref`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}/$ref`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/PaymentDetails/{paymentDetailsKey}/$ref`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **PATCH** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/$ref`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/$ref`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/$ref`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **DELETE** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country`

- **PATCH** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country`

- **GET** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country/$ref`

- **POST** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country/{countryKey}/$ref`

- **PUT** `/api/Transactions/{transactionsKey}/Customer/{customerKey}/Country/{countryKey}/$ref`

## Related Entities

[Customer](CustomerEndpoints.md)
[Booking](BookingEndpoints.md)