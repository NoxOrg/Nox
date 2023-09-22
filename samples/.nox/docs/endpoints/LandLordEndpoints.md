# API Endpoints for the LandLord entity

This document provides information about the various endpoints available in our API for the LandLord entity.

## LandLord Endpoints

### Get LandLord by ID
- **GET** `/api/LandLords/{key}`
  - Description: Retrieve information about a LandLord by ID.
  
### Get LandLords
- **GET** `/api/LandLords`
  - Description: Retrieve information about LandLords.

### Create LandLord
- **POST** `/api/LandLords`
  - Description: Create a new LandLord.

### Update LandLord
- **PUT** `/api/LandLords/{key}`
  - Description: Update an existing LandLord.

### Partially Update LandLord
- **PATCH** `/api/LandLords/{key}`
  - Description: Partially update an existing LandLord.
 
### Delete LandLord
- **DELETE** `/api/LandLords/{key}`
  - Description: Delete an existing LandLord.

## Relationships Endpoints

### VendingMachine

#### Get VendingMachine relation by ID
- **GET** `/api/LandLords/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Retrieve an existing VendingMachines relation for a specific LandLord.

#### Get VendingMachine relations
- **GET** `/api/LandLords/{key}/VendingMachines/$ref`
  - Description: Retrieve all VendingMachines relations for a specific LandLord.
  
#### Create VendingMachine relation
- **POST** `/api/LandLords/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific LandLord.

#### Update VendingMachine relation
- **PUT** `/api/LandLords/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Update an existing VendingMachine relation for a specific LandLord.
  
#### Partially Update VendingMachine relation
- **PATCH** `/api/LandLords/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Partially update an existing VendingMachine relation for a specific LandLord.

#### Delete VendingMachine relation
- **DELETE** `/api/LandLords/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific LandLord.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)
