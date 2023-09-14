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
