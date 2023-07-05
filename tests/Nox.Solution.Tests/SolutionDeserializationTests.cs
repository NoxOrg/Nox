using Microsoft.Extensions.DependencyInjection;
using Nox.Types;

namespace Nox.Solution.Tests;

public class SolutionDeserializationTests
{
    [Fact]
    public void Variables_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/variables.solution.nox.yaml")
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
            .UseYamlFile("./files/environments.solution.nox.yaml")
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
            .UseYamlFile("./files/version-control.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.VersionControl);
        Assert.Equal(VersionControlProvider.AzureDevops, noxConfig.VersionControl.Provider);
        Assert.Equal(new Uri("https://dev.azure.com/iwgplc"), noxConfig.VersionControl.Host);
        Assert.NotNull(noxConfig.VersionControl.Folders);
        Assert.Equal("/src", noxConfig.VersionControl.Folders.SourceCode);
        Assert.Equal("/docker", noxConfig.VersionControl.Folders.Containers);
    }
    
    [Fact]
    public void Team_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/team.solution.nox.yaml")
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
            .UseYamlFile("./files/domain.solution.nox.yaml")
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
        Assert.True(country.Persistence.IsVersioned);
        
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
        Assert.Equal(NoxType.Object, country.Events[0].Type);
        Assert.NotNull(country.Events[0].ObjectTypeOptions);
        Assert.NotNull(country.Events[0].ObjectTypeOptions!.Attributes);
        Assert.Equal(2, country.Events[0].ObjectTypeOptions!.Attributes.Count);
        Assert.Equal("CountryId", country.Events[0].ObjectTypeOptions!.Attributes[0].Name);
        Assert.Equal(NoxType.CountryCode2, country.Events[0].ObjectTypeOptions!.Attributes[0].Type);
        Assert.Equal("CountryName", country.Events[0].ObjectTypeOptions!.Attributes[1].Name);
        Assert.Equal(NoxType.Text, country.Events[0].ObjectTypeOptions!.Attributes[1].Type);
        
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
            .UseYamlFile("./files/application.solution.nox.yaml")
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
        Assert.Single(noxConfig.Application.Integrations);
        Assert.Equal("SampleEtl", noxConfig.Application.Integrations[0].Name);
        Assert.Equal("a Sample Etl", noxConfig.Application.Integrations[0].Description);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source);
        Assert.Equal("CountryJsonSource", noxConfig.Application.Integrations[0].Source!.Name);
        Assert.Equal("Sources Country data from a json file", noxConfig.Application.Integrations[0].Source!.Description);
        Assert.Equal("CountryJsonData", noxConfig.Application.Integrations[0].Source!.DataConnectionName);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Schedule);
        Assert.Equal("every day at 2am", noxConfig.Application.Integrations[0].Source!.Schedule!.Start);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Schedule!.Retry);
        Assert.Equal(5, noxConfig.Application.Integrations[0].Source!.Schedule!.Retry!.Limit);
        Assert.Equal(5, noxConfig.Application.Integrations[0].Source!.Schedule!.Retry!.DelaySeconds);
        Assert.Equal(10, noxConfig.Application.Integrations[0].Source!.Schedule!.Retry!.DoubleDelayLimit);
        Assert.True(noxConfig.Application.Integrations[0].Source!.Schedule!.RunOnStartup);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Watermark);
        Assert.NotNull(noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns);
        Assert.Equal(2, noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns!.Length);
        Assert.Equal("CreateDate", noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns![0]);
        Assert.Equal("EditDate", noxConfig.Application.Integrations[0].Source!.Watermark!.DateColumns![1]);
        Assert.Equal("CountryId", noxConfig.Application.Integrations[0].Source!.Watermark!.SequentialKeyColumn);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Transform);
        Assert.NotNull(noxConfig.Application.Integrations[0].Transform!.Mappings);
        Assert.Equal(3, noxConfig.Application.Integrations[0].Transform!.Mappings!.Count);
        Assert.Equal("IsoAlpha2Code", noxConfig.Application.Integrations[0].Transform!.Mappings![0].SourceColumn);
        Assert.Equal("Id", noxConfig.Application.Integrations[0].Transform!.Mappings![0].TargetAttribute);
        Assert.Equal(IntegrationMappingConverter.UpperCase, noxConfig.Application.Integrations[0].Transform!.Mappings![0].Converter);
        Assert.Equal("CountryName", noxConfig.Application.Integrations[0].Transform!.Mappings![1].SourceColumn);
        Assert.Equal("Name", noxConfig.Application.Integrations[0].Transform!.Mappings![1].TargetAttribute);
        Assert.Equal("CountryFullName", noxConfig.Application.Integrations[0].Transform!.Mappings![2].SourceColumn);
        Assert.Equal("FormalName", noxConfig.Application.Integrations[0].Transform!.Mappings![2].TargetAttribute);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Transform!.Lookups);
        Assert.Single(noxConfig.Application.Integrations[0].Transform!.Lookups!);
        Assert.Equal("RegionId", noxConfig.Application.Integrations[0].Transform!.Lookups![0].SourceColumn);
        Assert.NotNull(noxConfig.Application.Integrations[0].Transform!.Lookups![0].Match);
        Assert.Equal("GeoRegions", noxConfig.Application.Integrations[0].Transform!.Lookups![0].Match.Table);
        Assert.Equal("Id", noxConfig.Application.Integrations[0].Transform!.Lookups![0].Match.LookupColumn);
        Assert.Equal("Name", noxConfig.Application.Integrations[0].Transform!.Lookups![0].Match.ReturnColumn);
        Assert.Equal("GeoRegion", noxConfig.Application.Integrations[0].Transform!.Lookups![0].TargetAttribute);
        
        Assert.NotNull(noxConfig.Application.Integrations[0].Target);
        Assert.Equal("Country", noxConfig.Application.Integrations[0].Target!.Name);
        Assert.Equal(IntegrationTargetType.Entity, noxConfig.Application.Integrations[0].Target!.TargetType);
    }

    [Fact]
    public void Infrastructure_section_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/infrastructure.solution.nox.yaml")
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
        Assert.Equal("elastic.igwplc.com", noxConfig.Infrastructure.Persistence.SearchServer.ServerUri);
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
        Assert.Equal("IntegrationBus", noxConfig.Infrastructure.Messaging.IntegrationEventServer.Name);
        Assert.Equal("rabbitmq://localhost/", noxConfig.Infrastructure.Messaging.IntegrationEventServer.ServerUri);
        Assert.Equal(MessagingServerProvider.RabbitMq, noxConfig.Infrastructure.Messaging.IntegrationEventServer.Provider);
        Assert.Equal(5672, noxConfig.Infrastructure.Messaging.IntegrationEventServer.Port);
        Assert.Equal("guest", noxConfig.Infrastructure.Messaging.IntegrationEventServer.User);
        Assert.Equal("guest", noxConfig.Infrastructure.Messaging.IntegrationEventServer.Password);
        
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
        Assert.Equal("sendgrid.igwplc.com", noxConfig.Infrastructure.Dependencies.Notifications.EmailServer!.ServerUri);
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
        
        
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Monitoring);
        Assert.Equal("SampleObservabiity", noxConfig.Infrastructure.Dependencies.Monitoring!.Name);
        Assert.Equal("localhost", noxConfig.Infrastructure.Dependencies.Monitoring!.ServerUri);
        Assert.Equal(8200, noxConfig.Infrastructure.Dependencies.Monitoring!.Port);
        
        Assert.NotNull(noxConfig.Infrastructure.Dependencies.Translations);
        Assert.Equal("SampleTranslationService", noxConfig.Infrastructure.Dependencies.Translations!.Name);
        Assert.Equal("translator.iwgplc.com", noxConfig.Infrastructure.Dependencies.Translations!.ServerUri);
        Assert.Equal(443, noxConfig.Infrastructure.Dependencies.Translations!.Port);
        
        Assert.NotNull(noxConfig.Infrastructure.Security);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets);
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.SecretsServer);
        Assert.Equal("SampleSecretServer", noxConfig.Infrastructure.Security.Secrets!.SecretsServer!.Name);
        Assert.Equal(SecretsServerProvider.AzureKeyVault, noxConfig.Infrastructure.Security.Secrets!.SecretsServer!.Provider);
        Assert.Equal("kv.iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.SecretsServer!.ServerUri);
        Assert.Equal("secrets@iwgplc.com", noxConfig.Infrastructure.Security.Secrets!.SecretsServer!.User);
        Assert.Equal("SecretPassword", noxConfig.Infrastructure.Security.Secrets!.SecretsServer!.Password);
        
        Assert.NotNull(noxConfig.Infrastructure.Security.Secrets!.ValidFor);
        Assert.Equal(10, noxConfig.Infrastructure.Security.Secrets!.ValidFor!.Minutes);
        
        
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
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        
    }
}