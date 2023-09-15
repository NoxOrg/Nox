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

### CountryLocalNames

#### Get CountryLocalNames
- **GET** `/api/Countries/{key}/CountryLocalNames`
  - Description: Retrieve all CountryLocalNames for a specific Country.
  
#### Create CountryLocalNames
- **POST** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Create a new CountryLocalNames for a specific Country.
  
#### Update CountryLocalNames
- **PUT** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Update an existing CountryLocalNames for a specific Country.
  
#### Partially Update CountryLocalNames
- **PATCH** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Partially update an existing CountryLocalNames for a specific Country.

#### Delete CountryLocalNames
- **DELETE** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalNames for a specific Country.

## Relationships Endpoints

### Continent

#### Get Continent relation by ID
- **GET** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Retrieve an existing Continents relation for a specific Country.

#### Get Continent relations
- **GET** `/api/Countries/{key}/Continents/$ref`
  - Description: Retrieve all Continents relations for a specific Country.
  
#### Create Continent relation
- **POST** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Create a new Continent relation for a specific Country.
  
#### Update Continent relation
- **PUT** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Update an existing Continent relation for a specific Country.
  
#### Partially Update Continent relation
- **PATCH** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Partially update an existing Continent relation for a specific Country.

#### Delete Continent relation
- **DELETE** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Delete an existing Continent relation for a specific Country.

## Custom Commands

### UpdatePopulationStatistics
- **POST** `/UpdatePopulationStatistics`
  - Description: Instructs the service to collect updated population statistics

## Custom Queries

### GetCountriesByContinent
- **GET** `/GetCountriesByContinent`
  - Description: Returns a list of countries for a given continent

## Related Entities

[Continent](ContinentEndpoints.md)
