# API Endpoints for the Country entity

This document provides information about the various endpoints available in our API for the Country entity.

## Country Endpoints

### Get Country Count
- **GET** `/api/v1/Countries/$count`
  - Description: Retrieve the number of Countries.

### Get Country by ID
- **GET** `/api/v1/Countries/{key}`
  - Description: Retrieve information about a Country by ID.
  
### Get Countries
- **GET** `/api/v1/Countries`
  - Description: Retrieve information about Countries.

### Create Country
- **POST** `/api/v1/Countries`
  - Description: Create a new Country.

### Update Country
- **PUT** `/api/v1/Countries/{key}`
  - Description: Update an existing Country.

### Partially Update Country
- **PATCH** `/api/v1/Countries/{key}`
  - Description: Partially update an existing Country.
 
### Delete Country
- **DELETE** `/api/v1/Countries/{key}`
  - Description: Delete an existing Country.

## Owned Relationships Endpoints

### CountryBarCode

#### Get CountryBarCodes
- **GET** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Retrieve all CountryBarCodes for a specific Country.

#### Create CountryBarCode
- **POST** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Create a new CountryBarCode for a specific Country.

#### Update CountryBarCode
- **PUT** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Update an existing CountryBarCode for a specific Country.

  
#### Partially Update CountryBarCode
- **PATCH** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Partially update an existing CountryBarCode for a specific Country.

#### Delete CountryBarCode
- **DELETE** `/api/v1/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Delete an existing CountryBarCode for a specific Country.

### CountryLocalNames

#### Get CountryLocalNames
- **GET** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Retrieve all CountryLocalNames for a specific Country.
- **GET** `/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Retrieve a CountryLocalNames by ID for a specific Country.

#### Create CountryLocalNames
- **POST** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Create a new CountryLocalNames for a specific Country.

#### Delete CountryLocalNames
- **DELETE** `/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalNames for a specific Country.

## Relationships Endpoints

### Continent

#### Get Continent relations
- **GET** `/api/v1/Countries/{key}/Continents/$ref`
  - Description: Retrieve all existing Continents relations for a specific Country.


## Custom Commands

### UpdatePopulationStatistics
- **POST** `/UpdatePopulationStatistics`
  - Description: Instructs the service to collect updated population statistics

## Custom Queries

### GetCountriesByContinent
- **GET** `/GetCountriesByContinent`
  - Description: Returns a list of countries for a given continent

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Country.
- **GET** `/api/v1/Countries/CountryLanguages`
  - **Description**: Retrieve non-conventional values of Languages for a specific Country.
  
- **GET** `/api/v1/Countries/CountryLanguagesLocalized`
  - **Description**: Retrieve localized values of Languages for a specific Country.

- **DELETE** `/api/v1/Countries/CountryLanguagesLocalized/{cultureCode}`
  - **Description**: Delete the localized values of Languages for a specific culture code in Country.

- **PUT** `/api/v1/Countries/CountryLanguagesLocalized`
  - **Description**: Update or create localized values of Languages for a specific Country. Requires a payload with the new values.
## Localized Endpoints
- **GET** `/api/v1/Countries/{key}/CountriesLocalized`
  - Description: Retrieve all CountriesLocalized for a specific Country.

- **PUT** `/api/v1/Countries/{key}/CountriesLocalized/{cultureCode}`
    - Description: Update or create values of CountryLocalized for a specific Country. Requires a payload with the new value of CountryLocalizedUpsertDto.

- **DELETE** `/api/v1/Countries/{key}/CountriesLocalized/{cultureCode}`
    - Description: Delete the localized values of CountryLocalized for a specific culture code for a specific Country.


## Related Entities

[Continent](ContinentEndpoints.md)
[People](PeopleEndpoints.md)