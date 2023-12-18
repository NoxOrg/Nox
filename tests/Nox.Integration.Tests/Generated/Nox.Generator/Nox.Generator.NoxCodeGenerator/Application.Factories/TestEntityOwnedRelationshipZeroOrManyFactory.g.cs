
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
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> secentityownedrelzeroormanyfactory
    ) : base(repository, secentityownedrelzeroormanyfactory)
    {}
}

internal abstract class TestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> SecEntityOwnedRelZeroOrManyFactory {get;}

    public TestEntityOwnedRelationshipZeroOrManyFactoryBase(
        IRepository repository,
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany, SecEntityOwnedRelZeroOrManyUpsertDto, SecEntityOwnedRelZeroOrManyUpsertDto> secentityownedrelzeroormanyfactory
        )
    {
        _repository = repository;
        SecEntityOwnedRelZeroOrManyFactory = secentityownedrelzeroormanyfactory;
    }

    public virtual async Task<TestEntityOwnedRelationshipZeroOrManyEntity> CreateEntityAsync(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany> ToEntityAsync(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany();
<<<<<<< main
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        foreach (var dto in createDto.SecEntityOwnedRelZeroOrManies)
        {
            var newRelatedEntity = await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(dto);
            entity.CreateRefToSecEntityOwnedRelZeroOrManies(newRelatedEntity);
        }        
=======
        entity.Id = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>()));
        createDto.SecEntityOwnedRelZeroOrManies?.ForEach(async dto =>
        {
            var secEntityOwnedRelZeroOrMany = await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToSecEntityOwnedRelZeroOrManies(secEntityOwnedRelZeroOrMany);
        });
>>>>>>> Factory classes refactor has been completed (without tests)
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

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
                {
                    var ownedEntity = await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedSecEntityOwnedRelZeroOrManies.Add(ownedEntity);
                }
				else
				{
					var key = TestWebApp.Domain.SecEntityOwnedRelZeroOrManyMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.SecEntityOwnedRelZeroOrManies.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedSecEntityOwnedRelZeroOrManies.Add(await SecEntityOwnedRelZeroOrManyFactory.CreateEntityAsync(ownedUpsertDto, cultureCode));
					else
					{
						await SecEntityOwnedRelZeroOrManyFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedSecEntityOwnedRelZeroOrManies.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<TestWebApp.Domain.SecEntityOwnedRelZeroOrMany>(
                entity.SecEntityOwnedRelZeroOrManies.Where(x => !updatedSecEntityOwnedRelZeroOrManies.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToSecEntityOwnedRelZeroOrManies(updatedSecEntityOwnedRelZeroOrManies);
		}
	}
}