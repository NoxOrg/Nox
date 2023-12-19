# API Endpoints for the Currency entity

This document provides information about the various endpoints available in our API for the Currency entity.

## Currency Endpoints

### Get Currency Count
- **GET** `/api/Currencies/$count`
  - Description: Retrieve the number of Currencies.

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
- **GET** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Retrieve a BankNote by ID for a specific Currency.

#### Create BankNote
- **POST** `/api/Currencies/{key}/BankNotes`
  - Description: Create a new BankNote for a specific Currency.

#### Update BankNote
- **PUT** `/api/Currencies/{key}/BankNotes`
  - Description: Update an existing BankNote for a specific Currency.
  
#### Partially Update BankNote
- **PATCH** `/api/Currencies/{key}/BankNotes`
  - Description: Partially update an existing BankNote for a specific Currency.

#### Delete BankNote
- **DELETE** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Delete an existing BankNote for a specific Currency.

### ExchangeRate

#### Get ExchangeRates
- **GET** `/api/Currencies/{key}/ExchangeRates`
  - Description: Retrieve all ExchangeRates for a specific Currency.
- **GET** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Retrieve a ExchangeRate by ID for a specific Currency.

#### Create ExchangeRate
- **POST** `/api/Currencies/{key}/ExchangeRates`
  - Description: Create a new ExchangeRate for a specific Currency.

#### Update ExchangeRate
- **PUT** `/api/Currencies/{key}/ExchangeRates`
  - Description: Update an existing ExchangeRate for a specific Currency.
  
#### Partially Update ExchangeRate
- **PATCH** `/api/Currencies/{key}/ExchangeRates`
  - Description: Partially update an existing ExchangeRate for a specific Currency.

#### Delete ExchangeRate
- **DELETE** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Delete an existing ExchangeRate for a specific Currency.

## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/Currencies/{key}/CurrencyUsedByCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Currency.
  
#### Create Country relation
- **POST** `/api/Currencies/{key}/CurrencyUsedByCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Currency.
  
#### Update Country relation
- **PUT** `/api/Currencies/{key}/CurrencyUsedByCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Currency.
- **PUT** `/api/Currencies/{key}/CurrencyUsedByCountry/$ref`
  - Description: Updates the Country relations for a specific Currency.

#### Delete Country relation
- **DELETE** `/api/Currencies/{key}/CurrencyUsedByCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Currency.

#### Delete Country relations
- **DELETE** `/api/Currencies/{key}/CurrencyUsedByCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Currency.

### MinimumCashStock

#### Get MinimumCashStock relations
- **GET** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/$ref`
  - Description: Retrieve all existing MinimumCashStocks relations for a specific Currency.
  
#### Create MinimumCashStock relation
- **POST** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/{relatedKey}/$ref`
  - Description: Create a new MinimumCashStock relation for a specific Currency.
  
#### Update MinimumCashStock relation
- **PUT** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/{relatedKey}/$ref`
  - Description: Updates an existing MinimumCashStock relation for a specific Currency.
- **PUT** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/$ref`
  - Description: Updates the MinimumCashStock relations for a specific Currency.

#### Delete MinimumCashStock relation
- **DELETE** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/{relatedKey}/$ref`
  - Description: Delete an existing MinimumCashStock relation for a specific Currency.

#### Delete MinimumCashStock relations
- **DELETE** `/api/Currencies/{key}/CurrencyUsedByMinimumCashStocks/$ref`
  - Description: Delete all existing MinimumCashStocks relations for a specific Currency.

## Related Entities

[Country](CountryEndpoints.md)

[MinimumCashStock](MinimumCashStockEndpoints.md)

