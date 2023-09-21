# API Endpoints for the Country entity

This document provides information about the various endpoints available in our API for the Country entity.

## Country Endpoints

### Get Country by ID
- **GET** `/api/Countries/{key}`
  - Description: Retrieve information about a Country by ID.
  
### Get Countries
- **GET** `/api/Countries`
  - Description: Retrieve information about Countries.

### Create Country
- **POST** `/api/Countries`
  - Description: Create a new Country.

### Update Country
- **PUT** `/api/Countries/{key}`
  - Description: Update an existing Country.

### Partially Update Country
- **PATCH** `/api/Countries/{key}`
  - Description: Partially update an existing Country.
 
### Delete Country
- **DELETE** `/api/Countries/{key}`
  - Description: Delete an existing Country.

## Owned Relationships Endpoints

### CountryTimeZone

#### Get CountryTimeZones
- **GET** `/api/Countries/{key}/CountryTimeZones`
  - Description: Retrieve all CountryTimeZones for a specific Country.

#### Create CountryTimeZone
- **POST** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Create a new CountryTimeZone for a specific Country.

#### Update CountryTimeZone
- **PUT** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Update an existing CountryTimeZone for a specific Country.
  
#### Partially Update CountryTimeZone
- **PATCH** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Partially update an existing CountryTimeZone for a specific Country.

#### Delete CountryTimeZone
- **DELETE** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Delete an existing CountryTimeZone for a specific Country.

### Holiday

#### Get Holidays
- **GET** `/api/Countries/{key}/Holidays`
  - Description: Retrieve all Holidays for a specific Country.

#### Create Holiday
- **POST** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Create a new Holiday for a specific Country.

#### Update Holiday
- **PUT** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Update an existing Holiday for a specific Country.
  
#### Partially Update Holiday
- **PATCH** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Partially update an existing Holiday for a specific Country.

#### Delete Holiday
- **DELETE** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Delete an existing Holiday for a specific Country.

## Relationships Endpoints

### Currency

#### Get Currency relation by ID
- **GET** `/api/Countries/{key}/Currencies/{relatedKey}/$ref`
  - Description: Retrieve an existing Currencies relation for a specific Country.

#### Get Currency relations
- **GET** `/api/Countries/{key}/Currencies/$ref`
  - Description: Retrieve all Currencies relations for a specific Country.
  
#### Create Currency relation
- **POST** `/api/Countries/{key}/Currencies/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific Country.

#### Update Currency relation
- **PUT** `/api/Countries/{key}/Currencies/{relatedKey}/$ref`
  - Description: Update an existing Currency relation for a specific Country.
  
#### Partially Update Currency relation
- **PATCH** `/api/Countries/{key}/Currencies/{relatedKey}/$ref`
  - Description: Partially update an existing Currency relation for a specific Country.

#### Delete Currency relation
- **DELETE** `/api/Countries/{key}/Currencies/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific Country.

### Commission

#### Get Commission relation by ID
- **GET** `/api/Countries/{key}/Commissions/{relatedKey}/$ref`
  - Description: Retrieve an existing Commissions relation for a specific Country.

#### Get Commission relations
- **GET** `/api/Countries/{key}/Commissions/$ref`
  - Description: Retrieve all Commissions relations for a specific Country.
  
#### Create Commission relation
- **POST** `/api/Countries/{key}/Commissions/{relatedKey}/$ref`
  - Description: Create a new Commission relation for a specific Country.

#### Update Commission relation
- **PUT** `/api/Countries/{key}/Commissions/{relatedKey}/$ref`
  - Description: Update an existing Commission relation for a specific Country.
  
#### Partially Update Commission relation
- **PATCH** `/api/Countries/{key}/Commissions/{relatedKey}/$ref`
  - Description: Partially update an existing Commission relation for a specific Country.

#### Delete Commission relation
- **DELETE** `/api/Countries/{key}/Commissions/{relatedKey}/$ref`
  - Description: Delete an existing Commission relation for a specific Country.

### VendingMachine

#### Get VendingMachine relation by ID
- **GET** `/api/Countries/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Retrieve an existing VendingMachines relation for a specific Country.

#### Get VendingMachine relations
- **GET** `/api/Countries/{key}/VendingMachines/$ref`
  - Description: Retrieve all VendingMachines relations for a specific Country.
  
#### Create VendingMachine relation
- **POST** `/api/Countries/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific Country.

#### Update VendingMachine relation
- **PUT** `/api/Countries/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Update an existing VendingMachine relation for a specific Country.
  
#### Partially Update VendingMachine relation
- **PATCH** `/api/Countries/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Partially update an existing VendingMachine relation for a specific Country.

#### Delete VendingMachine relation
- **DELETE** `/api/Countries/{key}/VendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific Country.

### Customer

#### Get Customer relation by ID
- **GET** `/api/Countries/{key}/Customers/{relatedKey}/$ref`
  - Description: Retrieve an existing Customers relation for a specific Country.

#### Get Customer relations
- **GET** `/api/Countries/{key}/Customers/$ref`
  - Description: Retrieve all Customers relations for a specific Country.
  
#### Create Customer relation
- **POST** `/api/Countries/{key}/Customers/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Country.

#### Update Customer relation
- **PUT** `/api/Countries/{key}/Customers/{relatedKey}/$ref`
  - Description: Update an existing Customer relation for a specific Country.
  
#### Partially Update Customer relation
- **PATCH** `/api/Countries/{key}/Customers/{relatedKey}/$ref`
  - Description: Partially update an existing Customer relation for a specific Country.

#### Delete Customer relation
- **DELETE** `/api/Countries/{key}/Customers/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Country.

## Related Entities

[Currency](CurrencyEndpoints.md)

[Commission](CommissionEndpoints.md)

[VendingMachine](VendingMachineEndpoints.md)

[Customer](CustomerEndpoints.md)
