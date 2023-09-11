[![Nuget][version-shield]][version-url][![contributors][contributors-shield]][contributors-url][![issues][issues-shield]][issues-url][![stars][stars-shield]][stars-url][![build][build-shield]][build-url][![forks][forks-shield]][forks-url]

<br /><div align="center"><br /><a href="https://github.com/NoxOrg/Nox.Generator"><img src="https://noxorg.dev/docs/images/Logos/NoxTypes-logo_text-grey-white_bg-black_size-1418x1890.png" alt="Logo" width="150"></a></div><br />

<p align="center">A domain driven type system for Nox solutions</p>

# About

Nox.Types is a *Domain Driven* type system used to describe, transport and persist data within Nox solutions. Nox jettisons traditional primitive data types by implementing a collection of *value objects* that are language friendly and easily interpreted by domain experts, system users and developers alike.

> 💡 A great benefit of Domain Driven Design is that it fosters a common language to describe the requirements of the domain. This common language—sometimes referred to as the *ubiquitous language*—is predicated on terminology that is universally recognised and relevant to the domain.

The Nox team took a broad approach when deciding which types are to be in scope for the library. The resultant set of domain types are universal across multiple domains and often canonical in nature, thereby broadening the usefulness of the library.

# Key Features

- Provides a layer of abstraction over primitive data types to ensure domain types that are easily understood and universally recognised.
- Validation and presentation of domain data is centralised to a single codebase point.
- Value objects are extensible to ensure they match domain requirements.
- Value objects are persisted as primitive types to supported databases.
- Supports an extensive list of commonly used domain types.

# Simple and Compound Types

Nox.Types uses both simple and compound types to persist data. For `SimpleType` a single primitive data type is used to persist the data to the database. `CompoundType` is comprised of multiple `CompoundComponent` fields and these fields are individually persisted to the database.

