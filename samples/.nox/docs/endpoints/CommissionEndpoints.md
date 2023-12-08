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

#### Get Country relations
- **GET** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Commission.
  
#### Create Country relation
- **POST** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Commission.
  
#### Update Country relation
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Updates the Country relations for a specific Commission.

#### Delete Country relation
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Commission.

#### Delete Country relations
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Commission.

### Booking

#### Get Booking relations
- **GET** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Retrieve all existing Bookings relations for a specific Commission.
  
#### Create Booking relation
- **POST** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Commission.
  
#### Update Booking relation
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Updates an existing Booking relation for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Updates the Booking relations for a specific Commission.

#### Delete Booking relation
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Commission.

#### Delete Booking relations
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Delete all existing Bookings relations for a specific Commission.

## Related Entities

[Country](CountryEndpoints.md)

[Booking](BookingEndpoints.md)

