# API Endpoints for the CashStockOrder entity

This document provides information about the various endpoints available in our API for the CashStockOrder entity.

## CashStockOrder Endpoints

### Get CashStockOrder Count
- **GET** `/api/CashStockOrders/$count`
  - Description: Retrieve the number of CashStockOrders.

### Get CashStockOrder by ID
- **GET** `/api/CashStockOrders/{key}`
  - Description: Retrieve information about a CashStockOrder by ID.
  
### Get CashStockOrders
- **GET** `/api/CashStockOrders`
  - Description: Retrieve information about CashStockOrders.

### Create CashStockOrder
- **POST** `/api/CashStockOrders`
  - Description: Create a new CashStockOrder.

### Update CashStockOrder
- **PUT** `/api/CashStockOrders/{key}`
  - Description: Update an existing CashStockOrder.

### Partially Update CashStockOrder
- **PATCH** `/api/CashStockOrders/{key}`
  - Description: Partially update an existing CashStockOrder.
 
### Delete CashStockOrder
- **DELETE** `/api/CashStockOrders/{key}`
  - Description: Delete an existing CashStockOrder.

## Relationships Endpoints

### VendingMachine

#### Get VendingMachine relations
- **GET** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific CashStockOrder.
  
#### Create VendingMachine relation
- **POST** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific CashStockOrder.
  
#### Update VendingMachine relation
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific CashStockOrder.
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/$ref`
  - Description: Updates the VendingMachine relations for a specific CashStockOrder.

#### Delete VendingMachine relation
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific CashStockOrder.

#### Delete VendingMachine relations
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/$ref`
  - Description: Delete all existing VendingMachines relations for a specific CashStockOrder.

#### Get VendingMachine
- **GET** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine`
  - Description: Retrieve all existing VendingMachines for a specific CashStockOrder.
  
#### Create VendingMachine
- **POST** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}`
  - Description: Create a new VendingMachine for a specific CashStockOrder.
  
#### Update VendingMachine
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}`
  - Description: Updates an existing VendingMachine for a specific CashStockOrder.
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine`
  - Description: Updates the VendingMachine for a specific CashStockOrder.

#### Delete VendingMachine
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}`
  - Description: Delete an existing VendingMachine for a specific CashStockOrder.

#### Delete VendingMachine
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine`
  - Description: Delete all existing VendingMachines for a specific CashStockOrder.
### Employee

#### Get Employee relations
- **GET** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/$ref`
  - Description: Retrieve all existing Employees relations for a specific CashStockOrder.
  
#### Create Employee relation
- **POST** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}/$ref`
  - Description: Create a new Employee relation for a specific CashStockOrder.
  
#### Update Employee relation
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}/$ref`
  - Description: Updates an existing Employee relation for a specific CashStockOrder.
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/$ref`
  - Description: Updates the Employee relations for a specific CashStockOrder.

#### Delete Employee relation
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}/$ref`
  - Description: Delete an existing Employee relation for a specific CashStockOrder.

#### Delete Employee relations
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/$ref`
  - Description: Delete all existing Employees relations for a specific CashStockOrder.

#### Get Employee
- **GET** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee`
  - Description: Retrieve all existing Employees for a specific CashStockOrder.
  
#### Create Employee
- **POST** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}`
  - Description: Create a new Employee for a specific CashStockOrder.
  
#### Update Employee
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}`
  - Description: Updates an existing Employee for a specific CashStockOrder.
- **PUT** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee`
  - Description: Updates the Employee for a specific CashStockOrder.

#### Delete Employee
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}`
  - Description: Delete an existing Employee for a specific CashStockOrder.

#### Delete Employee
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee`
  - Description: Delete all existing Employees for a specific CashStockOrder.

## Other Related Endpoints

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country`

- **PATCH** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country/$ref`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country/{countryKey}/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Country/{countryKey}/$ref`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord`

- **PATCH** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord/$ref`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord/{landLordKey}/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/LandLord/{landLordKey}/$ref`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}`

- **PATCH** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/$ref`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/$ref`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}/$ref`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/Bookings/{bookingsKey}/$ref`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **PATCH** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}`

- **GET** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/$ref`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/$ref`

- **POST** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

- **PUT** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

- **DELETE** `/api/CashStockOrders/{cashStockOrdersKey}/VendingMachine/{vendingMachineKey}/MinimumCashStocks/{minimumCashStocksKey}/$ref`

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)
[Employee](EmployeeEndpoints.md)