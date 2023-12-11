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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityLocalizationFactory : TestEntityLocalizationFactoryBase
{
    public TestEntityLocalizationFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityLocalizationFactoryBase : IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityLocalizationFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityLocalizationEntity> CreateEntityAsync(TestEntityLocalizationCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityLocalization> ToEntityAsync(TestEntityLocalizationCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityLocalization();
        entity.Id = TestEntityLocalizationMetadata.CreateId(createDto.Id);
        entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(createDto.TextFieldToLocalize);
        entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(createDto.NumberField);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(IsDefaultCultureCode(cultureCode)) entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.NonNullValue<System.String>());
        entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            if (TextFieldToLocalizeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextFieldToLocalize' can't be null");
            }
            {
                entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            if (NumberFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'NumberField' can't be null");
            }
            {
                entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(NumberFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}