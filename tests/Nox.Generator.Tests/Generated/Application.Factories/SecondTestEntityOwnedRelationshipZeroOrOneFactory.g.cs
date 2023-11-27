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
using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOwnedRelationshipZeroOrOneEntity CreateEntity(SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto createDto)
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

    public virtual void UpdateEntity(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne ToEntity(SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne();
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class SecondTestEntityOwnedRelationshipZeroOrOneFactory : SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase
{
}