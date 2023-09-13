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
  - Description: Create a new Currency with the provided data.

### Update Currency
- **PUT** `/api/Currencies/{key}`
  - Description: Update an existing Currency by ID with the provided data.
 
### Delete Currency
- **DELETE** `/api/Currencies/{key}`
  - Description: Delete an existing Currency by its ID.

### Owned Relationships Endpoints

### Get BankNotes
- **GET** `/api/Currencies/{key}/BankNotes`
  - Description: Retrieve all BankNotes for a specific Currency.
  
### Create BankNote
- **POST** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Create a new BankNote for a specific Currency.
  
### Update BankNote
- **PUT** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Update an existing BankNote for a specific Currency.
  
### Partially Update BankNote
- **PATCH** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Partially update an existing BankNote for a specific Currency.

### Delete BankNote
- **DELETE** `/api/Currencies/{key}/BankNotes/{relatedKey}`
  - Description: Delete an existing BankNote by its ID for a specific Currency.

### Get ExchangeRates
- **GET** `/api/Currencies/{key}/ExchangeRates`
  - Description: Retrieve all ExchangeRates for a specific Currency.
  
### Create ExchangeRate
- **POST** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Create a new ExchangeRate for a specific Currency.
  
### Update ExchangeRate
- **PUT** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Update an existing ExchangeRate for a specific Currency.
  
### Partially Update ExchangeRate
- **PATCH** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Partially update an existing ExchangeRate for a specific Currency.

### Delete ExchangeRate
- **DELETE** `/api/Currencies/{key}/ExchangeRates/{relatedKey}`
  - Description: Delete an existing ExchangeRate by its ID for a specific Currency.

### Relationships Endpoints

[Country Endpoints](CountryEndpoints.md)

[MinimumCashStock Endpoints](MinimumCashStockEndpoints.md)
