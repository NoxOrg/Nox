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

#### Get VendingMachine relations
- **GET** `/api/LandLords/{key}/ContractedAreasForVendingMachines/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific LandLord.
  
#### Create VendingMachine relation
- **POST** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific LandLord.
  
#### Update VendingMachine relation
- **PUT** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific LandLord.
- **PUT** `/api/LandLords/{key}/ContractedAreasForVendingMachines/$ref`
  - Description: Updates the VendingMachine relations for a specific LandLord.

#### Delete VendingMachine relation
- **DELETE** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific LandLord.

#### Delete VendingMachine relations
- **DELETE** `/api/LandLords/{key}/ContractedAreasForVendingMachines/$ref`
  - Description: Delete all existing VendingMachines relations for a specific LandLord.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)
