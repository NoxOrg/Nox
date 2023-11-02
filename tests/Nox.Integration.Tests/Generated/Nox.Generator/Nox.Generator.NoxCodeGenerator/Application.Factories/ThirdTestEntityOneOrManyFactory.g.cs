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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class ThirdTestEntityOneOrManyFactoryBase : IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto>
{

    public ThirdTestEntityOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual ThirdTestEntityOneOrManyEntity CreateEntity(ThirdTestEntityOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(ThirdTestEntityOneOrManyEntity entity, ThirdTestEntityOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(ThirdTestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.ThirdTestEntityOneOrMany ToEntity(ThirdTestEntityOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.ThirdTestEntityOneOrMany();
        entity.Id = ThirdTestEntityOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(ThirdTestEntityOneOrManyEntity entity, ThirdTestEntityOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(ThirdTestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class ThirdTestEntityOneOrManyFactory : ThirdTestEntityOneOrManyFactoryBase
{
}