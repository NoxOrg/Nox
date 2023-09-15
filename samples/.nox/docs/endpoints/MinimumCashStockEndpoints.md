# API Endpoints for the MinimumCashStock entity

This document provides information about the various endpoints available in our API for the MinimumCashStock entity.

## MinimumCashStock Endpoints

### Get MinimumCashStock by ID
- **GET** `/api/MinimumCashStocks/{key}`
  - Description: Retrieve information about a MinimumCashStock by ID.
  
### Get MinimumCashStocks
- **GET** `/api/MinimumCashStocks`
  - Description: Retrieve information about MinimumCashStocks.

### Create MinimumCashStock
- **POST** `/api/MinimumCashStocks`
  - Description: Create a new MinimumCashStock.

### Update MinimumCashStock
- **PUT** `/api/MinimumCashStocks/{key}`
  - Description: Update an existing MinimumCashStock.

### Partially Update MinimumCashStock
- **PATCH** `/api/MinimumCashStocks/{key}`
  - Description: Partially update an existing MinimumCashStock.
 
### Delete MinimumCashStock
- **DELETE** `/api/MinimumCashStocks/{key}`
  - Description: Delete an existing MinimumCashStock.

## Relationships Endpoints

### VendingMachine

#### Get VendingMachine relation by ID
- **GET** `/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Retrieve an existing VendingMachines relation for a specific MinimumCashStock.

#### Get VendingMachine relations
- **GET** `/api/MinimumCashStocks/{key}/VendingMachines/$ref`
  - Description: Retrieve all VendingMachines relations for a specific MinimumCashStock.
  
#### Create VendingMachine relation
- **POST** `/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific MinimumCashStock.
  
#### Update VendingMachine relation
- **PUT** `/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Update an existing VendingMachine relation for a specific MinimumCashStock.
  
#### Partially Update VendingMachine relation
- **PATCH** `/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Partially update an existing VendingMachine relation for a specific MinimumCashStock.

#### Delete VendingMachine relation
- **DELETE** `/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific MinimumCashStock.

### Currency

#### Get Currency relation by ID
- **GET** `/api/MinimumCashStocks/{key}/Currencies/{relatedKey}/$ref`
  - Description: Retrieve an existing Currencies relation for a specific MinimumCashStock.

#### Get Currency relations
- **GET** `/api/MinimumCashStocks/{key}/Currencies/$ref`
  - Description: Retrieve all Currencies relations for a specific MinimumCashStock.
  
#### Create Currency relation
- **POST** `/api/MinimumCashStocks/{key}/Currencies/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific MinimumCashStock.
  
#### Update Currency relation
- **PUT** `/api/MinimumCashStocks/{key}/Currencies/{relatedKey}/$ref`
  - Description: Update an existing Currency relation for a specific MinimumCashStock.
  
#### Partially Update Currency relation
- **PATCH** `/api/MinimumCashStocks/{key}/Currencies/{relatedKey}/$ref`
  - Description: Partially update an existing Currency relation for a specific MinimumCashStock.

#### Delete Currency relation
- **DELETE** `/api/MinimumCashStocks/{key}/Currencies/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific MinimumCashStock.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)

[Currency](CurrencyEndpoints.md)
