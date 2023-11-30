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

internal abstract class TestEntityOwnedRelationshipZeroOrOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> SecondTestEntityOwnedRelationshipZeroOrOneFactory {get;}

    public TestEntityOwnedRelationshipZeroOrOneFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> secondtestentityownedrelationshipzerooronefactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipZeroOrOneFactory = secondtestentityownedrelationshipzerooronefactory;
        _repository = repository;
    }

    public virtual TestEntityOwnedRelationshipZeroOrOneEntity CreateEntity(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne ToEntity(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne();
        entity.Id = TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(createDto.TextTestField);
        if (createDto.SecondTestEntityOwnedRelationshipZeroOrOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(SecondTestEntityOwnedRelationshipZeroOrOneFactory.CreateEntity(createDto.SecondTestEntityOwnedRelationshipZeroOrOne));
        }
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
	    UpdateOwnedEntities(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private void UpdateOwnedEntities(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
                SecondTestEntityOwnedRelationshipZeroOrOneFactory.UpdateEntity(entity.SecondTestEntityOwnedRelationshipZeroOrOne, updateDto.SecondTestEntityOwnedRelationshipZeroOrOne, cultureCode);
            else
			    entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(SecondTestEntityOwnedRelationshipZeroOrOneFactory.CreateEntity(updateDto.SecondTestEntityOwnedRelationshipZeroOrOne));
		}
	}
}

internal partial class TestEntityOwnedRelationshipZeroOrOneFactory : TestEntityOwnedRelationshipZeroOrOneFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> secondtestentityownedrelationshipzerooronefactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshipzerooronefactory, repository)
    {}
}