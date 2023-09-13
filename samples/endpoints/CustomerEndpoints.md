# API Endpoints for the Customer entity

This document provides information about the various endpoints available in our API for the Customer entity.

## Customer Endpoints

### Get Customer by ID
- **GET** `/api/Customers/{key}`
  - Description: Retrieve information about a Customer by ID.
  
### Get Customers
- **GET** `/api/Customers`
  - Description: Retrieve information about Customers.

### Create Customer
- **POST** `/api/Customers`
  - Description: Create a new Customer with the provided data.

### Update Customer
- **PUT** `/api/Customers/{key}`
  - Description: Update an existing Customer by ID with the provided data.
 
### Delete Customer
- **DELETE** `/api/Customers/{key}`
  - Description: Delete an existing Customer by its ID.

### Relationships Endpoints

[PaymentDetail Endpoints](PaymentDetailEndpoints.md)

[Booking Endpoints](BookingEndpoints.md)

[Transaction Endpoints](TransactionEndpoints.md)

[Country Endpoints](CountryEndpoints.md)
