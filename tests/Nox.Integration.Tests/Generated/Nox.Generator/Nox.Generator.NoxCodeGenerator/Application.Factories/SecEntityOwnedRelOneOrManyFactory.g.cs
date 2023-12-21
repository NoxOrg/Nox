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
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;

namespace TestWebApp.Application.Factories;

internal partial class SecEntityOwnedRelOneOrManyFactory : SecEntityOwnedRelOneOrManyFactoryBase
{
    public SecEntityOwnedRelOneOrManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class SecEntityOwnedRelOneOrManyFactoryBase : IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public SecEntityOwnedRelOneOrManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<SecEntityOwnedRelOneOrManyEntity> CreateEntityAsync(SecEntityOwnedRelOneOrManyUpsertDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(SecEntityOwnedRelOneOrManyEntity entity, SecEntityOwnedRelOneOrManyUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(SecEntityOwnedRelOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.SecEntityOwnedRelOneOrMany> ToEntityAsync(SecEntityOwnedRelOneOrManyUpsertDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.SecEntityOwnedRelOneOrMany();
        exceptionCollector.Collect("Id",() => entity.Id = SecEntityOwnedRelOneOrManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField2", () => entity.SetIfNotNull(createDto.TextTestField2, (entity) => entity.TextTestField2 = 
            TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateTextTestField2(createDto.TextTestField2.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(SecEntityOwnedRelOneOrManyEntity entity, SecEntityOwnedRelOneOrManyUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField2",() => entity.TextTestField2 = TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(SecEntityOwnedRelOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestField2UpdateValue, "Attribute 'TextTestField2' can't be null.");
            {
                exceptionCollector.Collect("TextTestField2",() =>entity.TextTestField2 = TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}