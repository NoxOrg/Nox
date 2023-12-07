# API Endpoints for the Client entity

This document provides information about the various endpoints available in our API for the Client entity.

## Client Endpoints

### Get Client by ID
- **GET** `/api/Clients/{key}`
  - Description: Retrieve information about a Client by ID.
  
### Get Clients
- **GET** `/api/Clients`
  - Description: Retrieve information about Clients.

### Create Client
- **POST** `/api/Clients`
  - Description: Create a new Client.

### Update Client
- **PUT** `/api/Clients/{key}`
  - Description: Update an existing Client.

### Partially Update Client
- **PATCH** `/api/Clients/{key}`
  - Description: Partially update an existing Client.
 
### Delete Client
- **DELETE** `/api/Clients/{key}`
  - Description: Delete an existing Client.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/Clients/{key}/ClientOf/$ref`
  - Description: Retrieve all existing Stores relations for a specific Client.
  
#### Create Store relation
- **POST** `/api/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific Client.
  
#### Update Store relation
- **PUT** `/api/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific Client.
- **PUT** `/api/Clients/{key}/ClientOf/$ref`
  - Description: Updates the Store relations for a specific Client.

#### Delete Store relation
- **DELETE** `/api/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific Client.

#### Delete Store relations
- **DELETE** `/api/Clients/{key}/ClientOf/$ref`
  - Description: Delete all existing Stores relations for a specific Client.

## Related Entities

[Store](StoreEndpoints.md)

