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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOneOrManyFactoryBase : IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public SecondTestEntityOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOneOrManyEntity CreateEntity(SecondTestEntityOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityOneOrManyEntity entity, SecondTestEntityOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.SecondTestEntityOneOrMany ToEntity(SecondTestEntityOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOneOrMany();
        entity.Id = SecondTestEntityOneOrManyMetadata.CreateId(createDto.Id!);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOneOrManyEntity entity, SecondTestEntityOneOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class SecondTestEntityOneOrManyFactory : SecondTestEntityOneOrManyFactoryBase
{
}