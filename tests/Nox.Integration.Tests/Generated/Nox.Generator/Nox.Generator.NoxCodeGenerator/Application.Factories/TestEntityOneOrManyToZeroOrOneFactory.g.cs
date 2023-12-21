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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOneOrManyToZeroOrOneFactory : TestEntityOneOrManyToZeroOrOneFactoryBase
{
    public TestEntityOneOrManyToZeroOrOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityOneOrManyToZeroOrOneFactoryBase : IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityOneOrManyToZeroOrOneFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityOneOrManyToZeroOrOneEntity> CreateEntityAsync(TestEntityOneOrManyToZeroOrOneCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityOneOrManyToZeroOrOneEntity entity, TestEntityOneOrManyToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOneOrManyToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne> ToEntityAsync(TestEntityOneOrManyToZeroOrOneCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityOneOrManyToZeroOrOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField2", () => entity.SetIfNotNull(createDto.TextTestField2, (entity) => entity.TextTestField2 = 
            TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOneOrManyToZeroOrOneEntity entity, TestEntityOneOrManyToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField2",() => entity.TextTestField2 = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityOneOrManyToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestField2UpdateValue, "Attribute 'TextTestField2' can't be null.");
            {
                exceptionCollector.Collect("TextTestField2",() =>entity.TextTestField2 = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}