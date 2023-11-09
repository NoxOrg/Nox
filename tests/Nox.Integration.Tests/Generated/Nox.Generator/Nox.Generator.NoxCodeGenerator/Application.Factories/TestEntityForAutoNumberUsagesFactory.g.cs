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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityForAutoNumberUsagesFactoryBase : IEntityFactory<TestEntityForAutoNumberUsagesEntity, TestEntityForAutoNumberUsagesCreateDto, TestEntityForAutoNumberUsagesUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityForAutoNumberUsagesFactoryBase
    (
        )
    {
    }

    public virtual TestEntityForAutoNumberUsagesEntity CreateEntity(TestEntityForAutoNumberUsagesCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityForAutoNumberUsages ToEntity(TestEntityForAutoNumberUsagesCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForAutoNumberUsages();
        entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(createDto.TextField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.AutoNumberFieldWithOptions = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithOptions(updateDto.AutoNumberFieldWithOptions.NonNullValue<System.Int64>());
        entity.AutoNumberFieldWithoutOptions = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithoutOptions(updateDto.AutoNumberFieldWithoutOptions.NonNullValue<System.Int64>());
        entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("AutoNumberFieldWithOptions", out var AutoNumberFieldWithOptionsUpdateValue))
        {
            if (AutoNumberFieldWithOptionsUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AutoNumberFieldWithOptions' can't be null");
            }
            {
                entity.AutoNumberFieldWithOptions = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithOptions(AutoNumberFieldWithOptionsUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AutoNumberFieldWithoutOptions", out var AutoNumberFieldWithoutOptionsUpdateValue))
        {
            if (AutoNumberFieldWithoutOptionsUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AutoNumberFieldWithoutOptions' can't be null");
            }
            {
                entity.AutoNumberFieldWithoutOptions = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberFieldWithoutOptions(AutoNumberFieldWithoutOptionsUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextField' can't be null");
            }
            {
                entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(TextFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityForAutoNumberUsagesFactory : TestEntityForAutoNumberUsagesFactoryBase
{
}