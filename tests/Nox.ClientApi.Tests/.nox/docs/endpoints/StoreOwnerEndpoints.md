# API Endpoints for the StoreOwner entity

This document provides information about the various endpoints available in our API for the StoreOwner entity.

## StoreOwner Endpoints

### Get StoreOwner Count
- **GET** `/api/v1/StoreOwners/$count`
  - Description: Retrieve the number of StoreOwners.

### Get StoreOwner by ID
- **GET** `/api/v1/StoreOwners/{key}`
  - Description: Retrieve information about a StoreOwner by ID.
  
### Get StoreOwners
- **GET** `/api/v1/StoreOwners`
  - Description: Retrieve information about StoreOwners.

### Create StoreOwner
- **POST** `/api/v1/StoreOwners`
  - Description: Create a new StoreOwner.

### Update StoreOwner
- **PUT** `/api/v1/StoreOwners/{key}`
  - Description: Update an existing StoreOwner.

### Partially Update StoreOwner
- **PATCH** `/api/v1/StoreOwners/{key}`
  - Description: Partially update an existing StoreOwner.
 
### Delete StoreOwner
- **DELETE** `/api/v1/StoreOwners/{key}`
  - Description: Delete an existing StoreOwner.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Retrieve all existing Stores relations for a specific StoreOwner.
  
#### Create Store relation
- **POST** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific StoreOwner.
  
#### Update Store relation
- **PUT** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific StoreOwner.
- **PUT** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Updates the Store relations for a specific StoreOwner.

#### Delete Store relation
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific StoreOwner.

#### Delete Store relations
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/$ref`
  - Description: Delete all existing Stores relations for a specific StoreOwner.

#### Get Store
- **GET** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Retrieve all existing Stores for a specific StoreOwner.
  
#### Create Store
- **POST** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Create a new Store for a specific StoreOwner.
  
#### Update Store
- **PUT** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Updates an existing Store for a specific StoreOwner.
- **PUT** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Updates the Store for a specific StoreOwner.

#### Delete Store
- **DELETE** `/api/v1/StoreOwners/{key}/Stores/{relatedKey}`
  - Description: Delete an existing Store for a specific StoreOwner.

#### Delete Store
- **DELETE** `/api/v1/StoreOwners/{key}/Stores`
  - Description: Delete all existing Stores for a specific StoreOwner.


## Other Related Endpoints

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PATCH** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **GET** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/$ref`

- **POST** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **PUT** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **DELETE** `/api/v1/StoreOwners/{storeOwnersKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`
## Related Entities

[Store](StoreEndpoints.md)
