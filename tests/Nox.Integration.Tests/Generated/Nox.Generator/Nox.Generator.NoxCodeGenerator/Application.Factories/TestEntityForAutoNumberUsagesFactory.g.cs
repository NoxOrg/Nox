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
    private readonly IRepository _repository;

    public TestEntityForAutoNumberUsagesFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual TestEntityForAutoNumberUsagesEntity CreateEntity(TestEntityForAutoNumberUsagesCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
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
        entity.TextField = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityForAutoNumberUsagesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

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
    public TestEntityForAutoNumberUsagesFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}