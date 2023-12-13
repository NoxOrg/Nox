# Custom API Routes

This document provides information about custom API routes. Custom API routes are custom endpoints that are mapped to existing OData endpoints.

## Contents
- [CountriesByName](#CountriesByName)

- [CountriesByNameQueryString](#CountriesByNameQueryString)

- [CountriesPreserveOdataQuery](#CountriesPreserveOdataQuery)

- [CountriesPreserveOdataQueryMultipleSegments](#CountriesPreserveOdataQueryMultipleSegments)

- [AddWorkplaceToCountry](#AddWorkplaceToCountry)

- [twoSeqSegmentsWithProperties](#twoSeqSegmentsWithProperties)

### CountriesByName
- **GET** `/CountriesByName/{Count}`
  - Description: Get country names in alphabetical order.

### CountriesByNameQueryString
- **GET** `/CountriesByNameQuery?count={Top}`
  - Description: Get country names in alphabetical order.

### CountriesPreserveOdataQuery
- **GET** `/CountriesByOdata/{MyId}`
  - Description: Get country preserve odata query

### CountriesPreserveOdataQueryMultipleSegments
- **GET** `/CountriesByOdataSegments/{MyId}/MySpecial`
  - Description: Get country preserve odata query with multiple segments

### AddWorkplaceToCountry
- **PUT** `/MySpecial/{CountryId}/SecondSpecial/{ExtraId}/ThirdSpecial/$ref`
  - Description: Update country workplaces

### twoSeqSegmentsWithProperties
- **GET** `/countriesSeqSegProps/{CountryId}/{ExtraId}`
  - Description: test case for two sequential segments with properties
