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