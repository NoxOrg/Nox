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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Factories;

internal partial class ThirdTestEntityExactlyOneFactory : ThirdTestEntityExactlyOneFactoryBase
{
    public ThirdTestEntityExactlyOneFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class ThirdTestEntityExactlyOneFactoryBase : IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public ThirdTestEntityExactlyOneFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<ThirdTestEntityExactlyOneEntity> CreateEntityAsync(ThirdTestEntityExactlyOneCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(ThirdTestEntityExactlyOneEntity entity, ThirdTestEntityExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(ThirdTestEntityExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.ThirdTestEntityExactlyOne> ToEntityAsync(ThirdTestEntityExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.ThirdTestEntityExactlyOne();
        entity.Id = ThirdTestEntityExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateTextTestField(createDto.TextTestField);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(ThirdTestEntityExactlyOneEntity entity, ThirdTestEntityExactlyOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ThirdTestEntityExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}