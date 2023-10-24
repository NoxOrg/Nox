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

### EmailAddress

#### Get EmailAddresses
- **GET** `/api/Stores/{key}/EmailAddresses`
  - Description: Retrieve all EmailAddresses for a specific Store.

#### Create EmailAddress
- **POST** `/api/Stores/{key}/EmailAddresses`
  - Description: Create a new EmailAddress for a specific Store.

#### Update EmailAddress
- **PUT** `/api/Stores/{key}/EmailAddresses/{relatedKey}`
  - Description: Update an existing EmailAddress for a specific Store.
  
#### Partially Update EmailAddress
- **PATCH** `/api/Stores/{key}/EmailAddresses/{relatedKey}`
  - Description: Partially update an existing EmailAddress for a specific Store.

#### Delete EmailAddress
- **DELETE** `/api/Stores/{key}/EmailAddresses/{relatedKey}`
  - Description: Delete an existing EmailAddress for a specific Store.

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

#### Delete StoreLicense relation
- **DELETE** `/api/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Delete an existing StoreLicense relation for a specific Store.

#### Delete StoreLicense relations
- **DELETE** `/api/Stores/{key}/License/$ref`
  - Description: Delete all existing StoreLicenses relations for a specific Store.

## Related Entities

[StoreOwner](StoreOwnerEndpoints.md)

[StoreLicense](StoreLicenseEndpoints.md)
