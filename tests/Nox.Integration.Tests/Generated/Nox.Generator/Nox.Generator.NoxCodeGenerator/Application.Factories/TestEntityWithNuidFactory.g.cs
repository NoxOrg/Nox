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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityWithNuidFactoryBase : IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityWithNuidFactoryBase
    (
        )
    {
    }

    public virtual TestEntityWithNuidEntity CreateEntity(TestEntityWithNuidCreateDto createDto)
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

    public virtual void UpdateEntity(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityWithNuidEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityWithNuid ToEntity(TestEntityWithNuidCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityWithNuid();
        entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(createDto.Name);
		entity.EnsureId();
        return entity;
    }

    private void UpdateEntityInternal(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
    }

    private void PartialUpdateEntityInternal(TestEntityWithNuidEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(NameUpdateValue);
            }
        }
		entity.EnsureId();
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityWithNuidFactory : TestEntityWithNuidFactoryBase
{
}