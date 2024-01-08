# API Endpoints for the Country entity

This document provides information about the various endpoints available in our API for the Country entity.

## Country Endpoints

### Get Country Count
- **GET** `/api/Countries/$count`
  - Description: Retrieve the number of Countries.

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
- **GET** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Retrieve a CountryTimeZone by ID for a specific Country.

#### Create CountryTimeZone
- **POST** `/api/Countries/{key}/CountryTimeZones`
  - Description: Create a new CountryTimeZone for a specific Country.

#### Update CountryTimeZone
- **PUT** `/api/Countries/{key}/CountryTimeZones`
  - Description: Update an existing CountryTimeZone for a specific Country.
  
#### Partially Update CountryTimeZone
- **PATCH** `/api/Countries/{key}/CountryTimeZones`
  - Description: Partially update an existing CountryTimeZone for a specific Country.

#### Delete CountryTimeZone
- **DELETE** `/api/Countries/{key}/CountryTimeZones/{relatedKey}`
  - Description: Delete an existing CountryTimeZone for a specific Country.

### Holiday

#### Get Holidays
- **GET** `/api/Countries/{key}/Holidays`
  - Description: Retrieve all Holidays for a specific Country.
- **GET** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Retrieve a Holiday by ID for a specific Country.

#### Create Holiday
- **POST** `/api/Countries/{key}/Holidays`
  - Description: Create a new Holiday for a specific Country.

#### Update Holiday
- **PUT** `/api/Countries/{key}/Holidays`
  - Description: Update an existing Holiday for a specific Country.
  
#### Partially Update Holiday
- **PATCH** `/api/Countries/{key}/Holidays`
  - Description: Partially update an existing Holiday for a specific Country.

#### Delete Holiday
- **DELETE** `/api/Countries/{key}/Holidays/{relatedKey}`
  - Description: Delete an existing Holiday for a specific Country.

## Relationships Endpoints

### Currency

#### Get Currency relations
- **GET** `/api/Countries/{key}/CountryUsedByCurrency/$ref`
  - Description: Retrieve all existing Currencies relations for a specific Country.
  
#### Create Currency relation
- **POST** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}/$ref`
  - Description: Create a new Currency relation for a specific Country.
  
#### Update Currency relation
- **PUT** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}/$ref`
  - Description: Updates an existing Currency relation for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCurrency/$ref`
  - Description: Updates the Currency relations for a specific Country.

#### Delete Currency relation
- **DELETE** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}/$ref`
  - Description: Delete an existing Currency relation for a specific Country.

#### Delete Currency relations
- **DELETE** `/api/Countries/{key}/CountryUsedByCurrency/$ref`
  - Description: Delete all existing Currencies relations for a specific Country.

#### Get Currency
- **GET** `/api/Countries/{key}/CountryUsedByCurrency`
  - Description: Retrieve all existing Currencies for a specific Country.
  
#### Create Currency
- **POST** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}`
  - Description: Create a new Currency for a specific Country.
  
#### Update Currency
- **PUT** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}`
  - Description: Updates an existing Currency for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCurrency`
  - Description: Updates the Currency for a specific Country.

#### Delete Currency
- **DELETE** `/api/Countries/{key}/CountryUsedByCurrency/{relatedKey}`
  - Description: Delete an existing Currency for a specific Country.

#### Delete Currency
- **DELETE** `/api/Countries/{key}/CountryUsedByCurrency`
  - Description: Delete all existing Currencies for a specific Country.

### Commission

#### Get Commission relations
- **GET** `/api/Countries/{key}/CountryUsedByCommissions/$ref`
  - Description: Retrieve all existing Commissions relations for a specific Country.
  
#### Create Commission relation
- **POST** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}/$ref`
  - Description: Create a new Commission relation for a specific Country.
  
#### Update Commission relation
- **PUT** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}/$ref`
  - Description: Updates an existing Commission relation for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCommissions/$ref`
  - Description: Updates the Commission relations for a specific Country.

#### Delete Commission relation
- **DELETE** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}/$ref`
  - Description: Delete an existing Commission relation for a specific Country.

#### Delete Commission relations
- **DELETE** `/api/Countries/{key}/CountryUsedByCommissions/$ref`
  - Description: Delete all existing Commissions relations for a specific Country.

#### Get Commission
- **GET** `/api/Countries/{key}/CountryUsedByCommissions`
  - Description: Retrieve all existing Commissions for a specific Country.
  
#### Create Commission
- **POST** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}`
  - Description: Create a new Commission for a specific Country.
  
