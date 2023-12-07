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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityOwnedRelationshipOneOrManyFactory : TestEntityOwnedRelationshipOneOrManyFactoryBase
{
    public TestEntityOwnedRelationshipOneOrManyFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> secondtestentityownedrelationshiponeormanyfactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshiponeormanyfactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipOneOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> SecondTestEntityOwnedRelationshipOneOrManyFactory {get;}

    public TestEntityOwnedRelationshipOneOrManyFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> secondtestentityownedrelationshiponeormanyfactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipOneOrManyFactory = secondtestentityownedrelationshiponeormanyfactory;
        _repository = repository;
    }

    public virtual async Task<TestEntityOwnedRelationshipOneOrManyEntity> CreateEntityAsync(TestEntityOwnedRelationshipOneOrManyCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> ToEntityAsync(TestEntityOwnedRelationshipOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany();
        entity.Id = TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        foreach (var dto in createDto.SecondTestEntityOwnedRelationshipOneOrManies)
        {
            var newRelatedEntity = await SecondTestEntityOwnedRelationshipOneOrManyFactory.CreateEntityAsync(dto);
            entity.CreateRefToSecondTestEntityOwnedRelationshipOneOrManies(newRelatedEntity);
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.SecondTestEntityOwnedRelationshipOneOrManies.Any())
        { 
            _repository.DeleteOwned(entity.SecondTestEntityOwnedRelationshipOneOrManies);
			entity.DeleteAllRefToSecondTestEntityOwnedRelationshipOneOrManies();
        }
		else
		{
			var updatedSecondTestEntityOwnedRelationshipOneOrManies = new List<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany>();
			foreach(var ownedUpsertDto in updateDto.SecondTestEntityOwnedRelationshipOneOrManies)
			{
				if(ownedUpsertDto.Id is null)
					updatedSecondTestEntityOwnedRelationshipOneOrManies.Add(await SecondTestEntityOwnedRelationshipOneOrManyFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.SecondTestEntityOwnedRelationshipOneOrManies.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedSecondTestEntityOwnedRelationshipOneOrManies.Add(await SecondTestEntityOwnedRelationshipOneOrManyFactory.CreateEntityAsync(ownedUpsertDto));
					else
					{
						await SecondTestEntityOwnedRelationshipOneOrManyFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedSecondTestEntityOwnedRelationshipOneOrManies.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany>(
                entity.SecondTestEntityOwnedRelationshipOneOrManies.Where(x => !updatedSecondTestEntityOwnedRelationshipOneOrManies.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToSecondTestEntityOwnedRelationshipOneOrManies(updatedSecondTestEntityOwnedRelationshipOneOrManies);
		}
	}
}