# API Endpoints for the Country entity

This document provides information about the various endpoints available in our API for the Country entity.

## Country Endpoints

### Get Country Count
- **GET** `/api/v1/Countries/$count`
  - Description: Retrieve the number of Countries.

### Get Country by ID
- **GET** `/api/v1/Countries/{key}`
  - Description: Retrieve information about a Country by ID.
  
### Get Countries
- **GET** `/api/v1/Countries`
  - Description: Retrieve information about Countries.

### Create Country
- **POST** `/api/v1/Countries`
  - Description: Create a new Country.

### Update Country
- **PUT** `/api/v1/Countries/{key}`
  - Description: Update an existing Country.

### Partially Update Country
- **PATCH** `/api/v1/Countries/{key}`
  - Description: Partially update an existing Country.
 
### Delete Country
- **DELETE** `/api/v1/Countries/{key}`
  - Description: Delete an existing Country.

## Owned Relationships Endpoints

### CountryLocalName

#### Get CountryLocalNames
- **GET** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Retrieve all CountryLocalNames for a specific Country.
- **GET** `/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Retrieve a CountryLocalName by ID for a specific Country.

#### Create CountryLocalName
- **POST** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Create a new CountryLocalName for a specific Country.

#### Update CountryLocalName
- **PUT** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Update an existing CountryLocalName for a specific Country.
  
#### Partially Update CountryLocalName
- **PATCH** `/api/v1/Countries/{key}/CountryLocalNames`
  - Description: Partially update an existing CountryLocalName for a specific Country.

#### Delete CountryLocalName
- **DELETE** `/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}`
  - Description: Delete an existing CountryLocalName for a specific Country.

### CountryBarCode

#### Get CountryBarCodes
- **GET** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Retrieve all CountryBarCodes for a specific Country.

#### Create CountryBarCode
- **POST** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Create a new CountryBarCode for a specific Country.

#### Update CountryBarCode
- **PUT** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Update an existing CountryBarCode for a specific Country.
  
#### Partially Update CountryBarCode
- **PATCH** `/api/v1/Countries/{key}/CountryBarCodes`
  - Description: Partially update an existing CountryBarCode for a specific Country.

#### Delete CountryBarCode
- **DELETE** `/api/v1/Countries/{key}/CountryBarCodes/{relatedKey}`
  - Description: Delete an existing CountryBarCode for a specific Country.

### CountryTimeZone

#### Get CountryTimeZones
- **GET** `/api/v1/Countries/{key}/CountryTimeZones`
  - Description: Retrieve all CountryTimeZones for a specific Country.
- **GET** `/api/v1/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Retrieve a CountryTimeZone by ID for a specific Country.

#### Create CountryTimeZone
- **POST** `/api/v1/Countries/{key}/CountryTimeZones`
  - Description: Create a new CountryTimeZone for a specific Country.

#### Update CountryTimeZone
- **PUT** `/api/v1/Countries/{key}/CountryTimeZones`
  - Description: Update an existing CountryTimeZone for a specific Country.
  
#### Partially Update CountryTimeZone
- **PATCH** `/api/v1/Countries/{key}/CountryTimeZones`
  - Description: Partially update an existing CountryTimeZone for a specific Country.

#### Delete CountryTimeZone
- **DELETE** `/api/v1/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Delete an existing CountryTimeZone for a specific Country.

### Holiday

#### Get Holidays
- **GET** `/api/v1/Countries/{key}/Holidays`
  - Description: Retrieve all Holidays for a specific Country.
- **GET** `/api/v1/Countries/{key}/Holidays/{relatedKey}`
  - Description: Retrieve a Holiday by ID for a specific Country.

#### Create Holiday
- **POST** `/api/v1/Countries/{key}/Holidays`
  - Description: Create a new Holiday for a specific Country.

#### Update Holiday
- **PUT** `/api/v1/Countries/{key}/Holidays`
  - Description: Update an existing Holiday for a specific Country.
  
#### Partially Update Holiday
- **PATCH** `/api/v1/Countries/{key}/Holidays`
  - Description: Partially update an existing Holiday for a specific Country.

#### Delete Holiday
- **DELETE** `/api/v1/Countries/{key}/Holidays/{relatedKey}`
  - Description: Delete an existing Holiday for a specific Country.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/v1/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Country.
  
#### Create Workplace relation
- **POST** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Country.
  
#### Update Workplace relation
- **PUT** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Country.
- **PUT** `/api/v1/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Updates the Workplace relations for a specific Country.

#### Delete Workplace relation
- **DELETE** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Country.

#### Delete Workplace relations
- **DELETE** `/api/v1/Countries/{key}/PhysicalWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Country.

#### Get Workplace
- **GET** `/api/v1/Countries/{key}/PhysicalWorkplaces`
  - Description: Retrieve all existing Workplaces for a specific Country.
  
#### Create Workplace
- **POST** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}`
  - Description: Create a new Workplace for a specific Country.
  
