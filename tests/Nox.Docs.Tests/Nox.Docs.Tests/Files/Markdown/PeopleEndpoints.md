# API Endpoints for the People entity

This document provides information about the various endpoints available in our API for the People entity.

## People Endpoints

### Get People by ID
- **GET** `/api/v1/Peoples/{key}`
  - Description: Retrieve information about a People by ID.
  
### Get Peoples
- **GET** `/api/v1/Peoples`
  - Description: Retrieve information about Peoples.

### Create People
- **POST** `/api/v1/Peoples`
  - Description: Create a new People.

### Update People
- **PUT** `/api/v1/Peoples/{key}`
  - Description: Update an existing People.

### Partially Update People
- **PATCH** `/api/v1/Peoples/{key}`
  - Description: Partially update an existing People.

## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/$ref`
  - Description: Retrieve all existing Countries relations for a specific People.
  
#### Create Country relation
- **POST** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific People.
  
#### Update Country relation
- **PUT** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific People.
- **PUT** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/$ref`
  - Description: Updates the Country relations for a specific People.

#### Delete Country relation
- **DELETE** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific People.

#### Delete Country relations
- **DELETE** `/api/v1/Peoples/{key}/CountriesInhabitedByPeople/$ref`
  - Description: Delete all existing Countries relations for a specific People.

## Related Entities

[Country](CountryEndpoints.md)

