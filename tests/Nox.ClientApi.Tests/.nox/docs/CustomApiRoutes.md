# Custom API Routes

This document provides information about custom API routes. Custom API routes are custom endpoints that are mapped to existing OData endpoints.

## Contents
- [CountriesByName](#CountriesByName)

- [CountriesByNameQueryString](#CountriesByNameQueryString)

- [CountriesEncoded](#CountriesEncoded)

- [CountriesPreserveOdataQuery](#CountriesPreserveOdataQuery)

- [CountriesPreserveOdataQueryMultipleSegments](#CountriesPreserveOdataQueryMultipleSegments)

- [AddWorkplaceToCountry](#AddWorkplaceToCountry)

- [twoSeqSegmentsWithProperties](#twoSeqSegmentsWithProperties)

- [CountriesInPortugues](#CountriesInPortugues)

- [PostCountriesInPortugues](#PostCountriesInPortugues)

- [CountriesInPortuguesById](#CountriesInPortuguesById)

- [PatchCountriesInPortugues](#PatchCountriesInPortugues)

- [PutRefCountriesInPortuguesToWorkplaces](#PutRefCountriesInPortuguesToWorkplaces)

- [GetRefCountriesInPortuguesToWorkplaces](#GetRefCountriesInPortuguesToWorkplaces)

- [DeleteWorkplaceViaTenant](#DeleteWorkplaceViaTenant)

- [PatchWorkplaceViaTenant](#PatchWorkplaceViaTenant)

### CountriesByName
- **GET** `/api/v1/CountriesByName/{Count}`
  - Description: Get country names in alphabetical order.

### CountriesByNameQueryString
- **GET** `/api/v1/CountriesByNameQuery?count={Top}`
  - Description: Get country names in alphabetical order.

### CountriesEncoded
- **GET** `/api/v1/CountriesEncoded`
  - Description: Get country names in alphabetical order.

### CountriesPreserveOdataQuery
- **GET** `/api/v1/CountriesByOdata/{MyId}`
  - Description: Get country preserve odata query

### CountriesPreserveOdataQueryMultipleSegments
- **GET** `/api/v1/CountriesByOdataSegments/{MyId}/MySpecial`
  - Description: Get country preserve odata query with multiple segments

### AddWorkplaceToCountry
- **PUT** `/api/v1/MySpecial/{CountryId}/SecondSpecial/{ExtraId}/ThirdSpecial/$ref`
  - Description: Update country workplaces

### twoSeqSegmentsWithProperties
- **GET** `/api/v1/countriesSeqSegProps/{CountryId}/{ExtraId}`
  - Description: test case for two sequential segments with properties

### CountriesInPortugues
- **GET** `/api/v1/Paises`
  - Description: Get country names in alphabetical order.

### PostCountriesInPortugues
- **POST** `/api/v1/Paises`
  - Description: Post country

### CountriesInPortuguesById
- **GET** `/api/v1/Paises/{key}`
  - Description: Get country.

### PatchCountriesInPortugues
- **PATCH** `/api/v1/Paises/{key}`
  - Description: Get country

### PutRefCountriesInPortuguesToWorkplaces
- **PUT** `/api/v1/Paises/{key}/RefWorkplaces`
  - Description: Post ref country to workplaces.

### GetRefCountriesInPortuguesToWorkplaces
- **GET** `/api/v1/Paises/{key}/RefWorkplaces/{relatedKey}`
  - Description: Post ref country to workplaces.

### DeleteWorkplaceViaTenant
- **DELETE** `/api/v1/Tenants/{TenantId}/Workplaces/{key}`
  - Description: Delete workplace via Tenant

### PatchWorkplaceViaTenant
- **PATCH** `/api/v1/Tenants/{TenantId}/Workplaces/{key}`
  - Description: Patch workplace via Tenant
