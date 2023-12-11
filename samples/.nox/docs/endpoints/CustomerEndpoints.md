# API Endpoints for the Customer entity

This document provides information about the various endpoints available in our API for the Customer entity.

## Customer Endpoints

### Get Customer by ID
- **GET** `/api/Customers/{key}`
  - Description: Retrieve information about a Customer by ID.
  
### Get Customers
- **GET** `/api/Customers`
  - Description: Retrieve information about Customers.

### Create Customer
- **POST** `/api/Customers`
  - Description: Create a new Customer.

### Update Customer
- **PUT** `/api/Customers/{key}`
  - Description: Update an existing Customer.

### Partially Update Customer
- **PATCH** `/api/Customers/{key}`
  - Description: Partially update an existing Customer.
 
### Delete Customer
- **DELETE** `/api/Customers/{key}`
  - Description: Delete an existing Customer.

## Relationships Endpoints

### PaymentDetail

#### Get PaymentDetail relations
- **GET** `/api/Customers/{key}/CustomerRelatedPaymentDetails/$ref`
  - Description: Retrieve all existing PaymentDetails relations for a specific Customer.
  
#### Create PaymentDetail relation
- **POST** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Create a new PaymentDetail relation for a specific Customer.
  
#### Update PaymentDetail relation
- **PUT** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Updates an existing PaymentDetail relation for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedPaymentDetails/$ref`
  - Description: Updates the PaymentDetail relations for a specific Customer.

#### Delete PaymentDetail relation
- **DELETE** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Delete an existing PaymentDetail relation for a specific Customer.

#### Delete PaymentDetail relations
- **DELETE** `/api/Customers/{key}/CustomerRelatedPaymentDetails/$ref`
  - Description: Delete all existing PaymentDetails relations for a specific Customer.

### Booking

#### Get Booking relations
- **GET** `/api/Customers/{key}/CustomerRelatedBookings/$ref`
  - Description: Retrieve all existing Bookings relations for a specific Customer.
  
#### Create Booking relation
- **POST** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Customer.
  
#### Update Booking relation
- **PUT** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}/$ref`
  - Description: Updates an existing Booking relation for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedBookings/$ref`
  - Description: Updates the Booking relations for a specific Customer.

#### Delete Booking relation
- **DELETE** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Customer.

#### Delete Booking relations
- **DELETE** `/api/Customers/{key}/CustomerRelatedBookings/$ref`
  - Description: Delete all existing Bookings relations for a specific Customer.

### Transaction

#### Get Transaction relations
- **GET** `/api/Customers/{key}/CustomerRelatedTransactions/$ref`
  - Description: Retrieve all existing Transactions relations for a specific Customer.
  
#### Create Transaction relation
- **POST** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}/$ref`
  - Description: Create a new Transaction relation for a specific Customer.
  
#### Update Transaction relation
- **PUT** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}/$ref`
  - Description: Updates an existing Transaction relation for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedTransactions/$ref`
  - Description: Updates the Transaction relations for a specific Customer.

#### Delete Transaction relation
- **DELETE** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}/$ref`
  - Description: Delete an existing Transaction relation for a specific Customer.

#### Delete Transaction relations
- **DELETE** `/api/Customers/{key}/CustomerRelatedTransactions/$ref`
  - Description: Delete all existing Transactions relations for a specific Customer.

### Country

#### Get Country relations
- **GET** `/api/Customers/{key}/CustomerBaseCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Customer.
  
#### Create Country relation
- **POST** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Customer.
  
#### Update Country relation
- **PUT** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerBaseCountry/$ref`
  - Description: Updates the Country relations for a specific Customer.

#### Delete Country relation
- **DELETE** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Customer.

#### Delete Country relations
- **DELETE** `/api/Customers/{key}/CustomerBaseCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Customer.

## Related Entities

[PaymentDetail](PaymentDetailEndpoints.md)

[Booking](BookingEndpoints.md)

[Transaction](TransactionEndpoints.md)

[Country](CountryEndpoints.md)

