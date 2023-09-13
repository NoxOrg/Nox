# API Endpoints for the Employee entity

This document provides information about the various endpoints available in our API for the Employee entity.

## Employee Endpoints

### Get Employee by ID
- **GET** `/api/Employees/{key}`
  - Description: Retrieve information about a Employee by ID.
  
### Get Employees
- **GET** `/api/Employees`
  - Description: Retrieve information about Employees.

### Create Employee
- **POST** `/api/Employees`
  - Description: Create a new Employee with the provided data.

### Update Employee
- **PUT** `/api/Employees/{key}`
  - Description: Update an existing Employee by ID with the provided data.
 
### Delete Employee
- **DELETE** `/api/Employees/{key}`
  - Description: Delete an existing Employee by its ID.

## Owned Relationships Endpoints

### Get EmployeePhoneNumbers
- **GET** `/api/Employees/{key}/EmployeePhoneNumbers`
  - Description: Retrieve all EmployeePhoneNumbers for a specific Employee.
  
### Create EmployeePhoneNumber
- **POST** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Create a new EmployeePhoneNumber for a specific Employee.
  
### Update EmployeePhoneNumber
- **PUT** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Update an existing EmployeePhoneNumber for a specific Employee.
  
### Partially Update EmployeePhoneNumber
- **PATCH** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Partially update an existing EmployeePhoneNumber for a specific Employee.

### Delete EmployeePhoneNumber
- **DELETE** `/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}`
  - Description: Delete an existing EmployeePhoneNumber by its ID for a specific Employee.

## Relationships Endpoints

[CashStockOrder Endpoints](CashStockOrderEndpoints.md)
