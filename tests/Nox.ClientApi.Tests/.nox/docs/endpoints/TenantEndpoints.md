# API Endpoints for the Tenant entity

This document provides information about the various endpoints available in our API for the Tenant entity.

## Tenant Endpoints

### Get Tenant Count
- **GET** `/api/v1/Tenants/$count`
  - Description: Retrieve the number of Tenants.

### Get Tenant by ID
- **GET** `/api/v1/Tenants/{key}`
  - Description: Retrieve information about a Tenant by ID.
  
### Get Tenants
- **GET** `/api/v1/Tenants`
  - Description: Retrieve information about Tenants.

### Create Tenant
- **POST** `/api/v1/Tenants`
  - Description: Create a new Tenant.

### Update Tenant
- **PUT** `/api/v1/Tenants/{key}`
  - Description: Update an existing Tenant.

### Partially Update Tenant
- **PATCH** `/api/v1/Tenants/{key}`
  - Description: Partially update an existing Tenant.
 
### Delete Tenant
- **DELETE** `/api/v1/Tenants/{key}`
  - Description: Delete an existing Tenant.

## Owned Relationships Endpoints

### TenantBrand

#### Get TenantBrands
- **GET** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Retrieve all TenantBrands for a specific Tenant.
- **GET** `/api/v1/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Retrieve a TenantBrand by ID for a specific Tenant.

#### Create TenantBrand
- **POST** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Create a new TenantBrand for a specific Tenant.

#### Update TenantBrand
- **PUT** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Update an existing TenantBrand for a specific Tenant.
  
#### Partially Update TenantBrand
- **PATCH** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Partially update an existing TenantBrand for a specific Tenant.

#### Delete TenantBrand
- **DELETE** `/api/v1/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Delete an existing TenantBrand for a specific Tenant.

### TenantContact

#### Get TenantContacts
- **GET** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Retrieve all TenantContacts for a specific Tenant.

#### Create TenantContact
- **POST** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Create a new TenantContact for a specific Tenant.

#### Update TenantContact
- **PUT** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Update an existing TenantContact for a specific Tenant.
  
#### Partially Update TenantContact
- **PATCH** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Partially update an existing TenantContact for a specific Tenant.

#### Delete TenantContact
- **DELETE** `/api/v1/Tenants/{key}/TenantContacts/{relatedKey}`
  - Description: Delete an existing TenantContact for a specific Tenant.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Tenant.
  
#### Create Workplace relation
- **POST** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Tenant.
  
#### Update Workplace relation
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Tenant.
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Updates the Workplace relations for a specific Tenant.

#### Delete Workplace relation
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Tenant.

#### Delete Workplace relations
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Tenant.

#### Get Workplace
- **GET** `/api/v1/Tenants/{key}/TenantWorkplaces`
  - Description: Retrieve all existing Workplaces for a specific Tenant.
  
#### Create Workplace
- **POST** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}`
  - Description: Create a new Workplace for a specific Tenant.
  
#### Update Workplace
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}`
  - Description: Updates an existing Workplace for a specific Tenant.
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces`
  - Description: Updates the Workplace for a specific Tenant.

#### Delete Workplace
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}`
  - Description: Delete an existing Workplace for a specific Tenant.

#### Delete Workplace
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces`
  - Description: Delete all existing Workplaces for a specific Tenant.

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Tenant.
- **GET** `/api/v1/Tenants/TenantStatuses`
  - **Description**: Retrieve non-conventional values of Statuses for a specific Tenant.
## Localized Endpoints

- **PUT** `/api/v1/Tenants/{key}/TenantBrandsLocalized/{cultureCode}` 
    - Description: Update or create value of TenantBrandLocalized for a specific Tenant. Requires a payload with the new value of TenantBrandLocalizedUpsertDto.

- **DELETE** `/api/v1/Tenants/{key}/TenantBrandsLocalized/{cultureCode}` 
    - Description: Delete the localized values of TenantBrandLocalized for a specific culture code in Tenant.

- **PUT** `/api/v1/Tenants/{key}/TenantContactLocalized/{cultureCode}` 
    - Description: Update or create value of TenantContactLocalized for a specific Tenant. Requires a payload with the new value of TenantContactLocalizedUpsertDto.

- **DELETE** `/api/v1/Tenants/{key}/TenantContactLocalized/{cultureCode}` 
    - Description: Delete the localized values of TenantContactLocalized for a specific culture code in Tenant.


## Other Related Endpoints

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PATCH** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **GET** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/$ref`

- **POST** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **PUT** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **DELETE** `/api/v1/Tenants/{tenantsKey}/Workplaces/{workplacesKey}/Country/{countryKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

## Related Entities

[Workplace](WorkplaceEndpoints.md)