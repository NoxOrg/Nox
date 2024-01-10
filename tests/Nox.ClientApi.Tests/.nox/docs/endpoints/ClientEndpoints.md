# API Endpoints for the Client entity

This document provides information about the various endpoints available in our API for the Client entity.

## Client Endpoints

### Get Client Count
- **GET** `/api/v1/Clients/$count`
  - Description: Retrieve the number of Clients.

### Get Client by ID
- **GET** `/api/v1/Clients/{key}`
  - Description: Retrieve information about a Client by ID.
  
### Get Clients
- **GET** `/api/v1/Clients`
  - Description: Retrieve information about Clients.

### Create Client
- **POST** `/api/v1/Clients`
  - Description: Create a new Client.

### Update Client
- **PUT** `/api/v1/Clients/{key}`
  - Description: Update an existing Client.

### Partially Update Client
- **PATCH** `/api/v1/Clients/{key}`
  - Description: Partially update an existing Client.
 
### Delete Client
- **DELETE** `/api/v1/Clients/{key}`
  - Description: Delete an existing Client.

## Relationships Endpoints

### Store

#### Get Store relations
- **GET** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Retrieve all existing Stores relations for a specific Client.
  
#### Create Store relation
- **POST** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific Client.
  
#### Update Store relation
- **PUT** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific Client.
- **PUT** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Updates the Store relations for a specific Client.

#### Delete Store relation
- **DELETE** `/api/v1/Clients/{key}/ClientOf/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific Client.

#### Delete Store relations
- **DELETE** `/api/v1/Clients/{key}/ClientOf/$ref`
  - Description: Delete all existing Stores relations for a specific Client.

#### Get Store
- **GET** `/api/v1/Clients/{key}/ClientOf`
  - Description: Retrieve all existing Stores for a specific Client.
  
#### Create Store
- **POST** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Create a new Store for a specific Client.
  
#### Update Store
- **PUT** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Updates an existing Store for a specific Client.
- **PUT** `/api/v1/Clients/{key}/ClientOf`
  - Description: Updates the Store for a specific Client.

#### Delete Store
- **DELETE** `/api/v1/Clients/{key}/ClientOf/{relatedKey}`
  - Description: Delete an existing Store for a specific Client.

#### Delete Store
- **DELETE** `/api/v1/Clients/{key}/ClientOf`
  - Description: Delete all existing Stores for a specific Client.

## Other Related Endpoints

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/Country/{countryKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/Clients/{clientsKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

## Related Entities

[Store](StoreEndpoints.md)