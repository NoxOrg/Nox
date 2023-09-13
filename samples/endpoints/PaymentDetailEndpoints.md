# API Endpoints for the PaymentDetail entity

This document provides information about the various endpoints available in our API for the PaymentDetail entity.

## PaymentDetail Endpoints

### Get PaymentDetail by ID
- **GET** `/api/PaymentDetails/{key}`
  - Description: Retrieve information about a PaymentDetail by ID.
  
### Get PaymentDetails
- **GET** `/api/PaymentDetails`
  - Description: Retrieve information about PaymentDetails.

### Create PaymentDetail
- **POST** `/api/PaymentDetails`
  - Description: Create a new PaymentDetail with the provided data.

### Update PaymentDetail
- **PUT** `/api/PaymentDetails/{key}`
  - Description: Update an existing PaymentDetail by ID with the provided data.
 
### Delete PaymentDetail
- **DELETE** `/api/PaymentDetails/{key}`
  - Description: Delete an existing PaymentDetail by its ID.

### Relationships Endpoints

[Customer Endpoints](CustomerEndpoints.md)

[PaymentProvider Endpoints](PaymentProviderEndpoints.md)
