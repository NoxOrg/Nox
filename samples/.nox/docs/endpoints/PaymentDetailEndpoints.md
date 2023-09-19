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

#### Get Customer relation by ID
- **GET** `/api/PaymentDetails/{key}/Customers/{relatedKey}/$ref`
  - Description: Retrieve an existing Customers relation for a specific PaymentDetail.

#### Get Customer relations
- **GET** `/api/PaymentDetails/{key}/Customers/$ref`
  - Description: Retrieve all Customers relations for a specific PaymentDetail.
  
#### Create Customer relation
- **POST** `/api/PaymentDetails/{key}/Customers/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific PaymentDetail.

#### Update Customer relation
- **PUT** `/api/PaymentDetails/{key}/Customers/{relatedKey}/$ref`
  - Description: Update an existing Customer relation for a specific PaymentDetail.
  
#### Partially Update Customer relation
- **PATCH** `/api/PaymentDetails/{key}/Customers/{relatedKey}/$ref`
  - Description: Partially update an existing Customer relation for a specific PaymentDetail.

#### Delete Customer relation
- **DELETE** `/api/PaymentDetails/{key}/Customers/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific PaymentDetail.

### PaymentProvider

#### Get PaymentProvider relation by ID
- **GET** `/api/PaymentDetails/{key}/PaymentProviders/{relatedKey}/$ref`
  - Description: Retrieve an existing PaymentProviders relation for a specific PaymentDetail.

#### Get PaymentProvider relations
- **GET** `/api/PaymentDetails/{key}/PaymentProviders/$ref`
  - Description: Retrieve all PaymentProviders relations for a specific PaymentDetail.
  
#### Create PaymentProvider relation
- **POST** `/api/PaymentDetails/{key}/PaymentProviders/{relatedKey}/$ref`
  - Description: Create a new PaymentProvider relation for a specific PaymentDetail.

#### Update PaymentProvider relation
- **PUT** `/api/PaymentDetails/{key}/PaymentProviders/{relatedKey}/$ref`
  - Description: Update an existing PaymentProvider relation for a specific PaymentDetail.
  
#### Partially Update PaymentProvider relation
- **PATCH** `/api/PaymentDetails/{key}/PaymentProviders/{relatedKey}/$ref`
  - Description: Partially update an existing PaymentProvider relation for a specific PaymentDetail.

#### Delete PaymentProvider relation
- **DELETE** `/api/PaymentDetails/{key}/PaymentProviders/{relatedKey}/$ref`
  - Description: Delete an existing PaymentProvider relation for a specific PaymentDetail.

## Related Entities

[Customer](CustomerEndpoints.md)

[PaymentProvider](PaymentProviderEndpoints.md)
