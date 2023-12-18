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

internal partial class TestEntityWithNuidFactory : TestEntityWithNuidFactoryBase
{
    public TestEntityWithNuidFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityWithNuidFactoryBase : IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityWithNuidFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityWithNuidEntity> CreateEntityAsync(TestEntityWithNuidCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(TestEntityWithNuidEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityWithNuid> ToEntityAsync(TestEntityWithNuidCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityWithNuid();
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
		entity.EnsureId();
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityWithNuidEntity entity, TestEntityWithNuidUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = TestWebApp.Domain.TestEntityWithNuidMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
        await Task.CompletedTask;
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