Looking at [NoxType.cs](https://github.com/NoxOrg/Nox.Generator/blob/feature/nox-types-readme/src/Nox.Types.Abstractions/Enums/NoxType.cs) reveals the full list of implemented enums. Notice a few examples of `SimpleType` comprised of `decimal`, `int`, `bool`, `string`, `short`, `DateTime` and `byte` in the code snippet below:

```csharp
[SimpleType(typeof(decimal))]
Area = 998304025,

[SimpleType(typeof(int))] 
AutoNumber = 24779567,

[SimpleType(typeof(bool))]
Boolean = 2157507194,

[SimpleType(typeof(string))]
Color = 1567592592,

[SimpleType(typeof(short))]
CurrencyNumber = 2377452890,

[SimpleType(typeof(DateTime))]
Date = 463099971,

[SimpleType(typeof(byte))]
Month = 4186740261,

```

Conversely, the code snippet below illustrates a few examples of `CompoundType` which comprises two or more similar or differing primitive data types:

```csharp
[CompoundType]
[CompoundComponent("Lattitude",typeof(double))]
[CompoundComponent("Longitude",typeof(double))]
LatLong = 4061881939,

[CompoundType]
[CompoundComponent("Amount", typeof(decimal))]
[CompoundComponent("CurrencyCode", typeof(string))]
Money = 3500951620,

[CompoundType] 
[CompoundComponent("From", typeof(DateTimeOffset))]
[CompoundComponent("To", typeof(DateTimeOffset))]
DateTimeRange = 3837929056,

```

# Working with Nox.Types

Working with Nox.Types value objects are simple and intuitive. They follow the pattern of using a `From` method to instantiate them and offer a `ToString` method as well as an internal `Validate` method.

A Nox.Types value object is an immutable self-contained unit, and as a result its properties are set at object creation time via the `From` method. Let's have a look at the [LatLong.cs](https://github.com/NoxOrg/Nox.Generator/blob/main/src/Nox.Types/Types/LatLong/LatLong.cs) class as an example of how creation, validation and presentation is handled.

## Creation

Nox.Types value objects are instantiated by calling the associated `From()` method and passing the appropriate arguments.

```csharp
# From LatLong.cs
public static LatLong From(double latitude, double longitude)
    => From((latitude,longitude));

# From your class
public void DemoLatLong()
{
    # Empire State Building
    var vobjLatLong = LatLong.From(40.748817, -73.985428)
}

```

## Validation

Nox.Types value objects have internal validation methods that are called at creation time. The arguments passed to the `From` method must pass the validation criteria for the value object to be successfully instantiated.

If we continue with the example above, we can see that the latitude and longitude passed have to fall within the respective known valid ranges.

```csharp
# From LatLong.cs
internal override ValidationResult Validate()
{
    var result = base.Validate();

    if (Value.Latitude > 90 || Value.Latitude < -90)
    {
        result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LatLong type with latitude {Value.Latitude} as it is not in the range -90 to 90 degrees."));
    }

    if (Value.Longitude > 180 || Value.Longitude < -180)
    {
        result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox LatLong type with longitude {Value.Longitude} as it is not in the range -180 to 180 degrees."));
    }

    return result;
}

```

## Presentation

Each Nox.Types value objects offers a default public `ToString` method, and in some instances, one ore more `ToString` overloads which may handle more specific presentation needs depending on use case.

Our example includes and addition overload for `ToString` which takes a format string, in this case to present latitude/longitude in degree/minutes/seconds format.

```csharp
# From LatLong.cs
public override string ToString()
{
    return $"{Value.Latitude.ToString("0.000000", CultureInfo.InvariantCulture)} {Value.Longitude.ToString("0.000000", CultureInfo.InvariantCulture)}";
}

public string ToString(IFormatProvider formatProvider)
{
    return $"{Value.Latitude.ToString(formatProvider)} {Value.Longitude.ToString(formatProvider)}";
}

public string ToString(string format)
{
    return format.ToLower() switch
    {
        "dms" => ToDmsString(),
        _ => ToString(),
    };
}

# From your class
public void DemoLatLong()
{
    # Empire State Building
    var vobjLatLong = LatLong.From(40.748817, -73.985428)

    Console.WriteLine(vobjLatLong.ToString())
    # returns "40.748817 -73.985428"

    Console.WriteLine(vobjLatLong.ToString("dms"))
    # returns "40.7484° N 73.9857° W"
}

```

# Using Nox.Types

Within a Nox solution, Nox.Types are used to describe the data types of several *domain entity* attributes. These attributes include, but are not limited to, Domain Entity queries/commands/events/keys/attributes and Application DTO attributes/Event object type attributes.

## In a Nox Solution definition

Have a look at an example of a simple Nox solution file. Whilst a more elaborate Nox solution file may describe additional solution concerns such as environments, infrastructure, version control, team, integrations and application, this examples focuses only on the *Domain* and specifically the *Country* entity.

```yaml
name: SampleWebApp

description: Sample Nox solution yaml configuration

domain:

  entities:

    - name: Country
      description: The list of countries
      
      userInterface:
        # Omitted for example

      persistence:
        # Omitted for example

      relationships:
        # Omitted for example

      keys:

      - name: Id
        type: text
        isRequired: true
        textTypeOptions:
          isUnicode: false
          minLength: 2
          maxLength: 2

      attributes:

        - name: Name
          description: The country's common name
          type: text
          textTypeOptions:
            minLength: 4
            maxLength: 63
          isRequired: true

        - name: AlphaCode3
          description: The country's official ISO 4217 alpha-3 code
          type: countryCode3
          isRequired: true

        - name: AlphaCode2
          description: The country's official ISO 4217 alpha-2 code
          type: countryCode2          
          isRequired: true

        - name: NumericCode
          description: The country's official ISO 4217 alpha-3 code
          type: number
          numberTypeOptions:
            minValue: 4
            maxValue: 894
          isRequired: true

        - name: DialingCodes
          description: The country's phone dialing codes (comma-delimited)
          type: text
          textTypeOptions:
            isUnicode: false
            maxLength: 31

        - name: Capital
          description: The capital city of the country
          type: text
          textTypeOptions:
            maxLength: 63

        - name: Demonym
          description: Noun denoting the natives of the country
          type: text
          textTypeOptions:
            maxLength: 63

        - name: AreaInSquareKilometres
          description: Country area in square kilometers
          type: area
          areaTypeOptions:
            minValue: 0
            maxValue: 20000000 # 20,000,000 > Russia
            units: squareFoot
            persistAs: squareFoot
          isRequired: true

        - name: GeoCoord
          description: The the position of the workplace's point on the surface of the Earth
          type: latLong

        - name: GeoRegion
          description: The region the country is in
          type: text
          textTypeOptions:
            isUnicode: false
            maxLength: 8
          isRequired: true

        - name: GeoSubRegion
          description: The sub-region the country is in
          type: text
          textTypeOptions:
            isUnicode: false
            maxLength: 32
          isRequired: true

        - name: GeoWorldRegion
          description: The world region the country is in
          type: text
          textTypeOptions:
            isUnicode: false
            maxLength: 4
          isRequired: true

        - name: Population
          description: The estimated population of the country
          type: number
          numberTypeOptions:
            minValue: 0

        - name: TopLevelDomains
          description: The top level internet domains regitered to the country (comma-delimited)
          type: text
          textTypeOptions:
            maxLength: 31

```

Examining the code snippet above will reveal several Nox.Types used to describe the various data attributes. These include [text](https://github.com/NoxOrg/Nox.Generator/blob/main/src/Nox.Types/Types/Text/Text.cs), [countryCode2](https://github.com/NoxOrg/Nox.Generator/blob/main/src/Nox.Types/Types/CountryCode2/CountryCode2.cs), [countryCode3](https://github.com/NoxOrg/Nox.Generator/tree/main/src/Nox.Types/Types/CountryCode3), [number](https://github.com/NoxOrg/Nox.Generator/blob/main/src/Nox.Types/Types/Number/Number.cs), [area](https://github.com/NoxOrg/Nox.Generator/tree/main/src/Nox.Types/Types/Area) and [latLong](https://github.com/NoxOrg/Nox.Generator/blob/main/src/Nox.Types/Types/LatLong/LatLong.cs).

Click the links to view their respective implementations in the Nox library. You can view the complete list of implemented types in the [Nox.Types repo](https://github.com/NoxOrg/Nox.Generator/tree/main/src/Nox.Types/Types)

## In a Nox class

Any of the Nox.Types value objects can be used in class files by including the `using Nox.Types` statement. In the example below we're instantiating a *Money* object with the `Money.From()` method. We're passing a decimal value and converting the `string` currency to `CurrencyCode` enum by parsing it.

```csharp
using Nox.Types;

namespace SampleCurrencyService
{
    public class DemoMoney
    {
        public Money? CashBalance { get; set; }

        public DemoMoney(decimal amount, string currency)
        {
            Enum.TryParse(currency, out CurrencyCode sentCurrency);
            CashBalance = Money.From(amount, sentCurrency);

            var currSymbol = CurrencySymbol.GetCurrencySymbol(sentCurrency);

            Console.WriteLine($"Money amount = {currSymbol}{CashBalance.ToString()}");
        }
    }
}

```

Any of the Nox.Types value objects can be used in class files by including the `using Nox.Types` statement.

Click the links to view their respective implementations in the Nox library. You can view the complete list of implemented types in the [Nox.Types repo](https://github.com/NoxOrg/Nox.Generator/tree/main/src/Nox.Types/Types)

[version-shield]: https://img.shields.io/nuget/v/Nox.Generator.svg?style=for-the-badge

[version-url]: https://www.nuget.org/packages/Nox.Generator

[build-shield]: https://img.shields.io/github/actions/workflow/status/NoxOrg/Nox.Generator/ci.yml?branch=main&event=push&label=Build&style=for-the-badge

[build-url]: https://github.com/NoxOrg/Nox.Generator/actions/workflows/ci.yml?query=branch%3Amain

[contributors-shield]: https://img.shields.io/github/contributors/NoxOrg/Nox.Generator.svg?style=for-the-badge

[contributors-url]: https://github.com/NoxOrg/Nox.Generator/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/NoxOrg/Nox.Generator.svg?style=for-the-badge

[forks-url]: https://github.com/NoxOrg/Nox.Generator/network/members

[stars-shield]: https://img.shields.io/github/stars/NoxOrg/Nox.Generator.svg?style=for-the-badge

[stars-url]: https://github.com/NoxOrg/Nox.Generator/stargazers

[issues-shield]: https://img.shields.io/github/issues/NoxOrg/Nox.Generator.svg?style=for-the-badge

[issues-url]: https://github.com/NoxOrg/Nox.Generator/issues
