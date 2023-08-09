[![Nuget][version-shield]][version-url][![contributors][contributors-shield]][contributors-url][![issues][issues-shield]][issues-url][![stars][stars-shield]][stars-url][![build][build-shield]][build-url][![forks][forks-shield]][forks-url]

<br /><div align="center"><br /><a href="https://github.com/NoxOrg/Nox.Generator"><img src="https://noxorg.dev/docs/images/Logos/Nox-logo_text-grey-only_bg-black_size-1418x1890.png" alt="Logo" width="150"></a></div><br />

<p align="center">Build and deploy enterprise-grade business solutions in under an hour</p>

# Local Development - Contributors

To run the SampleWebApp you need to have a SQL Server running, this is temporary until we provide the remain database providers.

Using SQL Server on the root run `docker-compose -f .\docker-compose.sqlServer.yml up`

Update database with migrations by running command `dotnet ef database update -c "SampleWebAppDbContext"`

Run the Sample the database should be provisioned and properly setup its model.

## Steps to update the database model

Migration history do not need to be tracked, usually during local development you can delete 'Migration' folder and create a new migration.

To generate initial migration you can use the following command `dotnet ef migrations add "InitialCreate" -c "SampleWebAppDbContext"`

## Odata

Odata end point in debug can be found in `\$odata`

# Nox.Solution

## Environment Variables for Sensitive Data - Customers

Do not commit or keep sensitive data on your yaml solution files.

The current way to this is by using Environment Variables.

### Example

Nox will expand any text with the following convention  ``${{ env.VAR_NAME }}`` to the value of **VAR_NAME** Environment Variable if found.
Sample Yaml:

    databaseServer:
        name: SampleCurrencyDb
        serverUri: ${{ env.DB_SERVER }}
        provider: sqlServer
        port: 1433
        user: ${{ env.DB_USER }}
        password: ${{ env.DB_PASSWORD }}

## Schemas Update - Contributors

**Until we automate this process** whenever add a new TypeOption to the Nox Solution you need to:

1. Add your new type to class `NoxSimpleTypeDefinition` inside the `#region TypeOptions`;
2. Run the test in **NoxSolutionSchemaGenerate**, this test will generate the new schema files;
3. Add and commit changed `.json` files to the solution.

The is necessary for the CI pipeline to publish the new schemas.

# Nox Types

a Domain driven type system for Nox solutions

## ToString Conventions - Contributors

Nox does not follow the usual convention for ToString().

The ToString() should return the same result independently of the current culture, for example for DateTime, Currency, dependent types.

The reasoning behind this is to ensure a fully predictable result that facilitates ETL process's and interopability with other systems.

The same is expected for the ToString(string format) overload.

If you need a culture dependent representation create an overload with a IFormatProvider parameter, example

```c#
ToString(IFormatProvider formatProvider);
```

LatLong Nox type example:

```c#
 public override string ToString()
{
    return $"{Value.Latitude.ToString("0.000000", CultureInfo.InvariantCulture)} {Value.Longitude.ToString("0.000000", CultureInfo.InvariantCulture)}";
}

public string ToString(IFormatProvider formatProvider)
{
    return $"{Value.Latitude.ToString(formatProvider)} {Value.Longitude.ToString(formatProvider)}";
}
```
# Queries and Commands Extensability

## Security And Other Validations - Customers

To add security, or other business rule to generated queries, commands, orr custom queries, add an IValidator for the query, example for securing GetStoreByIdquery

```c#
 public class GetVendingMachineByIdSecurityValidator : AbstractValidator<GetVendingMachineByIdQuery>
    {
        public GetVendingMachineByIdSecurityValidator(ILogger<GetVendingMachineByIdQuery> logger)
        {
            // For the Current User
            // TODO Get Vending machines that he can see.... 

            // Do Validation The current user can only see EUR Store
            RuleFor(query => query.key).Must(key => key == 1).WithMessage("No permissions to access this Vending Machine");            
        }
    }
```

The validator will be excuted before the request. Add the validator to the service collection.

```c#
services.AddSingleton<IValidator<Queries.GetVendingMachineByIdQuery>, GetVendingMachineByIdSecurityValidator>();
```

Response:
![Response example](/docs/images//securityexceptionexample.png)

## Queries Filter Extension - Customers

To add extra filter to generated queries, for security or other purposes, add a new Pipeline behavior (see MediatR), filtering Get Stores example:

```c#
  public class GetStoresQuerySecurityFilter : IPipelineBehavior<GetStoresQuery, IQueryable<OStore>>
    {
        public async Task<IQueryable<OStore>> Handle(GetStoresQuery request, RequestHandlerDelegate<IQueryable<OStore>> next, CancellationToken cancellationToken)
        {
            var result = await next();

            return result.Where(store => store.Id == 1);
        }
    }
```

and register in the container

```c#
services.AddScoped<IPipelineBehavior<GetStoresQuery, IQueryable<OStore>>, GetStoresQuerySecurityFilter> ()
```

## Add new Queries to Existing Controllers - Customers

To add a custom query to a generated controller, you need to:

1. Create a partial class with the name of the controller
1. Create a Query Request
1. Create a Query Handler

example:

```c#
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

## Versioning - Contributors

We are using [SemVer](https://semver.org/) for versioning our deliverables.

To manage this version we are using [GitVersion](https://github.com/GitTools/GitVersion) tool.

### Using it locally

You can use gitversion locally to test and setup configuration. To do that intall the dotnet tool `dotnet tool install --global GitVersion.Tool --version 5.*`

run `dotnet-gitversion` to see the current variables of git version

run `dotnet-gitversion /updateprojectfiles` to update csproject files

## Release - Contributors

Just Create a release in GitHub, tag it properly, and that is all. In the future we want to automate this process.

# Contributing

We welcome community pull requests for bug fixes, enhancements, and documentation. See [How to contribute](./docs/CONTRIBUTING.md) for more information.

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
