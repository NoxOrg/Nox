# API Endpoints for the Store entity

This document provides information about the various endpoints available in our API for the Store entity.

## Store Endpoints

### Get Store by ID
- **GET** `/api/Stores/{key}`
  - Description: Retrieve information about a Store by ID.
  
### Get Stores
- **GET** `/api/Stores`
  - Description: Retrieve information about Stores.

### Create Store
- **POST** `/api/Stores`
  - Description: Create a new Store.

### Update Store
- **PUT** `/api/Stores/{key}`
  - Description: Update an existing Store.

### Partially Update Store
- **PATCH** `/api/Stores/{key}`
  - Description: Partially update an existing Store.
 
### Delete Store
- **DELETE** `/api/Stores/{key}`
  - Description: Delete an existing Store.

## Owned Relationships Endpoints

## Relationships Endpoints

### StoreOwner

#### Get StoreOwner relations
- **GET** `/api/Stores/{key}/Ownership/$ref`
  - Description: Retrieve all existing StoreOwners relations for a specific Store.
  
#### Create StoreOwner relation
- **POST** `/api/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Create a new StoreOwner relation for a specific Store.
  
#### Update StoreOwner relation
- **PUT** `/api/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Updates an existing StoreOwner relation for a specific Store.
- **PUT** `/api/Stores/{key}/Ownership/$ref`
  - Description: Updates the StoreOwner relations for a specific Store.

#### Delete StoreOwner relation
- **DELETE** `/api/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Delete an existing StoreOwner relation for a specific Store.

#### Delete StoreOwner relations
- **DELETE** `/api/Stores/{key}/Ownership/$ref`
  - Description: Delete all existing StoreOwners relations for a specific Store.

### StoreLicense

#### Get StoreLicense relations
- **GET** `/api/Stores/{key}/License/$ref`
  - Description: Retrieve all existing StoreLicenses relations for a specific Store.
  
#### Create StoreLicense relation
- **POST** `/api/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Create a new StoreLicense relation for a specific Store.
  
#### Update StoreLicense relation
- **PUT** `/api/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Updates an existing StoreLicense relation for a specific Store.
- **PUT** `/api/Stores/{key}/License/$ref`
  - Description: Updates the StoreLicense relations for a specific Store.

#### Delete StoreLicense relation
- **DELETE** `/api/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Delete an existing StoreLicense relation for a specific Store.

#### Delete StoreLicense relations
- **DELETE** `/api/Stores/{key}/License/$ref`
  - Description: Delete all existing StoreLicenses relations for a specific Store.

### Client

#### Get Client relations
- **GET** `/api/Stores/{key}/ClientsOfStore/$ref`
  - Description: Retrieve all existing Clients relations for a specific Store.
  
#### Create Client relation
- **POST** `/api/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Create a new Client relation for a specific Store.
  
#### Update Client relation
- **PUT** `/api/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Updates an existing Client relation for a specific Store.
- **PUT** `/api/Stores/{key}/ClientsOfStore/$ref`
  - Description: Updates the Client relations for a specific Store.

#### Delete Client relation
- **DELETE** `/api/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Delete an existing Client relation for a specific Store.

#### Delete Client relations
- **DELETE** `/api/Stores/{key}/ClientsOfStore/$ref`
  - Description: Delete all existing Clients relations for a specific Store.

## Related Entities

[StoreOwner](StoreOwnerEndpoints.md)

[StoreLicense](StoreLicenseEndpoints.md)

[Client](ClientEndpoints.md)

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Store.
- **GET** `/api/Stores/StoreStatuses`
  - **Description**: Retrieve non-conventional values of Statuses for a specific Store.