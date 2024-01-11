# API Endpoints for the Store entity

This document provides information about the various endpoints available in our API for the Store entity.

## Store Endpoints

### Get Store Count
- **GET** `/api/v1/Stores/$count`
  - Description: Retrieve the number of Stores.

### Get Store by ID
- **GET** `/api/v1/Stores/{key}`
  - Description: Retrieve information about a Store by ID.
  
### Get Stores
- **GET** `/api/v1/Stores`
  - Description: Retrieve information about Stores.

### Create Store
- **POST** `/api/v1/Stores`
  - Description: Create a new Store.

### Update Store
- **PUT** `/api/v1/Stores/{key}`
  - Description: Update an existing Store.

### Partially Update Store
- **PATCH** `/api/v1/Stores/{key}`
  - Description: Partially update an existing Store.
 
### Delete Store
- **DELETE** `/api/v1/Stores/{key}`
  - Description: Delete an existing Store.

## Owned Relationships Endpoints

## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/v1/Stores/{key}/CountryOfTheStore/$ref`
  - Description: Retrieve all existing Countries relations for a specific Store.
  
#### Create Country relation
- **POST** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Store.
  
#### Update Country relation
- **PUT** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Store.
- **PUT** `/api/v1/Stores/{key}/CountryOfTheStore/$ref`
  - Description: Updates the Country relations for a specific Store.

#### Delete Country relation
- **DELETE** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Store.

#### Delete Country relations
- **DELETE** `/api/v1/Stores/{key}/CountryOfTheStore/$ref`
  - Description: Delete all existing Countries relations for a specific Store.

#### Get Country
- **GET** `/api/v1/Stores/{key}/CountryOfTheStore`
  - Description: Retrieve all existing Countries for a specific Store.
  
#### Create Country
- **POST** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}`
  - Description: Create a new Country for a specific Store.
  
#### Update Country
- **PUT** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}`
  - Description: Updates an existing Country for a specific Store.
- **PUT** `/api/v1/Stores/{key}/CountryOfTheStore`
  - Description: Updates the Country for a specific Store.

#### Delete Country
- **DELETE** `/api/v1/Stores/{key}/CountryOfTheStore/{relatedKey}`
  - Description: Delete an existing Country for a specific Store.

#### Delete Country
- **DELETE** `/api/v1/Stores/{key}/CountryOfTheStore`
  - Description: Delete all existing Countries for a specific Store.
### StoreOwner

#### Get StoreOwner relations
- **GET** `/api/v1/Stores/{key}/Ownership/$ref`
  - Description: Retrieve all existing StoreOwners relations for a specific Store.
  
#### Create StoreOwner relation
- **POST** `/api/v1/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Create a new StoreOwner relation for a specific Store.
  
#### Update StoreOwner relation
- **PUT** `/api/v1/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Updates an existing StoreOwner relation for a specific Store.
- **PUT** `/api/v1/Stores/{key}/Ownership/$ref`
  - Description: Updates the StoreOwner relations for a specific Store.

#### Delete StoreOwner relation
- **DELETE** `/api/v1/Stores/{key}/Ownership/{relatedKey}/$ref`
  - Description: Delete an existing StoreOwner relation for a specific Store.

#### Delete StoreOwner relations
- **DELETE** `/api/v1/Stores/{key}/Ownership/$ref`
  - Description: Delete all existing StoreOwners relations for a specific Store.

#### Get StoreOwner
- **GET** `/api/v1/Stores/{key}/Ownership`
  - Description: Retrieve all existing StoreOwners for a specific Store.
  
#### Create StoreOwner
- **POST** `/api/v1/Stores/{key}/Ownership/{relatedKey}`
  - Description: Create a new StoreOwner for a specific Store.
  
#### Update StoreOwner
- **PUT** `/api/v1/Stores/{key}/Ownership/{relatedKey}`
  - Description: Updates an existing StoreOwner for a specific Store.
- **PUT** `/api/v1/Stores/{key}/Ownership`
  - Description: Updates the StoreOwner for a specific Store.

#### Delete StoreOwner
- **DELETE** `/api/v1/Stores/{key}/Ownership/{relatedKey}`
  - Description: Delete an existing StoreOwner for a specific Store.

