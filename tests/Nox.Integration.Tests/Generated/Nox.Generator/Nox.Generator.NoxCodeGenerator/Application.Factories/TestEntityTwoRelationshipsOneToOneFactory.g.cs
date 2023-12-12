// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityTwoRelationshipsOneToOneFactory : TestEntityTwoRelationshipsOneToOneFactoryBase
{
    public TestEntityTwoRelationshipsOneToOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityTwoRelationshipsOneToOneFactoryBase : IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityTwoRelationshipsOneToOneFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityTwoRelationshipsOneToOneEntity> CreateEntityAsync(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne> ToEntityAsync(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne();
        entity.Id = TestEntityTwoRelationshipsOneToOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}