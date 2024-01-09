# API Endpoints for the PaymentDetail entity

This document provides information about the various endpoints available in our API for the PaymentDetail entity.

## PaymentDetail Endpoints

### Get PaymentDetail Count
- **GET** `/api/PaymentDetails/$count`
  - Description: Retrieve the number of PaymentDetails.

### Get PaymentDetail by ID
- **GET** `/api/PaymentDetails/{key}`
  - Description: Retrieve information about a PaymentDetail by ID.
  
### Get PaymentDetails
- **GET** `/api/PaymentDetails`
  - Description: Retrieve information about PaymentDetails.

### Create PaymentDetail
- **POST** `/api/PaymentDetails`
  - Description: Create a new PaymentDetail.

### Update PaymentDetail
- **PUT** `/api/PaymentDetails/{key}`
  - Description: Update an existing PaymentDetail.

### Partially Update PaymentDetail
- **PATCH** `/api/PaymentDetails/{key}`
  - Description: Partially update an existing PaymentDetail.
 
### Delete PaymentDetail
- **DELETE** `/api/PaymentDetails/{key}`
  - Description: Delete an existing PaymentDetail.

## Relationships Endpoints

### Customer

#### Get Customer relations
- **GET** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/$ref`
  - Description: Retrieve all existing Customers relations for a specific PaymentDetail.
  
#### Create Customer relation
- **POST** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific PaymentDetail.
  
#### Update Customer relation
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}/$ref`
  - Description: Updates an existing Customer relation for a specific PaymentDetail.
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/$ref`
  - Description: Updates the Customer relations for a specific PaymentDetail.

#### Delete Customer relation
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific PaymentDetail.

#### Delete Customer relations
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/$ref`
  - Description: Delete all existing Customers relations for a specific PaymentDetail.

#### Get Customer
- **GET** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer`
  - Description: Retrieve all existing Customers for a specific PaymentDetail.
  
#### Create Customer
- **POST** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}`
  - Description: Create a new Customer for a specific PaymentDetail.
  
#### Update Customer
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}`
  - Description: Updates an existing Customer for a specific PaymentDetail.
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer`
  - Description: Updates the Customer for a specific PaymentDetail.

#### Delete Customer
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}`
  - Description: Delete an existing Customer for a specific PaymentDetail.

#### Delete Customer
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer`
  - Description: Delete all existing Customers for a specific PaymentDetail.

### PaymentProvider

#### Get PaymentProvider relations
- **GET** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/$ref`
  - Description: Retrieve all existing PaymentProviders relations for a specific PaymentDetail.
  
#### Create PaymentProvider relation
- **POST** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}/$ref`
  - Description: Create a new PaymentProvider relation for a specific PaymentDetail.
  
#### Update PaymentProvider relation
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}/$ref`
  - Description: Updates an existing PaymentProvider relation for a specific PaymentDetail.
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/$ref`
  - Description: Updates the PaymentProvider relations for a specific PaymentDetail.

#### Delete PaymentProvider relation
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}/$ref`
  - Description: Delete an existing PaymentProvider relation for a specific PaymentDetail.

#### Delete PaymentProvider relations
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/$ref`
  - Description: Delete all existing PaymentProviders relations for a specific PaymentDetail.

#### Get PaymentProvider
- **GET** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider`
  - Description: Retrieve all existing PaymentProviders for a specific PaymentDetail.
  
#### Create PaymentProvider
- **POST** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}`
  - Description: Create a new PaymentProvider for a specific PaymentDetail.
  
#### Update PaymentProvider
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}`
  - Description: Updates an existing PaymentProvider for a specific PaymentDetail.
- **PUT** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider`
  - Description: Updates the PaymentProvider for a specific PaymentDetail.

#### Delete PaymentProvider
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}`
  - Description: Delete an existing PaymentProvider for a specific PaymentDetail.

#### Delete PaymentProvider
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider`
  - Description: Delete all existing PaymentProviders for a specific PaymentDetail.


## Other Related Endpoints

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **PATCH** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/$ref`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/$ref`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/$ref`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Bookings/{bookingsKey}/$ref`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}`

- **PATCH** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/$ref`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/$ref`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/$ref`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}/$ref`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}/$ref`

- **DELETE** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Transactions/{transactionsKey}/$ref`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country`

- **PATCH** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country`

- **GET** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country/$ref`

- **POST** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country/{countryKey}/$ref`

- **PUT** `/api/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/Country/{countryKey}/$ref`
## Related Entities

[Customer](CustomerEndpoints.md)

[PaymentProvider](PaymentProviderEndpoints.md)
