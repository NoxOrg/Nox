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

#### Get Country relation by ID
- **GET** `/api/Continents/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific Continent.

#### Get Country relations
- **GET** `/api/Continents/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific Continent.
  
#### Create Country relation
- **POST** `/api/Continents/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Continent.
  
#### Update Country relation
- **PUT** `/api/Continents/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific Continent.
  
#### Partially Update Country relation
- **PATCH** `/api/Continents/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific Continent.

#### Delete Country relation
- **DELETE** `/api/Continents/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Continent.

## Related Entities

[Country](CountryEndpoints.md)
