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

    public TestEntityForAutoNumberUsagesFactoryBase
    (
        )
    {
    }

    public virtual TestEntityForAutoNumberUsagesEntity CreateEntity(TestEntityForAutoNumberUsagesCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityForAutoNumberUsages ToEntity(TestEntityForAutoNumberUsagesCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForAutoNumberUsages();
        entity.AutoNumberField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberField(createDto.AutoNumberField);
        entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(createDto.TextField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, TestEntityForAutoNumberUsagesUpdateDto updateDto)
    {
        entity.AutoNumberField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberField(updateDto.AutoNumberField.NonNullValue<System.Int64>());
        entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("AutoNumberField", out var AutoNumberFieldUpdateValue))
        {
            if (AutoNumberFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AutoNumberField' can't be null");
            }
            {
                entity.AutoNumberField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateAutoNumberField(AutoNumberFieldUpdateValue);
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
}

internal partial class TestEntityForAutoNumberUsagesFactory : TestEntityForAutoNumberUsagesFactoryBase
{
}