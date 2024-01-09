# API Endpoints for the Workplace entity

This document provides information about the various endpoints available in our API for the Workplace entity.

## Workplace Endpoints

### Get Workplace Count
- **GET** `/api/v1/Workplaces/$count`
  - Description: Retrieve the number of Workplaces.

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

#### Get Country
- **GET** `/api/v1/Workplaces/{key}/BelongsToCountry`
  - Description: Retrieve all existing Countries for a specific Workplace.
  
#### Create Country
- **POST** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}`
  - Description: Create a new Country for a specific Workplace.
  
#### Update Country
- **PUT** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}`
  - Description: Updates an existing Country for a specific Workplace.
- **PUT** `/api/v1/Workplaces/{key}/BelongsToCountry`
  - Description: Updates the Country for a specific Workplace.

#### Delete Country
- **DELETE** `/api/v1/Workplaces/{key}/BelongsToCountry/{relatedKey}`
  - Description: Delete an existing Country for a specific Workplace.

#### Delete Country
- **DELETE** `/api/v1/Workplaces/{key}/BelongsToCountry`
  - Description: Delete all existing Countries for a specific Workplace.

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

#### Get Tenant
- **GET** `/api/v1/Workplaces/{key}/TenantsInWorkplace`
  - Description: Retrieve all existing Tenants for a specific Workplace.
  
#### Create Tenant
- **POST** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}`
  - Description: Create a new Tenant for a specific Workplace.
  
#### Update Tenant
- **PUT** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}`
  - Description: Updates an existing Tenant for a specific Workplace.
- **PUT** `/api/v1/Workplaces/{key}/TenantsInWorkplace`
  - Description: Updates the Tenant for a specific Workplace.

#### Delete Tenant
- **DELETE** `/api/v1/Workplaces/{key}/TenantsInWorkplace/{relatedKey}`
  - Description: Delete an existing Tenant for a specific Workplace.

#### Delete Tenant
- **DELETE** `/api/v1/Workplaces/{key}/TenantsInWorkplace`
  - Description: Delete all existing Tenants for a specific Workplace.

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

## Other Related Endpoints

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PATCH** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **GET** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **POST** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **PUT** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **DELETE** `/api/v1/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`
## Related Entities

[Country](CountryEndpoints.md)

[Tenant](TenantEndpoints.md)
