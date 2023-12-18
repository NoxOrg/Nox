# API Endpoints for the Workplace entity

This document provides information about the various endpoints available in our API for the Workplace entity.

## Workplace Endpoints

### Get Workplace by ID
- **GET** `/api/v1/Workplaces/{key}`
  - Description: Retrieve information about a Workplace by ID.
  
### Get Workplaces
- **GET** `/api/v1/Workplaces`
  - Description: Retrieve information about Workplaces.

### Create Workplace
- **POST** `/api/v1/Workplaces`
  - Description: Create a new Workplace.

### Update Workplace
- **PUT** `/api/v1/Workplaces/{key}`
  - Description: Update an existing Workplace.

### Partially Update Workplace
- **PATCH** `/api/v1/Workplaces/{key}`
  - Description: Partially update an existing Workplace.
 
### Delete Workplace
- **DELETE** `/api/v1/Workplaces/{key}`
  - Description: Delete an existing Workplace.

## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/v1/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Workplace.
  
#### Create Country relation
- **POST** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Workplace.
  
#### Update Country relation
- **PUT** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Workplace.
- **PUT** `/api/v1/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Updates the Country relations for a specific Workplace.

#### Delete Country relation
- **DELETE** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Workplace.

#### Delete Country relations
- **DELETE** `/api/v1/Workplaces/{key}/BelongsToCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Workplace.

### Tenant

#### Get Tenant relations
- **GET** `/api/v1/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Retrieve all existing Tenants relations for a specific Workplace.
  
#### Create Tenant relation
- **POST** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Create a new Tenant relation for a specific Workplace.
  
#### Update Tenant relation
- **PUT** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Updates an existing Tenant relation for a specific Workplace.
- **PUT** `/api/v1/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Updates the Tenant relations for a specific Workplace.

#### Delete Tenant relation
- **DELETE** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}/$ref`
  - Description: Delete an existing Tenant relation for a specific Workplace.

#### Delete Tenant relations
- **DELETE** `/api/v1/Workplaces/{key}/TenantsInWorkplace/$ref`
  - Description: Delete all existing Tenants relations for a specific Workplace.

## Related Entities

[Country](CountryEndpoints.md)

[Tenant](TenantEndpoints.md)

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Workplace.
- **GET** `/api/v1/Workplaces/WorkplaceOwnerships`
  - **Description**: Retrieve non-conventional values of Ownerships for a specific Workplace.
  
- **GET** `/api/v1/Workplaces/WorkplaceOwnershipsLocalized`
  - **Description**: Retrieve localized values of Ownerships for a specific Workplace.

- **DELETE** `/api/v1/Workplaces/WorkplaceOwnershipsLocalized/{cultureCode}`
  - **Description**: Delete the localized values of Ownerships for a specific culture code in Workplace.

- **PUT** `/api/v1/Workplaces/WorkplaceOwnershipsLocalized`
  - **Description**: Update or create localized values of Ownerships for a specific Workplace. Requires a payload with the new values.

- **GET** `/api/v1/Workplaces/WorkplaceTypes`
  - **Description**: Retrieve non-conventional values of Types for a specific Workplace.
## Localized Endpoints

- **GET** `/api/v1/Workplaces/{key}/WorkplacesLocalized`
  - Description: Retrieve all WorkplacesLocalized for a specific Workplace.

- **PUT** `/api/v1/Workplaces/{key}/WorkplacesLocalized/{cultureCode}`
    - Description: Update or create values of WorkplaceLocalized for a specific Workplace. Requires a payload with the new value of WorkplaceLocalizedUpsertDto.
