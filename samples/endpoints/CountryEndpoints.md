# API Endpoints for the Country entity

This document provides information about the various endpoints available in our API for the Country entity.

## Country Endpoints

### Get Country by ID
- **GET** `/api/Countries/{key}`
  - Description: Retrieve information about a Country by ID.
  
### Get Countries
- **GET** `/api/Countries`
  - Description: Retrieve information about Countries.

### Create Country
- **POST** `/api/Countries`
  - Description: Create a new Country with the provided data.

### Update Country
- **PUT** `/api/Countries/{key}`
  - Description: Update an existing Country by ID with the provided data.
 
### Delete Country
- **DELETE** `/api/Countries/{key}`
  - Description: Delete an existing Country by its ID.

## Owned Relationships Endpoints

### Get CountryTimeZones
- **GET** `/api/Countries/{key}/CountryTimeZones`
  - Description: Retrieve all CountryTimeZones for a specific Country.
  
### Create CountryTimeZone
- **POST** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Create a new CountryTimeZone for a specific Country.
  
### Update CountryTimeZone
- **PUT** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Update an existing CountryTimeZone for a specific Country.
  
### Partially Update CountryTimeZone
- **PATCH** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Partially update an existing CountryTimeZone for a specific Country.

### Delete CountryTimeZone
- **DELETE** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Delete an existing CountryTimeZone by its ID for a specific Country.

### Get Holidays
- **GET** `/api/Countries/{key}/Holidays`
  - Description: Retrieve all Holidays for a specific Country.
  
### Create Holiday
- **POST** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Create a new Holiday for a specific Country.
  
### Update Holiday
- **PUT** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Update an existing Holiday for a specific Country.
  
### Partially Update Holiday
- **PATCH** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Partially update an existing Holiday for a specific Country.

### Delete Holiday
- **DELETE** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Delete an existing Holiday by its ID for a specific Country.

## Relationships Endpoints

[Currency Endpoints](CurrencyEndpoints.md)

[Commission Endpoints](CommissionEndpoints.md)

[VendingMachine Endpoints](VendingMachineEndpoints.md)

[Customer Endpoints](CustomerEndpoints.md)
