# API Endpoints for the LandLord entity

This document provides information about the various endpoints available in our API for the LandLord entity.

## LandLord Endpoints

### Get LandLord Count
- **GET** `/api/LandLords/$count`
  - Description: Retrieve the number of LandLords.

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

#### Get VendingMachine
- **GET** `/api/LandLords/{key}/ContractedAreasForVendingMachines`
  - Description: Retrieve all existing VendingMachines for a specific LandLord.
  
#### Create VendingMachine
- **POST** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}`
  - Description: Create a new VendingMachine for a specific LandLord.
  
#### Update VendingMachine
- **PUT** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}`
  - Description: Updates an existing VendingMachine for a specific LandLord.
- **PUT** `/api/LandLords/{key}/ContractedAreasForVendingMachines`
  - Description: Updates the VendingMachine for a specific LandLord.

#### Delete VendingMachine
- **DELETE** `/api/LandLords/{key}/ContractedAreasForVendingMachines/{relatedKey}`
  - Description: Delete an existing VendingMachine for a specific LandLord.

#### Delete VendingMachine
- **DELETE** `/api/LandLords/{key}/ContractedAreasForVendingMachines`
  - Description: Delete all existing VendingMachines for a specific LandLord.

## Other Related Endpoints

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country`

- **PATCH** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country/$ref`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country/{countryKey}/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Country/{countryKey}/$ref`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **PATCH** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/$ref`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/Bookings/{bookingsKey}/$ref`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **PATCH** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/$ref`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/CashStockOrders/{cashStockOrdersKey}/$ref`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **PATCH** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **GET** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/$ref`

- **POST** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

- **PUT** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

- **DELETE** `/api/LandLords/{landLordsKey}/VendingMachines/{vendingMachinesKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)