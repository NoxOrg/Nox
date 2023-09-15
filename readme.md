[![Nuget][version-shield]][version-url][![contributors][contributors-shield]][contributors-url][![issues][issues-shield]][issues-url][![stars][stars-shield]][stars-url][![build][build-shield]][build-url][![forks][forks-shield]][forks-url]


<br /><div align="center"><br /><a href="https://github.com/NoxOrg/Nox.Generator"><img src="https://noxorg.dev/docs/images/Logos/Nox-logo_text-grey-only_bg-black_size-1418x1890.png" alt="Logo" width="150"></a></div><br />

<p align="center">Build and deploy enterprise-grade business solutions in under an hour</p>

<div align="center"><a href="https://noxorg.dev"><strong>Visit the Nox homepage »</strong></a><br /><br /><a href="https://github.com/NoxOrg/Nox.Generator/blob/main/docs/CONTRIBUTING.md">Contribute to Nox</a> · <a href="https://noxorg.dev/en/nox-lib-quick-start-project/">Use Nox for your project</a></div><br />

<details><summary>Table of Contents</summary><ol><li><a href="#about">About</a></li><li><a href="#main-features">Main Features</a></li><li><a href="#contributing-to-the-nox-library">Contributing to the Nox library</a></li><ul><li><a href="#local-development">Local Development</a></li><li><a href="#update-the-database-model">Update the Database Model</a></li><li><a href="#odata">Odata</a></li><li><a href="#[nox.solution]-updating-schemas">[Nox.Solution] Updating Schemas</a></li><li><a href="#[nox.types]-tostring-conventions">[Nox.Types] ToString conventions</a></li><li><a href="#versioning">Versioning</a></li></ul><ul><li><a href="#using-it-locally">Using it locally</a></li></ul><ul><li><a href="#release">Release</a></li></ul><li><a href="#using-the-nox-library">Using the Nox Library</a></li><ul><li><a href="#environment-variables-for-sensitive-data">Environment Variables for Sensitive Data</a></li></ul><ul><li><a href="#example">Example</a></li></ul><ul><li><a href="#query-and-command-extensibility">Query and Command Extensibility</a></li></ul><ul><li><a href="#security-and-other-validations">Security and other Validations</a></li><li><a href="#queries-filter-extension">Queries Filter Extension</a></li><li><a href="#add-new-queries-to-existing-controllers">Add new Queries to Existing Controllers</a></li></ul></ol></details>

# About

Nox.Lib is a .NET framework that allows developers to rapidly build, maintain and deploy enterprise-grade, production-ready business solutions.

> 💡 At its heart, Nox is a code scaffolding engine that is extended through a range of handlers, including message, command, query and event handlers.

Nox pivots around the concept of a *solution definition*. This solution describes the domain, application, integrations, infrastructure, version control and project team. The Nox.Generator interprets this *solution* and scaffolds all the necessary code for a working solution.

# Main Features

- Declaration of your core application and domain (models, data, entities, attributes and bounded contexts) in a declaritive and easily maintainable way (YAML, using YamlDotNet).
- Automatic (and selective) Create, Read, Update and Delete (CRUD) API for entities and/or aggregate roots (supports REST with OData, with GraphQL and gRPC in the making).
- The choice of persisting your data in any database with current support for Sql Server, PostgreSQL or MySql (using Entity Framework).
- Automated Database Migrations (coming soon).
- Validation of entities and attributes (using FluentValidation).
- Logging, Observability and Monitoring (using SeriLog).
- Events and Messaging (In process/Mediator, Azure Servicebus, Amazon SQS, RabbitMQ) using MassTransit.
- Extract, transform and load (ETL) definitions from any database, file or API with bulk-load and merge support.
- A task scheduler for running recurring tasks at periodic intervals (using Hangfire).
- Automated DevOps including testing and deployment.

# Contributing to the Nox library

We welcome community pull requests for bug fixes, enhancements, and documentation. See [How to contribute](./docs/CONTRIBUTING.md) for more information.

## Local Development

To run the SampleWebApp you need to have SQL Server running. This is a temporary measure until support for MySQL and PostreSQL is implemented.

In the root of your project start SQL Server in a Docker container by running `docker-compose -f .\docker-compose.sqlServer.yml up`

Update database with migrations by running the command `dotnet ef database update -c "SampleWebAppDbContext"`

Run the Sample the database should be provisioned and properly setup its model.

## Update the Database Model

Migration history do not need to be tracked, usually during local development you can delete 'Migration' folder and create a new migration.

If you don't have .NET [EF Core Tools](https://www.nuget.org/packages/dotnet-ef) installed, run `dotnet tool install --global dotnet-ef` at the command line. You'll also need to add [EF Core Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design) to your project to run migrations. Simply run `dotnet add package Microsoft.EntityFrameworkCore.Design`.

To generate initial migration you can use the following command `dotnet ef migrations add "InitialCreate" -c "SampleWebAppDbContext"`

## Odata

