# API Endpoints for the PaymentProvider entity

This document provides information about the various endpoints available in our API for the PaymentProvider entity.

## PaymentProvider Endpoints

### Get PaymentProvider Count
- **GET** `/api/PaymentProviders/$count`
  - Description: Retrieve the number of PaymentProviders.

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

#### Get PaymentDetail relations
- **GET** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/$ref`
  - Description: Retrieve all existing PaymentDetails relations for a specific PaymentProvider.
  
#### Create PaymentDetail relation
- **POST** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Create a new PaymentDetail relation for a specific PaymentProvider.
  
#### Update PaymentDetail relation
- **PUT** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Updates an existing PaymentDetail relation for a specific PaymentProvider.
- **PUT** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/$ref`
  - Description: Updates the PaymentDetail relations for a specific PaymentProvider.

#### Delete PaymentDetail relation
- **DELETE** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}/$ref`
  - Description: Delete an existing PaymentDetail relation for a specific PaymentProvider.

#### Delete PaymentDetail relations
- **DELETE** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/$ref`
  - Description: Delete all existing PaymentDetails relations for a specific PaymentProvider.

#### Get PaymentDetail
- **GET** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails`
  - Description: Retrieve all existing PaymentDetails for a specific PaymentProvider.
  
#### Create PaymentDetail
- **POST** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}`
  - Description: Create a new PaymentDetail for a specific PaymentProvider.
  
#### Update PaymentDetail
- **PUT** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}`
  - Description: Updates an existing PaymentDetail for a specific PaymentProvider.
- **PUT** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails`
  - Description: Updates the PaymentDetail for a specific PaymentProvider.

#### Delete PaymentDetail
- **DELETE** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails/{relatedKey}`
  - Description: Delete an existing PaymentDetail for a specific PaymentProvider.

#### Delete PaymentDetail
- **DELETE** `/api/PaymentProviders/{key}/PaymentProviderRelatedPaymentDetails`
  - Description: Delete all existing PaymentDetails for a specific PaymentProvider.

## Other Related Endpoints

- **GET** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer`

- **POST** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer`

- **PUT** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer`

- **PATCH** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer`

- **GET** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer/$ref`

- **POST** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/$ref`

- **PUT** `/api/PaymentProviders/{paymentProvidersKey}/PaymentDetails/{paymentDetailsKey}/Customer/{customerKey}/$ref`

## Related Entities

[PaymentDetail](PaymentDetailEndpoints.md)