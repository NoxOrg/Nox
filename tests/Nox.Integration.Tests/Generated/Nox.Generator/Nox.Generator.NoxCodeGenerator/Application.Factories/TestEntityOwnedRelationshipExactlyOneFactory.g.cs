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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOwnedRelationshipExactlyOneFactory : TestEntityOwnedRelationshipExactlyOneFactoryBase
{
    public TestEntityOwnedRelationshipExactlyOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> secondtestentityownedrelationshipexactlyonefactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshipexactlyonefactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> SecondTestEntityOwnedRelationshipExactlyOneFactory {get;}

    public TestEntityOwnedRelationshipExactlyOneFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> secondtestentityownedrelationshipexactlyonefactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipExactlyOneFactory = secondtestentityownedrelationshipexactlyonefactory;
        _repository = repository;
    }

    public virtual async Task<TestEntityOwnedRelationshipExactlyOneEntity> CreateEntityAsync(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne> ToEntityAsync(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne();
        entity.Id = TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(createDto.TextTestField);
        if (createDto.SecondTestEntityOwnedRelationshipExactlyOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(await SecondTestEntityOwnedRelationshipExactlyOneFactory.CreateEntityAsync(createDto.SecondTestEntityOwnedRelationshipExactlyOne));
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.SecondTestEntityOwnedRelationshipExactlyOne is null)
        {
            if(entity.SecondTestEntityOwnedRelationshipExactlyOne is not null) 
                _repository.DeleteOwned(entity.SecondTestEntityOwnedRelationshipExactlyOne);
			entity.DeleteAllRefToSecondTestEntityOwnedRelationshipExactlyOne();
        }
		else
		{
            if(entity.SecondTestEntityOwnedRelationshipExactlyOne is not null)
                await SecondTestEntityOwnedRelationshipExactlyOneFactory.UpdateEntityAsync(entity.SecondTestEntityOwnedRelationshipExactlyOne, updateDto.SecondTestEntityOwnedRelationshipExactlyOne, cultureCode);
            else
			    entity.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(await SecondTestEntityOwnedRelationshipExactlyOneFactory.CreateEntityAsync(updateDto.SecondTestEntityOwnedRelationshipExactlyOne));
		}
	}
}