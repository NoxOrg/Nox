# API Endpoints for the Continent entity

This document provides information about the various endpoints available in our API for the Continent entity.

## Continent Endpoints

### Get Continent by ID
- **GET** `/api/Continents/{key}`
  - Description: Retrieve information about a Continent by ID.
  
### Get Continents
- **GET** `/api/Continents`
  - Description: Retrieve information about Continents.


## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/Continents/{key}/CountriesOnContinent/$ref`
  - Description: Retrieve all existing Countries relations for a specific Continent.
  
#### Create Country relation
- **POST** `/api/Continents/{key}/CountriesOnContinent/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Continent.
  
#### Update Country relation
- **PUT** `/api/Continents/{key}/CountriesOnContinent/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Continent.
- **PUT** `/api/Continents/{key}/CountriesOnContinent/$ref`
  - Description: Updates the Country relations for a specific Continent.

#### Delete Country relation
- **DELETE** `/api/Continents/{key}/CountriesOnContinent/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Continent.

#### Delete Country relations
- **DELETE** `/api/Continents/{key}/CountriesOnContinent/$ref`
  - Description: Delete all existing Countries relations for a specific Continent.

## Related Entities

[Country](CountryEndpoints.md)