#### Delete StoreOwner
- **DELETE** `/api/v1/Stores/{key}/Ownership`
  - Description: Delete all existing StoreOwners for a specific Store.
### StoreLicense

#### Get StoreLicense relations
- **GET** `/api/v1/Stores/{key}/License/$ref`
  - Description: Retrieve all existing StoreLicenses relations for a specific Store.
  
#### Create StoreLicense relation
- **POST** `/api/v1/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Create a new StoreLicense relation for a specific Store.
  
#### Update StoreLicense relation
- **PUT** `/api/v1/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Updates an existing StoreLicense relation for a specific Store.
- **PUT** `/api/v1/Stores/{key}/License/$ref`
  - Description: Updates the StoreLicense relations for a specific Store.

#### Delete StoreLicense relation
- **DELETE** `/api/v1/Stores/{key}/License/{relatedKey}/$ref`
  - Description: Delete an existing StoreLicense relation for a specific Store.

#### Delete StoreLicense relations
- **DELETE** `/api/v1/Stores/{key}/License/$ref`
  - Description: Delete all existing StoreLicenses relations for a specific Store.

#### Get StoreLicense
- **GET** `/api/v1/Stores/{key}/License`
  - Description: Retrieve all existing StoreLicenses for a specific Store.
  
#### Create StoreLicense
- **POST** `/api/v1/Stores/{key}/License/{relatedKey}`
  - Description: Create a new StoreLicense for a specific Store.
  
#### Update StoreLicense
- **PUT** `/api/v1/Stores/{key}/License/{relatedKey}`
  - Description: Updates an existing StoreLicense for a specific Store.
- **PUT** `/api/v1/Stores/{key}/License`
  - Description: Updates the StoreLicense for a specific Store.

#### Delete StoreLicense
- **DELETE** `/api/v1/Stores/{key}/License/{relatedKey}`
  - Description: Delete an existing StoreLicense for a specific Store.

#### Delete StoreLicense
- **DELETE** `/api/v1/Stores/{key}/License`
  - Description: Delete all existing StoreLicenses for a specific Store.
### Client

#### Get Client relations
- **GET** `/api/v1/Stores/{key}/ClientsOfStore/$ref`
  - Description: Retrieve all existing Clients relations for a specific Store.
  
#### Create Client relation
- **POST** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Create a new Client relation for a specific Store.
  
#### Update Client relation
- **PUT** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Updates an existing Client relation for a specific Store.
- **PUT** `/api/v1/Stores/{key}/ClientsOfStore/$ref`
  - Description: Updates the Client relations for a specific Store.

#### Delete Client relation
- **DELETE** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}/$ref`
  - Description: Delete an existing Client relation for a specific Store.

#### Delete Client relations
- **DELETE** `/api/v1/Stores/{key}/ClientsOfStore/$ref`
  - Description: Delete all existing Clients relations for a specific Store.

#### Get Client
- **GET** `/api/v1/Stores/{key}/ClientsOfStore`
  - Description: Retrieve all existing Clients for a specific Store.
  
#### Create Client
- **POST** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}`
  - Description: Create a new Client for a specific Store.
  
#### Update Client
- **PUT** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}`
  - Description: Updates an existing Client for a specific Store.
- **PUT** `/api/v1/Stores/{key}/ClientsOfStore`
  - Description: Updates the Client for a specific Store.

#### Delete Client
- **DELETE** `/api/v1/Stores/{key}/ClientsOfStore/{relatedKey}`
  - Description: Delete an existing Client for a specific Store.

#### Delete Client
- **DELETE** `/api/v1/Stores/{key}/ClientsOfStore`
  - Description: Delete all existing Clients for a specific Store.

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Store.
- **GET** `/api/v1/Stores/StoreStatuses`
  - **Description**: Retrieve non-conventional values of Statuses for a specific Store.

## Other Related Endpoints

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **POST** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PATCH** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **POST** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **POST** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PATCH** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **GET** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **POST** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **GET** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

## Related Entities

[Country](CountryEndpoints.md)
[StoreOwner](StoreOwnerEndpoints.md)
[StoreLicense](StoreLicenseEndpoints.md)
[Client](ClientEndpoints.md)