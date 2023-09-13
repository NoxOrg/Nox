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
  - Description: Create a new CashStockOrder with the provided data.

### Update CashStockOrder
- **PUT** `/api/CashStockOrders/{key}`
  - Description: Update an existing CashStockOrder by ID with the provided data.
 
### Delete CashStockOrder
- **DELETE** `/api/CashStockOrders/{key}`
  - Description: Delete an existing CashStockOrder by its ID.

## Relationships Endpoints

[VendingMachine Endpoints](VendingMachineEndpoints.md)

[Employee Endpoints](EmployeeEndpoints.md)
