// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityWithNuid = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityWithNuidFactoryBase : IEntityFactory<TestEntityWithNuid, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto>
{

    public TestEntityWithNuidFactoryBase
    (
        )
    {
    }

    public virtual TestEntityWithNuid CreateEntity(TestEntityWithNuidCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityWithNuid entity, TestEntityWithNuidUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityWithNuid entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityWithNuid ToEntity(TestEntityWithNuidCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityWithNuid();
        entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(createDto.Name);
		entity.EnsureId();
        return entity;
    }

    private void UpdateEntityInternal(TestEntityWithNuid entity, TestEntityWithNuidUpdateDto updateDto)
    {
        entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
    }

    private void PartialUpdateEntityInternal(TestEntityWithNuid entity, Dictionary<string, dynamic> updatedProperties)
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
}

internal partial class TestEntityWithNuidFactory : TestEntityWithNuidFactoryBase
{
}