# API Endpoints for the Commission entity

This document provides information about the various endpoints available in our API for the Commission entity.

## Commission Endpoints

### Get Commission Count
- **GET** `/api/Commissions/$count`
  - Description: Retrieve the number of Commissions.

### Get Commission by ID
- **GET** `/api/Commissions/{key}`
  - Description: Retrieve information about a Commission by ID.
  
### Get Commissions
- **GET** `/api/Commissions`
  - Description: Retrieve information about Commissions.

### Create Commission
- **POST** `/api/Commissions`
  - Description: Create a new Commission.

### Update Commission
- **PUT** `/api/Commissions/{key}`
  - Description: Update an existing Commission.

### Partially Update Commission
- **PATCH** `/api/Commissions/{key}`
  - Description: Partially update an existing Commission.
 
### Delete Commission
- **DELETE** `/api/Commissions/{key}`
  - Description: Delete an existing Commission.

## Relationships Endpoints

### Country

#### Get Country relations
- **GET** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Retrieve all existing Countries relations for a specific Commission.
  
#### Create Country relation
- **POST** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Create a new Country relation for a specific Commission.
  
#### Update Country relation
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Updates an existing Country relation for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Updates the Country relations for a specific Commission.

#### Delete Country relation
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}/$ref`
  - Description: Delete an existing Country relation for a specific Commission.

#### Delete Country relations
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry/$ref`
  - Description: Delete all existing Countries relations for a specific Commission.

#### Get Country
- **GET** `/api/Commissions/{key}/CommissionFeesForCountry`
  - Description: Retrieve all existing Countries for a specific Commission.
  
#### Create Country
- **POST** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}`
  - Description: Create a new Country for a specific Commission.
  
#### Update Country
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}`
  - Description: Updates an existing Country for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForCountry`
  - Description: Updates the Country for a specific Commission.

#### Delete Country
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry/{relatedKey}`
  - Description: Delete an existing Country for a specific Commission.

#### Delete Country
- **DELETE** `/api/Commissions/{key}/CommissionFeesForCountry`
  - Description: Delete all existing Countries for a specific Commission.
### Booking

#### Get Booking relations
- **GET** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Retrieve all existing Bookings relations for a specific Commission.
  
#### Create Booking relation
- **POST** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Create a new Booking relation for a specific Commission.
  
#### Update Booking relation
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Updates an existing Booking relation for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Updates the Booking relations for a specific Commission.

#### Delete Booking relation
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}/$ref`
  - Description: Delete an existing Booking relation for a specific Commission.

#### Delete Booking relations
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking/$ref`
  - Description: Delete all existing Bookings relations for a specific Commission.

#### Get Booking
- **GET** `/api/Commissions/{key}/CommissionFeesForBooking`
  - Description: Retrieve all existing Bookings for a specific Commission.
  
#### Create Booking
- **POST** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}`
  - Description: Create a new Booking for a specific Commission.
  
#### Update Booking
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}`
  - Description: Updates an existing Booking for a specific Commission.
- **PUT** `/api/Commissions/{key}/CommissionFeesForBooking`
  - Description: Updates the Booking for a specific Commission.

#### Delete Booking
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking/{relatedKey}`
  - Description: Delete an existing Booking for a specific Commission.

#### Delete Booking
- **DELETE** `/api/Commissions/{key}/CommissionFeesForBooking`
  - Description: Delete all existing Bookings for a specific Commission.

## Other Related Endpoints

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency`

- **PATCH** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency/$ref`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency/{currencyKey}/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Currency/{currencyKey}/$ref`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}`

- **PATCH** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/$ref`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/$ref`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}/$ref`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/VendingMachines/{vendingMachinesKey}/$ref`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}`

- **PATCH** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}`

- **GET** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/$ref`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/$ref`

- **POST** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}/$ref`

- **DELETE** `/api/Commissions/{commissionsKey}/Country/{countryKey}/Customers/{customersKey}/$ref`

- **GET** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction`

- **POST** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction`

- **PUT** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction`

- **PATCH** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction`

- **GET** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction/$ref`

- **POST** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction/{transactionKey}/$ref`

- **PUT** `/api/Commissions/{commissionsKey}/Bookings/{bookingsKey}/Transaction/{transactionKey}/$ref`

## Related Entities

[Country](CountryEndpoints.md)
[Booking](BookingEndpoints.md)