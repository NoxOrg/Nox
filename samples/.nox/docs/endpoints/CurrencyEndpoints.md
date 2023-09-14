# API Endpoints for the Currency entity

This document provides information about the various endpoints available in our API for the Currency entity.

## Currency Endpoints

### Get Currency by ID
- **GET** `/api/Currencies/{key}`
  - Description: Retrieve information about a Currency by ID.
  
### Get Currencies
- **GET** `/api/Currencies`
  - Description: Retrieve information about Currencies.

### Create Currency
- **POST** `/api/Currencies`
  - Description: Create a new Currency.

### Update Currency
- **PUT** `/api/Currencies/{key}`
  - Description: Update an existing Currency.

### Partially Update Currency
- **PATCH** `/api/Currencies/{key}`
  - Description: Partially update an existing Currency.
 
### Delete Currency
- **DELETE** `/api/Currencies/{key}`
  - Description: Delete an existing Currency.

## Owned Relationships Endpoints

### BankNote

#### Get BankNotes
- **GET** `/api/Currencies/{key}/BankNotes`
  - Description: Retrieve all BankNotes for a specific Currency.
  
#### Create BankNote
- **POST** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Create a new BankNote for a specific Currency.
  
#### Update BankNote
- **PUT** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Update an existing BankNote for a specific Currency.
  
#### Partially Update BankNote
- **PATCH** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Partially update an existing BankNote for a specific Currency.

#### Delete BankNote
- **DELETE** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Delete an existing BankNote for a specific Currency.

### ExchangeRate

#### Get ExchangeRates
- **GET** `/api/Currencies/{key}/ExchangeRates`
  - Description: Retrieve all ExchangeRates for a specific Currency.
  
#### Create ExchangeRate
- **POST** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Create a new ExchangeRate for a specific Currency.
  
#### Update ExchangeRate
- **PUT** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Update an existing ExchangeRate for a specific Currency.
  
#### Partially Update ExchangeRate
- **PATCH** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Partially update an existing ExchangeRate for a specific Currency.

#### Delete ExchangeRate
- **DELETE** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Delete an existing ExchangeRate for a specific Currency.

## Relationships Endpoints

### Country

#### Get Country relation by ID
- **GET** `/api/Currencies/{key}/Countries/{relatedKey}/$ref`
  - Description: Retrieve an existing Countries relation for a specific Currency.

#### Get Country relations
- **GET** `/api/Currencies/{key}/Countries/$ref`
  - Description: Retrieve all Countries relations for a specific Currency.
  
#### Create Country relation
- **POST** `/api/Currencies/{key}/Countries/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Currency.
  
#### Update Country relation
- **PUT** `/api/Currencies/{key}/Countries/{relatedKey}/$ref`
  - Description: Update an existing Country relation for a specific Currency.
  
#### Partially Update Country relation
- **PATCH** `/api/Currencies/{key}/Countries/{relatedKey}/$ref`
  - Description: Partially update an existing Country relation for a specific Currency.

#### Delete Country relation
- **DELETE** `/api/Currencies/{key}/Countries/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Currency.

### MinimumCashStock

#### Get MinimumCashStock relation by ID
- **GET** `/api/Currencies/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Retrieve an existing MinimumCashStocks relation for a specific Currency.

#### Get MinimumCashStock relations
- **GET** `/api/Currencies/{key}/MinimumCashStocks/$ref`
  - Description: Retrieve all MinimumCashStocks relations for a specific Currency.
  
#### Create MinimumCashStock relation
- **POST** `/api/Currencies/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Create a new MinimumCashStock relation for a specific Currency.
  
#### Update MinimumCashStock relation
- **PUT** `/api/Currencies/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Update an existing MinimumCashStock relation for a specific Currency.
  
#### Partially Update MinimumCashStock relation
- **PATCH** `/api/Currencies/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Partially update an existing MinimumCashStock relation for a specific Currency.

#### Delete MinimumCashStock relation
- **DELETE** `/api/Currencies/{key}/MinimumCashStocks/{relatedKey}/$ref`
  - Description: Delete an existing MinimumCashStock relation for a specific Currency.

## Related Entities

[Country](CountryEndpoints.md)

[MinimumCashStock](MinimumCashStockEndpoints.md)