[OData](https://www.odata.org/) endpoints in debug mode can be found at `\$odata`

## \[Nox.Solution\] Updating Schemas

Until this process is automated, whenever a new TypeOption is added to the Nox Solution the following steps must be followed:

1. Add your new type to class NoxSimpleTypeDefinition inside the `#region TypeOptions`;
2. Run the test in **NoxSolutionSchemaGenerate**, this test will generate the new schema files;
3. Add and commit changed `.json` schema files to the solution.

## \[Nox.Types\] ToString conventions

Nox does not follow the usual convention for `ToString()`.  
The `ToString()` method should return the same result independently of the current culture, for example for DateTime, Currency, dependent types.  
The reasoning behind this is to ensure a fully predictable result that facilitates ETL processes and interoperability with other systems.  
The same is expected for the `ToString(string format)` overload.  
If you need a culture dependent representation create an overload with a `IFormatProvider` parameter, example:

```csharp
ToString(IFormatProvider formatProvider);

```

LatLong Nox.Type example:

```csharp
public override string ToString()
{
    return $"{Value.Latitude.ToString("0.000000", CultureInfo.InvariantCulture)} {Value.Longitude.ToString("0.000000", CultureInfo.InvariantCulture)}";
}

public string ToString(IFormatProvider formatProvider)
{
    return $"{Value.Latitude.ToString(formatProvider)} {Value.Longitude.ToString(formatProvider)}";
}

```

## Versioning

We are using [SemVer](https://semver.org/) for versioning our deliverables.

To manage this version we are using [GitVersion](https://github.com/GitTools/GitVersion) tool.

### Using it locally

You can use gitversion locally to test and setup configuration. To do that intall the dotnet tool `dotnet tool install --global GitVersion.Tool --version 5.*`

Run `dotnet-gitversion` to see the current variables of git version

Run `dotnet-gitversion /updateprojectfiles` to update csproject files

## Release

Create a release in GitHub and tag it properly. In the future we want to automate this process.

# Using the Nox Library

## Environment Variables for Sensitive Data

Do not commit or keep sensitive data on your yaml solution files.  
The current way to this is by using Environment Variables.

### Example

Nox will expand any text with the following convention `${{ env.VAR_NAME }}` to the value of **VAR_NAME** Environment Variable if found. Sample Yaml:

```yaml
databaseServer:
name: SampleCurrencyDb
serverUri: ${{ env.DB_SERVER }}
provider: sqlServer
port: 1433
user: ${{ env.DB_USER }}
password: ${{ env.DB_PASSWORD }}

```

## Query and Command Extensibility

### Security and other Validations

To add security, or other business rules to generated/custom queries or commands, add an `IValidator` interface for the query. See the example below for securing `GetStoreByIdquery`

```csharp
public class GetStoreByIdSecurityValidator : AbstractValidator<GetStoreByIdQuery>
{
    public GetStoreByIdSecurityValidator(ILogger<GetStoreByIdQuery> logger)
    {
        // For the Current User
        // TODO Get Stores that he can see.... 

        // Do Validation The current user can only see EUR Store
        RuleFor(query => query.key).Must(key => key == "EUR").WithMessage("No permissions to access this store");            
    }
}

```

The validator will be excuted before the request. Adding the validator to the service collection as per the code snippet below should yield a `ValidationException` at runtime:

```csharp
services.AddSingleton<IValidator<Queries.GetStoreByIdQuery>, GetStoreByIdSecurityValidator>();

```

<div align="left"><img src="https://noxorg.dev/docs/images/securityexceptionexample.png" alt="" width="70%"><br /></div>

### Queries Filter Extension

To add extra filter to generated queries, for security or other purposes, add a new Pipeline behavior (see MediatR), filtering Get Stores example:

```csharp
public class GetStoresQuerySecurityFilter : IPipelineBehavior<GetStoresQuery, IQueryable<OStore>>
{
    public async Task<IQueryable<OStore>> Handle(GetStoresQuery request, RequestHandlerDelegate<IQueryable<OStore>> next, CancellationToken cancellationToken)
    {
        var result = await next();

        return result.Where(store => store.Id == "EUR");
    }
}

```

And register in the container:

```csharp
services.AddScoped<IPipelineBehavior<GetStoresQuery, IQueryable<OStore>>, GetStoresQuerySecurityFilter> ()

```

### Add new Queries to Existing Controllers

To add a custom query to a generated controller, you need to:

1. Create a partial class with the name of the controller
2. Create a Query Request
3. Create a Query Handler

Example:

```csharp
/// <summary>
/// Extending a OData controller example with additional queries (Action) and commands (Functions)
/// </summary>
public partial class CountriesController
{
    [HttpGet("GetCountriesIManage")]
    public async Task<IResult> GetCountriesIManage()
    {
        var result = await _mediator.Send(new GetCountriesIManageQuery());
        return Results.Ok(result);
    }
}


namespace SampleWebApp.Application.Queries
{
    /// <summary>
    /// Custom Query and Handler Example
    /// </summary>
    public record GetCountriesIManageQuery : IRequest<IQueryable<OCountry>>;

    public class GetCountriesIManageQueryHandler : IRequestHandler<GetCountriesIManageQuery, IQueryable<OCountry>>
    {
        public GetCountriesIManageQueryHandler(ODataDbContext dataDbContext)
        {
            DataDbContext = dataDbContext;
        }

        public ODataDbContext DataDbContext { get; }

        public Task<IQueryable<OCountry>> Handle(GetCountriesIManageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IQueryable<OCountry>)DataDbContext.Countries.Where(country => country.Population > 12348));
        }
    }
}

```

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

