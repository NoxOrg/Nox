﻿// Generated

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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityExactlyOneToZeroOrOneFactory : TestEntityExactlyOneToZeroOrOneFactoryBase
{
    public TestEntityExactlyOneToZeroOrOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityExactlyOneToZeroOrOneFactoryBase : IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityExactlyOneToZeroOrOneFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityExactlyOneToZeroOrOneEntity> CreateEntityAsync(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne> ToEntityAsync(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityExactlyOneToZeroOrOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField2", () => entity.SetIfNotNull(createDto.TextTestField2, (entity) => entity.TextTestField2 = 
            TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField2",() => entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestField2UpdateValue, "Attribute 'TextTestField2' can't be null.");
            {
                exceptionCollector.Collect("TextTestField2",() =>entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}