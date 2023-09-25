# API Endpoints for the PaymentDetail entity

This document provides information about the various endpoints available in our API for the PaymentDetail entity.

## PaymentDetail Endpoints

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

#### Delete Customer relation
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific PaymentDetail.

#### Delete Customer relations
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsUsedByCustomer/$ref`
  - Description: Delete all existing Customers relations for a specific PaymentDetail.

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

#### Delete PaymentProvider relation
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/{relatedKey}/$ref`
  - Description: Delete an existing PaymentProvider relation for a specific PaymentDetail.

#### Delete PaymentProvider relations
- **DELETE** `/api/PaymentDetails/{key}/PaymentDetailsRelatedPaymentProvider/$ref`
  - Description: Delete all existing PaymentProviders relations for a specific PaymentDetail.

## Related Entities

[Customer](CustomerEndpoints.md)

[PaymentProvider](PaymentProviderEndpoints.md)
