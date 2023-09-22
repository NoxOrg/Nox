# API Endpoints for the PaymentProvider entity

This document provides information about the various endpoints available in our API for the PaymentProvider entity.

## PaymentProvider Endpoints

### Get PaymentProvider by ID
- **GET** `/api/PaymentProviders/{key}`
  - Description: Retrieve information about a PaymentProvider by ID.
  
### Get PaymentProviders
- **GET** `/api/PaymentProviders`
  - Description: Retrieve information about PaymentProviders.

### Create PaymentProvider
- **POST** `/api/PaymentProviders`
  - Description: Create a new PaymentProvider.

### Update PaymentProvider
- **PUT** `/api/PaymentProviders/{key}`
  - Description: Update an existing PaymentProvider.

### Partially Update PaymentProvider
- **PATCH** `/api/PaymentProviders/{key}`
  - Description: Partially update an existing PaymentProvider.
 
### Delete PaymentProvider
- **DELETE** `/api/PaymentProviders/{key}`
  - Description: Delete an existing PaymentProvider.

## Relationships Endpoints

### PaymentDetail

#### Get PaymentDetail relation by ID
- **GET** `/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Retrieve an existing PaymentDetails relation for a specific PaymentProvider.

#### Get PaymentDetail relations
- **GET** `/api/PaymentProviders/{key}/PaymentDetails/$ref`
  - Description: Retrieve all PaymentDetails relations for a specific PaymentProvider.
  
#### Create PaymentDetail relation
- **POST** `/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Create a new PaymentDetail relation for a specific PaymentProvider.

#### Update PaymentDetail relation
- **PUT** `/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Update an existing PaymentDetail relation for a specific PaymentProvider.
  
#### Partially Update PaymentDetail relation
- **PATCH** `/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Partially update an existing PaymentDetail relation for a specific PaymentProvider.

#### Delete PaymentDetail relation
- **DELETE** `/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}/$ref`
  - Description: Delete an existing PaymentDetail relation for a specific PaymentProvider.

## Related Entities

[PaymentDetail](PaymentDetailEndpoints.md)
