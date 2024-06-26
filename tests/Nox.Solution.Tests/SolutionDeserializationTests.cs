using Nox.Types;

namespace Nox.Solution.Tests;

public class SolutionDeserializationTests
{
    [Fact]
    public void Variables_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/variables.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Variables);
        Assert.Equal(2, noxConfig.Variables.Count);
        Assert.Equal("value1", noxConfig.Variables["VARIABLE1"]);
        Assert.Equal("value2", noxConfig.Variables["VARIABLE2"]);
    }
    
    [Fact]
    public void Environments_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/environments.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Environments);
        Assert.Equal(4, noxConfig.Environments.Count);
        Assert.Equal("dev", noxConfig.Environments[0].Name);
        Assert.Equal("Used for development and testing", noxConfig.Environments[0].Description);
        Assert.Equal("test", noxConfig.Environments[1].Name);
        Assert.Equal("Test environment", noxConfig.Environments[1].Description);
        Assert.Equal("uat", noxConfig.Environments[2].Name);
        Assert.Equal("For them end users to check it works", noxConfig.Environments[2].Description);
        Assert.Equal("prod", noxConfig.Environments[3].Name);
        Assert.Equal("Production environment used for, well - the real thing!", noxConfig.Environments[3].Description);
    }
    
    [Fact]
    public void VersionControl_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/version-control.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.VersionControl);
        Assert.Equal(VersionControlProvider.AzureDevops, noxConfig.VersionControl.Provider);
        Assert.Equal(new System.Uri("https://dev.azure.com/iwgplc"), noxConfig.VersionControl.Host);
        Assert.NotNull(noxConfig.VersionControl.Folders);
        Assert.Equal("/src", noxConfig.VersionControl.Folders.SourceCode);
        Assert.Equal("/docker", noxConfig.VersionControl.Folders.Containers);
    }
    
    [Fact]
    public void Team_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/team.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Team);
        Assert.Equal(2, noxConfig.Team.Count);
        Assert.Equal("Andre Sharpe", noxConfig.Team[0].Name);
        Assert.Equal("andre.sharpe@iwgplc.com", noxConfig.Team[0].UserName);
        Assert.NotNull(noxConfig.Team[0].Roles);
        Assert.Equal(5, noxConfig.Team[0].Roles!.Count);
        Assert.Contains(TeamRole.Architect, noxConfig.Team[0].Roles!);
        Assert.Contains(TeamRole.Manager, noxConfig.Team[0].Roles!);
    }
    
    [Fact]
    public void Domain_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/domain.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Domain);
        Assert.NotNull(noxConfig.Domain.Entities);
        Assert.Equal(4, noxConfig.Domain.Entities.Count);
        
        var country = noxConfig.Domain.Entities[0];
        Assert.Equal("Country", country.Name);
        Assert.Equal("The list of countries", country.Description);
        
        Assert.NotNull(country.UserInterface);
        Assert.Equal("world", country.UserInterface.Icon);
        
        Assert.NotNull(country.Persistence);
        Assert.True(country.Persistence.IsAudited);
        
        Assert.NotNull(country.Relationships);
        Assert.Single(country.Relationships);
        Assert.Equal("CountryAcceptsCurrency", country.Relationships[0].Name);
        Assert.Equal("accepts as legal tender", country.Relationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.Relationships[0].Relationship);
        Assert.Equal("Currency", country.Relationships[0].Entity);
        
        Assert.NotNull(country.OwnedRelationships);
        Assert.Single(country.OwnedRelationships);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Name);
        Assert.Equal("is also know as", country.OwnedRelationships[0].Description);
        Assert.Equal(EntityRelationshipType.OneOrMany, country.OwnedRelationships[0].Relationship);
        Assert.Equal("CountryLocalNames", country.OwnedRelationships[0].Entity);
        
        Assert.NotNull(country.Queries);
        Assert.Single(country.Queries);
        Assert.Equal("GetCountriesByContinent", country.Queries[0].Name);
        Assert.Equal("Returns a list of countries for a given continent", country.Queries[0].Description);
        
        Assert.NotNull(country.Queries[0].RequestInput);
        Assert.Single(country.Queries[0].RequestInput!);
        Assert.Equal("continentName", country.Queries[0].RequestInput![0].Name);
        Assert.Equal("Africa, Europe, Asia, Australia, North America, or South America", country.Queries[0].RequestInput![0].Description);
        Assert.Equal(NoxType.Text, country.Queries[0].RequestInput![0].Type);
        Assert.NotNull(country.Queries[0].RequestInput![0].TextTypeOptions);
        Assert.False(country.Queries[0].RequestInput![0].TextTypeOptions!.IsUnicode);
        
        Assert.NotNull(country.Queries[0].ResponseOutput);
        Assert.Equal("countriesByContinentDto", country.Queries[0].ResponseOutput.Name);
        Assert.Equal(NoxType.Collection, country.Queries[0].ResponseOutput.Type);
        Assert.NotNull(country.Queries[0].ResponseOutput.CollectionTypeOptions);
        Assert.Equal("countryInfo", country.Queries[0].ResponseOutput.CollectionTypeOptions!.Name);
        Assert.Equal(NoxType.Object, country.Queries[0].ResponseOutput.CollectionTypeOptions!.Type);
        Assert.NotNull(country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions);
        Assert.NotNull(country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes);
        Assert.Equal(2, country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes.Count);
        Assert.Equal("CountryId", country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[0].Name);
        Assert.Equal("The country's Id", country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[0].Description);
        Assert.Equal(NoxType.CountryCode2, country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[0].Type);
        Assert.Equal("CountryName", country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[1].Name);
        Assert.Equal("The country name", country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[1].Description);
        Assert.Equal(NoxType.Text, country.Queries[0].ResponseOutput.CollectionTypeOptions!.ObjectTypeOptions!.Attributes[1].Type);
        
        Assert.NotNull(country.Commands);
        Assert.Single(country.Commands);
        Assert.Equal("UpdatePopulationStatistics", country.Commands[0].Name);
        Assert.Equal("Instructs the service to collect updated population statistics", country.Commands[0].Description);
        Assert.Equal(NoxType.Object, country.Commands[0].Type);
        Assert.NotNull(country.Commands[0].ObjectTypeOptions);
        Assert.NotNull(country.Commands[0].ObjectTypeOptions!.Attributes);
        Assert.Single(country.Commands[0].ObjectTypeOptions!.Attributes);
        Assert.Equal("CountryCode", country.Commands[0].ObjectTypeOptions!.Attributes[0].Name);
        Assert.Equal(NoxType.CountryCode2, country.Commands[0].ObjectTypeOptions!.Attributes[0].Type);
        Assert.NotNull(country.Commands[0].EmitEvents);
        Assert.Single(country.Commands[0].EmitEvents!);
        Assert.Equal("CountryNameUpdatedDomainEvent", country.Commands[0].EmitEvents![0]);
        
        Assert.NotNull(country.Events);
        Assert.Single(country.Events);
        Assert.Equal("CountryNameUpdatedDomainEvent", country.Events[0].Name);
        Assert.Equal("Raised when the name of a country is changed", country.Events[0].Description);
        
        Assert.NotNull(country.Keys);
        Assert.Single(country.Keys);
        Assert.Equal("Id", country.Keys[0].Name);
        Assert.Equal(NoxType.Text, country.Keys[0].Type);
        Assert.NotNull(country.Keys[0].TextTypeOptions);
        Assert.False(country.Keys[0].TextTypeOptions!.IsUnicode);
        Assert.Equal(2u, country.Keys[0].TextTypeOptions!.MaxLength);
        Assert.Equal(2u, country.Keys[0].TextTypeOptions!.MinLength);
        
        Assert.NotNull(country.Attributes);
        Assert.Equal(15, country.Attributes.Count);
        
    }

    [Fact]
    public void Application_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/application.solution.nox.yaml")
            .Build();
        
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Application);
        
        Assert.NotNull(noxConfig.Application.DataTransferObjects);
        Assert.Single(noxConfig.Application.DataTransferObjects);
        Assert.Equal("CountryDto", noxConfig.Application.DataTransferObjects[0].Name);
        Assert.Equal("Dto for country information", noxConfig.Application.DataTransferObjects[0].Description);
        Assert.NotNull(noxConfig.Application.DataTransferObjects[0].Attributes);
        Assert.Single(noxConfig.Application.DataTransferObjects[0].Attributes);
        Assert.Equal("Id", noxConfig.Application.DataTransferObjects[0].Attributes[0].Name);
        Assert.Equal("The identity of the country, the Iso Alpha 2 code", noxConfig.Application.DataTransferObjects[0].Attributes[0].Description);
        Assert.Equal(NoxType.Text, noxConfig.Application.DataTransferObjects[0].Attributes[0].Type);
        Assert.NotNull(noxConfig.Application.DataTransferObjects[0].Attributes[0].TextTypeOptions);
        Assert.Equal(TextTypeCasing.Lower, noxConfig.Application.DataTransferObjects[0].Attributes[0].TextTypeOptions!.Casing);
        Assert.Equal(2u, noxConfig.Application.DataTransferObjects[0].Attributes[0].TextTypeOptions!.MaxLength);
        Assert.Equal(2u, noxConfig.Application.DataTransferObjects[0].Attributes[0].TextTypeOptions!.MinLength);
        
        Assert.NotNull(noxConfig.Application.Integrations);
        Assert.Equal(2, noxConfig.Application.Integrations.Count);
        Assert.Equal("JsonToEntityIntegration", noxConfig.Application.Integrations[0].Name);
        Assert.Equal("a Sample integration that sources data from json files and persist to a Nox Entity", noxConfig.Application.Integrations[0].Description);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source);
        Assert.Equal("CountryJsonSource", noxConfig.Application.Integrations[0].Source!.Name);
        Assert.Equal("Sources Country data from a json file", noxConfig.Application.Integrations[0].Source!.Description);
        Assert.Equal("CountryJsonData", noxConfig.Application.Integrations[0].Source!.DataConnectionName);
        Assert.NotNull(noxConfig.Application.Integrations[0].Schedule);
        Assert.Equal("every day at 2am", noxConfig.Application.Integrations[0].Schedule!.Start);
        Assert.NotNull(noxConfig.Application.Integrations[0].Schedule!.Retry);
        Assert.Equal(5, noxConfig.Application.Integrations[0].Schedule!.Retry!.Limit);
        Assert.Equal(5, noxConfig.Application.Integrations[0].Schedule!.Retry!.DelaySeconds);
        Assert.Equal(10, noxConfig.Application.Integrations[0].Schedule!.Retry!.DoubleDelayLimit);
        Assert.True(noxConfig.Application.Integrations[0].Schedule!.RunOnStartup);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Watermark);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns);
        Assert.Equal(2, noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns!.Count);
        Assert.Equal("CreateDate", noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns![0]);
        Assert.Equal("EditDate", noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns![1]);
        Assert.Equal("CountryId", noxConfig.Application.Integrations[0].Source!.Watermark!.SequentialKeyColumns![0]);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Transformation!.Mapping);
        Assert.Equal(2, noxConfig.Application.Integrations[0].Transformation!.Mapping!.Count);

        Assert.NotNull(noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Source);
        Assert.Equal("CountryId", noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Source!.Name);
        Assert.Equal(IntegrationMapDataType.Integer, noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Source!.Type);
        Assert.NotNull(noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Target);
        Assert.Equal("Id", noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Target!.Name);
        Assert.Equal(IntegrationMapDataType.Integer, noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Target!.Type);
        Assert.True(noxConfig.Application.Integrations[0].Transformation!.Mapping![0].IsRequired);
        
        Assert.Null(noxConfig.Application.Integrations[0].Transformation!.Mapping![1].Source);
        Assert.NotNull(noxConfig.Application.Integrations[0].Transformation!.Mapping![1].Target);
        Assert.Equal("MyCalculatedField", noxConfig.Application.Integrations[0].Transformation!.Mapping![1].Target!.Name);
        Assert.Equal(IntegrationMapDataType.Integer, noxConfig.Application.Integrations[0].Transformation!.Mapping![1].Target!.Type);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Transformation!.Mapping![0].Target);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Target);
        Assert.Equal("Country", noxConfig.Application.Integrations[0].Target.Name);
        Assert.Equal(IntegrationTargetAdapterType.DatabaseTable, noxConfig.Application.Integrations[0].Target.TargetAdapterType);
    }

    [Fact]
    public void Infrastructure_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/infrastructure.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Infrastructure);
        
        Assert.NotNull(noxConfig.Infrastructure.Persistence);
        Assert.NotNull(noxConfig.Infrastructure.Persistence.DatabaseServer);
        Assert.Equal("SampleCurrencyDb", noxConfig.Infrastructure.Persistence.DatabaseServer.Name);
        Assert.Equal("sqlserver.iwgplc.com", noxConfig.Infrastructure.Persistence.DatabaseServer.ServerUri);
        Assert.Equal(DatabaseServerProvider.SqlServer, noxConfig.Infrastructure.Persistence.DatabaseServer.Provider);
        Assert.Equal(1433, noxConfig.Infrastructure.Persistence.DatabaseServer.Port);
        Assert.Equal("sqluser", noxConfig.Infrastructure.Persistence.DatabaseServer.User);
        Assert.Equal("sqlpassword", noxConfig.Infrastructure.Persistence.DatabaseServer.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Persistence.CacheServer);
        Assert.Equal("SampleCache", noxConfig.Infrastructure.Persistence.CacheServer.Name);
        Assert.Equal("redis.iwgplc.com", noxConfig.Infrastructure.Persistence.CacheServer.ServerUri);
        Assert.Equal(CacheServerProvider.AzureRedis, noxConfig.Infrastructure.Persistence.CacheServer.Provider);
        Assert.Equal("RedisUser", noxConfig.Infrastructure.Persistence.CacheServer.User);
        Assert.Equal("RedisPassword", noxConfig.Infrastructure.Persistence.CacheServer.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Persistence.SearchServer);
        Assert.Equal("SampleSearch", noxConfig.Infrastructure.Persistence.SearchServer.Name);
        Assert.Equal("elastic.iwgplc.com", noxConfig.Infrastructure.Persistence.SearchServer.ServerUri);
        Assert.Equal(SearchServerProvider.ElasticSearch, noxConfig.Infrastructure.Persistence.SearchServer.Provider);
        Assert.Equal("ElasticUser", noxConfig.Infrastructure.Persistence.SearchServer.User);
        Assert.Equal("ElasticPassword", noxConfig.Infrastructure.Persistence.SearchServer.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Persistence.EventSourceServer);
        Assert.Equal("SampleEvtSrc", noxConfig.Infrastructure.Persistence.EventSourceServer.Name);
        Assert.Equal("SampleEvt.iwgplc.com", noxConfig.Infrastructure.Persistence.EventSourceServer.ServerUri);
        Assert.Equal(EventSourceServerProvider.EventStoreDb, noxConfig.Infrastructure.Persistence.EventSourceServer.Provider);
        Assert.Equal("EvtUser", noxConfig.Infrastructure.Persistence.EventSourceServer.User);
        Assert.Equal("EvtPassword", noxConfig.Infrastructure.Persistence.EventSourceServer.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Messaging);
        
        Assert.NotNull(noxConfig.Infrastructure.Messaging.IntegrationEventServer);
        Assert.NotNull(noxConfig.Infrastructure.Messaging.IntegrationEventServer.AzureServiceBusConfig);
        Assert.Equal("sb://your-servicebus-name.servicebus.windows.net/", noxConfig.Infrastructure.Messaging.IntegrationEventServer.AzureServiceBusConfig.Endpoint);
        Assert.Equal("your-shared-access-key-name", noxConfig.Infrastructure.Messaging.IntegrationEventServer.AzureServiceBusConfig.SharedAccessKeyName);
        Assert.Equal("your-shared-access-key", noxConfig.Infrastructure.Messaging.IntegrationEventServer.AzureServiceBusConfig.SharedAccessKey);


        Assert.NotNull(noxConfig.Infrastructure.Endpoints);
        Assert.NotNull(noxConfig.Infrastructure.Endpoints.ApiServer);
        Assert.Equal("SampleApiServer", noxConfig.Infrastructure.Endpoints.ApiServer.Name);
        Assert.Equal("workplace.iwgplc.com", noxConfig.Infrastructure.Endpoints.ApiServer.ServerUri);
        Assert.Equal(8080, noxConfig.Infrastructure.Endpoints.ApiServer.Port);
        
        Assert.NotNull(noxConfig.Infrastructure.Endpoints.BffServer);
        Assert.Equal("SampleBffServer", noxConfig.Infrastructure.Endpoints.BffServer.Name);
        Assert.Equal("SampleBff.iwgplc.com", noxConfig.Infrastructure.Endpoints.BffServer.ServerUri);
        Assert.Equal(8080, noxConfig.Infrastructure.Endpoints.BffServer.Port);
        
        Assert.NotNull(noxConfig.Infrastructure.Dependencies);
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Notifications);
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Notifications.EmailServer);
        Assert.Equal("SampleEmailServer", noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.Name);
        Assert.Equal(EmailServerProvider.SendGrid, noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.Provider);
        Assert.Equal("sendgrid.iwgplc.com", noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.ServerUri);
        Assert.Equal("SendGridUser", noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.User);
        Assert.Equal("SendGridPassword", noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Notifications.SmsServer);
        Assert.Equal("SampleSmsServer", noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.Name);
        Assert.Equal(SmsServerProvider.Twilio, noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.Provider);
        Assert.Equal("https://twilio.com", noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.ServerUri);
        Assert.Equal(8080, noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.Port);
        Assert.Equal("TwilioUser", noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.User);
        Assert.Equal("TwilioPassword", noxConfig.Infrastructure.Dependencies.Notifications.SmsServer!.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Notifications.ImServer);
        Assert.Equal("SampleImServer", noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.Name);
        Assert.Equal(ImServerProvider.WhatsApp, noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.Provider);
        Assert.Equal("https://whatsapp.com", noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.ServerUri);
        Assert.Equal("whatsappUser", noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.User);
        Assert.Equal(8080, noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.Port);
        Assert.Equal("whatsappPassword", noxConfig.Infrastructure.Dependencies.Notifications.ImServer!.Password);
        
        
        Assert.NotNull(noxConfig.Infrastructure.Monitoring);
        Assert.Equal(MonitoringProvider.ElasticApm, noxConfig.Infrastructure.Monitoring!.Provider);
        Assert.NotNull(noxConfig.Infrastructure.Monitoring!.ElasticApmServer);
        Assert.Equal("localhost", noxConfig.Infrastructure.Monitoring!.ElasticApmServer.ServerUri);
        Assert.Equal(string.Empty, noxConfig.Infrastructure.Monitoring!.ElasticApmServer.ServiceName);
        Assert.Equal(string.Empty, noxConfig.Infrastructure.Monitoring!.ElasticApmServer.SecretToken);
        Assert.Equal("Production", noxConfig.Infrastructure.Monitoring!.ElasticApmServer.Environment);

        Assert.NotNull(noxConfig.Infrastructure.Dependencies.UiLocalizations);
        Assert.Equal("SampleCurrencyDb.Localization", noxConfig.Infrastructure.Dependencies.UiLocalizations!.Name);
        Assert.Equal("sqlserver.iwgplc.com", noxConfig.Infrastructure.Dependencies.UiLocalizations!.ServerUri);
        Assert.Equal(1433, noxConfig.Infrastructure.Dependencies.UiLocalizations!.Port);
        Assert.Equal(DatabaseServerProvider.SqlServer, noxConfig.Infrastructure.Dependencies.UiLocalizations.Provider);
        Assert.Equal("sqluser", noxConfig.Infrastructure.Dependencies.UiLocalizations.User);
        Assert.Equal("sqlpassword", noxConfig.Infrastructure.Dependencies.UiLocalizations.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Security);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer);
        Assert.Equal("SampleOrgSecretServer", noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.Name);
        Assert.Equal(SecretsServerProvider.AzureKeyVault, noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.Provider);
        Assert.Equal("kv.iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.ServerUri);
        Assert.Equal("secrets@iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.User);
        Assert.Equal("SecretPassword", noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.Password);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.ValidFor);
        Assert.Equal(10, noxConfig.Infrastructure.Security.Secrets!.OrganizationSecretsServer!.ValidFor!.Minutes);
        
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer);
        Assert.Equal("SampleSlnSecretServer", noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.Name);
        Assert.Equal(SecretsServerProvider.AzureKeyVault, noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.Provider);
        Assert.Equal("kv.iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.ServerUri);
        Assert.Equal("secrets@iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.User);
        Assert.Equal("SecretPassword", noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.Password);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.ValidFor);
        Assert.Equal(10, noxConfig.Infrastructure.Security.Secrets!.SolutionSecretsServer!.ValidFor!.Minutes);

        Assert.NotNull(noxConfig.Infrastructure.Dependencies.DataConnections);
        Assert.Single(noxConfig.Infrastructure.Dependencies.DataConnections);
        Assert.Equal("CountryJsonData", noxConfig.Infrastructure.Dependencies.DataConnections[0].Name);
        Assert.Equal(DataConnectionProvider.JsonFile, noxConfig.Infrastructure.Dependencies.DataConnections[0].Provider);
        Assert.Equal("file:///C:/my-data-files", noxConfig.Infrastructure.Dependencies.DataConnections[0].ServerUri);
        Assert.Equal("Source=File;Filename=country-data.json;", noxConfig.Infrastructure.Dependencies.DataConnections[0].Options);
    }

    [Fact]
    public void Can_create_a_full_configuration()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/sample.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        
    }
}