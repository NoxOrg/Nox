# API Endpoints for the Workplace entity

This document provides information about the various endpoints available in our API for the Workplace entity.

## Workplace Endpoints

### Get Workplace by ID
- **GET** `/api/Workplaces/{key}`
  - Description: Retrieve information about a Workplace by ID.
  
### Get Workplaces
- **GET** `/api/Workplaces`
  - Description: Retrieve information about Workplaces.

### Create Workplace
- **POST** `/api/Workplaces`
  - Description: Create a new Workplace.

### Update Workplace
- **PUT** `/api/Workplaces/{key}`
  - Description: Update an existing Workplace.

### Partially Update Workplace
- **PATCH** `/api/Workplaces/{key}`
  - Description: Partially update an existing Workplace.
 
### Delete Workplace
- **DELETE** `/api/Workplaces/{key}`
  - Description: Delete an existing Workplace.

## Relationships Endpoints

### Country

#### Get Country relation by ID
- **GET** `/api/Workplaces/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific Workplace.

#### Get Country relations
- **GET** `/api/Workplaces/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific Workplace.
  
#### Create Country relation
- **POST** `/api/Workplaces/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Workplace.
  
#### Update Country relation
- **PUT** `/api/Workplaces/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific Workplace.
  
#### Partially Update Country relation
- **PATCH** `/api/Workplaces/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific Workplace.

#### Delete Country relation
- **DELETE** `/api/Workplaces/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Workplace.

## Related Entities

[Country](CountryEndpoints.md)
