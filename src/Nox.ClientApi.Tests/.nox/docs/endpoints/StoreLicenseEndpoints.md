# API Endpoints for the StoreLicense entity

This document provides information about the various endpoints available in our API for the StoreLicense entity.

## StoreLicense Endpoints

### Get StoreLicense by ID
- **GET** `/api/StoreLicenses/{key}`
  - Description: Retrieve information about a StoreLicense by ID.
  
### Get StoreLicenses
- **GET** `/api/StoreLicenses`
  - Description: Retrieve information about StoreLicenses.

### Create StoreLicense
- **POST** `/api/StoreLicenses`
  - Description: Create a new StoreLicense.

### Update StoreLicense
- **PUT** `/api/StoreLicenses/{key}`
  - Description: Update an existing StoreLicense.

### Partially Update StoreLicense
- **PATCH** `/api/StoreLicenses/{key}`
  - Description: Partially update an existing StoreLicense.
 
### Delete StoreLicense
- **DELETE** `/api/StoreLicenses/{key}`
  - Description: Delete an existing StoreLicense.

## Relationships Endpoints

### Store

#### Get Store relation by ID
- **GET** `/api/StoreLicenses/{key}/Stores/{relatedKey}/$ref`
  - Description: Retrieve an existing Stores relation for a specific StoreLicense.

#### Get Store relations
- **GET** `/api/StoreLicenses/{key}/Stores/$ref`
  - Description: Retrieve all Stores relations for a specific StoreLicense.
  
#### Create Store relation
- **POST** `/api/StoreLicenses/{key}/Stores/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreLicense.

#### Update Store relation
- **PUT** `/api/StoreLicenses/{key}/Stores/{relatedKey}/$ref`
  - Description: Update an existing Store relation for a specific StoreLicense.
  
#### Partially Update Store relation
- **PATCH** `/api/StoreLicenses/{key}/Stores/{relatedKey}/$ref`
  - Description: Partially update an existing Store relation for a specific StoreLicense.

#### Delete Store relation
- **DELETE** `/api/StoreLicenses/{key}/Stores/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreLicense.

## Related Entities

[Store](StoreEndpoints.md)
