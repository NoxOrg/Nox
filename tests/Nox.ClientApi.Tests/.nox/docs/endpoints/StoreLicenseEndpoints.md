# API Endpoints for the StoreLicense entity

This document provides information about the various endpoints available in our API for the StoreLicense entity.

## StoreLicense Endpoints

### Get StoreLicense Count
- **GET** `/api/v1/StoreLicenses/$count`
  - Description: Retrieve the number of StoreLicenses.

### Get StoreLicense by ID
- **GET** `/api/v1/StoreLicenses/{key}`
  - Description: Retrieve information about a StoreLicense by ID.
  
### Get StoreLicenses
- **GET** `/api/v1/StoreLicenses`
  - Description: Retrieve information about StoreLicenses.

### Create StoreLicense
- **POST** `/api/v1/StoreLicenses`
  - Description: Create a new StoreLicense.

### Update StoreLicense
- **PUT** `/api/v1/StoreLicenses/{key}`
  - Description: Update an existing StoreLicense.

### Partially Update StoreLicense
- **PATCH** `/api/v1/StoreLicenses/{key}`
  - Description: Partially update an existing StoreLicense.
 
### Delete StoreLicense
- **DELETE** `/api/v1/StoreLicenses/{key}`
  - Description: Delete an existing StoreLicense.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Retrieve all existing Stores relations for a specific StoreLicense.
  
#### Create Store relation
- **POST** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreLicense.
  
#### Update Store relation
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Updates the Store relations for a specific StoreLicense.

#### Delete Store relation
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreLicense.

#### Delete Store relations
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Delete all existing Stores relations for a specific StoreLicense.

### Currency

#### Get Currency relations
- **GET** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific StoreLicense.
  
#### Create Currency relation
- **POST** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific StoreLicense.
  
#### Update Currency relation
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Updates the Currency relations for a specific StoreLicense.

#### Delete Currency relation
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific StoreLicense.

#### Delete Currency relations
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific StoreLicense.

### Currency

#### Get Currency relations
- **GET** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific StoreLicense.
  
#### Create Currency relation
- **POST** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific StoreLicense.
  
#### Update Currency relation
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Updates the Currency relations for a specific StoreLicense.

#### Delete Currency relation
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific StoreLicense.

#### Delete Currency relations
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific StoreLicense.

## Related Entities

[Store](StoreEndpoints.md)

[Currency](CurrencyEndpoints.md)

[Currency](CurrencyEndpoints.md)

