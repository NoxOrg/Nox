# Custom API Routes

This document provides information about custom API routes. Custom API routes are custom endpoints that are mapped to existing OData endpoints.

## Contents
- [CountriesByName](#CountriesByName)

- [CountriesByNameQueryString](#CountriesByNameQueryString)

- [CountriesEncoded](#CountriesEncoded)

- [CountriesInPortugues](#CountriesInPortugues)

- [CountriesPreserveOdataQuery](#CountriesPreserveOdataQuery)

- [CountriesPreserveOdataQueryMultipleSegments](#CountriesPreserveOdataQueryMultipleSegments)

- [AddWorkplaceToCountry](#AddWorkplaceToCountry)

- [twoSeqSegmentsWithProperties](#twoSeqSegmentsWithProperties)

### CountriesByName
- **GET** `/api/v1/CountriesByName/{Count}`
  - Description: Get country names in alphabetical order.

### CountriesByNameQueryString
- **GET** `/api/v1/CountriesByNameQuery?count={Top}`
  - Description: Get country names in alphabetical order.

### CountriesEncoded
- **GET** `/api/v1/CountriesEncoded`
  - Description: Get country names in alphabetical order.

### CountriesInPortugues
- **GET** `/api/v1/Paises`
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
