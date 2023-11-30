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
  - Description: Create a new Country.

### Update Country
- **PUT** `/api/Countries/{key}`
  - Description: Update an existing Country.

### Partially Update Country
- **PATCH** `/api/Countries/{key}`
  - Description: Partially update an existing Country.
 
### Delete Country
- **DELETE** `/api/Countries/{key}`
  - Description: Delete an existing Country.

## Owned Relationships Endpoints

### CountryLocalName

#### Get CountryLocalNames
- **GET** `/api/Countries/{key}/CountryLocalNames`
  - Description: Retrieve all CountryLocalNames for a specific Country.
- **GET** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Retrieve a CountryLocalName by ID for a specific Country.

#### Create CountryLocalName
- **POST** `/api/Countries/{key}/CountryLocalNames`
  - Description: Create a new CountryLocalName for a specific Country.

#### Update CountryLocalName
- **PUT** `/api/Countries/{key}/CountryLocalNames`
  - Description: Update an existing CountryLocalName for a specific Country.
  
#### Partially Update CountryLocalName
- **PATCH** `/api/Countries/{key}/CountryLocalNames`
  - Description: Partially update an existing CountryLocalName for a specific Country.

#### Delete CountryLocalName
- **DELETE** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalName for a specific Country.

### CountryBarCode

#### Get CountryBarCodes
- **GET** `/api/Countries/{key}/CountryBarCodes`
  - Description: Retrieve all CountryBarCodes for a specific Country.

#### Create CountryBarCode
- **POST** `/api/Countries/{key}/CountryBarCodes`
  - Description: Create a new CountryBarCode for a specific Country.

#### Update CountryBarCode
- **PUT** `/api/Countries/{key}/CountryBarCodes`
  - Description: Update an existing CountryBarCode for a specific Country.
  
#### Partially Update CountryBarCode
- **PATCH** `/api/Countries/{key}/CountryBarCodes`
  - Description: Partially update an existing CountryBarCode for a specific Country.

#### Delete CountryBarCode
- **DELETE** `/api/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Delete an existing CountryBarCode for a specific Country.

### CountryTimeZone

#### Get CountryTimeZones
- **GET** `/api/Countries/{key}/CountryTimeZones`
  - Description: Retrieve all CountryTimeZones for a specific Country.

#### Create CountryTimeZone
- **POST** `/api/Countries/{key}/CountryTimeZones`
  - Description: Create a new CountryTimeZone for a specific Country.

#### Update CountryTimeZone
- **PUT** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Update an existing CountryTimeZone for a specific Country.
  
#### Partially Update CountryTimeZone
- **PATCH** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Partially update an existing CountryTimeZone for a specific Country.

#### Delete CountryTimeZone
- **DELETE** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Delete an existing CountryTimeZone for a specific Country.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Country.
  
#### Create Workplace relation
- **POST** `/api/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Country.
  
#### Update Workplace relation
- **PUT** `/api/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Country.
- **PUT** `/api/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Updates the Workplace relations for a specific Country.

#### Delete Workplace relation
- **DELETE** `/api/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Country.

#### Delete Workplace relations
- **DELETE** `/api/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Country.

## Related Entities

[Workplace](WorkplaceEndpoints.md)
