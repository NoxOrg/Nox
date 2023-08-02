# Local Development

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

## Environment Variables for Sensitive Data

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

## Schemas Update

**Until we automate this process** whenever add a new TypeOption to the Nox Solution you need to:

1. Add your new type to class `NoxSimpleTypeDefinition` inside the `#region TypeOptions`;
2. Run the test in **NoxSolutionSchemaGenerate**, this test will generate the new schema files;
3. Add and commit changed `.json` files to the solution.

The is necessary for the CI pipeline to publish the new schemas.

# Nox Types

a Domain driven type system for Nox solutions

## ToString Conventions

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

# Security And Other Validations Extension

To add security, or other business rule to generated queries our custom queries, add an IValidator for the query, example for securing GetStoreByIdquery

```c#
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

The validator will be excuted before the request. Add the validator to the service collection.

```c#
services.AddSingleton<IValidator<Queries.GetStoreByIdQuery>, GetStoreByIdSecurityValidator>();
```

Response:
![Response example](/docs/images//securityexceptionexample.png)

## Versioning

We are using [SemVer](https://semver.org/) for versioning our deliverables.

To manage this version we are using [GitVersion](https://github.com/GitTools/GitVersion) tool.

### Using it locally

You can use gitversion locally to test and setup configuration. To do that intall the dotnet tool `dotnet tool install --global GitVersion.Tool --version 5.*`

run `dotnet-gitversion` to see the current variables of git version

run `dotnet-gitversion /updateprojectfiles` to update csproject files

## Release

Just Create a release in GitHub, tag it properly, and that is all. In the future we want to automate this process.
