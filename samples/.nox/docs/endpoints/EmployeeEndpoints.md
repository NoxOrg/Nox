# API Endpoints for the Employee entity

This document provides information about the various endpoints available in our API for the Employee entity.

## Employee Endpoints

### Get Employee Count
- **GET** `/api/Employees/$count`
  - Description: Retrieve the number of Employees.

### Get Employee by ID
- **GET** `/api/Employees/{key}`
  - Description: Retrieve information about a Employee by ID.
  
### Get Employees
- **GET** `/api/Employees`
  - Description: Retrieve information about Employees.

### Create Employee
- **POST** `/api/Employees`
  - Description: Create a new Employee.

### Update Employee
- **PUT** `/api/Employees/{key}`
  - Description: Update an existing Employee.

### Partially Update Employee
- **PATCH** `/api/Employees/{key}`
  - Description: Partially update an existing Employee.
 
### Delete Employee
- **DELETE** `/api/Employees/{key}`
  - Description: Delete an existing Employee.

## Owned Relationships Endpoints

### EmployeePhoneNumber

#### Get EmployeePhoneNumbers
- **GET** `/api/Employees/{key}/EmployeePhoneNumbers`
  - Description: Retrieve all EmployeePhoneNumbers for a specific Employee.
- **GET** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Retrieve a EmployeePhoneNumber by ID for a specific Employee.

#### Create EmployeePhoneNumber
- **POST** `/api/Employees/{key}/EmployeePhoneNumbers`
  - Description: Create a new EmployeePhoneNumber for a specific Employee.

#### Update EmployeePhoneNumber
- **PUT** `/api/Employees/{key}/EmployeePhoneNumbers`
  - Description: Update many EmployeePhoneNumber for a specific Employee.
#### Update EmployeePhoneNumber By Id
- **PUT** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Update an existing EmployeePhoneNumber by ID for a specific Employee.
  
#### Partially Update EmployeePhoneNumber
- **PATCH** `/api/Employees/{key}/EmployeePhoneNumbers`
  - Description: Partially update an existing EmployeePhoneNumber for a specific Employee.

#### Delete EmployeePhoneNumber
- **DELETE** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Delete an existing EmployeePhoneNumber for a specific Employee.

## Relationships Endpoints

### CashStockOrder

#### Get CashStockOrder relations
- **GET** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/$ref`
  - Description: Retrieve all existing CashStockOrders relations for a specific Employee.
  
#### Create CashStockOrder relation
- **POST** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}/$ref`
  - Description: Create a new CashStockOrder relation for a specific Employee.
  
#### Update CashStockOrder relation
- **PUT** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}/$ref`
  - Description: Updates an existing CashStockOrder relation for a specific Employee.
- **PUT** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/$ref`
  - Description: Updates the CashStockOrder relations for a specific Employee.

#### Delete CashStockOrder relation
- **DELETE** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}/$ref`
  - Description: Delete an existing CashStockOrder relation for a specific Employee.

#### Delete CashStockOrder relations
- **DELETE** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/$ref`
  - Description: Delete all existing CashStockOrders relations for a specific Employee.

#### Get CashStockOrder
- **GET** `/api/Employees/{key}/EmployeeReviewingCashStockOrder`
  - Description: Retrieve all existing CashStockOrders for a specific Employee.
  
#### Create CashStockOrder
- **POST** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}`
  - Description: Create a new CashStockOrder for a specific Employee.
  
#### Update CashStockOrder
- **PUT** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}`
  - Description: Updates an existing CashStockOrder for a specific Employee.
- **PUT** `/api/Employees/{key}/EmployeeReviewingCashStockOrder`
  - Description: Updates the CashStockOrder for a specific Employee.

#### Delete CashStockOrder
- **DELETE** `/api/Employees/{key}/EmployeeReviewingCashStockOrder/{relatedKey}`
  - Description: Delete an existing CashStockOrder for a specific Employee.

#### Delete CashStockOrder
- **DELETE** `/api/Employees/{key}/EmployeeReviewingCashStockOrder`
  - Description: Delete all existing CashStockOrders for a specific Employee.


## Other Related Endpoints

- **GET** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine`

- **POST** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine`

- **PUT** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine`

- **PATCH** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine`

- **GET** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine/$ref`

- **POST** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine/{vendingMachineKey}/$ref`

- **PUT** `/api/Employees/{employeesKey}/CashStockOrder/{cashStockOrderKey}/VendingMachine/{vendingMachineKey}/$ref`

## Related Entities

[CashStockOrder](CashStockOrderEndpoints.md)