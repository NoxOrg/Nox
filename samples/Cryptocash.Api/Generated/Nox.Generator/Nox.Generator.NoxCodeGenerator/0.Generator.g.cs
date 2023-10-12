// Generated

#nullable enable

// Found files ->
//  - cryptocash.application.nox.yaml
//  - CountrySync.integration.nox.yaml
//  - cryptocash.solution.nox.yaml
//  - cryptocash.domain.nox.yaml
//  - BankNote.entity.nox.yaml
//  - Booking.entity.nox.yaml
//  - CashStockOrder.entity.nox.yaml
//  - Commission.entity.nox.yaml
//  - Country.entity.nox.yaml
//  - CountryTimeZone.entity.nox.yaml
//  - Currency.entity.nox.yaml
//  - Customer.entity.nox.yaml
//  - Employee.entity.nox.yaml
//  - EmployeePhoneNumber.entity.nox.yaml
//  - ExchangeRate.entity.nox.yaml
//  - Holiday.entity.nox.yaml
//  - Landlord.entity.nox.yaml
//  - MinimumCashStock.entity.nox.yaml
//  - PaymentDetail.entity.nox.yaml
//  - PaymentProvider.entity.nox.yaml
//  - Transaction.entity.nox.yaml
//  - VendingMachine.entity.nox.yaml
//  - cryptocash.infrastructure.nox.yaml
//  - cryptocash.dependencies.nox.yaml
//  - NoxReferenceData.dataConnection.nox.yaml
//  - cryptocash.persistence.nox.yaml
//  - generator.nox.yaml
// Errors ->
//  - Missing property ["schedule"] on instance [name: CountrySync,description: Synchronization of ...] of type [Nox.Solution.Integration] is required.
Missing property ["transformationType"] on instance [name: CountrySync,description: Synchronization of ...] of type [Nox.Solution.Integration] is required.
Missing property ["sourceAdapterType"] on instance [name: NoxReferenceCountryData,description: Curated...] of type [Nox.Solution.IntegrationSource] is required.
Disallowed property ["schedule"] on instance [name: NoxReferenceCountryData,description: Curated...] of type [Nox.Solution.IntegrationSource].
Disallowed property ["sourceType"] on instance [name: NoxReferenceCountryData,description: Curated...] of type [Nox.Solution.IntegrationSource].
Disallowed property ["webApiOptions"] on instance [name: NoxReferenceCountryData,description: Curated...] of type [Nox.Solution.IntegrationSource].
Missing property ["targetAdapterType"] on instance [name: CountryEntities,description: The country ent...] of type [Nox.Solution.IntegrationTarget] is required.
Disallowed property ["targetType"] on instance [name: CountryEntities,description: The country ent...] of type [Nox.Solution.IntegrationTarget].
Disallowed property ["entityOptions"] on instance [name: CountryEntities,description: The country ent...] of type [Nox.Solution.IntegrationTarget].   at Nox.Solution.Schema.NoxSchemaValidator.Deserialize[T](YamlReferenceResolver yamlRefResolver)
   at Nox.Solution.NoxSolutionBuilder.ResolveAndLoadConfiguration()
   at Nox.Solution.NoxSolutionBuilder.Build()
   at Nox.Generator.NoxCodeGenerator.TryGetNoxSolution(ImmutableArray`1 noxYamls, NoxSolution& solution)
   at Nox.Generator.NoxCodeGenerator.GenerateSource(SourceProductionContext context, ImmutableArray`1 noxYamls)
