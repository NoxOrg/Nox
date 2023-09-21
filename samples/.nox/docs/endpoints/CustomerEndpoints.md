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

#### Get PaymentDetail relation by ID
- **GET** `/api/Customers/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Retrieve an existing PaymentDetails relation for a specific Customer.

#### Get PaymentDetail relations
- **GET** `/api/Customers/{key}/PaymentDetails/$ref`
  - Description: Retrieve all PaymentDetails relations for a specific Customer.
  
#### Create PaymentDetail relation
- **POST** `/api/Customers/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Create a new PaymentDetail relation for a specific Customer.

#### Update PaymentDetail relation
- **PUT** `/api/Customers/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Update an existing PaymentDetail relation for a specific Customer.
  
#### Partially Update PaymentDetail relation
- **PATCH** `/api/Customers/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Partially update an existing PaymentDetail relation for a specific Customer.

#### Delete PaymentDetail relation
- **DELETE** `/api/Customers/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Delete an existing PaymentDetail relation for a specific Customer.

### Booking

#### Get Booking relation by ID
- **GET** `/api/Customers/{key}/Bookings/{relatedKey}/$ref`
  - Description: Retrieve an existing Bookings relation for a specific Customer.

#### Get Booking relations
- **GET** `/api/Customers/{key}/Bookings/$ref`
  - Description: Retrieve all Bookings relations for a specific Customer.
  
#### Create Booking relation
- **POST** `/api/Customers/{key}/Bookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Customer.

#### Update Booking relation
- **PUT** `/api/Customers/{key}/Bookings/{relatedKey}/$ref`
  - Description: Update an existing Booking relation for a specific Customer.
  
#### Partially Update Booking relation
- **PATCH** `/api/Customers/{key}/Bookings/{relatedKey}/$ref`
  - Description: Partially update an existing Booking relation for a specific Customer.

#### Delete Booking relation
- **DELETE** `/api/Customers/{key}/Bookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Customer.

### Transaction

#### Get Transaction relation by ID
- **GET** `/api/Customers/{key}/Transactions/{relatedKey}/$ref`
  - Description: Retrieve an existing Transactions relation for a specific Customer.

#### Get Transaction relations
- **GET** `/api/Customers/{key}/Transactions/$ref`
  - Description: Retrieve all Transactions relations for a specific Customer.
  
#### Create Transaction relation
- **POST** `/api/Customers/{key}/Transactions/{relatedKey}/$ref`
  - Description: Create a new Transaction relation for a specific Customer.

#### Update Transaction relation
- **PUT** `/api/Customers/{key}/Transactions/{relatedKey}/$ref`
  - Description: Update an existing Transaction relation for a specific Customer.
  
#### Partially Update Transaction relation
- **PATCH** `/api/Customers/{key}/Transactions/{relatedKey}/$ref`
  - Description: Partially update an existing Transaction relation for a specific Customer.

#### Delete Transaction relation
- **DELETE** `/api/Customers/{key}/Transactions/{relatedKey}/$ref`
  - Description: Delete an existing Transaction relation for a specific Customer.

### Country

#### Get Country relation by ID
- **GET** `/api/Customers/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific Customer.

#### Get Country relations
- **GET** `/api/Customers/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific Customer.
  
#### Create Country relation
- **POST** `/api/Customers/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Customer.

#### Update Country relation
- **PUT** `/api/Customers/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific Customer.
  
#### Partially Update Country relation
- **PATCH** `/api/Customers/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific Customer.

#### Delete Country relation
- **DELETE** `/api/Customers/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Customer.

## Related Entities

[PaymentDetail](PaymentDetailEndpoints.md)

[Booking](BookingEndpoints.md)

[Transaction](TransactionEndpoints.md)

[Country](CountryEndpoints.md)
