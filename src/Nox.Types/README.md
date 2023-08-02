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

# Using Nox.Types

Nox.Types are used to describe the data types of several *domain entity* attributes within a Nox solution. These attributes include, but are not limited to, Domain Entity queries/commands/events/keys/attributes and Application DTO attributes/Event object type attributes.

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
