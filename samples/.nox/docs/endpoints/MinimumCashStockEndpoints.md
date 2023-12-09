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

#### Get VendingMachine relations
- **GET** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific MinimumCashStock.
  
#### Create VendingMachine relation
- **POST** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific MinimumCashStock.
  
#### Update VendingMachine relation
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific MinimumCashStock.
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/$ref`
  - Description: Updates the VendingMachine relations for a specific MinimumCashStock.

#### Delete VendingMachine relation
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific MinimumCashStock.

#### Delete VendingMachine relations
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/$ref`
  - Description: Delete all existing VendingMachines relations for a specific MinimumCashStock.

### Currency

#### Get Currency relations
- **GET** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific MinimumCashStock.
  
#### Create Currency relation
- **POST** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific MinimumCashStock.
  
#### Update Currency relation
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific MinimumCashStock.
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/$ref`
  - Description: Updates the Currency relations for a specific MinimumCashStock.

#### Delete Currency relation
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific MinimumCashStock.

#### Delete Currency relations
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific MinimumCashStock.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)

[Currency](CurrencyEndpoints.md)

