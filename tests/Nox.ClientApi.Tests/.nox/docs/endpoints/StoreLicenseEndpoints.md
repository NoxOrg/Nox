# API Endpoints for the StoreLicense entity

This document provides information about the various endpoints available in our API for the StoreLicense entity.

## StoreLicense Endpoints

### Get StoreLicense Count
- **GET** `/api/v1/StoreLicenses/$count`
  - Description: Retrieve the number of StoreLicenses.

### Get StoreLicense by ID
- **GET** `/api/v1/StoreLicenses/{key}`
  - Description: Retrieve information about a StoreLicense by ID.
  
### Get StoreLicenses
- **GET** `/api/v1/StoreLicenses`
  - Description: Retrieve information about StoreLicenses.

### Create StoreLicense
- **POST** `/api/v1/StoreLicenses`
  - Description: Create a new StoreLicense.

### Update StoreLicense
- **PUT** `/api/v1/StoreLicenses/{key}`
  - Description: Update an existing StoreLicense.

### Partially Update StoreLicense
- **PATCH** `/api/v1/StoreLicenses/{key}`
  - Description: Partially update an existing StoreLicense.
 
### Delete StoreLicense
- **DELETE** `/api/v1/StoreLicenses/{key}`
  - Description: Delete an existing StoreLicense.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Retrieve all existing Stores relations for a specific StoreLicense.
  
#### Create Store relation
- **POST** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreLicense.
  
#### Update Store relation
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Updates the Store relations for a specific StoreLicense.

#### Delete Store relation
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreLicense.

#### Delete Store relations
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense/$ref`
  - Description: Delete all existing Stores relations for a specific StoreLicense.

#### Get Store
- **GET** `/api/v1/StoreLicenses/{key}/StoreWithLicense`
  - Description: Retrieve all existing Stores for a specific StoreLicense.
  
#### Create Store
- **POST** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}`
  - Description: Create a new Store for a specific StoreLicense.
  
#### Update Store
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}`
  - Description: Updates an existing Store for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/StoreWithLicense`
  - Description: Updates the Store for a specific StoreLicense.

#### Delete Store
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense/{relatedKey}`
  - Description: Delete an existing Store for a specific StoreLicense.

#### Delete Store
- **DELETE** `/api/v1/StoreLicenses/{key}/StoreWithLicense`
  - Description: Delete all existing Stores for a specific StoreLicense.
### Currency

#### Get Currency relations
- **GET** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific StoreLicense.
  
#### Create Currency relation
- **POST** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific StoreLicense.
  
#### Update Currency relation
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Updates the Currency relations for a specific StoreLicense.

#### Delete Currency relation
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific StoreLicense.

#### Delete Currency relations
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific StoreLicense.

#### Get Currency
- **GET** `/api/v1/StoreLicenses/{key}/DefaultCurrency`
  - Description: Retrieve all existing Currencies for a specific StoreLicense.
  
#### Create Currency
- **POST** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}`
  - Description: Create a new Currency for a specific StoreLicense.
  
#### Update Currency
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}`
  - Description: Updates an existing Currency for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/DefaultCurrency`
  - Description: Updates the Currency for a specific StoreLicense.

#### Delete Currency
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency/{relatedKey}`
  - Description: Delete an existing Currency for a specific StoreLicense.

#### Delete Currency
- **DELETE** `/api/v1/StoreLicenses/{key}/DefaultCurrency`
  - Description: Delete all existing Currencies for a specific StoreLicense.
### Currency

#### Get Currency relations
- **GET** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific StoreLicense.
  
#### Create Currency relation
- **POST** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific StoreLicense.
  
#### Update Currency relation
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Updates the Currency relations for a specific StoreLicense.

#### Delete Currency relation
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific StoreLicense.

#### Delete Currency relations
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific StoreLicense.

#### Get Currency
- **GET** `/api/v1/StoreLicenses/{key}/SoldInCurrency`
  - Description: Retrieve all existing Currencies for a specific StoreLicense.
  
#### Create Currency
- **POST** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}`
  - Description: Create a new Currency for a specific StoreLicense.
  
#### Update Currency
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}`
  - Description: Updates an existing Currency for a specific StoreLicense.
- **PUT** `/api/v1/StoreLicenses/{key}/SoldInCurrency`
  - Description: Updates the Currency for a specific StoreLicense.

#### Delete Currency
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency/{relatedKey}`
  - Description: Delete an existing Currency for a specific StoreLicense.

#### Delete Currency
- **DELETE** `/api/v1/StoreLicenses/{key}/SoldInCurrency`
  - Description: Delete all existing Currencies for a specific StoreLicense.

## Other Related Endpoints

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country`

- **PATCH** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/$ref`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/$ref`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PATCH** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/$ref`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PATCH** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner`

- **PATCH** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner/$ref`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner/{storeOwnerKey}/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner/{storeOwnerKey}/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/StoreOwner/{storeOwnerKey}/$ref`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}`

- **PATCH** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}`

- **GET** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/$ref`

- **POST** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}/$ref`

- **PUT** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}/$ref`

- **DELETE** `/api/v1/StoreLicenses/{storeLicensesKey}/Store/{storeKey}/Clients/{clientsKey}/$ref`

## Related Entities

[Store](StoreEndpoints.md)
[Currency](CurrencyEndpoints.md)
[Currency](CurrencyEndpoints.md)