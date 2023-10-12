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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class ThirdTestEntityZeroOrOneFactoryBase : IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto>
{

    public ThirdTestEntityZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual ThirdTestEntityZeroOrOneEntity CreateEntity(ThirdTestEntityZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(ThirdTestEntityZeroOrOneEntity entity, ThirdTestEntityZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(ThirdTestEntityZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.ThirdTestEntityZeroOrOne ToEntity(ThirdTestEntityZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.ThirdTestEntityZeroOrOne();
        entity.Id = ThirdTestEntityZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(ThirdTestEntityZeroOrOneEntity entity, ThirdTestEntityZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(ThirdTestEntityZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class ThirdTestEntityZeroOrOneFactory : ThirdTestEntityZeroOrOneFactoryBase
{
}