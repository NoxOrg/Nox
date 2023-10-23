﻿// Generated

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
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto>
{

    public SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOwnedRelationshipZeroOrManyEntity CreateEntity(SecondTestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany ToEntity(SecondTestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany();
        entity.Id = SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityOwnedRelationshipZeroOrManyFactory : SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase
{
}