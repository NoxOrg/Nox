

// Generated
//TODO: if CultureCode is not needed, remove it from the factory
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
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelOneOrMany, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> secentityownedreloneormanyfactory
    ) : base(repository, secentityownedreloneormanyfactory)
    {}
}

internal abstract class TestEntityOwnedRelationshipOneOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelOneOrMany, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> SecEntityOwnedRelOneOrManyFactory {get;}

    public TestEntityOwnedRelationshipOneOrManyFactoryBase(
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelOneOrMany, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> secentityownedreloneormanyfactory
        )
    {
        _repository = repository;
        SecEntityOwnedRelOneOrManyFactory = secentityownedreloneormanyfactory;
    }

    public virtual async Task<TestEntityOwnedRelationshipOneOrManyEntity> CreateEntityAsync(TestEntityOwnedRelationshipOneOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> ToEntityAsync(TestEntityOwnedRelationshipOneOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany();
<<<<<<< main
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        foreach (var dto in createDto.SecEntityOwnedRelOneOrManies)
        {
            var newRelatedEntity = await SecEntityOwnedRelOneOrManyFactory.CreateEntityAsync(dto);
            entity.CreateRefToSecEntityOwnedRelOneOrManies(newRelatedEntity);
        }        
=======
        entity.Id = TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>()));
        createDto.SecEntityOwnedRelOneOrManies?.ForEach(async dto =>
        {
            var secEntityOwnedRelOneOrMany = await SecEntityOwnedRelOneOrManyFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToSecEntityOwnedRelOneOrManies(secEntityOwnedRelOneOrMany);
        });
>>>>>>> Factory classes refactor has been completed (without tests)
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.SecEntityOwnedRelOneOrManies.Any())
        { 
            _repository.DeleteOwned(entity.SecEntityOwnedRelOneOrManies);
			entity.DeleteAllRefToSecEntityOwnedRelOneOrManies();
        }
		else
		{
			var updatedSecEntityOwnedRelOneOrManies = new List<TestWebApp.Domain.SecEntityOwnedRelOneOrMany>();
			foreach(var ownedUpsertDto in updateDto.SecEntityOwnedRelOneOrManies)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await SecEntityOwnedRelOneOrManyFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedSecEntityOwnedRelOneOrManies.Add(ownedEntity);
                }
				else
				{
					var key = TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.SecEntityOwnedRelOneOrManies.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedSecEntityOwnedRelOneOrManies.Add(await SecEntityOwnedRelOneOrManyFactory.CreateEntityAsync(ownedUpsertDto, cultureCode));
					else
					{
						await SecEntityOwnedRelOneOrManyFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedSecEntityOwnedRelOneOrManies.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<TestWebApp.Domain.SecEntityOwnedRelOneOrMany>(
                entity.SecEntityOwnedRelOneOrManies.Where(x => !updatedSecEntityOwnedRelOneOrManies.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToSecEntityOwnedRelOneOrManies(updatedSecEntityOwnedRelOneOrManies);
		}
	}
}