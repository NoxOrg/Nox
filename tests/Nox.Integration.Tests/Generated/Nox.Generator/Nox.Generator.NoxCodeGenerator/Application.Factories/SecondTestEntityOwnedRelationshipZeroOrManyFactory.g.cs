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
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Factories;

internal partial class SecondTestEntityOwnedRelationshipZeroOrManyFactory : SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase
{
    public SecondTestEntityOwnedRelationshipZeroOrManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public SecondTestEntityOwnedRelationshipZeroOrManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrManyEntity> CreateEntityAsync(SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto createDto)
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

    public virtual async Task UpdateEntityAsync(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany> ToEntityAsync(SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany();
        entity.Id = SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}