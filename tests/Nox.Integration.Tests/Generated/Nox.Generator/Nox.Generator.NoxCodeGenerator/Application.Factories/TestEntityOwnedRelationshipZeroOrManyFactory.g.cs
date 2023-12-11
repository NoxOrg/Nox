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
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> secentityownedrelzeroormanyfactory,
        IRepository repository
    ) : base(secentityownedrelzeroormanyfactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> SecEntityOwnedRelZeroOrManyFactory {get;}

    public TestEntityOwnedRelationshipZeroOrManyFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> secentityownedrelzeroormanyfactory,
        IRepository repository
        )
    {
        SecEntityOwnedRelZeroOrManyFactory = secentityownedrelzeroormanyfactory;
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
        foreach (var dto in createDto.SecEntityOwnedRelZeroOrManies)
        {
            var newRelatedEntity = await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(dto);
            entity.CreateRefToSecEntityOwnedRelZeroOrManies(newRelatedEntity);
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
        if(!updateDto.SecEntityOwnedRelZeroOrManies.Any())
        { 
            _repository.DeleteOwned(entity.SecEntityOwnedRelZeroOrManies);
			entity.DeleteAllRefToSecEntityOwnedRelZeroOrManies();
        }
		else
		{
			var updatedSecEntityOwnedRelZeroOrManies = new List<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany>();
			foreach(var ownedUpsertDto in updateDto.SecEntityOwnedRelZeroOrManies)
			{
				if(ownedUpsertDto.Id is null)
					updatedSecEntityOwnedRelZeroOrManies.Add(await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = TestWebApp.Domain.SecEntityOwnedRelZeroOrManyMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.SecEntityOwnedRelZeroOrManies.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedSecEntityOwnedRelZeroOrManies.Add(await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto));
					else
					{
						await SecEntityOwnedRelZeroOrManyFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedSecEntityOwnedRelZeroOrManies.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany>(
                entity.SecEntityOwnedRelZeroOrManies.Where(x => !updatedSecEntityOwnedRelZeroOrManies.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToSecEntityOwnedRelZeroOrManies(updatedSecEntityOwnedRelZeroOrManies);
		}
	}
}