#### Update Commission
- **PUT** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}`
  - Description: Updates an existing Commission for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCommissions`
  - Description: Updates the Commission for a specific Country.

#### Delete Commission
- **DELETE** `/api/Countries/{key}/CountryUsedByCommissions/{relatedKey}`
  - Description: Delete an existing Commission for a specific Country.

#### Delete Commission
- **DELETE** `/api/Countries/{key}/CountryUsedByCommissions`
  - Description: Delete all existing Commissions for a specific Country.

### VendingMachine

#### Get VendingMachine relations
- **GET** `/api/Countries/{key}/CountryUsedByVendingMachines/$ref`
  - Description: Retrieve all existing VendingMachines relations for a specific Country.
  
#### Create VendingMachine relation
- **POST** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}/$ref`
  - Description: Create a new VendingMachine relation for a specific Country.
  
#### Update VendingMachine relation
- **PUT** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}/$ref`
  - Description: Updates an existing VendingMachine relation for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByVendingMachines/$ref`
  - Description: Updates the VendingMachine relations for a specific Country.

#### Delete VendingMachine relation
- **DELETE** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}/$ref`
  - Description: Delete an existing VendingMachine relation for a specific Country.

#### Delete VendingMachine relations
- **DELETE** `/api/Countries/{key}/CountryUsedByVendingMachines/$ref`
  - Description: Delete all existing VendingMachines relations for a specific Country.

#### Get VendingMachine
- **GET** `/api/Countries/{key}/CountryUsedByVendingMachines`
  - Description: Retrieve all existing VendingMachines for a specific Country.
  
#### Create VendingMachine
- **POST** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}`
  - Description: Create a new VendingMachine for a specific Country.
  
#### Update VendingMachine
- **PUT** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}`
  - Description: Updates an existing VendingMachine for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByVendingMachines`
  - Description: Updates the VendingMachine for a specific Country.

#### Delete VendingMachine
- **DELETE** `/api/Countries/{key}/CountryUsedByVendingMachines/{relatedKey}`
  - Description: Delete an existing VendingMachine for a specific Country.

#### Delete VendingMachine
- **DELETE** `/api/Countries/{key}/CountryUsedByVendingMachines`
  - Description: Delete all existing VendingMachines for a specific Country.

### Customer

#### Get Customer relations
- **GET** `/api/Countries/{key}/CountryUsedByCustomers/$ref`
  - Description: Retrieve all existing Customers relations for a specific Country.
  
#### Create Customer relation
- **POST** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}/$ref`
  - Description: Create a new Customer relation for a specific Country.
  
#### Update Customer relation
- **PUT** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}/$ref`
  - Description: Updates an existing Customer relation for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCustomers/$ref`
  - Description: Updates the Customer relations for a specific Country.

#### Delete Customer relation
- **DELETE** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}/$ref`
  - Description: Delete an existing Customer relation for a specific Country.

#### Delete Customer relations
- **DELETE** `/api/Countries/{key}/CountryUsedByCustomers/$ref`
  - Description: Delete all existing Customers relations for a specific Country.

#### Get Customer
- **GET** `/api/Countries/{key}/CountryUsedByCustomers`
  - Description: Retrieve all existing Customers for a specific Country.
  
#### Create Customer
- **POST** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}`
  - Description: Create a new Customer for a specific Country.
  
#### Update Customer
- **PUT** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}`
  - Description: Updates an existing Customer for a specific Country.
- **PUT** `/api/Countries/{key}/CountryUsedByCustomers`
  - Description: Updates the Customer for a specific Country.

#### Delete Customer
- **DELETE** `/api/Countries/{key}/CountryUsedByCustomers/{relatedKey}`
  - Description: Delete an existing Customer for a specific Country.

#### Delete Customer
- **DELETE** `/api/Countries/{key}/CountryUsedByCustomers`
  - Description: Delete all existing Customers for a specific Country.

## Related Entities

[Currency](CurrencyEndpoints.md)

[Commission](CommissionEndpoints.md)

[VendingMachine](VendingMachineEndpoints.md)

[Customer](CustomerEndpoints.md)

