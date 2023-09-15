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

#### Get VendingMachine relation by ID
- **GET** `/api/CashStockOrders/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Retrieve an existing VendingMachines relation for a specific CashStockOrder.

#### Get VendingMachine relations
- **GET** `/api/CashStockOrders/{key}/VendingMachines/$ref`
  - Description: Retrieve all VendingMachines relations for a specific CashStockOrder.
  
#### Create VendingMachine relation
- **POST** `/api/CashStockOrders/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific CashStockOrder.
  
#### Update VendingMachine relation
- **PUT** `/api/CashStockOrders/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Update an existing VendingMachine relation for a specific CashStockOrder.
  
#### Partially Update VendingMachine relation
- **PATCH** `/api/CashStockOrders/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Partially update an existing VendingMachine relation for a specific CashStockOrder.

#### Delete VendingMachine relation
- **DELETE** `/api/CashStockOrders/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific CashStockOrder.

### Employee

#### Get Employee relation by ID
- **GET** `/api/CashStockOrders/{key}/Employees/{relatedKey}/$ref`
  - Description: Retrieve an existing Employees relation for a specific CashStockOrder.

#### Get Employee relations
- **GET** `/api/CashStockOrders/{key}/Employees/$ref`
  - Description: Retrieve all Employees relations for a specific CashStockOrder.
  
#### Create Employee relation
- **POST** `/api/CashStockOrders/{key}/Employees/{relatedKey}/$ref`
  - Description: Create a new Employee relation for a specific CashStockOrder.
  
#### Update Employee relation
- **PUT** `/api/CashStockOrders/{key}/Employees/{relatedKey}/$ref`
  - Description: Update an existing Employee relation for a specific CashStockOrder.
  
#### Partially Update Employee relation
- **PATCH** `/api/CashStockOrders/{key}/Employees/{relatedKey}/$ref`
  - Description: Partially update an existing Employee relation for a specific CashStockOrder.

#### Delete Employee relation
- **DELETE** `/api/CashStockOrders/{key}/Employees/{relatedKey}/$ref`
  - Description: Delete an existing Employee relation for a specific CashStockOrder.

## Related Entities

[VendingMachine](VendingMachineEndpoints.md)

[Employee](EmployeeEndpoints.md)
