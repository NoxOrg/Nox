# API Endpoints for the CashStockOrder entity

This document provides information about the various endpoints available in our API for the CashStockOrder entity.

## CashStockOrder Endpoints

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

#### Delete VendingMachine relation
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific CashStockOrder.

#### Delete VendingMachine relations
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderForVendingMachine/$ref`
  - Description: Delete all existing VendingMachines relations for a specific CashStockOrder.

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

#### Delete Employee relation
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/{relatedKey}/$ref`
  - Description: Delete an existing Employee relation for a specific CashStockOrder.

#### Delete Employee relations
- **DELETE** `/api/CashStockOrders/{key}/CashStockOrderReviewedByEmployee/$ref`
  - Description: Delete all existing Employees relations for a specific CashStockOrder.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)

[Employee](EmployeeEndpoints.md)
