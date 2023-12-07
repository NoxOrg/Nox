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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOwnedRelationshipZeroOrManyFactory : TestEntityOwnedRelationshipZeroOrManyFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrManyFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> secondtestentityownedrelationshipzeroormanyfactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshipzeroormanyfactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> SecondTestEntityOwnedRelationshipZeroOrManyFactory {get;}

    public TestEntityOwnedRelationshipZeroOrManyFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> secondtestentityownedrelationshipzeroormanyfactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipZeroOrManyFactory = secondtestentityownedrelationshipzeroormanyfactory;
        _repository = repository;
    }

    public virtual async Task<TestEntityOwnedRelationshipZeroOrManyEntity> CreateEntityAsync(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany> ToEntityAsync(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany();
        entity.Id = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        foreach (var dto in createDto.SecondTestEntityOwnedRelationshipZeroOrManies)
        {
            var newRelatedEntity = await SecondTestEntityOwnedRelationshipZeroOrManyFactory.CreateEntityAsync(dto);
            entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrManies(newRelatedEntity);
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.SecondTestEntityOwnedRelationshipZeroOrManies.Any())
        { 
            _repository.DeleteOwned(entity.SecondTestEntityOwnedRelationshipZeroOrManies);
			entity.DeleteAllRefToSecondTestEntityOwnedRelationshipZeroOrManies();
        }
		else
		{
			var updatedSecondTestEntityOwnedRelationshipZeroOrManies = new List<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany>();
			foreach(var ownedUpsertDto in updateDto.SecondTestEntityOwnedRelationshipZeroOrManies)
			{
				if(ownedUpsertDto.Id is null)
					updatedSecondTestEntityOwnedRelationshipZeroOrManies.Add(await SecondTestEntityOwnedRelationshipZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.SecondTestEntityOwnedRelationshipZeroOrManies.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedSecondTestEntityOwnedRelationshipZeroOrManies.Add(await SecondTestEntityOwnedRelationshipZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto));
					else
					{
						await SecondTestEntityOwnedRelationshipZeroOrManyFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedSecondTestEntityOwnedRelationshipZeroOrManies.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany>(
                entity.SecondTestEntityOwnedRelationshipZeroOrManies.Where(x => !updatedSecondTestEntityOwnedRelationshipZeroOrManies.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToSecondTestEntityOwnedRelationshipZeroOrManies(updatedSecondTestEntityOwnedRelationshipZeroOrManies);
		}
	}
}