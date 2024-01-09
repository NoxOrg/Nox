# API Endpoints for the MinimumCashStock entity

This document provides information about the various endpoints available in our API for the MinimumCashStock entity.

## MinimumCashStock Endpoints

### Get MinimumCashStock Count
- **GET** `/api/MinimumCashStocks/$count`
  - Description: Retrieve the number of MinimumCashStocks.

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

#### Get VendingMachine
- **GET** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines`
  - Description: Retrieve all existing VendingMachines for a specific MinimumCashStock.
  
#### Create VendingMachine
- **POST** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}`
  - Description: Create a new VendingMachine for a specific MinimumCashStock.
  
#### Update VendingMachine
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}`
  - Description: Updates an existing VendingMachine for a specific MinimumCashStock.
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines`
  - Description: Updates the VendingMachine for a specific MinimumCashStock.

#### Delete VendingMachine
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines/{relatedKey}`
  - Description: Delete an existing VendingMachine for a specific MinimumCashStock.

#### Delete VendingMachine
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStocksRequiredByVendingMachines`
  - Description: Delete all existing VendingMachines for a specific MinimumCashStock.

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

#### Get Currency
- **GET** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency`
  - Description: Retrieve all existing Currencies for a specific MinimumCashStock.
  
#### Create Currency
- **POST** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}`
  - Description: Create a new Currency for a specific MinimumCashStock.
  
#### Update Currency
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}`
  - Description: Updates an existing Currency for a specific MinimumCashStock.
- **PUT** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency`
  - Description: Updates the Currency for a specific MinimumCashStock.

#### Delete Currency
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency/{relatedKey}`
  - Description: Delete an existing Currency for a specific MinimumCashStock.

#### Delete Currency
- **DELETE** `/api/MinimumCashStocks/{key}/MinimumCashStockRelatedCurrency`
  - Description: Delete all existing Currencies for a specific MinimumCashStock.


## Other Related Endpoints

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country`

- **PATCH** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country/$ref`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country/{countryKey}/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Country/{countryKey}/$ref`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord`

- **PATCH** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord/$ref`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord/{landLordKey}/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/LandLord/{landLordKey}/$ref`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **PATCH** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **PATCH** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **GET** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **POST** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`

- **PUT** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`

- **DELETE** `/api/MinimumCashStocks/{minimumCashStocksKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`
## Related Entities

[VendingMachine](VendingMachineEndpoints.md)

[Currency](CurrencyEndpoints.md)
