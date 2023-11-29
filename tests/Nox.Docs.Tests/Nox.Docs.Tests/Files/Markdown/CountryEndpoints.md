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
- **GET** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Retrieve a CountryLocalNames by ID for a specific Country.

#### Create CountryLocalNames
- **POST** `/api/Countries/{key}/CountryLocalNames`
  - Description: Create a new CountryLocalNames for a specific Country.

#### Delete CountryLocalNames
- **DELETE** `/api/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalNames for a specific Country.

## Relationships Endpoints

### Continent

#### Get Continent relations
- **GET** `/api/Countries/{key}/Continents/$ref`
  - Description: Retrieve all existing Continents relations for a specific Country.

### People

#### Get People relations
- **GET** `/api/Countries/{key}/Inhabitants/$ref`
  - Description: Retrieve all existing Peoples relations for a specific Country.
  
#### Create People relation
- **POST** `/api/Countries/{key}/Inhabitants/{relatedKey}/$ref`
  - Description: Create a new People relation for a specific Country.
  
#### Update People relation
- **PUT** `/api/Countries/{key}/Inhabitants/{relatedKey}/$ref`
  - Description: Updates an existing People relation for a specific Country.
- **PUT** `/api/Countries/{key}/Inhabitants/$ref`
  - Description: Updates the People relations for a specific Country.

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

[People](PeopleEndpoints.md)
