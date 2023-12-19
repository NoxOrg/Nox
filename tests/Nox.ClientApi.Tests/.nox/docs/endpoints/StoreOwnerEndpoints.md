# API Endpoints for the StoreOwner entity

This document provides information about the various endpoints available in our API for the StoreOwner entity.

## StoreOwner Endpoints

### Get StoreOwner Count
- **GET** `/api/v1/StoreOwners/$count`
  - Description: Retrieve the number of StoreOwners.

### Get StoreOwner by ID
- **GET** `/api/v1/StoreOwners/{key}`
  - Description: Retrieve information about a StoreOwner by ID.
  
### Get StoreOwners
- **GET** `/api/v1/StoreOwners`
  - Description: Retrieve information about StoreOwners.

### Create StoreOwner
- **POST** `/api/v1/StoreOwners`
  - Description: Create a new StoreOwner.

### Update StoreOwner
- **PUT** `/api/v1/StoreOwners/{key}`
  - Description: Update an existing StoreOwner.

### Partially Update StoreOwner
- **PATCH** `/api/v1/StoreOwners/{key}`
  - Description: Partially update an existing StoreOwner.
 
### Delete StoreOwner
- **DELETE** `/api/v1/StoreOwners/{key}`
  - Description: Delete an existing StoreOwner.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Retrieve all existing Stores relations for a specific StoreOwner.
  
#### Create Store relation
- **POST** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreOwner.
  
#### Update Store relation
- **PUT** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific StoreOwner.
- **PUT** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Updates the Store relations for a specific StoreOwner.

#### Delete Store relation
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreOwner.

#### Delete Store relations
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Delete all existing Stores relations for a specific StoreOwner.

#### Get Store
- **GET** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Retrieve all existing Stores for a specific StoreOwner.
  
#### Create Store
- **POST** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Create a new Store for a specific StoreOwner.
  
#### Update Store
- **PUT** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Updates an existing Store for a specific StoreOwner.
- **PUT** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Updates the Store for a specific StoreOwner.

#### Delete Store
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Delete an existing Store for a specific StoreOwner.

#### Delete Store
- **DELETE** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Delete all existing Stores for a specific StoreOwner.

## Related Entities

[Store](StoreEndpoints.md)

