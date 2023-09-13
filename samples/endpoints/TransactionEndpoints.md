# API Endpoints for the Transaction entity

This document provides information about the various endpoints available in our API for the Transaction entity.

## Transaction Endpoints

### Get Transaction by ID
- **GET** `/api/Transactions/{key}`
  - Description: Retrieve information about a Transaction by ID.
  
### Get Transactions
- **GET** `/api/Transactions`
  - Description: Retrieve information about Transactions.

### Create Transaction
- **POST** `/api/Transactions`
  - Description: Create a new Transaction with the provided data.

### Update Transaction
- **PUT** `/api/Transactions/{key}`
  - Description: Update an existing Transaction by ID with the provided data.
 
### Delete Transaction
- **DELETE** `/api/Transactions/{key}`
  - Description: Delete an existing Transaction by its ID.

## Relationships Endpoints

[Customer Endpoints](CustomerEndpoints.md)

[Booking Endpoints](BookingEndpoints.md)
