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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityZeroOrOneToOneOrManyFactory : TestEntityZeroOrOneToOneOrManyFactoryBase
{
    public TestEntityZeroOrOneToOneOrManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityZeroOrOneToOneOrManyFactoryBase : IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityZeroOrOneToOneOrManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityZeroOrOneToOneOrManyEntity> CreateEntityAsync(TestEntityZeroOrOneToOneOrManyCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityZeroOrOneToOneOrManyEntity entity, TestEntityZeroOrOneToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany> ToEntityAsync(TestEntityZeroOrOneToOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany();
        entity.Id = TestEntityZeroOrOneToOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityZeroOrOneToOneOrManyEntity entity, TestEntityZeroOrOneToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}