// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityExactlyOneFactoryBase : IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto>
{

    public SecondTestEntityExactlyOneFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityExactlyOneEntity CreateEntity(SecondTestEntityExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityExactlyOneEntity entity, SecondTestEntityExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityExactlyOne ToEntity(SecondTestEntityExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityExactlyOne();
        entity.Id = SecondTestEntityExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityExactlyOneEntity entity, SecondTestEntityExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityExactlyOneFactory : SecondTestEntityExactlyOneFactoryBase
{
}