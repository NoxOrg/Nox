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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using AProductEntity = Cryptocash.Domain.AProduct;

namespace Cryptocash.Application.Factories;

internal partial class AProductFactory : AProductFactoryBase
{
    public AProductFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class AProductFactoryBase : IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public AProductFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<AProductEntity> CreateEntityAsync(AProductCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(AProductEntity entity, AProductUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(AProductEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.AProduct> ToEntityAsync(AProductCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.AProduct();
        entity.SetIfNotNull(createDto.MyGuid, (entity) => entity.MyGuid = 
            Cryptocash.Domain.AProductMetadata.CreateMyGuid(createDto.MyGuid.NonNullValue<System.Guid>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(AProductEntity entity, AProductUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.MyGuid = Cryptocash.Domain.AProductMetadata.CreateMyGuid(updateDto.MyGuid.NonNullValue<System.Guid>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(AProductEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("MyGuid", out var MyGuidUpdateValue))
        {
            if (MyGuidUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MyGuid' can't be null");
            }
            {
                entity.MyGuid = Cryptocash.Domain.AProductMetadata.CreateMyGuid(MyGuidUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}