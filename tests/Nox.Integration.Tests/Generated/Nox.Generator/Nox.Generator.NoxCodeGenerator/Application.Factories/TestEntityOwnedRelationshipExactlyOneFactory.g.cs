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
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> secentityownedrelexactlyonefactory,
        IRepository repository
    ) : base(secentityownedrelexactlyonefactory, repository)
    {}
}

internal abstract class TestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> SecEntityOwnedRelExactlyOneFactory {get;}

    public TestEntityOwnedRelationshipExactlyOneFactoryBase(
        IEntityFactory<TestWebApp.Domain.SecEntityOwnedRelExactlyOne, SecEntityOwnedRelExactlyOneUpsertDto, SecEntityOwnedRelExactlyOneUpsertDto> secentityownedrelexactlyonefactory,
        IRepository repository
        )
    {
        SecEntityOwnedRelExactlyOneFactory = secentityownedrelexactlyonefactory;
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
        if (createDto.SecEntityOwnedRelExactlyOne is not null)
        {
            entity.CreateRefToSecEntityOwnedRelExactlyOne(await SecEntityOwnedRelExactlyOneFactory.CreateEntityAsync(createDto.SecEntityOwnedRelExactlyOne));
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
		if(updateDto.SecEntityOwnedRelExactlyOne is null)
        {
            if(entity.SecEntityOwnedRelExactlyOne is not null) 
                _repository.DeleteOwned(entity.SecEntityOwnedRelExactlyOne);
			entity.DeleteAllRefToSecEntityOwnedRelExactlyOne();
        }
		else
		{
            if(entity.SecEntityOwnedRelExactlyOne is not null)
                await SecEntityOwnedRelExactlyOneFactory.UpdateEntityAsync(entity.SecEntityOwnedRelExactlyOne, updateDto.SecEntityOwnedRelExactlyOne, cultureCode);
            else
			    entity.CreateRefToSecEntityOwnedRelExactlyOne(await SecEntityOwnedRelExactlyOneFactory.CreateEntityAsync(updateDto.SecEntityOwnedRelExactlyOne));
		}
	}
}