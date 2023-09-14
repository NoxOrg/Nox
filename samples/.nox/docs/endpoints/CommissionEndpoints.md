# API Endpoints for the Commission entity

This document provides information about the various endpoints available in our API for the Commission entity.

## Commission Endpoints

### Get Commission by ID
- **GET** `/api/Commissions/{key}`
  - Description: Retrieve information about a Commission by ID.
  
### Get Commissions
- **GET** `/api/Commissions`
  - Description: Retrieve information about Commissions.

### Create Commission
- **POST** `/api/Commissions`
  - Description: Create a new Commission.

### Update Commission
- **PUT** `/api/Commissions/{key}`
  - Description: Update an existing Commission.

### Partially Update Commission
- **PATCH** `/api/Commissions/{key}`
  - Description: Partially update an existing Commission.
 
### Delete Commission
- **DELETE** `/api/Commissions/{key}`
  - Description: Delete an existing Commission.

## Relationships Endpoints

### Country

#### Get Country relation by ID
- **GET** `/api/Commissions/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific Commission.

#### Get Country relations
- **GET** `/api/Commissions/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific Commission.
  
#### Create Country relation
- **POST** `/api/Commissions/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Commission.
  
#### Update Country relation
- **PUT** `/api/Commissions/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific Commission.
  
#### Partially Update Country relation
- **PATCH** `/api/Commissions/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific Commission.

#### Delete Country relation
- **DELETE** `/api/Commissions/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Commission.

### Booking

#### Get Booking relation by ID
- **GET** `/api/Commissions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Retrieve an existing Bookings relation for a specific Commission.

#### Get Booking relations
- **GET** `/api/Commissions/{key}/Bookings/$ref`
  - Description: Retrieve all Bookings relations for a specific Commission.
  
#### Create Booking relation
- **POST** `/api/Commissions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Commission.
  
#### Update Booking relation
- **PUT** `/api/Commissions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Update an existing Booking relation for a specific Commission.
  
#### Partially Update Booking relation
- **PATCH** `/api/Commissions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Partially update an existing Booking relation for a specific Commission.

#### Delete Booking relation
- **DELETE** `/api/Commissions/{key}/Bookings/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Commission.

## Related Entities

[Country](CountryEndpoints.md)

[Booking](BookingEndpoints.md)
