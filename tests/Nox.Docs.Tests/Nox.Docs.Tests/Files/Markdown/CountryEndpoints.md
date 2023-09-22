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

## Owned Relationships Endpoints

### CountryLocalNames

#### Get CountryLocalNames
- **GET** `/api/Countries/{key}/CountryLocalNames`
  - Description: Retrieve all CountryLocalNames for a specific Country.

#### Create CountryLocalNames
- **POST** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Create a new CountryLocalNames for a specific Country.

## Relationships Endpoints

### Continent

#### Get Continent relation by ID
- **GET** `/api/Countries/{key}/Continents/{relatedKey}/$ref`
  - Description: Retrieve an existing Continents relation for a specific Country.

#### Get Continent relations
- **GET** `/api/Countries/{key}/Continents/$ref`
  - Description: Retrieve all Continents relations for a specific Country.

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
