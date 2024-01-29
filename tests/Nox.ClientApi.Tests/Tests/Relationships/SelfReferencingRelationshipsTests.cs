using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Types;
using Xunit.Abstractions;

namespace ClientApi.Tests.Relationships;

[Collection("Sequential")]
public class SelfReferencingRelationshipsTests : NoxWebApiTestBase
{
    public SelfReferencingRelationshipsTests(
        ITestOutputHelper testOutput,
        TestDatabaseContainerService containerService)
        : base(testOutput, containerService)
    {
    }

    #region To Many

    [Fact]
    public async Task WhenAddingFranchiseStores_WhenCreatingStore_RelationshipsAreCreated()
    {
        // Arrange
        var franchiseStore1 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var franchiseStore2 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        // Act
        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            FranchisesOfStoreId = new List<System.Guid> { franchiseStore1!.Id, franchiseStore2!.Id }
        });

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.FranchisesOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.FranchisesOfStore.Should().BeEquivalentTo(new[] { franchiseStore1, franchiseStore2 });
    }

    [Fact]
    public async Task WhenAddingFranchiseStores_WhenAddingFranchiseOfStoreRelations_RelationshipsAreCreated()
    {
        // Arrange
        var franchiseStore1 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!,null!, null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var franchiseStore2 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        // Act
        await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/FranchisesOfStore/{franchiseStore1!.Id}/$ref");
        await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/FranchisesOfStore/{franchiseStore2!.Id}/$ref");

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store.Id}?$expand={nameof(StoreDto.FranchisesOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.FranchisesOfStore.Should().BeEquivalentTo(new[] { franchiseStore1, franchiseStore2 });
    }

    [Fact]
    public async Task WhenDeletingFranchiseStores_RelationshipsAreDeleted()
    {
        // Arrange
        var franchiseStore1 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var franchiseStore2 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            FranchisesOfStoreId = new List<System.Guid> { franchiseStore1!.Id, franchiseStore2!.Id }
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{franchiseStore1!.Id}", CreateEtagHeader(franchiseStore1.Etag));

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.FranchisesOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.FranchisesOfStore.Should().BeEquivalentTo(new[] { franchiseStore2 });
    }

    [Fact]
    public async Task WhenDeletingFranchiseStoreRelation_RelationshipsAreDeleted()
    {
        // Arrange
        var franchiseStore1 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var franchiseStore2 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            FranchisesOfStoreId = new List<System.Guid> { franchiseStore1!.Id, franchiseStore2!.Id }
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}/FranchisesOfStore/{franchiseStore1!.Id}/$ref", CreateEtagHeader(store.Etag));

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.FranchisesOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.FranchisesOfStore.Should().BeEquivalentTo(new[] { franchiseStore2 });
    }

    [Fact]
    public async Task WhenDeletingStore_FranchiseStoresAreNotDeleted()
    {
        // Arrange
        var franchiseStore1 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var franchiseStore2 = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!,null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            FranchisesOfStoreId = new List<System.Guid> { franchiseStore1!.Id, franchiseStore2!.Id }
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}", CreateEtagHeader(store.Etag));

        var result = await GetODataCollectionResponseAsync<IEnumerable<StoreDto>>($"{Endpoints.StoresUrl}");

        //Assert
        result.Should().NotBeNull();
        result!.Should().BeEquivalentTo(new[] { franchiseStore1, franchiseStore2 });
    }

    #endregion To Many

    #region To One

    [Fact]
    public async Task WhenAddingParentStore_WhenCreatingStore_RelationshipIsCreated()
    {
        // Arrange
        var parentStore = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!,null!, null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        // Act
        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            ParentOfStoreId = parentStore!.Id
        });

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.ParentOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.ParentOfStore.Should().BeEquivalentTo(parentStore);
    }

    [Fact]
    public async Task WhenAddingParentStore_WhenAddingParentOfStoreRelations_RelationshipIsCreated()
    {
        // Arrange
        var parentStore = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        // Act
        await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/ParentOfStore/{parentStore!.Id}/$ref");

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store.Id}?$expand={nameof(StoreDto.ParentOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.ParentOfStore.Should().BeEquivalentTo(parentStore);
    }

    [Fact]
    public async Task WhenDeletingParentStore_RelationshipIsDeleted()
    {
        // Arrange
        var parentStore = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            ParentOfStoreId = parentStore!.Id
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{parentStore!.Id}", CreateEtagHeader(parentStore.Etag));

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.ParentOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.ParentOfStore.Should().BeNull();
    }

    [Fact]
    public async Task WhenDeletingParentStoreRelation_RelationshipIsDeleted()
    {
        // Arrange
        var parentStore = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            ParentOfStoreId = parentStore!.Id
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}/ParentOfStore/{parentStore!.Id}/$ref", CreateEtagHeader(store.Etag));

        var result = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?$expand={nameof(StoreDto.ParentOfStore)}");

        //Assert
        result.Should().NotBeNull();
        result!.ParentOfStore.Should().BeNull();
    }

    [Fact]
    public async Task WhenDeletingStore_ParentStoreIsNotDeleted()
    {
        // Arrange
        var parentStore = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!,null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
        });

        var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(null!, "3000 Hillswood Business Park", null!, null!, null!, null!, null!, null!, null!, "KT16 0RS", CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749),
            ParentOfStoreId = parentStore!.Id
        });

        // Act
        await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}", CreateEtagHeader(store.Etag));

        var result = await GetODataCollectionResponseAsync<IEnumerable<StoreDto>>($"{Endpoints.StoresUrl}");

        //Assert
        result.Should().NotBeNull();
        result!.Should().BeEquivalentTo(new[] { parentStore });
    }

    #endregion
}
