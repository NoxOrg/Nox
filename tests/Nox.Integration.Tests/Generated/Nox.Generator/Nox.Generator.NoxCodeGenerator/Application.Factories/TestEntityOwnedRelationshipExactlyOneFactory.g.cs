﻿
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
using Dto = TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOwnedRelationshipExactlyOneFactory : TestEntityOwnedRelationshipExactlyOneFactoryBase
{
    public TestEntityOwnedRelationshipExactlyOneFactory
    (
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> secentityownedrelexactlyonefactory
    ) : base(repository, secentityownedrelexactlyonefactory)
    {}
}

internal abstract class TestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> SecEntityOwnedRelExactlyOneFactory {get;}

    public TestEntityOwnedRelationshipExactlyOneFactoryBase(
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> secentityownedrelexactlyonefactory
        )
    {
        _repository = repository;
        SecEntityOwnedRelExactlyOneFactory = secentityownedrelexactlyonefactory;
    }

    public virtual async Task<TestEntityOwnedRelationshipExactlyOneEntity> CreateEntityAsync(TestEntityOwnedRelationshipExactlyOneCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityOwnedRelationshipExactlyOneEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityOwnedRelationshipExactlyOneEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityOwnedRelationshipExactlyOneEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne> ToEntityAsync(TestEntityOwnedRelationshipExactlyOneCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        if (createDto.SecEntityOwnedRelExactlyOne is not null)
        {
            var secEntityOwnedRelExactlyOne = await SecEntityOwnedRelExactlyOneFactory.CreateEntityAsync(createDto.SecEntityOwnedRelExactlyOne, cultureCode);
            entity.CreateSecEntityOwnedRelExactlyOne(secEntityOwnedRelExactlyOne);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateSecEntityOwnedRelExactlyOneAsync(entity, updateDto, cultureCode);
	}

    private async Task UpdateSecEntityOwnedRelExactlyOneAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.SecEntityOwnedRelExactlyOne is null)
        {
            if(entity.SecEntityOwnedRelExactlyOne is not null) 
                _repository.DeleteOwned(entity.SecEntityOwnedRelExactlyOne);
            entity.DeleteAllSecEntityOwnedRelExactlyOne();
        }
		else
		{
            if(entity.SecEntityOwnedRelExactlyOne is not null)
                await SecEntityOwnedRelExactlyOneFactory.UpdateEntityAsync(entity.SecEntityOwnedRelExactlyOne, updateDto.SecEntityOwnedRelExactlyOne, cultureCode);
            else
			    entity.CreateSecEntityOwnedRelExactlyOne(await SecEntityOwnedRelExactlyOneFactory.CreateEntityAsync(updateDto.SecEntityOwnedRelExactlyOne, cultureCode));
        }
	}
}