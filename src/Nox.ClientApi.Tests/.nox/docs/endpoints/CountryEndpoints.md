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
  
#### Create CountryLocalName
- **POST** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Create a new CountryLocalName for a specific Country.
  
#### Update CountryLocalName
- **PUT** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Update an existing CountryLocalName for a specific Country.
  
#### Partially Update CountryLocalName
- **PATCH** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Partially update an existing CountryLocalName for a specific Country.

#### Delete CountryLocalName
- **DELETE** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalName for a specific Country.

### CountryBarCode

#### Get CountryBarCodes
- **GET** `/api/Countries/{key}/CountryBarCodes`
  - Description: Retrieve all CountryBarCodes for a specific Country.
  
#### Create CountryBarCode
- **POST** `/api/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Create a new CountryBarCode for a specific Country.
  
#### Update CountryBarCode
- **PUT** `/api/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Update an existing CountryBarCode for a specific Country.
  
#### Partially Update CountryBarCode
- **PATCH** `/api/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Partially update an existing CountryBarCode for a specific Country.

#### Delete CountryBarCode
- **DELETE** `/api/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Delete an existing CountryBarCode for a specific Country.

## Relationships Endpoints

### Workplace

#### Get Workplace relation by ID
- **GET** `/api/Countries/{key}/Workplaces/{relatedKey}/$ref`
  - Description: Retrieve an existing Workplaces relation for a specific Country.

#### Get Workplace relations
- **GET** `/api/Countries/{key}/Workplaces/$ref`
  - Description: Retrieve all Workplaces relations for a specific Country.
  
#### Create Workplace relation
- **POST** `/api/Countries/{key}/Workplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Country.
  
#### Update Workplace relation
- **PUT** `/api/Countries/{key}/Workplaces/{relatedKey}/$ref`
  - Description: Update an existing Workplace relation for a specific Country.
  
#### Partially Update Workplace relation
- **PATCH** `/api/Countries/{key}/Workplaces/{relatedKey}/$ref`
  - Description: Partially update an existing Workplace relation for a specific Country.

#### Delete Workplace relation
- **DELETE** `/api/Countries/{key}/Workplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Country.

## Related Entities

[Workplace](WorkplaceEndpoints.md)