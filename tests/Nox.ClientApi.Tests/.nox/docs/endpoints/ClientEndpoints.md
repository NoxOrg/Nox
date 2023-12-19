# API Endpoints for the Client entity

This document provides information about the various endpoints available in our API for the Client entity.

## Client Endpoints

### Get Client Count
- **GET** `/api/v1/Clients/$count`
  - Description: Retrieve the number of Clients.

### Get Client by ID
- **GET** `/api/v1/Clients/{key}`
  - Description: Retrieve information about a Client by ID.
  
### Get Clients
- **GET** `/api/v1/Clients`
  - Description: Retrieve information about Clients.

### Create Client
- **POST** `/api/v1/Clients`
  - Description: Create a new Client.

### Update Client
- **PUT** `/api/v1/Clients/{key}`
  - Description: Update an existing Client.

### Partially Update Client
- **PATCH** `/api/v1/Clients/{key}`
  - Description: Partially update an existing Client.
 
### Delete Client
- **DELETE** `/api/v1/Clients/{key}`
  - Description: Delete an existing Client.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Retrieve all existing Stores relations for a specific Client.
  
#### Create Store relation
- **POST** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific Client.
  
#### Update Store relation
- **PUT** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific Client.
- **PUT** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Updates the Store relations for a specific Client.

#### Delete Store relation
- **DELETE** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific Client.

#### Delete Store relations
- **DELETE** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Delete all existing Stores relations for a specific Client.

#### Get Store
- **GET** `/api/v1/Clients/{key}/ClientOf`
  - Description: Retrieve all existing Stores for a specific Client.
  
#### Create Store
- **POST** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Create a new Store for a specific Client.
  
#### Update Store
- **PUT** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Updates an existing Store for a specific Client.
- **PUT** `/api/v1/Clients/{key}/ClientOf`
  - Description: Updates the Store for a specific Client.

#### Delete Store
- **DELETE** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Delete an existing Store for a specific Client.

#### Delete Store
- **DELETE** `/api/v1/Clients/{key}/ClientOf`
  - Description: Delete all existing Stores for a specific Client.

## Related Entities

[Store](StoreEndpoints.md)

