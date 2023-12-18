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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityZeroOrOneToExactlyOneFactory : TestEntityZeroOrOneToExactlyOneFactoryBase
{
    public TestEntityZeroOrOneToExactlyOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityZeroOrOneToExactlyOneFactoryBase : IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityZeroOrOneToExactlyOneFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityZeroOrOneToExactlyOneEntity> CreateEntityAsync(TestEntityZeroOrOneToExactlyOneCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne> ToEntityAsync(TestEntityZeroOrOneToExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne();
        entity.Id = TestEntityZeroOrOneToExactlyOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}