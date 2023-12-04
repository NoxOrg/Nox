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

internal abstract class TestEntityTwoRelationshipsOneToOneFactoryBase : IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityTwoRelationshipsOneToOneFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual TestEntityTwoRelationshipsOneToOneEntity CreateEntity(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne ToEntity(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne();
        entity.Id = TestEntityTwoRelationshipsOneToOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
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

internal partial class TestEntityTwoRelationshipsOneToOneFactory : TestEntityTwoRelationshipsOneToOneFactoryBase
{
    public TestEntityTwoRelationshipsOneToOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}