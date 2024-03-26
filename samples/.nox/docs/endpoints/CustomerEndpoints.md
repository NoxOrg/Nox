# API Endpoints for the Customer entity

This document provides information about the various endpoints available in our API for the Customer entity.

## Customer Endpoints

### Get Customer Count
- **GET** `/api/Customers/$count`
  - Description: Retrieve the number of Customers.

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

#### Get PaymentDetail
- **GET** `/api/Customers/{key}/CustomerRelatedPaymentDetails`
  - Description: Retrieve all existing PaymentDetails for a specific Customer.
  
#### Create PaymentDetail
- **POST** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}`
  - Description: Create a new PaymentDetail for a specific Customer.
  
#### Update PaymentDetail
- **PUT** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}`
  - Description: Updates an existing PaymentDetail for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedPaymentDetails`
  - Description: Updates the PaymentDetail for a specific Customer.

#### Delete PaymentDetail
- **DELETE** `/api/Customers/{key}/CustomerRelatedPaymentDetails/{relatedKey}`
  - Description: Delete an existing PaymentDetail for a specific Customer.

#### Delete PaymentDetail
- **DELETE** `/api/Customers/{key}/CustomerRelatedPaymentDetails`
  - Description: Delete all existing PaymentDetails for a specific Customer.
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

#### Get Booking
- **GET** `/api/Customers/{key}/CustomerRelatedBookings`
  - Description: Retrieve all existing Bookings for a specific Customer.
  
#### Create Booking
- **POST** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}`
  - Description: Create a new Booking for a specific Customer.
  
#### Update Booking
- **PUT** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}`
  - Description: Updates an existing Booking for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedBookings`
  - Description: Updates the Booking for a specific Customer.

#### Delete Booking
- **DELETE** `/api/Customers/{key}/CustomerRelatedBookings/{relatedKey}`
  - Description: Delete an existing Booking for a specific Customer.

#### Delete Booking
- **DELETE** `/api/Customers/{key}/CustomerRelatedBookings`
  - Description: Delete all existing Bookings for a specific Customer.
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

#### Get Transaction
- **GET** `/api/Customers/{key}/CustomerRelatedTransactions`
  - Description: Retrieve all existing Transactions for a specific Customer.
  
#### Create Transaction
- **POST** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}`
  - Description: Create a new Transaction for a specific Customer.
  
#### Update Transaction
- **PUT** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}`
  - Description: Updates an existing Transaction for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerRelatedTransactions`
  - Description: Updates the Transaction for a specific Customer.

#### Delete Transaction
- **DELETE** `/api/Customers/{key}/CustomerRelatedTransactions/{relatedKey}`
  - Description: Delete an existing Transaction for a specific Customer.

#### Delete Transaction
- **DELETE** `/api/Customers/{key}/CustomerRelatedTransactions`
  - Description: Delete all existing Transactions for a specific Customer.
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

#### Get Country
- **GET** `/api/Customers/{key}/CustomerBaseCountry`
  - Description: Retrieve all existing Countries for a specific Customer.
  
#### Create Country
- **POST** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}`
  - Description: Create a new Country for a specific Customer.
  
#### Update Country
- **PUT** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}`
  - Description: Updates an existing Country for a specific Customer.
- **PUT** `/api/Customers/{key}/CustomerBaseCountry`
  - Description: Updates the Country for a specific Customer.

#### Delete Country
- **DELETE** `/api/Customers/{key}/CustomerBaseCountry/{relatedKey}`
  - Description: Delete an existing Country for a specific Customer.

#### Delete Country
- **DELETE** `/api/Customers/{key}/CustomerBaseCountry`
  - Description: Delete all existing Countries for a specific Customer.

## Other Related Endpoints

- **GET** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider`

- **POST** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider`

- **PUT** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider`

- **PATCH** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider`

- **GET** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider/$ref`

- **POST** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider/{paymentProviderKey}/$ref`

- **PUT** `/api/Customers/{customersKey}/PaymentDetails/{paymentDetailsKey}/PaymentProvider/{paymentProviderKey}/$ref`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine`

- **PATCH** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine/$ref`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine/{vendingMachineKey}/$ref`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/VendingMachine/{vendingMachineKey}/$ref`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission`

- **PATCH** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission/$ref`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission/{commissionKey}/$ref`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Commission/{commissionKey}/$ref`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction`

- **PATCH** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction`

- **GET** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction/$ref`

- **POST** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction/{transactionKey}/$ref`

- **PUT** `/api/Customers/{customersKey}/Bookings/{bookingsKey}/Transaction/{transactionKey}/$ref`

- **GET** `/api/Customers/{customersKey}/Country/{countryKey}/Currency`

- **POST** `/api/Customers/{customersKey}/Country/{countryKey}/Currency`

- **PUT** `/api/Customers/{customersKey}/Country/{countryKey}/Currency`

- **PATCH** `/api/Customers/{customersKey}/Country/{countryKey}/Currency`

- **GET** `/api/Customers/{customersKey}/Country/{countryKey}/Currency/$ref`

- **POST** `/api/Customers/{customersKey}/Country/{countryKey}/Currency/{currencyKey}/$ref`

- **PUT** `/api/Customers/{customersKey}/Country/{countryKey}/Currency/{currencyKey}/$ref`

## Related Entities

[PaymentDetail](PaymentDetailEndpoints.md)
[Booking](BookingEndpoints.md)
[Transaction](TransactionEndpoints.md)
[Country](CountryEndpoints.md)