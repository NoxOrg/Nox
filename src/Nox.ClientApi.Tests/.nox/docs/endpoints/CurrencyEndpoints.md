# API Endpoints for the Currency entity

This document provides information about the various endpoints available in our API for the Currency entity.

## Currency Endpoints

### Get Currency by ID
- **GET** `/api/Currencies/{key}`
  - Description: Retrieve information about a Currency by ID.
  
### Get Currencies
- **GET** `/api/Currencies`
  - Description: Retrieve information about Currencies.

### Create Currency
- **POST** `/api/Currencies`
  - Description: Create a new Currency.

### Update Currency
- **PUT** `/api/Currencies/{key}`
  - Description: Update an existing Currency.

### Partially Update Currency
- **PATCH** `/api/Currencies/{key}`
  - Description: Partially update an existing Currency.
 
### Delete Currency
- **DELETE** `/api/Currencies/{key}`
  - Description: Delete an existing Currency.

## Relationships Endpoints

### StoreLicense

#### Get StoreLicense relations
- **GET** `/api/Currencies/{key}/StoreLicenseDefault/$ref`
  - Description: Retrieve all existing StoreLicenses relations for a specific Currency.
  
#### Create StoreLicense relation
- **POST** `/api/Currencies/{key}/StoreLicenseDefault/{relatedKey}/$ref`
  - Description: Create a new StoreLicense relation for a specific Currency.
  
#### Update StoreLicense relation
- **PUT** `/api/Currencies/{key}/StoreLicenseDefault/{relatedKey}/$ref`
  - Description: Updates an existing StoreLicense relation for a specific Currency.
- **PUT** `/api/Currencies/{key}/StoreLicenseDefault/$ref`
  - Description: Updates the StoreLicense relations for a specific Currency.

#### Delete StoreLicense relation
- **DELETE** `/api/Currencies/{key}/StoreLicenseDefault/{relatedKey}/$ref`
  - Description: Delete an existing StoreLicense relation for a specific Currency.

#### Delete StoreLicense relations
- **DELETE** `/api/Currencies/{key}/StoreLicenseDefault/$ref`
  - Description: Delete all existing StoreLicenses relations for a specific Currency.

### StoreLicense

#### Get StoreLicense relations
- **GET** `/api/Currencies/{key}/StoreLicenseSoldIn/$ref`
  - Description: Retrieve all existing StoreLicenses relations for a specific Currency.
  
#### Create StoreLicense relation
- **POST** `/api/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}/$ref`
  - Description: Create a new StoreLicense relation for a specific Currency.
  
#### Update StoreLicense relation
- **PUT** `/api/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}/$ref`
  - Description: Updates an existing StoreLicense relation for a specific Currency.
- **PUT** `/api/Currencies/{key}/StoreLicenseSoldIn/$ref`
  - Description: Updates the StoreLicense relations for a specific Currency.

#### Delete StoreLicense relation
- **DELETE** `/api/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}/$ref`
  - Description: Delete an existing StoreLicense relation for a specific Currency.

#### Delete StoreLicense relations
- **DELETE** `/api/Currencies/{key}/StoreLicenseSoldIn/$ref`
  - Description: Delete all existing StoreLicenses relations for a specific Currency.

## Related Entities

[StoreLicense](StoreLicenseEndpoints.md)

[StoreLicense](StoreLicenseEndpoints.md)

