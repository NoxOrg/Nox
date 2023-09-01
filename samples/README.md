# Cryptocash Solution Design

``` mermaid
erDiagram
    Booking {
        DatabaseGuid Id PK
        Money AmountFrom
        Money AmountTo
        DateTimeRange RequestedPickUpDate
        DateTimeRange PickedUpDateTime
        DateTime ExpiryDateTime
        DateTime CancelledDateTime
        Formula Status
        VatNumber VatNumber
        DatabaseNumber CustomerId FK
        DatabaseGuid VendingMachineId FK
        DatabaseNumber CommissionId FK
        DatabaseNumber CustomerTransactionId FK
    }
    Commission {
        DatabaseNumber Id PK
        Percentage Rate
        DateTime EffectiveAt
        CountryCode2 CountryId FK
        DatabaseGuid BookingId FK
    }
    Commission||--o{Booking : "Booking's fee"
    Country {
        CountryCode2 Id PK
        Text Name
        Text OfficialName
        CountryNumber CountryIsoNumeric
        CountryCode3 CountryIsoAlpha3
        LatLong GeoCoords
        Text FlagEmoji
        Image FlagSvg
        Image FlagPng
        Image CoatOfArmsSvg
        Image CoatOfArmsPng
        Url GoogleMapsUrl
        Url OpenStreetMapsUrl
        DayOfWeek StartOfWeek
        CurrencyCode3 CurrencyId FK
        DatabaseNumber CountryTimeZonesId FK
        DatabaseNumber CommissionId FK
        DatabaseGuid VendingMachineId FK
        DatabaseNumber CountryHolidayId FK
        DatabaseNumber CustomerId FK
    }
    Country|o--|{Commission : "Commission's country"
    CountryHoliday {
        DatabaseNumber Id PK
        Text Name
        Text Type
        Date Date
        CountryCode2 CountryId FK
    }
    CountryHoliday}o--||Country : "Country's holidays"
    CountryTimeZones {
        DatabaseNumber Id PK
        TimeZoneCode TimeZoneCode
        CountryCode2 CountryId FK
    }
    CountryTimeZones}|--||Country : "Country's time zones"
    Currency {
        CurrencyCode3 Id PK
        Text Name
        CurrencyNumber CurrencyIsoNumeric
        Text Symbol
        Text ThousandsSeparator
        Text DecimalSeparator
        Boolean SpaceBetweenAmountAndSymbol
        Number DecimalDigits
        Text MajorName
        Text MajorSymbol
        Text MinorName
        Text MinorSymbol
        Money MinorToMajorValue
        DatabaseNumber BankNotesId FK
        CountryCode2 CountryId FK
        DatabaseNumber MinimumCashStockId FK
        DatabaseNumber ExchangeRateId FK
    }
    Currency||--|{BankNotes : "Currency's bank notes"
    Currency||--|{Country : "Country's currency"
    BankNotes {
        DatabaseNumber Id PK
        Text BankNote
        Boolean IsRare
        CurrencyCode3 CurrencyId FK
    }
    Customer {
        DatabaseNumber Id PK
        Text FirstName
        Text LastName
        Email EmailAddress
        StreetAddress Address
        PhoneNumber MobileNumber
        DatabaseNumber CustomerPaymentDetailsId FK
        DatabaseGuid BookingId FK
        DatabaseNumber CustomerTransactionId FK
        CountryCode2 CountryId FK
    }
    Customer||--o{Booking : "Customer's booking"
    Customer}o--||Country : "Customer's country"
    CustomerPaymentDetails {
        DatabaseNumber Id PK
        Text PaymentAccountName
        Text PaymentAccountNumber
        Text PaymentAccountSortCode
        DatabaseNumber CustomerId FK
        DatabaseNumber PaymentProviderId FK
    }
    CustomerPaymentDetails}o--||Customer : "Customer's payment account"
    CustomerTransaction {
        DatabaseNumber Id PK
        Text TransactionType
        DateTime ProcessedOnDateTime
        Money Amount
        Text Reference
        DatabaseNumber CustomerId FK
        DatabaseGuid BookingId FK
    }
    CustomerTransaction}o--||Customer : "Transaction's customer"
    CustomerTransaction||--||Booking : "Transaction's booking"
    Employee {
        DatabaseNumber Id PK
        Text FirstName
        Text LastName
        Email EmailAddress
        StreetAddress Address
        Date FirstWorkingDay
        Date LastWorkingDay
        DatabaseNumber EmployeePhoneNumberId
        DatabaseNumber VendingMachineOrderId FK
    }
    EmployeePhoneNumber {
        DatabaseNumber Id PK
        Text PhoneNumberType
        PhoneNumber PhoneNumber
    }
    ExchangeRate {
        DatabaseNumber Id PK
        Number EffectiveRate
        DateTime EffectiveAt
        CurrencyCode3 CurrencyId FK
    }
    ExchangeRate}|--||Currency : "Exchanged from currency"
    LandLord {
        DatabaseNumber Id PK
        Text Name
        StreetAddress Address
        DatabaseGuid VendingMachineId FK
    }
    MinimumCashStock {
        DatabaseNumber Id PK
        Money Amount
        DatabaseGuid VendingMachineId FK
        CurrencyCode3 CurrencyId FK
    }
    MinimumCashStock}o--||Currency : "Cash stock's currency"
    PaymentProvider {
        DatabaseNumber Id PK
        Text PaymentProviderName
        Text PaymentProviderType
        DatabaseNumber CustomerPaymentDetailsId FK
    }
    PaymentProvider||--||CustomerPaymentDetails : "Payment provider"
    VendingMachine {
        DatabaseGuid Id PK
        MacAddress MacAddress
        IpAddress PublicIp
        LatLong GeoLocation
        StreetAddress StreetAddress
        Text SerialNumber
        Area InstallationFootPrint
        Money RentPerSquareMetre
        CountryCode2 CountryId FK
        DatabaseNumber LandLordId FK
        DatabaseGuid BookingId FK
        DatabaseNumber VendingMachineOrderId FK
        DatabaseNumber MinimumCashStockId FK
    }
    VendingMachine}o--||Country : "Vending machine's country"
    VendingMachine}o--||LandLord : "Area of the vending machine installation landlord"
    VendingMachine||--o{Booking : "Booking's vending machine"
    VendingMachine||--o{MinimumCashStock : "Vending machine's minimum cash stock"
    VendingMachineOrder {
        DatabaseNumber Id PK
        Money Amount
        Date RequestedDeliveryDate
        DateTime DeliveryDateTime
        Formula Status
        DatabaseGuid VendingMachineId FK
        DatabaseNumber EmployeeId FK
    }
    VendingMachineOrder}o--||VendingMachine : "Vending machine's orders"
    VendingMachineOrder||--||Employee : "Reviewed by employee"

```