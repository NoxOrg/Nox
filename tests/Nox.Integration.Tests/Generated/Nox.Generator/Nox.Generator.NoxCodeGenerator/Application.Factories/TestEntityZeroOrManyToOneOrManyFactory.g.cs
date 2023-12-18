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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityZeroOrManyToOneOrManyFactory : TestEntityZeroOrManyToOneOrManyFactoryBase
{
    public TestEntityZeroOrManyToOneOrManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityZeroOrManyToOneOrManyFactoryBase : IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityZeroOrManyToOneOrManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityZeroOrManyToOneOrManyEntity> CreateEntityAsync(TestEntityZeroOrManyToOneOrManyCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityZeroOrManyToOneOrManyEntity entity, TestEntityZeroOrManyToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrManyToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany> ToEntityAsync(TestEntityZeroOrManyToOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany();
        entity.Id = TestEntityZeroOrManyToOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField2, (entity) => entity.TextTestField2 = 
            TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(createDto.TextTestField2.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityZeroOrManyToOneOrManyEntity entity, TestEntityZeroOrManyToOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrManyToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}