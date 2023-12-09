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

#### Get Country relations
- **GET** `/api/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Workplace.
  
#### Create Country relation
- **POST** `/api/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Workplace.
  
#### Update Country relation
- **PUT** `/api/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Workplace.
- **PUT** `/api/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Updates the Country relations for a specific Workplace.

#### Delete Country relation
- **DELETE** `/api/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Workplace.

#### Delete Country relations
- **DELETE** `/api/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Workplace.

### Tenant

#### Get Tenant relations
- **GET** `/api/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Retrieve all existing Tenants relations for a specific Workplace.
  
#### Create Tenant relation
- **POST** `/api/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Create a new Tenant relation for a specific Workplace.
  
#### Update Tenant relation
- **PUT** `/api/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Updates an existing Tenant relation for a specific Workplace.
- **PUT** `/api/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Updates the Tenant relations for a specific Workplace.

#### Delete Tenant relation
- **DELETE** `/api/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Delete an existing Tenant relation for a specific Workplace.

#### Delete Tenant relations
- **DELETE** `/api/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Delete all existing Tenants relations for a specific Workplace.

## Related Entities

[Country](CountryEndpoints.md)

[Tenant](TenantEndpoints.md)

## Localized Endpoints

- **GET** `/api/Workplaces/{key}/WorkplacesLocalized`
  - Description: Retrieve all WorkplacesLocalized for a specific Workplace.

- **PUT** `/api/Workplaces/{key}/WorkplacesLocalized/{cultureCode}`
    - Description: Update or create values of WorkplaceLocalized for a specific Workplace. Requires a payload with the new value of WorkplaceLocalizedUpsertDto.
