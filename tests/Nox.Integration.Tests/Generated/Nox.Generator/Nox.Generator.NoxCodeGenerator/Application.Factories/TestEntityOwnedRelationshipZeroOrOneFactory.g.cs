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
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOwnedRelationshipZeroOrOneFactory : TestEntityOwnedRelationshipZeroOrOneFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> secondtestentityownedrelationshipzerooronefactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshipzerooronefactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipZeroOrOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> SecondTestEntityOwnedRelationshipZeroOrOneFactory {get;}

    public TestEntityOwnedRelationshipZeroOrOneFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> secondtestentityownedrelationshipzerooronefactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipZeroOrOneFactory = secondtestentityownedrelationshipzerooronefactory;
        _repository = repository;
    }

    public virtual async Task<TestEntityOwnedRelationshipZeroOrOneEntity> CreateEntityAsync(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne> ToEntityAsync(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        if (createDto.SecondTestEntityOwnedRelationshipZeroOrOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(await SecondTestEntityOwnedRelationshipZeroOrOneFactory.CreateEntityAsync(createDto.SecondTestEntityOwnedRelationshipZeroOrOne));
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.SecondTestEntityOwnedRelationshipZeroOrOne is null)
        {
            if(entity.SecondTestEntityOwnedRelationshipZeroOrOne is not null) 
                _repository.DeleteOwned(entity.SecondTestEntityOwnedRelationshipZeroOrOne);
			entity.DeleteAllRefToSecondTestEntityOwnedRelationshipZeroOrOne();
        }
		else
		{
            if(entity.SecondTestEntityOwnedRelationshipZeroOrOne is not null)
                await SecondTestEntityOwnedRelationshipZeroOrOneFactory.UpdateEntityAsync(entity.SecondTestEntityOwnedRelationshipZeroOrOne, updateDto.SecondTestEntityOwnedRelationshipZeroOrOne, cultureCode);
            else
			    entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(await SecondTestEntityOwnedRelationshipZeroOrOneFactory.CreateEntityAsync(updateDto.SecondTestEntityOwnedRelationshipZeroOrOne));
		}
	}
}