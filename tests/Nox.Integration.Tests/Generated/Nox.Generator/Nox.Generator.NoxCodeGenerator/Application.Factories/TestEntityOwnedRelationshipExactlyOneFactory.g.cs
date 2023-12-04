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

internal abstract class TestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> SecondTestEntityOwnedRelationshipExactlyOneFactory {get;}

    public TestEntityOwnedRelationshipExactlyOneFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> secondtestentityownedrelationshipexactlyonefactory,
        IRepository repository
        )
    {
        SecondTestEntityOwnedRelationshipExactlyOneFactory = secondtestentityownedrelationshipexactlyonefactory;
        _repository = repository;
    }

    public virtual TestEntityOwnedRelationshipExactlyOneEntity CreateEntity(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
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

    public virtual void UpdateEntity(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne ToEntity(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne();
        entity.Id = TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(createDto.TextTestField);
        if (createDto.SecondTestEntityOwnedRelationshipExactlyOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(SecondTestEntityOwnedRelationshipExactlyOneFactory.CreateEntity(createDto.SecondTestEntityOwnedRelationshipExactlyOne));
        }
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
	    UpdateOwnedEntities(entity, updateDto, cultureCode);
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

	private void UpdateOwnedEntities(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
                SecondTestEntityOwnedRelationshipExactlyOneFactory.UpdateEntity(entity.SecondTestEntityOwnedRelationshipExactlyOne, updateDto.SecondTestEntityOwnedRelationshipExactlyOne, cultureCode);
            else
			    entity.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(SecondTestEntityOwnedRelationshipExactlyOneFactory.CreateEntity(updateDto.SecondTestEntityOwnedRelationshipExactlyOne));
		}
	}
}

internal partial class TestEntityOwnedRelationshipExactlyOneFactory : TestEntityOwnedRelationshipExactlyOneFactoryBase
{
    public TestEntityOwnedRelationshipExactlyOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto, SecondTestEntityOwnedRelationshipExactlyOneUpsertDto> secondtestentityownedrelationshipexactlyonefactory,
        IRepository repository
    ) : base(secondtestentityownedrelationshipexactlyonefactory, repository)
    {}
}