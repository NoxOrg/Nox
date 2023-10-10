# API Endpoints for the StoreOwner entity

This document provides information about the various endpoints available in our API for the StoreOwner entity.

## StoreOwner Endpoints

### Get StoreOwner by ID
- **GET** `/api/StoreOwners/{key}`
  - Description: Retrieve information about a StoreOwner by ID.
  
### Get StoreOwners
- **GET** `/api/StoreOwners`
  - Description: Retrieve information about StoreOwners.

### Create StoreOwner
- **POST** `/api/StoreOwners`
  - Description: Create a new StoreOwner.

### Update StoreOwner
- **PUT** `/api/StoreOwners/{key}`
  - Description: Update an existing StoreOwner.

### Partially Update StoreOwner
- **PATCH** `/api/StoreOwners/{key}`
  - Description: Partially update an existing StoreOwner.
 
### Delete StoreOwner
- **DELETE** `/api/StoreOwners/{key}`
  - Description: Delete an existing StoreOwner.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/StoreOwners/{key}/Stores/$ref`
  - Description: Retrieve all existing Stores relations for a specific StoreOwner.
  
#### Create Store relation
- **POST** `/api/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreOwner.
  
#### Update Store relation
- **PUT** `/api/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific StoreOwner.

#### Delete Store relation
- **DELETE** `/api/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreOwner.

#### Delete Store relations
- **DELETE** `/api/StoreOwners/{key}/Stores/$ref`
  - Description: Delete all existing Stores relations for a specific StoreOwner.

## Related Entities

[Store](StoreEndpoints.md)