#### Update Workplace
- **PUT** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}`
  - Description: Updates an existing Workplace for a specific Country.
- **PUT** `/api/v1/Countries/{key}/PhysicalWorkplaces`
  - Description: Updates the Workplace for a specific Country.

#### Delete Workplace
- **DELETE** `/api/v1/Countries/{key}/PhysicalWorkplaces/{relatedKey}`
  - Description: Delete an existing Workplace for a specific Country.

#### Delete Workplace
- **DELETE** `/api/v1/Countries/{key}/PhysicalWorkplaces`
  - Description: Delete all existing Workplaces for a specific Country.
### Store

#### Get Store relations
- **GET** `/api/v1/Countries/{key}/StoresInTheCountry/$ref`
  - Description: Retrieve all existing Stores relations for a specific Country.
  
#### Create Store relation
- **POST** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}/$ref`
  - Description: Create a new Store relation for a specific Country.
  
#### Update Store relation
- **PUT** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}/$ref`
  - Description: Updates an existing Store relation for a specific Country.
- **PUT** `/api/v1/Countries/{key}/StoresInTheCountry/$ref`
  - Description: Updates the Store relations for a specific Country.

#### Delete Store relation
- **DELETE** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}/$ref`
  - Description: Delete an existing Store relation for a specific Country.

#### Delete Store relations
- **DELETE** `/api/v1/Countries/{key}/StoresInTheCountry/$ref`
  - Description: Delete all existing Stores relations for a specific Country.

#### Get Store
- **GET** `/api/v1/Countries/{key}/StoresInTheCountry`
  - Description: Retrieve all existing Stores for a specific Country.
  
#### Create Store
- **POST** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}`
  - Description: Create a new Store for a specific Country.
  
#### Update Store
- **PUT** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}`
  - Description: Updates an existing Store for a specific Country.
- **PUT** `/api/v1/Countries/{key}/StoresInTheCountry`
  - Description: Updates the Store for a specific Country.

#### Delete Store
- **DELETE** `/api/v1/Countries/{key}/StoresInTheCountry/{relatedKey}`
  - Description: Delete an existing Store for a specific Country.

#### Delete Store
- **DELETE** `/api/v1/Countries/{key}/StoresInTheCountry`
  - Description: Delete all existing Stores for a specific Country.

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Country.
- **GET** `/api/v1/Countries/Continents`
  - **Description**: Retrieve non-conventional values of Continents for a specific Country.
  
- **GET** `/api/v1/Countries/CountryContinentsLocalized`
  - **Description**: Retrieve localized values of Continents for a specific Country.

- **DELETE** `/api/v1/Countries/CountryContinentsLocalized/{cultureCode}`
  - **Description**: Delete the localized values of Continents for a specific culture code in Country.

- **PUT** `/api/v1/Countries/CountryContinentsLocalized`
  - **Description**: Update or create localized values of Continents for a specific Country. Requires a payload with the new values.
## Localized Endpoints

- **PUT** `/api/v1/Countries/{key}/CountryLocalNamesLocalized/{cultureCode}` 
    - Description: Update or create value of CountryLocalNameLocalized for a specific Country. Requires a payload with the new value of CountryLocalNameLocalizedUpsertDto.

- **DELETE** `/api/v1/Countries/{key}/CountryLocalNamesLocalized/{cultureCode}` 
    - Description: Delete the localized values of CountryLocalNameLocalized for a specific culture code in Country.

- **PUT** `/api/v1/Countries/{key}/CountryBarCodeLocalized/{cultureCode}` 
    - Description: Update or create value of CountryBarCodeLocalized for a specific Country. Requires a payload with the new value of CountryBarCodeLocalizedUpsertDto.

- **DELETE** `/api/v1/Countries/{key}/CountryBarCodeLocalized/{cultureCode}` 
    - Description: Delete the localized values of CountryBarCodeLocalized for a specific culture code in Country.

- **PUT** `/api/v1/Countries/{key}/CountryTimeZonesLocalized/{cultureCode}` 
    - Description: Update or create value of CountryTimeZoneLocalized for a specific Country. Requires a payload with the new value of CountryTimeZoneLocalizedUpsertDto.

- **DELETE** `/api/v1/Countries/{key}/CountryTimeZonesLocalized/{cultureCode}` 
    - Description: Delete the localized values of CountryTimeZoneLocalized for a specific culture code in Country.

- **PUT** `/api/v1/Countries/{key}/HolidaysLocalized/{cultureCode}` 
    - Description: Update or create value of HolidayLocalized for a specific Country. Requires a payload with the new value of HolidayLocalizedUpsertDto.

- **DELETE** `/api/v1/Countries/{key}/HolidaysLocalized/{cultureCode}` 
    - Description: Delete the localized values of HolidayLocalized for a specific culture code in Country.


## Other Related Endpoints

- **GET** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants`

- **POST** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants`

- **DELETE** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants`

- **GET** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PUT** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **PATCH** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **DELETE** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}`

- **GET** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Workplaces/{workplacesKey}/Tenants/{tenantsKey}/$ref`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner`

- **PATCH** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreOwner/{storeOwnerKey}/$ref`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense`

- **PATCH** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/$ref`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **PATCH** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/DefaultCurrency/{defaultCurrencyKey}/$ref`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **PATCH** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/StoreLicense/{storeLicenseKey}/SoldInCurrency/{soldInCurrencyKey}/$ref`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **PATCH** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}`

- **GET** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/$ref`

- **POST** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **PUT** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

- **DELETE** `/api/v1/Countries/{countriesKey}/Stores/{storesKey}/Clients/{clientsKey}/$ref`

## Related Entities

[Workplace](WorkplaceEndpoints.md)
[Store](StoreEndpoints.md)